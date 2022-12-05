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
        Functions function = new Functions();
        private int check1 = 0;
        private int check2 = 0;
        private int check3 = 0;
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
            lbErr2.Text = "";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            if (txbMatKhauCu.Text == "" || txbMatKhauMoi.Text == "" || txbNhapLaiMatKhau.Text == "")
            {
                lbErr2.Text = "Không được để trống thông tin!";
            }
            else if (function.GetMD5(txbMatKhauCu.Text) != nhanVien.matKhau)
            {
                lbErr2.Text = "Mật khẩu cũ không chính xác!";
            }
            else
            {
                if (txbMatKhauMoi.Text.Length < 6 || txbNhapLaiMatKhau.Text.Length < 6)
                {
                    lbErr2.Text = "Mật khẩu mới không được ít hơn 6 ký tự!";
                }
                else if (txbMatKhauMoi.Text == txbMatKhauCu.Text)
                {
                    lbErr2.Text = "Mật khẩu mới không được trùng với mật khẩu cũ!";
                }
                else if (txbNhapLaiMatKhau.Text != txbMatKhauMoi.Text)
                {
                    lbErr2.Text = "Mật khẩu mới không trùng khớp!";
                }
                else
                {
                    lbErr2.Text = "";
                    nhanVien.matKhau = function.GetMD5(txbNhapLaiMatKhau.Text);
                    dAO_NhanVien.Update(nhanVien, dAO_ChiNhanh.GetByUserID(nhanVien.maNV).maCN);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.tpDoiMatKhau.Hide();
            tcTaiKhoan.TabPages.Remove(tpDoiMatKhau);
            tcTaiKhoan.TabPages.Insert(0, tpTrangCaNhan);
            this.tpTrangCaNhan.Show();
            txbMatKhauCu.Text = "";
            txbMatKhauMoi.Text = "";
            txbNhapLaiMatKhau.Text = "";
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

        private void btnThoatNV_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (check1)
            {
                case 0:
                    txbMatKhauCu.PasswordChar = '*';
                    check1 = 1;
                    break;
                case 1:
                    txbMatKhauCu.PasswordChar = (char)0;
                    check1 = 0;
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            switch (check2)
            {
                case 0:
                    txbMatKhauMoi.PasswordChar = '*';
                    check2 = 1;
                    break;
                case 1:
                    txbMatKhauMoi.PasswordChar = (char)0;
                    check2 = 0;
                    break;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            switch (check3)
            {
                case 0:
                    txbNhapLaiMatKhau.PasswordChar = '*';
                    check3 = 1;
                    break;
                case 1:
                    txbNhapLaiMatKhau.PasswordChar = (char)0;
                    check3 = 0;
                    break;
            }
        }
    }
}
