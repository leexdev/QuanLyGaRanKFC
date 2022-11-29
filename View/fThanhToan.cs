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
        public fThanhToan(HoaDon HoaDon, ChiNhanh ChiNhanh, NhanVien NhanVien, DanhMuc DanhMuc)
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
            if (NhanVien.quyen == 2)
            {
                cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
            }
            else
            {
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
            }
            cbKhachHang.DataSource = dAO_KhachHang.GetAll();
            cbKhachHang.ValueMember = "maKH";
            cbKhachHang.DisplayMember = "tenKH";
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
            LoadData();
            if (dgvThanhToan.Rows.Count == 0)
            {
                txbMaHD.Text = "HD1";
            }
            else if (dgvThanhToan.Rows.Count > 0)
            {
                txbMaHD.Text = function.CreateID(dAO_NhanVien.GetLast().maNV);
            }
            txbSoLuong.ReadOnly = false;
        }
    }
}
