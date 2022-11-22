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
    public partial class fQuanLyNhanVien : Form
    {
        Functions function = new Functions();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NhanVien NhanVien = new NhanVien();
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvNhanVien.Rows.Clear();
            int i = 1;
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            List<NhanVien> NhanVien = dAO_NhanVien.GetAll();
            foreach(NhanVien nhanVien in NhanVien)
            {
                dgvNhanVien.Rows.Add(i, nhanVien.maNV, nhanVien.tenNV, nhanVien.ngaySinh, nhanVien.gioiTinh, nhanVien.diaChi, nhanVien.sdt, nhanVien.cmnd, nhanVien.quyen, nhanVien.tenDangNhap, nhanVien.matKhau);
                i++;
            }

        }
        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
            cbChiNhanh.ValueMember = "maCN";
            cbChiNhanh.DisplayMember = "tenCN";
            function.turnOffButton(btnSuaNV);
            function.turnOffButton(btnXoaNV);
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txbTenNV.Text == "" || cbGioiTinhNV.SelectedValue.ToString() == null || txbDiaChiNV.Text == "" || txbSdtNV.Text == "" || txbCmndNV.Text == "" || cbChucVu.SelectedValue.ToString() == null || txbTenDangNhap.Text == "" || txbMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
                cbChiNhanh.DisplayMember = "tenCN";
                txbMaNV.Text = 
                txbTenNV.Text = NhanVien.tenNV;
                
            }
        }
        private void resetFieldsNV()
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
