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
        private readonly DAO_ChiNhanh repository;
        Functions function = new Functions();
        public ucChiNhanh()
        {
            InitializeComponent();
            this.repository = new DAO_ChiNhanh();
            this.LoadData();
        }

        private void maCNTuTang()
        {
            int count = 0;
            count = dgvChiNhanh.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dgvChiNhanh.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
            {
                txbMaCN.Text = "CN00" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txbMaCN.Text = "CN0" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 1000)
            {
                txbMaCN.Text = "CN" + (chuoi2 + 1).ToString();
            }
        }

        public void LoadData()
        {
            List<ChiNhanh> list = this.repository.GetAll();
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
            List<ChiNhanh> listCN = this.repository.GetAll();
            List<NhanVien> listNV = new List<NhanVien>();
            List<NguyenLieu> listNL = new List<NguyenLieu>();
            dgvChiNhanh.DataSource = listCN;
            string maCN = txbMaCN.Text;
            string tenCN = txbTenCN.Text;
            string diaChiCN = txbDiaChi.Text;
            ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChiCN, listNV, listNL);
            if (txbMaCN.Text == "" || txbTenCN.Text == "" || txbDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Có lỗi xảy ra", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                this.repository.Add(chiNhanh);
                this.LoadData();
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                resetFieldsCN();
                maCNTuTang();
            }
        }
        private void resetFieldsCN()
        {
            txbMaCN.Text = "";
            txbTenCN.Text = "";
            txbDiaChi.Text = "";
        }
        private void btnSuaCN_Click(object sender, EventArgs e)
        {
            List<ChiNhanh> list = this.repository.GetAll();
            List<NhanVien> listNV = new List<NhanVien>();
            List<NguyenLieu> listNL = new List<NguyenLieu>();
            dgvChiNhanh.DataSource = list;
            string maCN = txbMaCN.Text;
            string tenCN = txbTenCN.Text;
            string diaChiCN = txbDiaChi.Text;
            ChiNhanh chiNhanh = new ChiNhanh(maCN, tenCN, diaChiCN, listNV, listNL);
            this.repository.Update(chiNhanh);
            this.LoadData();
            MessageBox.Show("Sửa thành công!", "Thông báo!");
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
            function.turnOnButton(btnThemCN);
            resetFieldsCN();
            maCNTuTang();
        }

        private void btnTimKiemCN_Click(object sender, EventArgs e)
        {
            
        }

        private void ucChiNhanh_Load(object sender, EventArgs e)
        {
            maCNTuTang();
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
        }
        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chi nhánh này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.repository.Delete(txbMaCN.Text);
                this.LoadData();
                resetFieldsCN();
                function.turnOffButton(btnSuaCN);
                function.turnOffButton(btnXoaCN);
                function.turnOnButton(btnThemCN);
                maCNTuTang();
            }
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

        private void btnLamMoiCN_Click(object sender, EventArgs e)
        {
            resetFieldsCN();
            maCNTuTang();
            function.turnOnButton(btnThemCN);
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
        }

        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaCN.Text = dgvChiNhanh.CurrentRow.Cells[0].Value.ToString();
            txbTenCN.Text = dgvChiNhanh.CurrentRow.Cells[1].Value.ToString();
            txbDiaChi.Text = dgvChiNhanh.CurrentRow.Cells[2].Value.ToString();
            function.turnOnButton(btnSuaCN);
            function.turnOnButton(btnXoaCN);
            function.turnOffButton(btnThemCN);
        }
    }
}
