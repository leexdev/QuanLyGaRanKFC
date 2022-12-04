using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGaRanKFC.DAO;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.View
{
    public partial class fDangNhap : Form
    {
        Functions _function = new Functions();
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txbPassword.PasswordChar = (char)0;

            }
            else
            {
                txbPassword.PasswordChar = '●';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbErr1.Text = "";
            lbErr2.Text = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lbErr1.Text = "";
            lbErr2.Text = "";
            string usn = txbUserName.Text;
            string pwd = txbPassword.Text;

            if (usn.Length == 0)
            {
                lbErr1.Text = "*Tên đăng nhập không được để trống";
            }
            if (pwd.Length < 6)
            {
                lbErr2.Text = "*Mật khẩu phải ít nhất 6 kí tự";
            }
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            NhanVien nhanVien = dAO_NhanVien.GetByUserName(usn);
            if (nhanVien.tenDangNhap != usn)
            {
                lbErr1.Text = "*Tên đăng nhập không tồn tại";
            }
            else
            {
                if (_function.GetMD5(pwd) != nhanVien.matKhau)
                {
                    lbErr2.Text = "*Mật khẩu không chính xác";
                }
                else
                {
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.Hide();
                        fQuanLyGaRanKFC qlch = new fQuanLyGaRanKFC(nhanVien);
                        qlch.WindowState = FormWindowState.Maximized;
                        qlch.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                        fQuanLyGaRanKFC qlch = new fQuanLyGaRanKFC(nhanVien);
                        qlch.WindowState = FormWindowState.Normal;
                        qlch.ShowDialog();
                        this.Close();
                    }
                }
            }
        }
    }
}
