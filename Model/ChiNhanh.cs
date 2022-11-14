using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class ChiNhanh
    {
        public string maCN { get; set; }
        public string tenCN { get; set; }
        public string diaChi { get; set; }
        public List<NhanVien> nhanVien { get; set; }
        public List<NguyenLieu> nguyenLieu { get; set; }

        public ChiNhanh() 
        { 
        
        }

        public ChiNhanh(string maCN, string tenCN, string diaChi, List<NhanVien> nhanVien, List<NguyenLieu> nguyenLieu)
        {
            this.maCN = maCN;
            this.tenCN = tenCN;
            this.diaChi = diaChi;
            this.nhanVien = nhanVien;
            this.nguyenLieu = nguyenLieu;
        }
    }
}
