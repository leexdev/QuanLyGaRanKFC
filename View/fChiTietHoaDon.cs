using QuanLyGaRanKFC.DAO;
using QuanLyGaRanKFC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGaRanKFC.View
{
    public partial class fChiTietHoaDon : Form
    {
        HoaDon HoaDon = new HoaDon();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NhanVien NhanVien = new NhanVien();
        public fChiTietHoaDon()
        {
            InitializeComponent();
        }
        public fChiTietHoaDon(HoaDon HoaDon, ChiNhanh ChiNhanh, NhanVien NhanVien)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
            this.ChiNhanh = ChiNhanh;
            this.NhanVien = NhanVien;
        }

        public void LoadData()
        {
            dgvCTHD.Rows.Clear();
            int i = 1;
            decimal tongTien = 0;
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            List<CTHD> cTHDs = dAO_CTHD.GetList(HoaDon.MaHD);
            foreach(CTHD cthd in cTHDs)
            {
                dgvCTHD.Rows.Add(i, cthd.MonAn.maMon, cthd.MonAn.tenMon, cthd.soLuong, cthd.MonAn.donGia, cthd.thanhTien, "Xóa");
                tongTien += cthd.thanhTien;
                i++;
            }
            txbTongTien.Text = tongTien.ToString();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            txbMaHD.Text = HoaDon.MaHD;
            cbChiNhanh.Text = ChiNhanh.tenCN;
            cbKhachHang.Text = HoaDon.khachHang.tenKH;
            cbNhanVien.Text = HoaDon.nhanVien.tenNV;

        }
    }
}
