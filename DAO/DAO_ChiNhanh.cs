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
        public List<ChiNhanh> getAll()
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"select * from ChiNhanh", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu _NguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                List<NguyenLieu> nguyenLieu = _NguyenLieu.GetList(maCN);
                ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien, nguyenLieu);
                list.Add(chiNhanh);
            }
            return list;
        }
        public List<ChiNhanh> GetByName(string _tenCN)
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM ChiNhanh WHERE TenCN LIKE '%{_tenCN}%'");
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu _NguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NguyenLieu> nguyenLieu = _NguyenLieu.GetList(maCN);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien, nguyenLieu);
                list.Add(chiNhanh);
            }
            _conn.Close();
            return list;
        }
        public ChiNhanh GetLast()
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM ChiNhanh ORDER BY MaCN DESC", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu _NguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NguyenLieu> nguyenLieu = _NguyenLieu.GetList(maCN);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien, nguyenLieu);
            }
            _conn.Close();
            return chiNhanh;
        }
        public ChiNhanh GetByID(string _maCN)
        {
            ChiNhanh chiNhanh = new ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM ChiNhanh WHERE MACN = '{_maCN}'", _conn);
            reader = command.ExecuteReader();
            DAO_NhanVien _NhanVien = new DAO_NhanVien();
            DAO_NguyenLieu _NguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NguyenLieu> nguyenLieu = _NguyenLieu.GetList(maCN);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien, nguyenLieu);
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
            DAO_NguyenLieu _NguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                string maCN = reader.GetString(0);
                string tenCN = reader.GetString(1);
                string diaChi = reader.GetString(2);
                List<NguyenLieu> nguyenLieu = _NguyenLieu.GetList(maCN);
                List<NhanVien> nhanVien = _NhanVien.GetList(maCN);
                chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanVien, nguyenLieu);
            }
            _conn.Close();
            return chiNhanh;
        }
        public void Add(ChiNhanh chiNhanh)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO ChiNhanh VALUES('{chiNhanh.maCN}', N'{chiNhanh.tenCN}', N'{chiNhanh.diaChi}'");
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(ChiNhanh chiNhanh)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE ChiNhanh SET TenCN = N'{chiNhanh.tenCN}', DiaChi = N'{chiNhanh.diaChi}' WHERE MaCN = '{chiNhanh.maCN}'");
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM ChiNhanh WHERE MaCN = '{_maCN}'");
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
