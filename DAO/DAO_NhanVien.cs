using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Jose;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_NhanVien : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_NhanVien()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<NhanVien> GetAll()
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                NhanVien nv = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public List<NhanVien> GetList(string _maCN)
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where MaCN = '{_maCN}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                NhanVien nv = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public List<NhanVien> GetListByName(string _tenNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where TenNV like '%{_tenNV}%'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                NhanVien nv = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public NhanVien GetLast()
        {
            NhanVien nhanVien = new NhanVien();
            _conn.Open();
            command = new SqlCommand($"select top(1)* from NhanVien order by MaNV desc", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                nhanVien = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
            }
            _conn.Close();
            return nhanVien;
        }
        public NhanVien GetByID(string _maNV)
        {
            NhanVien nhanVien = new NhanVien();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where MaNV = '{_maNV}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                nhanVien = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
            }
            _conn.Close();
            return nhanVien;
        }
        public NhanVien GetByUserName(string _tenDangNhap)
        {
            NhanVien nhanVien = new NhanVien();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where TenDangNhap = '{_tenDangNhap}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string tenDangNhap = reader.GetString(2);
                string matKhau = reader.GetString(3);
                DateTime ngaySinh = reader.GetDateTime(4);
                string diaChi = reader.GetString(5);
                string sdt = reader.GetString(6);
                string cmnd = reader.GetString(7);
                int quyen = reader.GetInt32(8);
                nhanVien = new NhanVien(maNV, tenNV, tenDangNhap, matKhau, ngaySinh, diaChi, sdt, cmnd, quyen);
            }
            _conn.Close();
            return nhanVien;
        }
        public void Add(NhanVien _nhanVien, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($@"INSERT INTO NhanVien 
                                        VALUES(MaNV = '{_nhanVien.maNV}', 
                                               TenNV = N'{_nhanVien.tenNV}',
                                               TenDangNhap = N'{_nhanVien.tenDangNhap}',
                                               MatKhau = '{GetMD5(_nhanVien.matKhau)}',
                                               NgaySinh = '{_nhanVien.ngaySinh}',
                                               DiaChi = N'{_nhanVien.diaChi}',
                                               SDT = '{_nhanVien.sdt}',
                                               CMND = '{_nhanVien.cmnd}',
                                               Quyen = {_nhanVien.quyen},
                                               MaCN = '{_maCN}'
                                               )", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(NhanVien _nhanVien, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($@"UPDATE NhanVien 
                                        SET TenNV = N'{_nhanVien.tenNV}',
                                            TenDangNhap = N'{_nhanVien.tenDangNhap}',
                                            MatKhau = '{GetMD5(_nhanVien.matKhau)}',
                                            NgaySinh = '{_nhanVien.ngaySinh}',
                                            DiaChi = N'{_nhanVien.diaChi}',
                                            SDT = '{_nhanVien.sdt}',
                                            CMND = '{_nhanVien.cmnd}',
                                            Quyen = {_nhanVien.quyen},
                                            MaCN = '{_maCN}'
                                        WHERE MaNV = '{_nhanVien.maNV}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maNV)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM NhanVien WHERE MaNV = '{_maNV}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public static string GetMD5(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("X2"));
            }

            return strBuilder.ToString();
        }
    }
}
