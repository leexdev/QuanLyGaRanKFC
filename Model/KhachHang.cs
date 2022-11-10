using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class KhachHang
    {
        public string maKH { get; set; }
        public string tenKH { get; set; }
        public string diaChi { get; set; }
        public string sdt { get; set; }

        public KhachHang() { }

        public KhachHang(string maKH, string tenKH, string diaChi, string sdt)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.diaChi = diaChi;
            this.sdt = sdt;
        }
    }
}
