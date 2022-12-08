using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_NguyenLieu_ChiNhanh : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_NguyenLieu_ChiNhanh()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<NguyenLieu_ChiNhanh> GetAll()
        {
            List<NguyenLieu_ChiNhanh> list = new List<NguyenLieu_ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"select MaNL, MaCN, Sum(SoLuongTon)  from NguyenLieu_ChiNhanh GROUP BY MaNL, MaCN", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();
            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));
                NguyenLieu_ChiNhanh nl_cn = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
                list.Add(nl_cn);
            }
            _conn.Close();
            return list;
        }
        public List<NguyenLieu_ChiNhanh> GetList(string _maCN)
        {
            List<NguyenLieu_ChiNhanh> list = new List<NguyenLieu_ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"select MaNL, MaCN, Sum(SoLuongTon) from NguyenLieu_ChiNhanh where MaCN = '{_maCN}' group by MaNL, MaCN", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();
            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));
                NguyenLieu_ChiNhanh nl_cn = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
                list.Add(nl_cn);
            }
            _conn.Close();
            return list;
        }
        public List<NguyenLieu_ChiNhanh> GetLast(string _maCN)
        {
            List<NguyenLieu_ChiNhanh> list = new List<NguyenLieu_ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"SELECT dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN, Sum(SoLuongTon) FROM NguyenLieu_ChiNhanh, dbo.NguyenLieu WHERE NguyenLieu_ChiNhanh.MaNL = dbo.NguyenLieu.MaNL AND dbo.NguyenLieu_ChiNhanh.MaCN = '{_maCN}' group by dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();

            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));
                NguyenLieu_ChiNhanh nl_cn = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
                list.Add(nl_cn);
            }
            _conn.Close();
            return list;
        }
        public List<NguyenLieu_ChiNhanh> GetListByName(string _tenNL)
        {
            List<NguyenLieu_ChiNhanh> list = new List<NguyenLieu_ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"SELECT dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN, SUM(SoLuongTon) as SoLuongTon FROM NguyenLieu_ChiNhanh, dbo.NguyenLieu WHERE NguyenLieu_ChiNhanh.MaNL = dbo.NguyenLieu.MaNL AND dbo.NguyenLieu.TenNL LIKE N'%{_tenNL}%' GROUP BY dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();

            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));
                NguyenLieu_ChiNhanh nl_cn = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
                list.Add(nl_cn);
            }
            _conn.Close();
            return list;
        }
        public List<NguyenLieu_ChiNhanh> GetListByNameForUser(string _tenNL,string _maCN)
        {
            List<NguyenLieu_ChiNhanh> list = new List<NguyenLieu_ChiNhanh>();
            _conn.Open();
            command = new SqlCommand($"SELECT dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN SUM(SoLuongTon) as SoLuongTon FROM NguyenLieu_ChiNhanh, dbo.NguyenLieu WHERE NguyenLieu_ChiNhanh.MaNL = dbo.NguyenLieu.MaNL AND (dbo.NguyenLieu.TenNL LIKE N'%{_tenNL}%' AND MaCN = N'{_maCN}') GROUP BY dbo.NguyenLieu.MaNL, dbo.NguyenLieu.TenNL, MaCN", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();

            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));
                NguyenLieu_ChiNhanh nl_cn = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
                list.Add(nl_cn);
            }
            _conn.Close();
            return list;
        }
        public NguyenLieu_ChiNhanh GetByID(string _maNL, string _maCN)
        {
            NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM NguyenLieu_ChiNhanh WHERE MaNL = '{_maNL}' and MaCN = '{_maCN}'", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh _chiNhanh = new DAO_ChiNhanh();

            while (reader.Read())
            {
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                ChiNhanh cn = _chiNhanh.GetByID(reader.GetString(1));

                nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh(soLuongTon, nl, cn);
            }
            _conn.Close();
            return nguyenLieu_ChiNhanh;
        }
        public void Add(NguyenLieu_ChiNhanh NLCN)
        {
            _conn.Open();
            command = new SqlCommand($"IF EXISTS (SELECT * FROM dbo.NguyenLieu_ChiNhanh WHERE MaNL = '{NLCN.NguyenLieu.maNL}' AND MaCN = '{NLCN.ChiNhanh.maCN}') " +
                $"BEGIN " +
                $"UPDATE dbo.NguyenLieu_ChiNhanh SET SoLuongTon = SoLuongTon + {NLCN.soLuongTon} WHERE MaNL = '{NLCN.NguyenLieu.maNL}' AND MaCN = '{NLCN.ChiNhanh.maCN}' END " +
                $"ELSE " +
                $"BEGIN INSERT INTO dbo.NguyenLieu_ChiNhanh (MaNL, MaCN, SoLuongTon) VALUES ('{NLCN.NguyenLieu.maNL}', '{NLCN.ChiNhanh.maCN}', {NLCN.soLuongTon}) " +
                $"END", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(NguyenLieu_ChiNhanh NLCN, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE NguyenLieu_ChiNhanh SET SoLuongTon = {NLCN.soLuongTon}, MaCN = '{_maCN}' where MaNL = '{NLCN.NguyenLieu.maNL}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maCN, string _maNL)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM NguyenLieu_ChiNhanh WHERE MaCN = '{_maCN}' AND MaNL = '{_maNL}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public bool isNhanVienExist(string _maNL, string _maCN)
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(*) FROM NguyenLieu_ChiNhanh WHERE MaNL = '{_maNL}' and MaCN ='{_maCN}'", _conn);
            int exist = (Int32)command.ExecuteScalar();
            _conn.Close();
            return exist > 0;
        }
    }
}
