using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class CongThuc
    {
        public int soLuong { get; set; }
        public MonAn monAn { get; set; }
        public NguyenLieu nguyenLieu { get; set; }
        public CongThuc() { }
        public CongThuc(int soLuong, NguyenLieu nguyenLieu)
        {
            this.soLuong = soLuong;
            this.nguyenLieu = nguyenLieu;
        }
    }
}
