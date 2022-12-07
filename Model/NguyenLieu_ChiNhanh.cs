using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class NguyenLieu_ChiNhanh
    {
        public int soLuongTon { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public ChiNhanh ChiNhanh { get; set; }
        public NguyenLieu_ChiNhanh() { }
        public NguyenLieu_ChiNhanh(int soLuongTon, NguyenLieu nguyenLieu, ChiNhanh chiNhanh)
        {
            this.soLuongTon = soLuongTon;
            this.NguyenLieu = nguyenLieu;
            this.ChiNhanh = chiNhanh;
        }
    }
}
