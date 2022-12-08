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

    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class Dashboard : DatabaseConnection
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderStockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        public Dashboard()
        {

        }

        private void GetNumerItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    // get total customers
                    command.CommandText = "SELECT count(MaKH) from KhachHang";
                    this.NumCustomers = (int)command.ExecuteScalar();

                    // dummy total Suppliers
                    this.NumSuppliers = 24719274;

                    // get total products
                    command.CommandText = "SELECT count(MaMon) from MonAn";
                    this.NumProducts = (int)command.ExecuteScalar();

                    // get total orders
                    command.CommandText = @"SELECT count(MaHD) from HoaDon Where NgayTaoHD between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.Date).Value = this.startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.Date).Value = this.endDate;
                    this.NumOrders = (int)command.ExecuteScalar();
                }
            }
        }

        private void GetOrderAnalysis()
        {
            this.GrossRevenueList = new List<RevenueByDate>();
            this.TotalProfit = 0;
            this.TotalRevenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT NgayTaoHD, sum(ThanhTien) from HoaDon, CTHoaDon
                                            Where NgayTaoHD between @fromDate and @toDate AND HoaDon.MaHD = CTHoaDon.MaHD
                                            GROUP BY NgayTaoHD";

                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.Date).Value = this.startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.Date).Value = this.endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1]));
                        this.TotalRevenue += (decimal)reader[1];
                    }
                    this.TotalProfit = this.TotalRevenue * 0.2m;
                    reader.Close();

                    // groups by Days
                    if (this.numberDays <= 30)
                    {
                        foreach (var item in resultTable)
                        {
                            this.GrossRevenueList.Add(new RevenueByDate()
                            {
                                Date = item.Key.ToString("dd MMM"),
                                TotalAmount = item.Value
                            });
                        }
                    }

                    // groups by weeks
                    else if (this.numberDays <= 92)
                    {
                        this.GrossRevenueList = (from orderList in resultTable
                                                 group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                                 into order
                                                 select new RevenueByDate
                                                 {
                                                     Date = "Week " + order.Key.ToString(),
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }
                                                 ).ToList();
                    }

                    // group by months

                    else if (this.numberDays <= 365 * 2)
                    {
                        bool isYear = this.numberDays <= 365 ? true : false;
                        this.GrossRevenueList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("MMM yyyy")
                                                 into order
                                                 select new RevenueByDate
                                                 {
                                                     Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }
                                                 ).ToList();
                    }

                    // group by years
                    else
                    {
                        this.GrossRevenueList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("yyyy")
                                                                         into order
                                                 select new RevenueByDate
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }
                                                                         ).ToList();
                    }
                }
            }
        }

        private void GetProductAnalysys()
        {
            this.TopProductsList = new List<KeyValuePair<string, int>>();
            this.UnderStockList = new List<KeyValuePair<string, int>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    // get top 5 products
                    command.CommandText = @"SELECT top 5 MonAn.TenMon, sum(CTHoaDon.SoLuong) as Quantity
                                          from HoaDon, CTHoaDon, MonAn Where NgayTaoHD between @fromDate and @toDate AND HoaDon.MaHD = CTHoaDon.MaHD AND MonAn.MaMon = CTHoaDon.MaMon
                                          GROUP BY MonAn.TenMon ORDER BY Quantity DESC";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.Date).Value = this.startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.Date).Value = this.endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.TopProductsList.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();

                    // get understock
                    command.CommandText = @"select top 10 TenMon, count(TenMon) as count from MonAn group by TenMon Order by count ASC";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.UnderStockList.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }

        public bool LoadData(DateTime _startDate, DateTime _endDate)
        {
            _endDate = new DateTime(_endDate.Year, _endDate.Month, _endDate.Day, _endDate.Hour, endDate.Minute, 59);
            if (_startDate != this.startDate || _endDate != this.endDate)
            {
                this.startDate = _startDate;
                this.endDate = _endDate;
                this.numberDays = (endDate - startDate).Days;

                this.GetNumerItems();
                this.GetProductAnalysys();
                this.GetOrderAnalysis();
                Console.WriteLine("Get Data: {0} - {1}", _startDate.ToString(), _endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Get Data Fail: {0} - {1}", _startDate.ToString(), _endDate.ToString());
                return false;
            }
        }
    }
}
