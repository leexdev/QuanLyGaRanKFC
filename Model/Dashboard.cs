using QuanLyGaRanKFC.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public struct DoanhThuByDate
    {
        public string Date { get; set; };
        public decimal TongTien { get; set; }

    }
    public class Dashboard : DatabaseConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int KhachHang { get; private set; }
        public int NguyenLieu { get; private set; }
        public int MonAn { get; private set; }
        public List<KeyValuePair<string, int>> TopMonAnList { get; private set; }
        public List<KeyValuePair<string, int>> UnderNguyenLieuList { get; private set; }
        public List<DoanhThuByDate> TongDoanhThuList { get; private set; }
        public int SoLuong { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongLoiNhuan { get; set; }

        public Dashboard()
        {

        }

        private void GetSLSP()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select count(MaKH) from KhachHang";
                    KhachHang = (int)command.ExecuteScalar();

                    command.CommandText = "Select count(MaNL) from NguyenLieu";
                    NguyenLieu = (int)command.ExecuteScalar();

                    command.CommandText = "Select count(MaMon) from MonAn";
                    MonAn = (int)command.ExecuteScalar();

                    command.CommandText = @"SELECT COUNT(MaHD) FROM dbo.HoaDon WHERE NgayTaoHD BETWEEN @fromDate + @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    SoLuong = (int)command.ExecuteScalar();
                }
            }
        }
        private void DonHang()
        {
            TongDoanhThuList = new List<DoanhThuByDate>;
            TongLoiNhuan = 0;
            TongDoanhThu = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"select NgayTaoHD, sum(TongTien) from HoaDon where NgayTaoHD between @fromDate and @toDate group by NgayTaoHD";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1]));
                        TongDoanhThu += (decimal)reader[0];
                    }
                    TongLoiNhuan = TongDoanhThu * 0.2m;
                    reader.Close();

                    if(numberDays <= 30)
                    {
                        foreach(var item in resultTable)
                        {
                            TongDoanhThuList.Add(new DoanhThuByDate()
                            {
                                Date = item.Key.ToString("dd MM"),
                                TongTien = item.Value
                            });
                        }
                    }

                    else if(numberDays <= 92)
                    {
                        TongDoanhThuList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday) into HoaDon
                                            select new DoanhThuByDate
                                            {
                                                Date = "Week " + HoaDon.Key.ToString(),
                                                TongTien = HoaDon.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    
                    else if (numberDays <= (365 *2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        TongDoanhThuList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                            into HoaDon
                                            select new DoanhThuByDate
                                            {
                                                Date = isYear ? HoaDon.Key.Substring(0, HoaDon.Key.IndexOf(" ")) : HoaDon.Key,
                                                TongTien = HoaDon.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    else
                    {
                        TongDoanhThuList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                            into HoaDon
                                            select new DoanhThuByDate
                                            {
                                                Date = HoaDon.Key,
                                                TongTien = HoaDon.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }
        private void SanPham()
        {

        }
    }
}
