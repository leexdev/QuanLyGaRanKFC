using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class NhanVien
    {
        public string maNV { get; set; }
        public string tenNV { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        public DateTime ngaySinh = new DateTime();
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string sdt { get; set; }
        public string cmnd { get; set; }
        public int quyen { get; set; }

        public NhanVien() { }
        public NhanVien(string maNV, string tenNV, string tenDangNhap, string matKhau, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string cmnd, int quyen)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.cmnd = cmnd;
            this.quyen = quyen;
        }
    }
}
