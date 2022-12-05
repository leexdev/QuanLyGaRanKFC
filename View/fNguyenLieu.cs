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
        public fNguyenLieu(NguyenLieu nguyenLieu, ChiNhanh chiNhanh, NhanVien nhanVien)
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
            this.ChiNhanh = chiNhanh;
            this.NguyenLieu = nguyenLieu;
            this.NhanVien = nhanVien;
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
        private void LoadData()
        {
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            List<NguyenLieu> nguyenLieus;
            if (NhanVien.quyen == 2)
            {
                nguyenLieus = dAO_NguyenLieu.GetAll();
            }
            else
            {
                nguyenLieus = dAO_NguyenLieu.GetList(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            foreach (NguyenLieu nguyenLieu in nguyenLieus)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu.maNL, nguyenLieu.tenNL, nguyenLieu.soLuongTon);
                i++;
            }
        }

        private void fNguyenLieu_Load(object sender, EventArgs e)
        {
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
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
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
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
                label25.Hide();
                label26.Hide();
                cbChiNhanhLoc.Hide();
                btnLocNL.Hide();
            }
            resetFieldNL();
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu _nguyenLieu = new NguyenLieu();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
            _nguyenLieu.soLuongTon = Convert.ToInt32(nmrupSoLuongTon.Value);
            if (txbTenNL.Text == "" || txbMaNL.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NhanVien.quyen == 2)
            {
                ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
                dAO_NguyenLieu.Add(_nguyenLieu, chiNhanh.maCN);
            }
            else
            {
                dAO_NguyenLieu.Add(_nguyenLieu, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            resetFieldNL();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu _nguyenLieu = new NguyenLieu();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
            _nguyenLieu.soLuongTon = Convert.ToInt32(nmrupSoLuongTon.Value);
            if (NhanVien.quyen == 2)
            {
                ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
                dAO_NguyenLieu.Update(_nguyenLieu, chiNhanh.maCN);
            }
            else
            {
                dAO_NguyenLieu.Update(_nguyenLieu, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
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
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            if (NhanVien.quyen == 1 && cbChiNhanh.Text != dAO_ChiNhanh.GetByUserID(NguyenLieu.maNL).tenCN)
            {
                MessageBox.Show("Không thể xóa! Nguyên liệu này không thuộc chi nhánh của bạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanhLoc.SelectedValue.ToString());
            List<NguyenLieu> NguyenLieu = dAO_NguyenLieu.GetList(chiNhanh.maCN);
            foreach(NguyenLieu nguyenLieu in NguyenLieu)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu.maNL, nguyenLieu.tenNL, nguyenLieu.soLuongTon);
                i++;
            }
        }

        private void btnTimKiemNL_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemNL.Text;
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            List<NguyenLieu> NguyenLieu = dAO_NguyenLieu.GetListByName(_keyWord);
            foreach (NguyenLieu nguyenLieu in NguyenLieu)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu.maNL, nguyenLieu.tenNL, nguyenLieu.soLuongTon);
                i++;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
                NguyenLieu _nguyenLieu = dAO_NguyenLieu.GetByID(dgvNguyenLieu.CurrentRow.Cells[1].Value.ToString());
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(_nguyenLieu.maNL).tenCN;
                cbChiNhanh.ValueMember = "maCN";
                txbMaNL.Text = _nguyenLieu.maNL;
                txbTenNL.Text = _nguyenLieu.tenNL;
                nmrupSoLuongTon.Value = _nguyenLieu.soLuongTon;
                function.turnOffButton(btnThemNL);
                function.turnOnButton(btnSuaNL);
                function.turnOnButton(btnXoaNL);
            }
        }
        private void resetFieldNL()
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            LoadData();
            txbMaNL.Text = "NL" + dAO_NguyenLieu.AutoId();
            txbMaNL.Enabled = false;
            txbTenNL.Text = "";
            nmrupSoLuongTon.Value = 0;
            txbTimKiemNL.Text = "";
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
    }
}
