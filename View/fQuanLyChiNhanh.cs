using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using QuanLyGaRanKFC.DAO;
using QuanLyGaRanKFC.Model;

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class ucChiNhanh : Form
    {
        ChiNhanh ChiNhanh = new ChiNhanh();
        Functions function = new Functions();
        public ucChiNhanh()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvent();
        }
        private void AssociateAndRaiseViewEvent()
        {
            txbTimKiemCN.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimKiemCN_Click(s, e);
                }
            };
        }
        public void LoadData()
        {
            dgvChiNhanh.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            List<ChiNhanh> ChiNhanh = dAO_ChiNhanh.GetAll();
            foreach (ChiNhanh chiNhanh in ChiNhanh)
            {
                dgvChiNhanh.Rows.Add(i, chiNhanh.maCN, chiNhanh.tenCN, chiNhanh.diaChi);
                i++;
            }
        }
        private void btnThemCN_Click_1(object sender, EventArgs e)
        {
            if (txbTenCN.Text == "" || txbDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                ChiNhanh.maCN = txbMaCN.Text;
                ChiNhanh.tenCN = txbTenCN.Text;
                ChiNhanh.diaChi = txbDiaChi.Text;
                dAO_ChiNhanh.Add(ChiNhanh);
                resetFieldCN();
                MessageBox.Show("Thêm thành công!");
            }
        }
        private void resetFieldCN()
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            LoadData();
            if (dgvChiNhanh.Rows.Count == 0)
            {
                txbMaCN.Text = "CN1";
            }
            else if (dgvChiNhanh.Rows.Count > 0)
            {
                txbMaCN.Text = function.CreateID(dAO_ChiNhanh.GetLast().maCN);
            }
            txbTenCN.Text = "";
            txbDiaChi.Text = "";
            txbTimKiemCN.Text = "";
        }
        private void btnSuaCN_Click(object sender, EventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            ChiNhanh.maCN = txbMaCN.Text;
            ChiNhanh.tenCN = txbTenCN.Text;
            ChiNhanh.diaChi = txbDiaChi.Text;
            dAO_ChiNhanh.Update(ChiNhanh);
            resetFieldCN();
            MessageBox.Show("Sửa thành công!");
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
            function.turnOnButton(btnThemCN);
        }
        private void btnTimKiemCN_Click(object sender, EventArgs e)
        {
            string _keyWord = txbTimKiemCN.Text;
            dgvChiNhanh.Rows.Clear();
            int i = 1;
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            List<ChiNhanh> ChiNhanh = dAO_ChiNhanh.GetByName(_keyWord);
            foreach (ChiNhanh chiNhanh in ChiNhanh)
            {
                dgvChiNhanh.Rows.Add(i, chiNhanh.maCN, chiNhanh.tenCN, chiNhanh.diaChi);
                i++;
            }
        }
        private void ucChiNhanh_Load(object sender, EventArgs e)
        {
            dgvChiNhanh.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiNhanh.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiNhanh.Columns[0].Width = 50;
            dgvChiNhanh.Columns[1].Width = 120;
            List<Button> btnList = new List<Button>() { btnThemCN, btnSuaCN, btnXoaCN, btnLamMoiCN, btnTimKiemCN};
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            foreach(Button button in btnList)
            {
                button.FlatAppearance.BorderSize = 0;
            }
            LoadData();
            if (dgvChiNhanh.Rows.Count == 0)
            {
                txbMaCN.Text = "CN1";
            }
            else if (dgvChiNhanh.Rows.Count > 0)
            {
                txbMaCN.Text = function.CreateID(dAO_ChiNhanh.GetLast().maCN);
            }
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
        }
        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn xóa chi nhánh này?", "Xác nhận xóa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                dAO_ChiNhanh.Delete(txbMaCN.Text);
                resetFieldCN();
            }
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
            function.turnOnButton(btnThemCN);
        }
        private void btnLamMoiCN_Click(object sender, EventArgs e)
        {
            resetFieldCN();
            function.turnOnButton(btnThemCN);
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
        }
        private void dtgvChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void ucChiNhanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                txbTenCN.Text = "";
                txbDiaChi.Text = "";
                function.turnOnButton(btnThemCN);
                function.turnOffButton(btnSuaCN);
                function.turnOffButton(btnXoaCN);
            }
            else
            {
                DataGridViewRow row = dgvChiNhanh.Rows[e.RowIndex];
                DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
                ChiNhanh _chiNhanh = dAO_ChiNhanh.GetByID(row.Cells[1].Value.ToString());
                txbMaCN.Text = _chiNhanh.maCN;
                txbTenCN.Text = _chiNhanh.tenCN;
                txbDiaChi.Text = _chiNhanh.diaChi;
                function.turnOffButton(btnThemCN);
                function.turnOnButton(btnSuaCN);
                function.turnOnButton(btnXoaCN);
            }
        }
    }
}
