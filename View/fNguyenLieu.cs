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
    public partial class fNguyenLieu : Form
    {
        Functions function = new Functions();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NguyenLieu NguyenLieu = new NguyenLieu();
        NhanVien NhanVien = new NhanVien();
        CTHD cTHD = new CTHD();
        CongThuc congThuc = new CongThuc();
        NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh();
        public fNguyenLieu(NguyenLieu nguyenLieu, ChiNhanh chiNhanh, NhanVien nhanVien, NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh)
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
            this.ChiNhanh = chiNhanh;
            this.NguyenLieu = nguyenLieu;
            this.NhanVien = nhanVien;
            this.nguyenLieu_ChiNhanh = nguyenLieu_ChiNhanh;
        }

        private void AssociateAndRaiseViewEvent()
        {
            txbTimKiemNL.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiemNL_Click(s, e);
                }
            };
            cbChiNhanhLoc.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLocNL_Click(s, e);
                }
            };
        }
        private void LoadDataNL()
        {
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            List<NguyenLieu> NguyenLieu = dAO_NguyenLieu.GetAll();
            foreach (NguyenLieu nguyenLieu in NguyenLieu)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu.maNL, nguyenLieu.tenNL);
                i++;
            }
        }

        private void LoadDataKho()
        {
            dgvKho.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs;
            if (NhanVien.quyen == 2)
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetAll();
            }
            else
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetList(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            foreach (NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
            {
                dgvKho.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon, nguyenLieu_ChiNhanh.ChiNhanh.maCN);
                i++;
            }
        }
        private void fNguyenLieu_Load(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            dgvNguyenLieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNguyenLieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            function.turnOffButton(btnSuaNL);
            function.turnOffButton(btnXoaNL);
            function.turnOnButton(btnThemNL);
            dgvNguyenLieu.Columns[0].Width = 50;
            dgvNguyenLieu.Columns[1].Width = 140;
            List<Button> btnList = new List<Button>() { btnThemNL, btnSuaNL, btnXoaNL, btnLamMoiNL, btnTimKiemNL };
            foreach (Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            if (NhanVien.quyen == 2)
            {
                cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
                cbChiNhanhLoc.DataSource = dAO_ChiNhanh.GetAll();
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
                cbChiNhanhLoc.ValueMember = "maCN";
                cbChiNhanhLoc.DisplayMember = "tenCN";
            }
            else
            {
                cbChiNhanh.DataSource = dAO_ChiNhanh.GetList(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
                label25.Hide();
                label26.Hide();
                cbChiNhanhLoc.Hide();
                btnLocNL.Hide();
            }
            cbNguyenLieu.DataSource = dAO_NguyenLieu.GetAll();
            cbNguyenLieu.ValueMember = "maNL";
            cbNguyenLieu.DisplayMember = "tenNL";
            function.turnOffButton(btnXoa);
            resetFieldNL();
            resetFieldKho();
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            if (txbTenNL.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dAO_NguyenLieu.isNguyenLieuExist(txbTenNL.Text))
            {
                MessageBox.Show("Nguyên liệu đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NguyenLieu _nguyenLieu = new NguyenLieu();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
            dAO_NguyenLieu.Add(_nguyenLieu);
            resetFieldKho();
            fNguyenLieu_Load(sender, e);
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu _nguyenLieu = new NguyenLieu();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
            dAO_NguyenLieu.Update(_nguyenLieu);
            resetFieldNL();
            MessageBox.Show("Sửa thành công!");
        }

        private void btnLamMoiNL_Click(object sender, EventArgs e)
        {
            resetFieldNL();
            function.turnOnButton(btnThemNL);
            function.turnOffButton(btnSuaNL);
            function.turnOffButton(btnXoaNL);
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            var result = MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dAO_NguyenLieu.Delete(txbMaNL.Text);
                resetFieldNL();
            }
            else
            {
                resetFieldNL();
            }
            function.turnOffButton(btnSuaNL);
            function.turnOffButton(btnXoaNL);
            function.turnOnButton(btnThemNL);
        }

        private void btnLocNL_Click(object sender, EventArgs e)
        {
            dgvKho.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanhLoc.SelectedValue.ToString());
            List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetList(chiNhanh.maCN);
            foreach (NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
            {
                dgvKho.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon, nguyenLieu_ChiNhanh.ChiNhanh.maCN);
                i++;
            }
        }

        private void btnTimKiemNL_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemNL.Text;
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            List<NguyenLieu> NguyenLieus = dAO_NguyenLieu.GetListByName(_keyWord);
            
            foreach (NguyenLieu nguyenLieu in NguyenLieus)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu.maNL, nguyenLieu.tenNL);
                i++;
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldNL();
                function.turnOnButton(btnThemNL);
                function.turnOffButton(btnSuaNL);
                function.turnOffButton(btnXoaNL);
            }
            else
            {
                DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
                DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
                NguyenLieu _nguyenLieu = dAO_NguyenLieu.GetByID(dgvNguyenLieu.CurrentRow.Cells[1].Value.ToString());
                txbMaNL.Text = _nguyenLieu.maNL;
                txbTenNL.Text = _nguyenLieu.tenNL;
                function.turnOffButton(btnThemNL);
                function.turnOnButton(btnSuaNL);
                function.turnOnButton(btnXoaNL);
            }
        }
        private void resetFieldNL()
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            LoadDataNL();
            txbMaNL.Text = "NL" + dAO_NguyenLieu.AutoId();
            txbTenNL.Text = "";
            txbTimKiemNL.Text = "";
        }
        private void resetFieldKho()
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            nmrupSoLuongTon.Value = 0;
            LoadDataKho();
        }

        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void cbChiNhanh_MouseClick(object sender, MouseEventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }
        private void cbChiNhanhLoc_MouseClick(object sender, MouseEventArgs e)
        {
            cbChiNhanhLoc.DroppedDown = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (nmrupSoLuongTon.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            NguyenLieu _nguyenLieu = dAO_NguyenLieu.GetByID(cbNguyenLieu.SelectedValue.ToString());
            NguyenLieu_ChiNhanh _nguyenLieu_ChiNhanh;
            ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
            _nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh(Convert.ToInt32(nmrupSoLuongTon.Value), _nguyenLieu, chiNhanh);
            dAO_NguyenLieu_ChiNhanh.Add(_nguyenLieu_ChiNhanh);
            resetFieldKho();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            dAO_NguyenLieu_ChiNhanh.Delete(dAO_ChiNhanh.GetByID(dgvKho.CurrentRow.Cells[4].Value.ToString()).maCN, dAO_NguyenLieu.GetByID(dgvKho.CurrentRow.Cells[1].Value.ToString()).maNL);
            resetFieldKho();
            MessageBox.Show("Xóa thành công!");
            function.turnOffButton(btnXoa);
            function.turnOnButton(btnThem);
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            
            cbChiNhanh.Text = dAO_ChiNhanh.GetByID(dgvKho.CurrentRow.Cells[4].Value.ToString()).tenCN;
            cbNguyenLieu.Text = dAO_NguyenLieu.GetByID(dgvKho.CurrentRow.Cells[1].Value.ToString()).tenNL;
            nmrupSoLuongTon.Value = Convert.ToInt32(dgvKho.CurrentRow.Cells[3].Value.ToString());
            function.turnOffButton(btnThem);
            function.turnOnButton(btnXoa);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            resetFieldKho();
            function.turnOnButton(btnThem);
            function.turnOffButton(btnXoa);
        }

        private void cbNguyenLieu_MouseClick(object sender, MouseEventArgs e)
        {
            cbNguyenLieu.DroppedDown = true;
        }

        private void cbChiNhanh_MouseClick_1(object sender, MouseEventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }

        private void cbChiNhanhLoc_MouseClick_1(object sender, MouseEventArgs e)
        {
            cbChiNhanhLoc.DroppedDown = true;
        }
    }
}
