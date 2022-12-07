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
    public partial class fMonAn : Form
    {
        Functions function = new Functions();
        DanhMuc DanhMuc = new DanhMuc();
        MonAn MonAn = new MonAn();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NguyenLieu NguyenLieu = new NguyenLieu();
        NhanVien NhanVien = new NhanVien();
        public fMonAn(MonAn monAn, DanhMuc danhMuc, NhanVien nhanVien, ChiNhanh chiNhanh)
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
            this.MonAn = monAn;
            this.DanhMuc = danhMuc;
            this.NhanVien = nhanVien;
            this.ChiNhanh = chiNhanh;
        }
        private void AssociateAndRaiseViewEvent()
        {
            txbTimKiemMA.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiemMA_Click(s, e);
                }
            };
            cbDanhMucLoc.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLocMA_Click(s, e);
                }
            };
        }
        private void LoadDataDM()
        {
            dgvDanhMuc.Rows.Clear();
            int i = 1;
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            List<DanhMuc> DanhMuc = dAO_DanhMuc.GetAll();
            foreach (DanhMuc danhMuc in DanhMuc)
            {
                dgvDanhMuc.Rows.Add(i, danhMuc.maDM, danhMuc.tenDM);
                i++;
            }
        }
        private void LoadDataMA()
        {
            dgvMonAn.Rows.Clear();
            int i = 1;
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            List<MonAn> MonAn = dAO_MonAn.GetAll();
            foreach (MonAn monAn in MonAn)
            {
                dgvMonAn.Rows.Add(i, monAn.maMon, monAn.tenMon, monAn.donGia);
                i++;
            }
        }
        private void fMonAn_Load(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            this.tpCongThuc.Hide();
            tcMonAn.TabPages.Remove(tpCongThuc);
            dgvMonAn.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMonAn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            function.turnOffButton(btnSuaMA);
            function.turnOffButton(btnXoaMA);
            function.turnOffButton(btnCongThuc);
            function.turnOffButton(btnSuaDM);
            function.turnOffButton(btnXoaDM);
            dgvMonAn.Columns[0].Width = 50;
            dgvDanhMuc.Columns[0].Width = 50;
            dgvCongThuc.Columns[0].Width = 50;

            List<Button> btnList = new List<Button>() { btnThemMA, btnSuaMA, btnXoaMA, btnLamMoiMA, btnCongThuc, btnTimKiemMA, btnThemDM, btnSuaDM, btnXoaDM, btnLamMoiDM, btnTimKiemMA, btnThemCT, btnThoat};
            foreach (Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            cbDanhMuc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMucLoc.DataSource = dAO_DanhMuc.GetAll();
            cbNguyenLieu.DataSource = dAO_NguyenLieu.GetAll();
            cbNguyenLieu.ValueMember = "maNL";
            cbNguyenLieu.DisplayMember = "tenNL";
            cbDanhMuc.ValueMember = "maDM";
            cbDanhMuc.DisplayMember = "tenDM";
            cbDanhMucLoc.ValueMember = "maDM";
            cbDanhMucLoc.DisplayMember = "tenDM";
            resetFieldMA();
            resetFieldDM();
        }

        private void btnThemMA_Click(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            if (txbTenMA.Text == "" || nmrupDonGia.Text == "") 
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMuc.SelectedValue.ToString());
            MonAn _monAn = new MonAn();
            _monAn.maMon = txbMaMA.Text;
            _monAn.tenMon = txbTenMA.Text;
            _monAn.donGia = nmrupDonGia.Value;
            dAO_MonAn.Add(_monAn, danhMuc.maDM);
            resetFieldMA();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSuaMA_Click(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMuc.SelectedValue.ToString());
            MonAn _monAn = new MonAn();
            _monAn.maMon = txbMaMA.Text;
            _monAn.tenMon = txbTenMA.Text;
            _monAn.donGia = nmrupDonGia.Value;
            dAO_MonAn.Update(_monAn, danhMuc.maDM);
            resetFieldMA();
            MessageBox.Show("Sửa thành công!");
        }

        private void btnXoaMA_Click(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            var result = MessageBox.Show("Bạn có chắc muốn xóa món ăn này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dAO_MonAn.Delete(txbMaMA.Text);
                resetFieldMA();
            }
            else
            {
                resetFieldMA();
                function.turnOffButton(btnSuaMA);
                function.turnOffButton(btnXoaMA);
                function.turnOffButton(btnCongThuc);
                function.turnOnButton(btnThemMA);
            }
        }

        private void btnLamMoiMA_Click(object sender, EventArgs e)
        {
            resetFieldMA();
            function.turnOffButton(btnSuaMA);
            function.turnOffButton(btnXoaMA);
            function.turnOffButton(btnCongThuc);
            function.turnOnButton(btnThemMA);
        }

        private void btnTimKiemMA_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemMA.Text;
            dgvMonAn.Rows.Clear();
            int i = 1;
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            List<MonAn> MonAn = dAO_MonAn.GetListByName(_keyWord);

            foreach (MonAn monAn in MonAn)
            {
                dgvMonAn.Rows.Add(i, monAn.maMon, monAn.tenMon, monAn.donGia);
                i++;
            }
        }
        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldMA();
                function.turnOnButton(btnThemMA);
                function.turnOffButton(btnSuaMA);
                function.turnOffButton(btnXoaMA);
                function.turnOffButton(btnCongThuc);
            }
            else
            {
                DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
                DAO_MonAn dAO_MonAn = new DAO_MonAn();
                MonAn monAn = dAO_MonAn.GetByID(dgvMonAn.CurrentRow.Cells[1].Value.ToString());
                cbDanhMuc.Text = dAO_DanhMuc.GetByUserID(monAn.maMon).tenDM;
                cbDanhMuc.ValueMember = "maDM";
                txbMaMA.Text = monAn.maMon;
                txbTenMA.Text = monAn.tenMon;
                nmrupDonGia.Value = monAn.donGia;
                function.turnOffButton(btnThemMA);
                function.turnOnButton(btnSuaMA);
                function.turnOnButton(btnXoaMA);
                function.turnOnButton(btnCongThuc);
            }
        }
        private void btnLocMA_Click(object sender, EventArgs e)
        {
            dgvMonAn.Rows.Clear();
            int i = 1;
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMucLoc.SelectedValue.ToString());
            List<MonAn> MonAn = dAO_MonAn.GetList(danhMuc.maDM);

            foreach (MonAn monAn in MonAn)
            {
                dgvMonAn.Rows.Add(i, monAn.maMon, monAn.tenMon, monAn.donGia);
                i++;
            }
        }
        private void resetFieldMA()
        {
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            LoadDataMA();
            txbMaMA.Text = "MA" + dAO_MonAn.AutoId();
            txbMaMA.Enabled = false;
            txbTenMA.Text = "";
            nmrupDonGia.Value = 0;
            txbTimKiemMA.Text = "";
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            if (txbTenDM.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
                DanhMuc.maDM = txbMaDM.Text;
                DanhMuc.tenDM = txbTenDM.Text;
                dAO_DanhMuc.Add(DanhMuc);
                resetFieldDM();
                MessageBox.Show("Thêm thành công!");
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DanhMuc.maDM = txbMaDM.Text;
            DanhMuc.tenDM = txbTenDM.Text;
            dAO_DanhMuc.Update(DanhMuc);
            resetFieldDM();
            MessageBox.Show("Sừa thành công!");
            function.turnOffButton(btnSuaDM);
            function.turnOffButton(btnXoaDM);
            function.turnOnButton(btnThemDM);
        }

        private void btnLamMoiDM_Click(object sender, EventArgs e)
        {
            resetFieldDM();
            function.turnOffButton(btnSuaDM);
            function.turnOffButton(btnXoaDM);
            function.turnOnButton(btnThemDM);
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
                dAO_DanhMuc.Delete(txbMaDM.Text);
                resetFieldDM();
                function.turnOffButton(btnSuaDM);
                function.turnOffButton(btnXoaDM);
                function.turnOnButton(btnThemDM);
            }
        }
        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldDM();
                function.turnOffButton(btnSuaDM);
                function.turnOffButton(btnXoaDM);
                function.turnOnButton(btnThemDM);
            }
            else
            {
                DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
                DanhMuc _danhMuc = dAO_DanhMuc.GetByID(dgvDanhMuc.CurrentRow.Cells[1].Value.ToString());
                txbMaDM.Text = _danhMuc.maDM;
                txbTenDM.Text = _danhMuc.tenDM;
                function.turnOffButton(btnThemDM);
                function.turnOnButton(btnSuaDM);
                function.turnOnButton(btnXoaDM);
            }
        }
        private void resetFieldDM()
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            LoadDataDM();
            txbMaDM.Text = "DM" + dAO_DanhMuc.AutoId();
            txbMaDM.Enabled = false;
            txbTenDM.Text = "";
        }
        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }
        private void cbDanhMuc_MouseClick(object sender, MouseEventArgs e)
        {
            cbDanhMuc.DroppedDown = true;
        }
        private void cbDanhMucLoc_MouseClick(object sender, MouseEventArgs e)
        {
            cbDanhMucLoc.DroppedDown = true;
        }

        private void btnCongThuc_Click(object sender, EventArgs e)
        {
            tcMonAn.TabPages.Insert(0, tpCongThuc);
            this.tpCongThuc.Show();
            tcMonAn.SelectedTab = tpCongThuc;
            this.tpMonAn.Hide();
            tcMonAn.TabPages.Remove(tpMonAn);
            this.tpDanhMuc.Hide();
            tcMonAn.TabPages.Remove(tpDanhMuc);
            txbMaMon.Enabled = false;
            txbMaMon.Text = txbMaMA.Text;
            txbTenMon.Enabled = false;
            txbTenMon.Text = txbTenMA.Text;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.tpCongThuc.Hide();
            tcMonAn.TabPages.Remove(tpCongThuc);
            tcMonAn.TabPages.Insert(0, tpMonAn);
            this.tpMonAn.Show();
            tcMonAn.TabPages.Insert(1, tpDanhMuc);
            this.tpDanhMuc.Show();
            tcMonAn.SelectedTab = tpMonAn;
        }
        private void LoadDataCT()
        {
            dgvCongThuc.Rows.Clear();
            int i = 1;
            DAO_CongThuc dAO_CongThuc = new DAO_CongThuc();
            List<CongThuc> congThucs = dAO_CongThuc.GetList(txbMaMA.Text);
            foreach (CongThuc congThuc in congThucs)
            {
                dgvCongThuc.Rows.Add(i, congThuc.nguyenLieu.maNL, congThuc.nguyenLieu.tenNL, congThuc.soLuong, "Xóa");
                i++;
            }
        }
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            DAO_NguyenLieu dAO_NguyenLieu = new DAO_NguyenLieu();
            NguyenLieu nguyenLieu = dAO_NguyenLieu.GetByID(cbNguyenLieu.SelectedValue.ToString());
            CongThuc congThuc = new CongThuc(Convert.ToInt32(nmrupSoLuong.Value), nguyenLieu);
            DAO_CongThuc dAO_CongThuc = new DAO_CongThuc();
            dAO_CongThuc.Add(congThuc, txbMaMon.Text);
            resetFieldCT();
        }
        private void resetFieldCT()
        {
            LoadDataCT();
            nmrupSoLuong.Value = 0;
        }

        private void txbMaMA_TextChanged(object sender, EventArgs e)
        {
            resetFieldCT();
        }

        private void dgvCongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldCT();
                function.turnOnButton(btnThemCT);
            }
            else if (e.ColumnIndex == dgvCongThuc.Columns["_xoa"].Index)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này?","Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DAO_CongThuc dAO_CongThuc = new DAO_CongThuc();
                    dAO_CongThuc.Delete(txbMaMon.Text, dgvCongThuc.CurrentRow.Cells[1].Value.ToString());
                    resetFieldCT();
                }
            }
        }

        private void tcMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            cbDanhMuc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMucLoc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMuc.ValueMember = "maDM";
            cbDanhMuc.DisplayMember = "tenDM";
            cbDanhMucLoc.ValueMember = "maDM";
            cbDanhMucLoc.DisplayMember = "tenDM";
        }

        private void cbNguyenLieu_MouseClick(object sender, MouseEventArgs e)
        {
            cbNguyenLieu.DroppedDown = true;
        }
    }
}
