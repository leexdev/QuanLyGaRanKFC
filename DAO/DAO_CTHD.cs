using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_CTHD : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_CTHD()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<CTHD> GetList(string _maHD)
        {
            List<CTHD> list = new List<CTHD>();
            _conn.Open();
            command = new SqlCommand($"SELECT SoLuong, MonAn.MaMon FROM CTHoaDon, MonAn WHERE CTHoaDon.MaMon = MonAn.MaMon AND MaHD = '{_maHD}'", _conn);
            reader = command.ExecuteReader();
            DAO_MonAn _monAn = new DAO_MonAn();
            while (reader.Read())
            {
                int soLuong = reader.GetInt32(0);
                MonAn ma = _monAn.GetByID(reader.GetString(1));
                CTHD cthd = new CTHD(soLuong, ma);
                list.Add(cthd);
            }
            _conn.Close();
            return list;
        }
        public void Add(CTHD CTHD, string _maHD)
        {
            _conn.Open();
            command = new SqlCommand($"INSERT INTO CTHoaDon (MaHD, SoLuong, MaMon) VALUES('{_maHD}', {CTHD.soLuong}, '{CTHD.MonAn.maMon}')", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(CTHD CTHD, string _maHD)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE CTHoaDon SET SoLuong = {CTHD.soLuong} WHERE MaHD = '{_maHD}' AND MaMon = '{CTHD.MonAn.maMon}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maHD, string _maMon)
        {
            _conn.Open();
            command = new SqlCommand($"DELETE FROM CTHoaDon WHERE MaHD = '{_maHD}' AND MaMon = '{_maMon}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public void XoaNguyenLieu(CTHD cthd, string _maCN)
        {
            DAO_CongThuc dao_CongThuc = new DAO_CongThuc();
            List<CongThuc> listCongThuc = dao_CongThuc.GetList(cthd.MonAn.maMon);
            foreach (CongThuc ct in listCongThuc)
            {
                _conn.Open();

                command = new SqlCommand($"UPDATE NguyenLieu_ChiNhanh SET SoLuongTon = SoLuongTon - {ct.soLuong} WHERE MaNL = '{ct.nguyenLieu.maNL}' and MaCN = '{_maCN}'", _conn);
                command.ExecuteNonQuery();
                _conn.Close();
            }
        }
    }
}