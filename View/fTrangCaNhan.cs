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
    public partial class fTrangCaNhan : Form
    {
        NhanVien nhanVien = new NhanVien();
        public fTrangCaNhan(NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            tcTaiKhoan.TabPages.Insert(0, tpDoiMatKhau);
            this.tpDoiMatKhau.Show();
            tcTaiKhoan.SelectedTab = tpDoiMatKhau;
            this.tpTrangCaNhan.Hide();
            tcTaiKhoan.TabPages.Remove(tpTrangCaNhan);
            txbTenDangNhapNV.Enabled = false;
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            if (txbTenDangNhap.Text == nhanVien.tenDangNhap)
            {
                nhanVien.maNV = txbMaNV.Text;
                nhanVien.tenNV = txbHoTen.Text;
                nhanVien.ngaySinh = dtpkNgaySinh.Value;
                nhanVien.gioiTinh = cbGioiTinh.Text;
                nhanVien.diaChi = txbDiaChiNV.Text;
                nhanVien.sdt = txbSdtNV.Text;
                nhanVien.cmnd = txbCmndNV.Text;
                nhanVien.tenDangNhap = txbTenDangNhap.Text;
                dAO_NhanVien.Update(nhanVien, dAO_ChiNhanh.GetByUserID(nhanVien.maNV).maCN);
                MessageBox.Show("Lưu thành công!");
            }
            else if (dAO_NhanVien.isNhanVienExist(txbTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nhanVien.maNV = txbMaNV.Text;
                nhanVien.tenNV = txbHoTen.Text;
                nhanVien.ngaySinh = dtpkNgaySinh.Value;
                nhanVien.gioiTinh = cbGioiTinh.Text;
                nhanVien.diaChi = txbDiaChiNV.Text;
                nhanVien.sdt = txbSdtNV.Text;
                nhanVien.cmnd = txbCmndNV.Text;
                nhanVien.tenDangNhap = txbTenDangNhap.Text;
                dAO_NhanVien.Update(nhanVien, dAO_ChiNhanh.GetByUserID(nhanVien.maNV).maCN);
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void btnThoatNV_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thay đổi mật khẩu thành công!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.tpDoiMatKhau.Hide();
            tcTaiKhoan.TabPages.Remove(tpDoiMatKhau);
            tcTaiKhoan.TabPages.Insert(0, tpTrangCaNhan);
            this.tpTrangCaNhan.Show();
        }

        private void fTrangCaNhan_Load(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            dtpkNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpkNgaySinh.ShowUpDown = false;
            this.tpDoiMatKhau.Hide();
            tcTaiKhoan.TabPages.Remove(tpDoiMatKhau);
            txbMaCN.Text = dAO_ChiNhanh.GetByUserID(nhanVien.maNV).tenCN;
            txbMaNV.Text = nhanVien.maNV;
            txbHoTen.Text = nhanVien.tenNV;
            dtpkNgaySinh.Value = nhanVien.ngaySinh;
            cbGioiTinh.Text = nhanVien.gioiTinh;
            txbDiaChiNV.Text = nhanVien.diaChi;
            txbSdtNV.Text = nhanVien.sdt;
            txbCmndNV.Text = nhanVien.cmnd;
            if (nhanVien.quyen == 0)
            {
                txbChucVu.Text = "Nhân Viên";
            }
            else if (nhanVien.quyen == 1)
            {
                txbChucVu.Text = "Quản Lý";
            }
            else
            {
                txbChucVu.Text = "Quản Trị Viên";
            }
            txbTenDangNhap.Text = nhanVien.tenDangNhap;
            txbTenDangNhapNV.Text = txbTenDangNhap.Text;
            if (tcTaiKhoan.SelectedTab == tcTaiKhoan.TabPages["tpTrangCaNhan"])
            {
                this.AcceptButton = btnLuuNV;
            }
        }

        private void cbGioiTinh_MouseClick(object sender, MouseEventArgs e)
        {
            cbGioiTinh.DroppedDown = true;
        }

        private void cbGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void tcTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcTaiKhoan.SelectedTab == tcTaiKhoan.TabPages["tpTrangCaNhan"])
            {
                this.AcceptButton = btnLuuNV;
            }
            else if (tcTaiKhoan.SelectedTab == tcTaiKhoan.TabPages["tpDoiMatKhau"])
            {
                this.AcceptButton = btnLuu;
                this.CancelButton = btnThoat;
            }
        }
    }
}
