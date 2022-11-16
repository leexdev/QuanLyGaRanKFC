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

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class ucChiNhanh : Form
    {
        private readonly DAO_ChiNhanh repository;
        Functions function = new Functions();
        public ucChiNhanh()
        {
            InitializeComponent();
            this.repository = new DAO_ChiNhanh();
            this.LoadData();
        }

        private void LoadData()
        {
            List<ChiNhanh> list = this.repository.getAll();

            dgvChiNhanh.DataSource = list;

            dgvChiNhanh.Columns[0].HeaderText = "Mã Chi Nhánh";
            dgvChiNhanh.Columns[1].HeaderText = "Tên Chi Nhánh";
            dgvChiNhanh.Columns[2].HeaderText = "Địa Chỉ";
            dgvChiNhanh.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiNhanh.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiNhanh.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnThemCN_Click_1(object sender, EventArgs e)
        {

            string maCN = txbMaCN.Text;
            string tenCN = txbTenCN.Text;
            string diaChi = txbDiaChi.Text;
            List<NhanVien> nhanViens = new List<NhanVien>();
            List<NguyenLieu> nguyenLieus = new List<NguyenLieu>();

            ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChi, nhanViens, nguyenLieus);
            this.repository.Add(chiNhanh);

            MessageBox.Show("Thêm thành công");

            this.resetFields();

            this.LoadData();
        }

        private void resetFields()
        {
            txbMaCN.Text = "";
            txbTenCN.Text = "";
            txbDiaChi.Text = "";
        }

        private void btnTimKiemCN_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucChiNhanh_Load(object sender, EventArgs e)
        {

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
            txbMaCN.Text = dgvChiNhanh.CurrentRow.Cells[0].Value.ToString();
            txbTenCN.Text = dgvChiNhanh.CurrentRow.Cells[1].Value.ToString();
            txbDiaChi.Text = dgvChiNhanh.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
