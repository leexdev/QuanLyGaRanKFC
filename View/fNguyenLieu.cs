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
        private void LoadData()
        {
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs = new List<NguyenLieu_ChiNhanh>();
            if (NhanVien.quyen == 2)
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetAll();
            }
            else
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetLast(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            foreach (NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon, nguyenLieu_ChiNhanh.ChiNhanh.maCN);
                i++;
            }
        }

        private void fNguyenLieu_Load(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
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
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
                label25.Hide();
                label26.Hide();
                cbChiNhanhLoc.Hide();
                btnLocNL.Hide();
            }
            if (txbTenNL.Text == "")
            {

            }
            resetFieldNL();
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu _nguyenLieu = new NguyenLieu();
            ChiNhanh _chiNhanh = new ChiNhanh();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
           
            NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh(Convert.ToInt32(nmrupSoLuongTon.Value), _nguyenLieu, _chiNhanh);
            if (NhanVien.quyen == 2)
            {
                ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
                if (!dAO_NguyenLieu.isNguyenLieuExist(txbMaNL.Text))
                {
                    dAO_NguyenLieu.Add(_nguyenLieu);
                }
                dAO_NguyenLieu_ChiNhanh.Add(nguyenLieu_ChiNhanh, chiNhanh.maCN);
            }
            else
            {
                if (!dAO_NguyenLieu.isNguyenLieuExist(txbMaNL.Text))
                {
                    dAO_NguyenLieu.Add(_nguyenLieu);
                }
                dAO_NguyenLieu_ChiNhanh.Add(nguyenLieu_ChiNhanh, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            resetFieldNL();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            NguyenLieu _nguyenLieu = new NguyenLieu();
            ChiNhanh _chiNhanh = new ChiNhanh();
            _nguyenLieu.maNL = txbMaNL.Text;
            _nguyenLieu.tenNL = txbTenNL.Text;
            NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh(Convert.ToInt32(nmrupSoLuongTon.Value), _nguyenLieu, _chiNhanh);
            if (NhanVien.quyen == 2)
            {
                ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString());
                dAO_NguyenLieu_ChiNhanh.Update(nguyenLieu_ChiNhanh, chiNhanh.maCN);
            }
            else
            {
                dAO_NguyenLieu_ChiNhanh.Update(nguyenLieu_ChiNhanh, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
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
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            var result = MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dAO_NguyenLieu_ChiNhanh.Delete(dgvNguyenLieu.CurrentRow.Cells[4].Value.ToString(), dgvNguyenLieu.CurrentRow.Cells[1].Value.ToString());
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
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            if (NhanVien.quyen == 2)
            {
                ChiNhanh chiNhanh = dAO_ChiNhanh.GetByID(cbChiNhanhLoc.SelectedValue.ToString());
                List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetLast(chiNhanh.maCN);
                foreach(NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
                {
                    dgvNguyenLieu.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon, nguyenLieu_ChiNhanh.ChiNhanh.maCN);
                    i++;
                }
            }
            else
            {
                List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetLast(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
                foreach (NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
                {
                    dgvNguyenLieu.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon, nguyenLieu_ChiNhanh.ChiNhanh.maCN);
                    i++;
                }
            }
        }

        private void btnTimKiemNL_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemNL.Text;
            dgvNguyenLieu.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
            List<NguyenLieu_ChiNhanh> nguyenLieu_ChiNhanhs;
            if (NhanVien.quyen == 2)
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetListByName(_keyWord);
            }
            else
            {
                nguyenLieu_ChiNhanhs = dAO_NguyenLieu_ChiNhanh.GetListByNameForUser(_keyWord, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
            }
            
            foreach (NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh in nguyenLieu_ChiNhanhs)
            {
                dgvNguyenLieu.Rows.Add(i, nguyenLieu_ChiNhanh.NguyenLieu.maNL, nguyenLieu_ChiNhanh.NguyenLieu.tenNL, nguyenLieu_ChiNhanh.soLuongTon);
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
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
                DAO_NguyenLieu_ChiNhanh dAO_NguyenLieu_ChiNhanh = new DAO_NguyenLieu_ChiNhanh();
                NguyenLieu _nguyenLieu = dAO_NguyenLieu.GetByID(dgvNguyenLieu.CurrentRow.Cells[1].Value.ToString());
                NguyenLieu_ChiNhanh _nguyenLieu_ChiNhanh = dAO_NguyenLieu_ChiNhanh.GetByID(dgvNguyenLieu.CurrentRow.Cells[1].Value.ToString(), dgvNguyenLieu.CurrentRow.Cells[4].Value.ToString());
                cbChiNhanh.Text = _nguyenLieu_ChiNhanh.ChiNhanh.tenCN;
                txbMaNL.Text = _nguyenLieu.maNL;
                txbTenNL.Text = _nguyenLieu.tenNL;
                nmrupSoLuongTon.Value = Convert.ToInt32(dgvNguyenLieu.CurrentRow.Cells[3].Value.ToString());
                function.turnOffButton(btnThemNL);
                function.turnOnButton(btnSuaNL);
                function.turnOnButton(btnXoaNL);
            }
        }
        private void resetFieldNL()
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            LoadData();
            txbMaNL.Text = "";
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

        private void txbMaNL_TextChanged(object sender, EventArgs e)
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu nguyenLieu = dAO_NguyenLieu.GetByID(txbMaNL.Text);
            txbTenNL.Text = nguyenLieu.tenNL;
            if (txbTenNL.Text.Length > 0)
            {
                txbTenNL.Enabled = false;
            }
            if (txbTenNL.Text.Length == 0)
            {
                txbTenNL.Enabled = true;
            }
        }
    }
}
