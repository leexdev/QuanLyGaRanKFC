using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.DAO
{
    public class DatabaseConnection
    {
        public string _strConn = "Data Source=LEE;Initial Catalog=QuanLyBanGaRan;Integrated Security=True";
        public DatabaseConnection()
        {

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_strConn);
        }
    }
}
