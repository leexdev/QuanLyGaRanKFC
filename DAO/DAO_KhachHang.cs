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
            command = new SqlCommand($"SELECT * FROM KhachHang", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string diaChi = reader.GetString(2);
                string sdt = reader.GetString(3);
                KhachHang khachHang = new KhachHang(maKH, tenKH, diaChi, sdt);
                list.Add(khachHang);
            }
            _conn.Close();
            return list;
        }
        public KhachHang GetByID(string _maKH)
        {
            KhachHang khachHang = new KhachHang();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang WHERE MaKH = '{_maKH}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string diaChi = reader.GetString(2);
                string sdt = reader.GetString(3);
                khachHang = new KhachHang(maKH, tenKH, diaChi, sdt);
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
                string diaChi = reader.GetString(2);
                string sdt = reader.GetString(3);
                khachHang = new KhachHang(maKH, tenKH, diaChi, sdt);
            }
            _conn.Close();
            return khachHang;
        }
        public List<KhachHang> GetByName(string _tenKH)
        {
            List<KhachHang> list = new List<KhachHang>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM KhachHang WHERE TenKH LIKE '%{_tenKH}%'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                string tenKH = reader.GetString(1);
                string diaChi = reader.GetString(2);
                string sdt = reader.GetString(3);
                KhachHang khachHang = new KhachHang(maKH, tenKH, diaChi, sdt);
                list.Add(khachHang);
            }
            _conn.Close();
            return list;
        }
        public void Add(KhachHang khachHang)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO KhachHang VALUES ('{khachHang.maKH}', N'{khachHang.tenKH}', N'{khachHang.diaChi}', '{khachHang.sdt}')", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(KhachHang khachHang)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE KhachHang SET TenKH = N'{khachHang.tenKH}', DiaChi = N'{khachHang.diaChi}', SDT = '{khachHang.sdt}' WHERE MaKH = '{khachHang.maKH}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maKH)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM KhachHang WHERE MaKH = '{_maKH}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
