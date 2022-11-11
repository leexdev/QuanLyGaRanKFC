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
            function.turnOffButton(btnSuaCN, pbSua);
            function.turnOffButton(btnLuuCN, pbLuu);
            function.turnOffButton(btnXoaCN, pbXoa);
        }

        private void btnThemCN_Click(object sender, EventArgs e)
        {
            txbMaCN.Enabled = true;
            txbTenCN.Enabled = true;
            txbDiaChi.Enabled = true;

            function.turnOffButton(btnThemCN, pbThem);
            function.turnOnButton(btnLuuCN, pbLuu);
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
            function.turnOnButton(btnSuaCN, pbSua);
            function.turnOnButton(btnXoaCN, pbXoa);
            function.turnOffButton(btnThemCN, pbThem);
        }
    }
}
