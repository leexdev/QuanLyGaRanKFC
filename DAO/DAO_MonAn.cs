using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.DAO
{
    public class DAO_MonAn : DatabaseConnection
    {
        SqlConnection _conn;
        private SqlCommand command;
        private SqlDataReader reader;
        public DAO_MonAn()
        {
            _conn = new SqlConnection(_strConn);
        }
        public List<MonAn> GetAll()
        {
            List<MonAn> list = new List<MonAn>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM MonAn where isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maMon = reader.GetString(0);
                string tenMon = reader.GetString(1);
                decimal donGia = reader.GetDecimal(2);
                MonAn ma = new MonAn(maMon, tenMon, donGia);
                list.Add(ma);
            }
            _conn.Close();
            return list;
        }
        public List<MonAn> GetList(string _maDM)
        {
            List<MonAn> list = new List<MonAn>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM MonAn WHERE MaDM = '{_maDM}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maMon = reader.GetString(0);
                string tenMon = reader.GetString(1);
                decimal donGia = reader.GetDecimal(2);
                MonAn ma = new MonAn(maMon, tenMon, donGia);
                list.Add(ma);
            }
            _conn.Close();
            return list;
        }
        public List<MonAn> GetListByName(string _tenMon)
        {
            List<MonAn> list = new List<MonAn>();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM MonAn WHERE TenMon LIKE N'%{_tenMon}%' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maMon = reader.GetString(0);
                string tenMon = reader.GetString(1);
                decimal donGia = reader.GetDecimal(2);
                MonAn ma = new MonAn(maMon, tenMon, donGia);
                list.Add(ma);
            }
            _conn.Close();
            return list;
        }

        public MonAn GetLast()
        {
            MonAn monAn = new MonAn();
            _conn.Open();
            command = new SqlCommand($"SELECT TOP(1)* FROM MonAn ORDER BY MaMon DESC", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maMon = reader.GetString(0);
                string tenMon = reader.GetString(1);
                decimal donGia = reader.GetDecimal(2);
                monAn = new MonAn(maMon, tenMon, donGia);
            }
            _conn.Close();
            return monAn;
        }
        public MonAn GetByID(string _maMon)
        {
            MonAn monAn = new MonAn();
            _conn.Open();
            command = new SqlCommand($"SELECT * FROM MonAn WHERE MaMon = '{_maMon}' and isDeleted = 0", _conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string maMon = reader.GetString(0);
                string tenMon = reader.GetString(1);
                decimal donGia = reader.GetDecimal(2);
                monAn = new MonAn(maMon, tenMon, donGia);

            }
            _conn.Close();
            return monAn;
        }
        public void Add(MonAn _monAn, string _maDM)
        {
            _conn.Open();
            command = new SqlCommand($@"INSERT INTO MonAn 
                                        VALUES(N'{_monAn.maMon}',
                                               N'{_monAn.tenMon}',
                                               {_monAn.donGia},
                                               '{_maDM}',
                                                0)", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Update(MonAn _monAn, string _maDM)
        {
            _conn.Open();
            command = new SqlCommand($@"UPDATE MonAn 
                                    SET TenMon = N'{_monAn.tenMon}',
                                        DonGia = {_monAn.donGia},
                                        MaCN = '{_maDM}'
                                    WHERE MaMon = '{_monAn.maMon}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public void Delete(string _maMon)
        {
            _conn.Open();
            command = new SqlCommand($"UPDATE MonAn SET isDeleted = 1 WHERE MaMon = '{_maMon}'", _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public int AutoId()
        {
            _conn.Open();
            command = new SqlCommand($"SELECT COUNT(MaMon) FROM MonAn", _conn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            _conn.Close();
            i++;
            return i;
        }
    }
}
