using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_HoaDon : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_HoaDon()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<HoaDon> GetAll()
        {
            List<HoaDon> list = new List<HoaDon>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM HoaDon", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            while (reader.Read())
            {
                string maHD = reader.GetString(0);
                NhanVien nhanVien = dAO_NhanVien.GetByID(reader.GetString(3));
                KhachHang khachHang = dAO_KhachHang.GetByID(reader.GetString(2));
                DateTime ngayTaoHD = reader.GetDateTime(1);
                List<CTHD> chiTiet = dAO_CTHD.GetList(reader.GetString(0));
                HoaDon hoaDon = new HoaDon(maHD, ngayTaoHD, nhanVien, khachHang, chiTiet);
                list.Add(hoaDon);
            }
            _conn.Close();
            return list;
        }
        public List<HoaDon> GetByDate(DateTime _from, DateTime _to)
        {
            List<HoaDon> list = new List<HoaDon>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM HoaDon WHERE NgayTaoHD <= '{_to}' AND NgayTaoHD >='{_from}'", _conn);
            reader = command.ExecuteReader();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            while (reader.Read())
            {
                string maHD = reader.GetString(0);
                NhanVien nhanVien = dAO_NhanVien.GetByID(reader.GetString(1));
                KhachHang khachHang = dAO_KhachHang.GetByID(reader.GetString(2));
                DateTime ngayTaoHD = reader.GetDateTime(3);
                List<CTHD> chiTiet = dAO_CTHD.GetList(reader.GetString(0));
                HoaDon hoaDon = new HoaDon(maHD, ngayTaoHD, nhanVien, khachHang, chiTiet);
                list.Add(hoaDon);
            }
            _conn.Close();
            return list;
        }
        public HoaDon GetLast()
        {
            _conn.Open();
            HoaDon hoaDon = new HoaDon();
            command = new SqlCommand($"SELECT TOP(1)* FROM HoaDon ORDER BY MaHD DESC", _conn);
            reader = command.ExecuteReader();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            while (reader.Read())
            {
                string maHD = reader.GetString(0);
                NhanVien nhanVien = dAO_NhanVien.GetByID(reader.GetString(1));
                KhachHang khachHang = dAO_KhachHang.GetByID(reader.GetString(2));
                DateTime ngayTaoHD = reader.GetDateTime(3);
                List<CTHD> chiTiet = dAO_CTHD.GetList(reader.GetString(0));
                hoaDon = new HoaDon(maHD, ngayTaoHD, nhanVien, khachHang, chiTiet);
            }
            _conn.Close();
            return hoaDon;
        }
        public HoaDon GetByID(string _maHD)
        {
            _conn.Open();
            HoaDon hoaDon = new HoaDon();
            command = new SqlCommand($"SELECT * FROM HoaDon WHERE MaHD = '{_maHD}'", _conn);
            reader = command.ExecuteReader();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            while (reader.Read())
            {
                string maHD = reader.GetString(0);
                NhanVien nhanVien = dAO_NhanVien.GetByID(reader.GetString(1));
                KhachHang khachHang = dAO_KhachHang.GetByID(reader.GetString(2));
                DateTime ngayTaoHD = reader.GetDateTime(3);
                List<CTHD> chiTiet = dAO_CTHD.GetList(reader.GetString(0));
                hoaDon = new HoaDon(maHD, ngayTaoHD, nhanVien, khachHang, chiTiet);
            }
            _conn.Close();
            return hoaDon;
        }
        public void Add(HoaDon hoaDon)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO HoaDon VALUES ('{hoaDon.MaHD}', '{hoaDon.ngayTaoHD}', '{hoaDon.khachHang.maKH}', '{hoaDon.nhanVien.maNV}')", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(HoaDon hoaDon)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE HoaDon SET MaNV = '{hoaDon.nhanVien.maNV}', maKH = '{hoaDon.khachHang.maKH}', NgayTaoHD = '{hoaDon.ngayTaoHD}' WHERE MaHD = '{hoaDon.MaHD}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maHD)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM CTHoaDon WHERE MaHD = '{_maHD}'", _conn);
            command.ExecuteNonQuery();
            command = new SqlCommand($"DELETE FROM HoaDon WHERE MaHD = '{_maHD}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaHD) FROM HoaDon", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
