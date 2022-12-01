using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_KhachHang : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_KhachHang()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<KhachHang> GetAll()
        {
            List<KhachHang> list = new List<KhachHang>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang where isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string sdt = reader.GetString(2);
                KhachHang khachHang = new KhachHang(maKH, tenKH, sdt);
                list.Add(khachHang);
            }
            _conn.Close();
            return list;
        }
        public KhachHang GetByID(string _maKH)
        {
            KhachHang khachHang = new KhachHang();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang WHERE MaKH = '{_maKH}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string sdt = reader.GetString(2);
                khachHang = new KhachHang(maKH, tenKH, sdt);
            }
            _conn.Close();
            return khachHang;
        }
        public KhachHang GetByPhone(string _sdtKH)
        {
            KhachHang khachHang = new KhachHang();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang WHERE SDT = N'{_sdtKH}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string sdt = reader.GetString(2);
                khachHang = new KhachHang(maKH, tenKH, sdt);
            }
            _conn.Close();
            return khachHang;
        }
        public KhachHang GetLast()
        {
            KhachHang khachHang = new KhachHang();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM KhachHang ORDER BY MaKH DESC", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string sdt = reader.GetString(2);
                khachHang = new KhachHang(maKH, tenKH, sdt);
            }
            _conn.Close();
            return khachHang;
        }
        public List<KhachHang> GetByName(string _tenKH, string _sdtKH)
        {
            List<KhachHang> list = new List<KhachHang>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang WHERE (TenKH LIKE N'%{_tenKH}%' OR SDT LIKE N'%{_sdtKH}%') and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string sdt = reader.GetString(2);
                KhachHang khachHang = new KhachHang(maKH, tenKH, sdt);
                list.Add(khachHang);
            }
            _conn.Close();
            return list;
        }
        public void Add(KhachHang khachHang)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO KhachHang VALUES (N'{khachHang.maKH}', N'{khachHang.tenKH}', N'{khachHang.sdt}', 0)", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(KhachHang khachHang)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE KhachHang SET TenKH = N'{khachHang.tenKH}', SDT = '{khachHang.sdt}' WHERE MaKH = '{khachHang.maKH}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maKH)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE KhachHang SET isDeleted = 1 WHERE MaKH = '{_maKH}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaKH) FROM KhachHang", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
