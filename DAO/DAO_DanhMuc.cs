using QuanLyGaRanKFC.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_DanhMuc : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;

        public DAO_DanhMuc()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<DanhMuc> GetAll()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM DanhMuc where isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                DanhMuc danhMuc = new DanhMuc(maDM, tenDM, monAn);
                list.Add(danhMuc);
            }
            _conn.Close();
            return list;
        }
        public List<DanhMuc> GetList(string _maDM)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM DanhMuc WHERE MaDM = '{_maDM}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                DanhMuc danhMuc = new DanhMuc(maDM, tenDM, monAn);
                list.Add(danhMuc);
            }
            _conn.Close();
            return list;
        }
        public List<DanhMuc> GetByName(string _tenDM)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM DanhMuc WHERE TenDM LIKE N'%{_tenDM}%' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                DanhMuc danhMuc = new DanhMuc(maDM, tenDM, monAn);
                list.Add(danhMuc);
            }
            _conn.Close();
            return list;
        }
        public DanhMuc GetLast()
        {
            DanhMuc danhMuc = new DanhMuc();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM DanhMuc ORDER BY MaDM DESC", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                danhMuc = new DanhMuc(maDM, tenDM, monAn);
            }
            _conn.Close();
            return danhMuc;
        }
        public DanhMuc GetByID(string _maDM)
        {
            DanhMuc danhMuc = new DanhMuc();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM DanhMuc WHERE MADM = '{_maDM}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                danhMuc = new DanhMuc(maDM, tenDM, monAn);
            }
            _conn.Close();
            return danhMuc;
        }
        public DanhMuc GetByUserID(string _maMon)
        {
            DanhMuc danhMuc = new DanhMuc();
            _conn.Open();
            command = new SqlCommand($"SELECT DanhMuc.* FROM DanhMuc, MonAn WHERE DanhMuc.MaDM = MonAn.MaDM AND MaMon = '{_maMon}'", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _MonAn = new DAO_MonAn();
            while (reader.Read())
            {
                string maDM = reader.GetString(0);
                string tenDM = reader.GetString(1);
                List<MonAn> monAn = _MonAn.GetList(maDM);
                danhMuc = new DanhMuc(maDM, tenDM, monAn);
            }
            _conn.Close();
            return danhMuc;
        }
        public void Add(DanhMuc danhMuc)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO DanhMuc VALUES(N'{danhMuc.maDM}', N'{danhMuc.tenDM}', 0)", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(DanhMuc danhMuc)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE DanhMuc SET TenDM = N'{danhMuc.tenDM}' WHERE MaDM = '{danhMuc.maDM}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maDM)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE DanhMuc SET isDeleted = 1 WHERE MaDM = '{_maDM}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaDM) FROM DanhMuc", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
