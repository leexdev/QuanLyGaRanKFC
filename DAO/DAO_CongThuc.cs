using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_CongThuc : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_CongThuc()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<CongThuc> GetList(string _maMon)
        {
            List<CongThuc> list = new List<CongThuc>();
            _conn.Open();
            command = new SqlCommand($"SELECT MaNL ,SoLuong FROM CongThuc WHERE CongThuc.MaMon = '{_maMon}'", _conn);
            reader = command.ExecuteReader();
            DAO_NguyenLieu _nguyenLieu = new DAO_NguyenLieu();
            while (reader.Read())
            {
                int soLuong = reader.GetInt32(1);
                NguyenLieu nl = _nguyenLieu.GetByID(reader.GetString(0));
                CongThuc ct = new CongThuc(soLuong, nl);
                list.Add(ct);
            }
            _conn.Close();
            return list;
        }
        public void Add(CongThuc congThuc, string _maMon)
        {
            _conn.Open();
            command = new SqlCommand($"IF EXISTS(SELECT * FROM dbo.CongThuc WHERE MaMon = '{_maMon}' AND MaNL = '{congThuc.nguyenLieu.maNL}') " +
                $"BEGIN " +
                $"UPDATE dbo.CongThuc SET SoLuong = Soluong + {congThuc.soLuong} WHERE MaMon = '{_maMon}' AND MaNL = '{congThuc.nguyenLieu.maNL}' END " +
                $"ELSE " +
                $"BEGIN INSERT INTO dbo.CongThuc (MaMon, MaNL, SoLuong) VALUES ('{_maMon}', '{congThuc.nguyenLieu.maNL}', {congThuc.soLuong}) " +
                $"END", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(CongThuc congThuc, string _maMon)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE CongThuc SET SoLuong = {congThuc.soLuong} WHERE MaMon = '{_maMon}' AND MaNL = '{congThuc.nguyenLieu.maNL}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maMon, string _maNL)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM CongThuc WHERE MaMon = '{_maMon}' AND MaNL = '{_maNL}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
