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
        List<CTHD> ListChitietHD = new List<CTHD>();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NhanVien NhanVien = new NhanVien();
        DanhMuc DanhMuc = new DanhMuc();
        Functions function = new Functions();
        public fThanhToan(HoaDon HoaDon, ChiNhanh ChiNhanh, NhanVien NhanVien, DanhMuc DanhMuc, CTHD cTHD)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
            this.ChiNhanh = ChiNhanh;
            this.NhanVien = NhanVien;
            this.DanhMuc = DanhMuc;
        }
        public void LoadData(bool isFromVal = false)
        {
            dgvThanhToan.Rows.Clear();
            int i = 1;
            decimal tongTien = 0;
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            List<CTHD> cTHDs;
            if(!isFromVal)
            {
                cTHDs = dAO_CTHD.GetList(HoaDon.MaHD);
            }
            else
            {
                cTHDs = this.ListChitietHD;
            }
            //List<CTHD> cTHDs = dAO_CTHD.GetList(HoaDon.MaHD);
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
            dgvThanhToan.Columns[0].Width = 50;
            dgvThanhToan.Columns[1].Width = 250;
            dgvThanhToan.Columns[2].Width = 80;

            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            txbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
            txbChiNhanh.Enabled = false;
            txbNhanVien.Enabled = false;
            txbTenKH.Enabled = false;
            KhachHang khachHang = dAO_KhachHang.GetByPhone(txbSdtKH.Text);
            txbTenKH.Text = khachHang.tenKH;
            txbNhanVien.Text = NhanVien.tenNV;
            cbDanhMuc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMuc.ValueMember = "maDM";
            cbDanhMuc.DisplayMember = "tenDM";
            resetFieldHD();
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

        private void cbDanhMuc_TextChanged(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMuc.SelectedValue.ToString());
            cbMonAn.DataSource = dAO_MonAn.GetList(danhMuc.maDM);
            cbMonAn.ValueMember = "maMon";
            cbMonAn.DisplayMember = "tenMon";
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            MonAn monAn = dAO_MonAn.GetByID(cbMonAn.SelectedValue.ToString());
            CTHD cTHD = new CTHD(Convert.ToInt32(nmrupSoLuong.Value), monAn);
            this.ListChitietHD.Add(cTHD);
            LoadData(true);
        }
        private void resetFieldHD()
        {
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            txbMaHD.Text = "HD" + dAO_HoaDon.AutoId();
            txbTongTien.Text = "";
            dgvThanhToan.Rows.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            HoaDon.MaHD = txbMaHD.Text;
            HoaDon.ngayTaoHD = dtpkNgayTaoHD.Value;
            HoaDon.khachHang.maKH = dAO_KhachHang.GetByPhone(txbSdtKH.Text).maKH;
            HoaDon.nhanVien.maNV = NhanVien.maNV;
            dAO_HoaDon.Add(HoaDon);
            foreach(CTHD cthd in ListChitietHD)
            {
                dAO_CTHD.Add(cthd, HoaDon.MaHD);
            }
            MessageBox.Show("Lưu thành công!");
            resetFieldHD();
            ListChitietHD.Clear();
        }

        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            MonAn monAn = dAO_MonAn.GetByName(dgvThanhToan.CurrentRow.Cells[1].Value.ToString();
            int soluong = Convert.ToInt32(dgvThanhToan.CurrentRow.Cells[2].Value.ToString());
            CTHD cTHD = new CTHD(soluong, monAn);
            this.ListChitietHD.Remove(cTHD);
            LoadData(true);
        }

        private void cbDanhMuc_MouseClick(object sender, MouseEventArgs e)
        {
            cbDanhMuc.DroppedDown = true;
        }

        private void cbMonAn_MouseClick(object sender, MouseEventArgs e)
        {
            cbMonAn.DroppedDown = true;
        }
    }
}
