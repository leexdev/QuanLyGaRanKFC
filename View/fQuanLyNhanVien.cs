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
            List<Button> btnList = new List<Button>() { btnThemNV, btnSuaNV, btnXoaNV, btnLamMoiNV, btnTimKiemNV };
            foreach (Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
            cbChiNhanh.ValueMember = "maCN";
            cbChiNhanh.DisplayMember = "tenCN";
            txbMaNV.Text = function.CreateID(dAO_NhanVien.GetLast().maNV);
            LoadData();
            function.turnOffButton(btnSuaNV);
            function.turnOffButton(btnXoaNV);
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txbTenNV.Text == "" || cbGioiTinhNV.SelectedIndex == -1 || txbDiaChiNV.Text == "" || txbSdtNV.Text == "" || txbCmndNV.Text == "" || cbChucVu.SelectedIndex == -1 || txbTenDangNhap.Text == "" || txbMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txbMatKhau.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải ít nhất 6 kí tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
                    DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                    ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
                    NhanVien.maNV = txbMaNV.Text;
                    NhanVien.tenNV = txbTenNV.Text;
                    NhanVien.ngaySinh = dtpkNgaySinhNV.Value;
                    NhanVien.gioiTinh = cbGioiTinhNV.Text;
                    NhanVien.diaChi = txbDiaChiNV.Text;
                    NhanVien.sdt = txbSdtNV.Text;
                    NhanVien.cmnd = txbCmndNV.Text;
                    NhanVien.quyen = cbChucVu.SelectedIndex;
                    NhanVien.tenDangNhap = txbTenDangNhap.Text;
                    NhanVien.matKhau = txbMatKhau.Text;
                    dAO_NhanVien.Add(NhanVien, chiNhanh.maCN);
                    resetFieldNV();
                    MessageBox.Show("Thêm thành công!");
                }
            }
        }
        private void resetFieldNV()
        {
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            LoadData();
            txbMaNV.Text = function.CreateID(dAO_NhanVien.GetLast().maNV);
            txbTenNV.Text = "";
            cbGioiTinhNV.Text = "";
            txbDiaChiNV.Text = "";
            txbSdtNV.Text = "";
            txbCmndNV.Text = "";
            cbChucVu.Text = "";
            txbTenDangNhap.Text = "";
            txbMatKhau.Text = "";
        }

        private void cbGioiTinhNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }
    }
}
