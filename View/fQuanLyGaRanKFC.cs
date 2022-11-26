using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGaRanKFC.Model;
using QuanLyGaRanKFC.DAO;
using QuanLyGaRanKFC.View.UserControl;

namespace QuanLyGaRanKFC.View
{
    public partial class fQuanLyGaRanKFC : Form
    {
        NhanVien nhanVien = new NhanVien();
        public fQuanLyGaRanKFC()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnChildForm.Controls.Add(childForm);
            pnChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public fQuanLyGaRanKFC(NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ucQuanLyKhachHang());
        }

        private void QuanLyGaRanKFC_Load(object sender, EventArgs e)
        {
            lbDisplayName.Text = nhanVien.tenNV;
            if (nhanVien.quyen == 0)
            {
                lbCapBac.Text = "Nhân Viên";
            }
            if (nhanVien.quyen == 1)
            {
                lbCapBac.Text = "Quản Lý";
            }
            if (nhanVien.quyen == 2)
            {
                lbCapBac.Text = "Admin";
            }
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            if (nhanVien.quyen == 2)
            {
                OpenChildForm(new ucChiNhanh());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
            this.Close();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pnChildForm.Controls.Clear();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLyHoaDon());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVien.quyen == 1 || nhanVien.quyen == 2)
            {
                OpenChildForm(new fQuanLyNhanVien());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
