using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class CTHD
    {
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
        public MonAn MonAn { get; set; }
        public CTHD() { }

        public CTHD(int soLuong, MonAn MonAn)
        {
            this.soLuong = soLuong;
            this.MonAn = MonAn;
            this.thanhTien = Convert.ToDecimal(soLuong) * MonAn.donGia;
        }
    }
}
