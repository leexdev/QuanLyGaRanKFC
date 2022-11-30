using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_NguyenLieu : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_NguyenLieu()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<NguyenLieu> GetAll()
        {
            List<NguyenLieu> list = new List<NguyenLieu>();
            _conn.Open();
            command = new SqlCommand($"select * from NguyenLieu", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNL = reader.GetString(0);
                string tenNL = reader.GetString(1);
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = new NguyenLieu(maNL, tenNL, soLuongTon);
                list.Add(nl);
            }
            _conn.Close();
            return list;
        }
        public List<NguyenLieu> GetList(string _maCN)
        {
            List<NguyenLieu> list = new List<NguyenLieu>();
            _conn.Open();
            command = new SqlCommand($"select * from NguyenLieu where MaCN = '{_maCN}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNL = reader.GetString(0);
                string tenNL = reader.GetString(1);
                int soLuongTon = reader.GetInt32(2);
                NguyenLieu nl = new NguyenLieu(maNL, tenNL, soLuongTon);
                list.Add(nl);
            }
            _conn.Close();
            return list;
        }
        public NguyenLieu GetLast(string _maNL)
        {
            NguyenLieu nguyenLieu = new NguyenLieu();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM NguyenLieu ORDER BY MaNL DESC", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNL = reader.GetString(0);
                string tenNL = reader.GetString(1);
                int soLuongTon = reader.GetInt32(2);
                nguyenLieu = new NguyenLieu(maNL, tenNL, soLuongTon);
            }
            _conn.Close();
            return nguyenLieu;
        }
        public NguyenLieu GetByID(string _maNL)
        {
            NguyenLieu nguyenLieu = new NguyenLieu();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM NguyenLieu WHERE MaNL = '{_maNL}'", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maNL = reader.GetString(0);
                string tenNL = reader.GetString(1);
                int soLuongTon = reader.GetInt32(2);
                nguyenLieu = new NguyenLieu(maNL, tenNL, soLuongTon);
            }
            _conn.Close();
            return nguyenLieu;
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaNL) FROM NguyenLieu", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
