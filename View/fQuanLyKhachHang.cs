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

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class ucQuanLyKhachHang : Form
    {
        KhachHang KhachHang = new KhachHang();
        Functions function = new Functions();
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
        }

        private void AssociateAndRaiseViewEvent()
        {
            txbTimKiemKH.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiemKH_Click(s, e);
                }
            };
        }
        private void LoadData()
        {
            dgvKhachHang.Rows.Clear();
            int i = 1;
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            List<KhachHang> KhachHang = dAO_KhachHang.GetAll();
            foreach (KhachHang khachHang in KhachHang)
            {
                dgvKhachHang.Rows.Add(i, khachHang.maKH, khachHang.tenKH, khachHang.sdt);
                i++;
            }
        }
        private void ucQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[0].Width = 30;
            dgvKhachHang.Columns[1].Width = 120;
            List<Button> btnList = new List<Button>() { btnThemKH, btnSuaKH, btnXoaKH, btnLamMoiKH, btnTimKiemKH};
            foreach (Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            resetFieldKH();
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
        }
        private void addKhachHang(object sender, EventArgs e)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            if (txbTenKH.Text == "" || txbSdtKH.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dAO_KhachHang.isKhachHangExist(txbSdtKH.Text))
            {
                MessageBox.Show("Khách hàng đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KhachHang.maKH = txbMaKH.Text;
            KhachHang.tenKH = txbTenKH.Text;
            KhachHang.sdt = txbSdtKH.Text;
            dAO_KhachHang.Add(KhachHang);
            resetFieldKH();
            MessageBox.Show("Thêm thành công!");
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            KhachHang khachHang = dAO_KhachHang.GetByID(dgvKhachHang.CurrentRow.Cells[1].Value.ToString());

            if (txbSdtKH.Text == khachHang.sdt)
            {
                KhachHang.maKH = txbMaKH.Text;
                KhachHang.tenKH = txbTenKH.Text;
                KhachHang.sdt = txbSdtKH.Text;
                dAO_KhachHang.Update(KhachHang);
                resetFieldKH();
                MessageBox.Show("Sửa thành công!");
                function.turnOffButton(btnSuaKH);
                function.turnOffButton(btnXoaKH);
                function.turnOnButton(btnThemKH);
            }
            else if (dAO_KhachHang.isKhachHangExist(txbSdtKH.Text))
            {
                MessageBox.Show("Số điện thoại đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KhachHang.maKH = txbMaKH.Text;
                KhachHang.tenKH = txbTenKH.Text;
                KhachHang.sdt = txbSdtKH.Text;
                dAO_KhachHang.Update(KhachHang);
                resetFieldKH();
                MessageBox.Show("Sửa thành công!");
                function.turnOffButton(btnSuaKH);
                function.turnOffButton(btnXoaKH);
                function.turnOnButton(btnThemKH);
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txbMaKH.Text == "KH1")
            {
                MessageBox.Show("Không thể xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
                dAO_KhachHang.Delete(txbMaKH.Text);
                resetFieldKH();
                function.turnOffButton(btnSuaKH);
                function.turnOffButton(btnXoaKH);
                function.turnOnButton(btnThemKH);
            }
        }

        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            resetFieldKH();
            function.turnOnButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
        }
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemKH.Text;
            dgvKhachHang.Rows.Clear();
            int i = 1;
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            List<KhachHang> KhachHang = dAO_KhachHang.GetByName(_keyWord, _keyWord);
            foreach (KhachHang khachHang in KhachHang)
            {
                dgvKhachHang.Rows.Add(i, khachHang.maKH, khachHang.tenKH, khachHang.sdt);
                i++;
            }

        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                resetFieldKH();
                function.turnOnButton(btnThemKH);
                function.turnOffButton(btnSuaKH);
                function.turnOffButton(btnXoaKH);
            }
            else
            {
                DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
                KhachHang khachHang = dAO_KhachHang.GetByID(dgvKhachHang.CurrentRow.Cells[1].Value.ToString());
                txbMaKH.Text = khachHang.maKH;
                txbTenKH.Text = khachHang.tenKH;
                txbSdtKH.Text = khachHang.sdt;
                function.turnOffButton(btnThemKH);
                function.turnOnButton(btnSuaKH);
                function.turnOnButton(btnXoaKH);
            }
        }
        private void resetFieldKH()
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            LoadData();
            txbMaKH.Text = "KH" + dAO_KhachHang.AutoId();
            txbMaKH.Enabled = false;
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
            txbTimKiemKH.Text = "";
        }

        private void txbSdtKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
