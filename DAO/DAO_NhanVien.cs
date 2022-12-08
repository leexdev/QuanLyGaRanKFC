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
            command = new SqlCommand($"select * from NhanVien where isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                NhanVien nv = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public List<NhanVien> GetList(string _maCN)
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where MaCN = '{_maCN}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                NhanVien nv = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public List<NhanVien> GetListByName(string _tenNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where TenNV like N'%{_tenNV}%' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                NhanVien nv = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
                list.Add(nv);
            }
            _conn.Close();
            return list;
        }
        public List<NhanVien> GetListNVByCN(string _tenNV, string _maCN)
        {
            List<NhanVien> list = new List<NhanVien>();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where TenNV like N'%{_tenNV}%' and (MaCN = '{_maCN}' and isDeleted = 0)", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                NhanVien nv = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
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
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                nhanVien = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
            }
            _conn.Close();
            return nhanVien;
        }
        public NhanVien GetByID(string _maNV)
        {
            NhanVien nhanVien = new NhanVien();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where MaNV = '{_maNV}' and (isDeleted = 0 or MaNV = 'NV1')", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                nhanVien = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
            }
            _conn.Close();
            return nhanVien;
        }
        public NhanVien GetByUserName(string _tenDangNhap)
        {
            NhanVien nhanVien = new NhanVien();
            _conn.Open();
            command = new SqlCommand($"select * from NhanVien where TenDangNhap = '{_tenDangNhap}' and (isDeleted = 0 or MaNV = 'NV1')", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                DateTime ngaySinh = reader.GetDateTime(2);
                string gioiTinh = reader.GetString(3);
                string diaChi = reader.GetString(4);
                string sdt = reader.GetString(5);
                string cmnd = reader.GetString(6);
                int quyen = reader.GetInt32(7);
                string tenDangNhap = reader.GetString(8);
                string matKhau = reader.GetString(9);
                nhanVien = new NhanVien(maNV, tenNV, ngaySinh, gioiTinh, diaChi, sdt, cmnd, quyen, tenDangNhap, matKhau);
            }
            _conn.Close();
            return nhanVien;
        }
        public void Add(NhanVien _nhanVien, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($@"INSERT INTO NhanVien 
                                        VALUES('{_nhanVien.maNV}', 
                                               N'{_nhanVien.tenNV}',
                                               '{_nhanVien.ngaySinh}',
                                               N'{_nhanVien.gioiTinh}',
                                               N'{_nhanVien.diaChi}',
                                               '{_nhanVien.sdt}',
                                               '{_nhanVien.cmnd}',
                                               {_nhanVien.quyen},
                                               N'{_nhanVien.tenDangNhap}',
                                               '{GetMD5(_nhanVien.matKhau)}',
                                               '{_maCN}',
                                                0)", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(NhanVien _nhanVien, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($@"UPDATE NhanVien 
                                    SET TenNV = N'{_nhanVien.tenNV}',
                                        NgaySinh = '{_nhanVien.ngaySinh}',
                                        GioiTinh = N'{_nhanVien.gioiTinh}',
                                        DiaChi = N'{_nhanVien.diaChi}',
                                        SDT = '{_nhanVien.sdt}',
                                        CMND = '{_nhanVien.cmnd}',
                                        Quyen = {_nhanVien.quyen},
                                        TenDangNhap = N'{_nhanVien.tenDangNhap}',
                                        MatKhau = '{_nhanVien.matKhau}',
                                        MaCN = '{_maCN}'
                                    WHERE MaNV = '{_nhanVien.maNV}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maNV)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE NhanVien SET isDeleted = 1 WHERE MaNV = '{_maNV}'", _conn);
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

        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaNV) FROM NhanVien", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
        public bool isNhanVienExist(string userName)
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = '{userName}' and (isDeleted = 0 or MaNV = 'NV1')", _conn);
            int exist = (Int32)command.ExecuteScalar();
            _conn.Close();
            return exist > 0;
        }
    }
}
