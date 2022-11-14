using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class ucChiNhanh : Form
    {
        Functions function = new Functions();
        ucChiNhanh
        public ucChiNhanh()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucChiNhanh_Load(object sender, EventArgs e)
        {
            txbMaCN.Enabled = false;
            txbTenCN.Enabled = false;
            txbDiaChi.Enabled = false;

            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnLuuCN);
            function.turnOffButton(btnXoaCN);
        }

        private void btnLuuCN_Click(object sender, EventArgs e)
        {
            if (txbMaCN.Text == "" || txbTenCN.Text == "" || txbDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Có lỗi xảy ra", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            function.turnOnButton(btnSuaCN);
            function.turnOnButton(btnXoaCN);
            function.turnOffButton(btnThemCN);
        }

        private void btnXoaCN_Click(object sender, EventArgs e)
        {

        }

        private void dtgvChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemCN_Click_1(object sender, EventArgs e)
        {

            txbMaCN.Enabled = true;
            txbTenCN.Enabled = true;
            txbDiaChi.Enabled = true;

            function.turnOffButton(btnThemCN);
            function.turnOnButton(btnLuuCN);
        }
    }
}
