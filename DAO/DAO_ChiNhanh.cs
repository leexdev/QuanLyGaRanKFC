using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_ChiNhanh : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;

        public DAO_ChiNhanh()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<ChiNhanh> GetAll()
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"select * from ChiNhanh where isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
                list.Add(chiNhanh);
            }
            _conn.Close();
            return list;
        }
        public List<ChiNhanh> GetByName(string _tenCN)
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM ChiNhanh WHERE TenCN LIKE N'%{_tenCN}%' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
                list.Add(chiNhanh);
            }
            _conn.Close();
            return list;
        }
        public ChiNhanh GetLast()
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM dbo.ChiNhanh ORDER BY LEN(MaCN) DESC, MaCN DESC", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu_ChiNhanh _NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
            }
            _conn.Close();
            return chiNhanh;
        }
        public ChiNhanh GetByID(string _maCN)
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM ChiNhanh WHERE MACN = '{_maCN}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu_ChiNhanh _NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
            }
            _conn.Close();
            return chiNhanh;
        }
        public ChiNhanh GetByUserID(string _maNV)
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT ChiNhanh.* FROM ChiNhanh, NhanVien WHERE ChiNhanh.MaCN = NhanVien.MaCN AND MaNV = '{_maNV}'", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu_ChiNhanh _NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
            }
            _conn.Close();
            return chiNhanh;
        }
        public ChiNhanh GetByNguyenLieuID(string _maNL)
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT ChiNhanh.* FROM ChiNhanh, NguyenLieu_ChiNhanh WHERE ChiNhanh.MaCN = NguyenLieu_ChiNhanh.MaCN AND MaNL = '{_maNL}'", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu_ChiNhanh _NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien);
            }
            _conn.Close();
            return chiNhanh;
        }
        public void Add(ChiNhanh chiNhanh)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO ChiNhanh VALUES(N'{chiNhanh.maCN}', N'{chiNhanh.tenCN}', N'{chiNhanh.diaChi}', 0)", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(ChiNhanh chiNhanh)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE ChiNhanh SET TenCN = N'{chiNhanh.tenCN}', DiaChi = N'{chiNhanh.diaChi}' WHERE MaCN = '{chiNhanh.maCN}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE ChiNhanh SET isDeleted = 1 WHERE MaCN = '{_maCN}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaCN) FROM ChiNhanh", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
