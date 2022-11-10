using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class HoaDon
    {
        public string MaHD;
        public DateTime ngayTaoHD = new DateTime();
        public NhanVien nhanVien = new NhanVien();
        public KhachHang khachHang = new KhachHang();
        public List<CTHD> chiTietHoaDon = new List<CTHD>();
        public decimal tongTien { get; set; }
        public HoaDon() { }
        public HoaDon(string maHD, DateTime ngayTaoHD, NhanVien nhanVien, KhachHang khachHang)
        {
            this.MaHD = maHD;
            this.ngayTaoHD = ngayTaoHD;
            this.nhanVien = nhanVien;
            this.khachHang = khachHang;
        }
        public HoaDon( string maHD, DateTime ngayTaoHD, NhanVien nhanVien, KhachHang khachHang, List<CTHD> chiTietHoaDon)
        {
            List<decimal> thanhTien = new List<decimal>();
            foreach(CTHD ct in chiTietHoaDon)
            {
                thanhTien.Add(ct.thanhTien);
            }
            MaHD = maHD;
            this.ngayTaoHD = ngayTaoHD;
            this.nhanVien = nhanVien;
            this.khachHang = khachHang;
            this.chiTietHoaDon = chiTietHoaDon;
            this.tongTien = sum(thanhTien);
        }
        public static decimal sum(List<decimal> thanhTien)
        {
            decimal tongtien = 0;
            foreach(decimal i in thanhTien)
            {
                tongtien += i;
            }
            return tongtien;
        }
    }
}
