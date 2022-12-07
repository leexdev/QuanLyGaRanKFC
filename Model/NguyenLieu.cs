using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class NguyenLieu
    {
        public string maNL { get; set; }
        public string tenNL { get; set; }

        public NguyenLieu() { }

        public NguyenLieu(string maNL, string tenNL)
        {
            this.maNL = maNL;
            this.tenNL = tenNL;
        }
    }
}
