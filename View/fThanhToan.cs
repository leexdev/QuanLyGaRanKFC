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
    public partial class fThanhToan : Form
    {
        HoaDon HoaDon = new HoaDon();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NhanVien NhanVien = new NhanVien();
        DanhMuc DanhMuc = new DanhMuc();
        Functions function = new Functions();
        public fThanhToan(HoaDon HoaDon, ChiNhanh ChiNhanh, NhanVien NhanVien, DanhMuc DanhMuc, CTHD CTHD)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
            this.ChiNhanh = ChiNhanh;
            this.NhanVien = NhanVien;
            this.DanhMuc = DanhMuc;
        }
        public void LoadData()
        {
            dgvThanhToan.Rows.Clear();
            int i = 1;
            decimal tongTien = 0;
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            List<CTHD> cTHDs = dAO_CTHD.GetList(HoaDon.MaHD);
            foreach (CTHD cthd in cTHDs)
            {
                dgvThanhToan.Rows.Add(i, cthd.MonAn.tenMon, cthd.soLuong, cthd.MonAn.donGia, cthd.thanhTien, "Xóa");
                tongTien += cthd.thanhTien;
                i++;
            }
            txbTongTien.Text = tongTien.ToString();
            txbMaHD.Enabled = false;
        }
        private void fThanhToan_Load(object sender, EventArgs e)
        {
            dgvThanhToan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvThanhToan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtpkNgayTaoHD.Format = DateTimePickerFormat.Custom;
            dtpkNgayTaoHD.CustomFormat = "dd/MM/yyyy";
            dtpkNgayTaoHD.ShowUpDown = false;

            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            txbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
            txbChiNhanh.Enabled = false;
            txbNhanVien.Enabled = false;
            txbTenKH.Enabled = false;
            KhachHang khachHang = dAO_KhachHang.GetByPhone(txbSdtKH.Text);
            txbTenKH.Text = khachHang.tenKH;
            cbDanhMuc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMuc.ValueMember = "maDM";
            cbDanhMuc.DisplayMember = "tenDM";
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMuc.SelectedValue.ToString());
            cbMonAn.DataSource = dAO_MonAn.GetList(danhMuc.maDM);
            cbMonAn.ValueMember = "maMon";
            cbMonAn.DisplayMember = "tenMon";
            txbNhanVien.Text = NhanVien.tenNV;
            resetfield();
        }
        private void resetfield()
        {
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            txbMaHD.Text = "HD" + dAO_HoaDon.AutoId();
            LoadData();
        }
        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void txbSdtKH_TextChanged(object sender, EventArgs e)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            KhachHang khachHang = dAO_KhachHang.GetByPhone(txbSdtKH.Text);
            txbTenKH.Text = khachHang.tenKH;
        }
    }
}
