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
    public partial class QuanLyGaRanKFC : Form
    {
        NhanVien nhanVien = new NhanVien();
        public QuanLyGaRanKFC()
        {
            InitializeComponent();
        }
        public QuanLyGaRanKFC(NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            pnMain.Controls.Add(new ucQuanLyKhachHang());
        }

        private void QuanLyGaRanKFC_Load(object sender, EventArgs e)
        {
            lbDisplayName.Text = nhanVien.tenNV;
            if (nhanVien.quyen == 0)
            {
                lbCapBac.Text = "(Nhân Viên)";
            }
            if (nhanVien.quyen == 1)
            {
                lbCapBac.Text = "(Quản Lý)";
            }
            if (nhanVien.quyen == 2)
            {
                lbCapBac.Text = "(Admin)";
            }
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            ucChiNhanh f = new ucChiNhanh();
            this.AddOwnedForm(f);
            f.Show();
        }
    }
}
