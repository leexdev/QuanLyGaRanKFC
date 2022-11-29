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
        public fQuanLyNhanVien(NhanVien nhanVien, ChiNhanh chiNhanh)
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
            this.NhanVien = nhanVien;
            this.ChiNhanh = chiNhanh;
        }
        private void AssociateAndRaiseViewEvent()
        {
            txbTimKiemNV.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiemNV_Click(s, e);
                }
            };
        }
        private void LoadData()
        {
            dgvNhanVien.Rows.Clear();
            int i = 1;
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            List<NhanVien> NhanVien = dAO_NhanVien.GetAll();
            foreach(NhanVien nhanVien in NhanVien)
            {
                string chucVu = "";
                if (nhanVien.quyen == 0)
                {
                    chucVu = "Nhân Viên";
                }
                else if (nhanVien.quyen == 1)
                {
                    chucVu = "Quản Lý";
                }
                else if (nhanVien.quyen == 2)
                {
                    chucVu = "Quản Trị Viên";
                }
                dgvNhanVien.Rows.Add(i, nhanVien.maNV, nhanVien.tenNV, nhanVien.ngaySinh.ToShortDateString(), nhanVien.gioiTinh, nhanVien.diaChi, nhanVien.sdt, nhanVien.cmnd, chucVu, nhanVien.tenDangNhap);
                i++;
            }

        }
        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            function.turnOffButton(btnSuaNV);
            function.turnOffButton(btnXoaNV);
            function.turnOnButton(btnThemNV);
            dgvNhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns[0].Width = 50;
            dgvNhanVien.Columns[1].Width = 90;
            dgvNhanVien.Columns[2].MinimumWidth = 130;
            dgvNhanVien.Columns[4].Width = 60;
            dgvNhanVien.Columns[6].Width = 120;
            dgvNhanVien.Columns[7].Width = 90;
            dgvNhanVien.Columns[8].Width = 110;
            dgvNhanVien.Columns[9].Width = 120;
            dtpkNgaySinhNV.Format = DateTimePickerFormat.Custom;
            dtpkNgaySinhNV.CustomFormat = "dd/MM/yyyy";
            dtpkNgaySinhNV.ShowUpDown = false;
            List<Button> btnList = new List<Button>() { btnThemNV, btnSuaNV, btnXoaNV, btnLamMoiNV, btnTimKiemNV};
            foreach (Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
            cbChiNhanhLoc.DataSource = dAO_ChiNhanh.GetAll();
            if (NhanVien.quyen == 2)
            {
                cbChucVu.Items.Clear();
                cbChucVu.Items.Add("Nhân Viên");
                cbChucVu.Items.Add("Quản Lý");
                cbChucVu.Items.Add("Quản Trị Viên");
            }
            else
            {
                cbChucVu.Items.Clear();
                cbChucVu.Items.Add("Nhân Viên");
            }
            cbChiNhanh.ValueMember = "maCN";
            cbChiNhanh.DisplayMember = "tenCN";
            cbChiNhanhLoc.ValueMember = "maCN";
            cbChiNhanhLoc.DisplayMember = "tenCN";
            resetFieldNV();
            
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            if (txbTenNV.Text == "" || cbGioiTinhNV.SelectedIndex == -1 || txbDiaChiNV.Text == "" || txbSdtNV.Text == "" || txbCmndNV.Text == "" || cbChucVu.SelectedIndex == -1 || txbTenDangNhap.Text == "" || txbMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txbMatKhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải ít nhất 6 kí tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dAO_NhanVien.isNhanVienExist(txbTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
            NhanVien _nhanvien = new NhanVien();
            _nhanvien.maNV = txbMaNV.Text;
            _nhanvien.tenNV = txbTenNV.Text;
            _nhanvien.ngaySinh = dtpkNgaySinhNV.Value;
            _nhanvien.gioiTinh = cbGioiTinhNV.Text;
            _nhanvien.diaChi = txbDiaChiNV.Text;
            _nhanvien.sdt = txbSdtNV.Text;
            _nhanvien.cmnd = txbCmndNV.Text;
            _nhanvien.quyen = cbChucVu.SelectedIndex;
            _nhanvien.tenDangNhap = txbTenDangNhap.Text;
            _nhanvien.matKhau = txbMatKhau.Text;
            dAO_NhanVien.Add(_nhanvien, chiNhanh.maCN);
            resetFieldNV();
            MessageBox.Show("Thêm thành công!");
            cbChucVu.SelectedIndex = _nhanvien.quyen;
            this.loadDataChucVu(cbChucVu.SelectedIndex);
        }

        private void loadDataChucVu(int quyen)
        {
            switch (quyen)
            {
                case 0:
                    cbChucVu.Text = "Nhân Viên";
                    break;
                case 1:
                    cbChucVu.Text = "Quản Lý";
                    break;
                case 2:
                    cbChucVu.Text = "Quản Trị Viên";
                    break;
                default:
                    cbChucVu.Text = "";
                    break;
            }
        }
        private void btnSuaNV_Click(object sender, EventArgs e)
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
            dAO_NhanVien.Update(NhanVien, chiNhanh.maCN);
            resetFieldNV();
            MessageBox.Show("Sửa thành công!");
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {

            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            if (txbMaNV.Text == "NV1")
            {
                MessageBox.Show("Không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NhanVien.quyen == 1 && cbChucVu.Text == "Quản Lý")
            {
                MessageBox.Show("Không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NhanVien.quyen == 1 && cbChiNhanh.Text != dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN)
            {
                MessageBox.Show("Không thể xóa! Nhân viên này không thuộc chi nhánh của bạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    dAO_NhanVien.Delete(txbMaNV.Text);
                    resetFieldNV();
                }
                else
                {
                    resetFieldNV();

                }
                function.turnOffButton(btnSuaNV);
                function.turnOffButton(btnXoaNV);
                function.turnOnButton(btnThemNV);
            }
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldNV();
                function.turnOnButton(btnThemNV);
                function.turnOffButton(btnSuaNV);
                function.turnOffButton(btnXoaNV);
            }
            else
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
                NhanVien _nhanVien = dAO_NhanVien.GetByID(row.Cells[1].Value.ToString());
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(_nhanVien.maNV).tenCN;
                cbChiNhanh.ValueMember = "maCN";
                txbMaNV.Text = _nhanVien.maNV;
                txbTenNV.Text = _nhanVien.tenNV;
                dtpkNgaySinhNV.Value = _nhanVien.ngaySinh;
                cbGioiTinhNV.Text = _nhanVien.gioiTinh;
                txbDiaChiNV.Text = _nhanVien.diaChi;
                txbSdtNV.Text = _nhanVien.sdt;
                txbCmndNV.Text = _nhanVien.cmnd;
                if (_nhanVien.quyen == 0)
                {
                    cbChucVu.Text = "Nhân Viên";
                    cbChucVu.Enabled = true;
                    txbTenNV.Enabled = true;
                    txbDiaChiNV.Enabled = true;
                    txbCmndNV.Enabled = true;
                    txbTenDangNhap.Enabled = true;
                    txbSdtNV.Enabled = true;
                    cbChiNhanh.Enabled = true;
                    cbGioiTinhNV.Enabled = true;
                    dtpkNgaySinhNV.Enabled = true;
                }
                else if (_nhanVien.quyen == 1)
                {
                    cbChucVu.Text = "Quản Lý";
                    cbChucVu.Enabled = true;
                    txbTenNV.Enabled = true;
                    txbDiaChiNV.Enabled = true;
                    txbCmndNV.Enabled = true;
                    txbTenDangNhap.Enabled = true;
                    txbSdtNV.Enabled = true;
                    cbChiNhanh.Enabled = true;
                    cbGioiTinhNV.Enabled = true;
                    dtpkNgaySinhNV.Enabled = true;
                }
                else if (_nhanVien.quyen == 2)
                {
                    cbChucVu.Text = "Quản Trị Viên";
                    cbChucVu.Enabled = false;
                    txbTenNV.Enabled = false;
                    txbDiaChiNV.Enabled = false;
                    txbCmndNV.Enabled = false;
                    txbTenDangNhap.Enabled = false;
                    txbSdtNV.Enabled = false;
                    cbChiNhanh.Enabled = false;
                    cbGioiTinhNV.Enabled = false;
                    dtpkNgaySinhNV.Enabled = false;
                }
                txbTenDangNhap.Text = _nhanVien.tenDangNhap;
                txbMatKhau.Text = _nhanVien.matKhau;
                txbMatKhau.ReadOnly = true;
                function.turnOffButton(btnThemNV);
                function.turnOnButton(btnSuaNV);
                function.turnOnButton(btnXoaNV);
            }
        }
        
        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            resetFieldNV();
            function.turnOnButton(btnThemNV);
            function.turnOffButton(btnSuaNV);
            function.turnOffButton(btnXoaNV);
        }
        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemNV.Text;
            dgvNhanVien.Rows.Clear();
            int i = 1;
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            List<NhanVien> NhanVien = dAO_NhanVien.GetListByName(_keyWord);

            foreach (NhanVien nhanVien in NhanVien)
            {
                string chucVu = "";
                if (nhanVien.quyen == 0)
                {
                    chucVu = "Nhân Viên";
                }
                else if (nhanVien.quyen == 1)
                {
                    chucVu = "Quản Lý";
                }
                else if (nhanVien.quyen == 2)
                {
                    chucVu = "Quản Trị Viên";
                }
                dgvNhanVien.Rows.Add(i, nhanVien.maNV, nhanVien.tenNV, nhanVien.ngaySinh.ToShortDateString(), nhanVien.gioiTinh, nhanVien.diaChi, nhanVien.sdt, nhanVien.cmnd, chucVu, nhanVien.tenDangNhap);
                i++;
            }
        }
        private void btnLocNV_Click(object sender, EventArgs e)
        {
            dgvNhanVien.Rows.Clear();
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanhLoc.SelectedValue.ToString());
            List<NhanVien> NhanVien = dAO_NhanVien.GetList(chiNhanh.maCN);
            foreach (NhanVien nhanVien in NhanVien)
            {
                string chucVu = "";
                int i = 1;
                if (nhanVien.quyen == 0)
                {
                    chucVu = "Nhân Viên";
                }
                else if (nhanVien.quyen == 1)
                {
                    chucVu = "Quản Lý";
                }
                else if (nhanVien.quyen == 2)
                {
                    chucVu = "Quản Trị Viên";
                }
                dgvNhanVien.Rows.Add(i, nhanVien.maNV, nhanVien.tenNV, nhanVien.ngaySinh.ToShortDateString(), nhanVien.gioiTinh, nhanVien.diaChi, nhanVien.sdt, nhanVien.cmnd, chucVu, nhanVien.tenDangNhap);
                i++;
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
            dtpkNgaySinhNV.Text = DateTime.Now.ToString();
            txbCmndNV.Text = "";
            cbChucVu.Text = "";
            txbTenDangNhap.Text = "";
            txbMatKhau.Text = "";
            txbTimKiemNV.Text = "";
            txbMatKhau.ReadOnly = false;
            cbChucVu.Enabled = true;
            txbTenNV.Enabled = true;
            txbDiaChiNV.Enabled = true;
            txbCmndNV.Enabled = true;
            txbTenDangNhap.Enabled = true;
            txbSdtNV.Enabled = true;
            cbChiNhanh.Enabled = true;
            cbGioiTinhNV.Enabled = true;
            dtpkNgaySinhNV.Enabled = true;
        }
        private void cbGioiTinhNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void cbGioiTinhNV_MouseClick(object sender, MouseEventArgs e)
        {
            cbGioiTinhNV.DroppedDown = true;
        }
        private void cbChucVuNV_MouseClick(object sender, MouseEventArgs e)
        {
            cbChucVu.DroppedDown = true;
        }

        private void cbChiNhanh_MouseClick(object sender, MouseEventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }

        private void cbChiNhanhLoc_MouseClick(object sender, MouseEventArgs e)
        {
            cbChiNhanhLoc.DroppedDown = true;
        }
    }
}
