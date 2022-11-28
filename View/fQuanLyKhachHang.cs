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
            List<Button> btnList = new List<Button>() { btnThemKH, btnSuaKH, btnXoaKH, btnLamMoiKH, btnTimKiemKH };
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
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
            if (txbTenKH.Text == "" || txbSdtKH.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
                KhachHang.maKH = txbMaKH.Text;
                KhachHang.tenKH = txbTenKH.Text;
                KhachHang.sdt = txbSdtKH.Text;
                dAO_KhachHang.Add(KhachHang);
                resetFieldKH();
                MessageBox.Show("Thêm thành công!");
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
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

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
                dAO_KhachHang.Delete(txbMaKH.Text);
                resetFieldKH();
            }
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
            function.turnOnButton(btnThemKH);
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
            List<KhachHang> KhachHang = dAO_KhachHang.GetByName(_keyWord);
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
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
                KhachHang khachHang = dAO_KhachHang.GetByID(row.Cells[1].Value.ToString());
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
            if (dgvKhachHang.Rows.Count == 0)
            {
                txbMaKH.Text = "KH1";
            }
            else if (dgvKhachHang.Rows.Count > 0)
            {
                txbMaKH.Text = function.CreateID(dAO_KhachHang.GetLast().maKH);
            }
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
            txbTimKiemKH.Text = "";
        }
    }
}
