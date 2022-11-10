using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class DanhMuc
    {
        public string maDM { get; set; }
        public string tenDM { get; set; }
        public List<MonAn> MonAn { get; set; }

        public DanhMuc() { }

        public DanhMuc(string maDM, string tenDM, List<MonAn> monAn)
        {
            this.maDM = maDM;
            this.tenDM = tenDM;
            MonAn = monAn;
        }
    }
}
