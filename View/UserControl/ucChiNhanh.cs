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

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class ucChiNhanh : Form
    {
        Functions function = new Functions();
        private string currentButton;
        private string clickMaCN;
        public ucChiNhanh()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        public string TangMa()
        {
            string sql = "SELECT * FROM ChiNhanh";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "CN001";
            }
            else
            {
                int k;
                ma = "CN";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 3));
                k += 1;
                if (k < 10)
                {
                    ma = ma + "00";
                }
                else if (k < 100)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }

        public void LoadData()
        {
            string sqlSELECT = "SELECT * FROM ChiNhanh";
            SqlCommand cmd = new SqlCommand(sqlSELECT, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvChiNhanh.DataSource = dt;
        }
        private void btnThemCN_Click_1(object sender, EventArgs e)
        {
            txbMaCN.Enabled = true;
            txbTenCN.Enabled = true;
            txbDiaChi.Enabled = true;
            txbMaCN.Text = TangMa();
            function.turnOnButton(btnLuuCN);
            function.turnOffButton(btnThemCN);
            function.turnOffButton(btnSuaCN);
            function.turnOffButton(btnXoaCN);
            this.currentButton = btnThemCN.Name;
        }
        private void btnSuaCN_Click(object sender, EventArgs e)
        {
            txbMaCN.Enabled = true;
            txbTenCN.Enabled = true;
            txbDiaChi.Enabled = true;
            txbMaCN.Text = dgvChiNhanh.CurrentRow.Cells[0].Value.ToString();
            txbTenCN.Text = dgvChiNhanh.CurrentRow.Cells[1].Value.ToString();
            txbDiaChi.Text = dgvChiNhanh.CurrentRow.Cells[2].Value.ToString();
            function.turnOnButton(btnXoaCN);
            function.turnOffButton(btnThemCN);
            function.turnOffButton(btnSuaCN);
            function.turnOnButton(btnLuuCN);
            this.currentButton = btnSuaCN.Name;
        }

        private void btnTimKiemCN_Click(object sender, EventArgs e)
        {
            
        }

        private void ucChiNhanh_Load(object sender, EventArgs e)
        {
            txbMaCN.Enabled = false;
            txbTenCN.Enabled = false;
            txbDiaChi.Enabled = false;

            function.turnOffButton(btnLuuCN);
            string connString = ConfigurationManager.ConnectionStrings["QuanLyGaRanKFC"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            LoadData();
        }

        private void resetFieldCN()
        {
            txbMaCN.Text = "";
            txbTenCN.Text = "";
            txbDiaChi.Text = "";
        }

        private void btnLuuCN_Click(object sender, EventArgs e)
        {
            if(this.currentButton == btnThemCN.Name)
            {
                if (txbTenCN.Text == "" || txbDiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Có lỗi xảy ra", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {
                    string sqlINSERT = "INSERT INTO ChiNhanh VALUES (@MaCN, @TenCN, @DiaChi)";
                    SqlCommand cmd = new SqlCommand(sqlINSERT, conn);
                    cmd.Parameters.AddWithValue("MaCN", txbMaCN.Text);
                    cmd.Parameters.AddWithValue("TenCN", txbTenCN.Text);
                    cmd.Parameters.AddWithValue("DiaChi", txbDiaChi.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    resetFieldCN();
                    function.turnOffButton(btnLuuCN);
                    function.turnOnButton(btnThemCN);
                    function.turnOnButton(btnSuaCN);
                    function.turnOnButton(btnXoaCN);
                    this.currentButton = null;
                }
            }
            else if(this.currentButton == btnSuaCN.Name)
            {
                string sqlEDIT = "UPDATE ChiNhanh SET TenCN = @TenCN, DiaChi = @DiaChi WHERE MaCN = @MaCN";
                SqlCommand cmd = new SqlCommand(sqlEDIT, conn);
                cmd.Parameters.AddWithValue("MaCN", txbMaCN.Text);
                cmd.Parameters.AddWithValue("TenCN", txbTenCN.Text);
                cmd.Parameters.AddWithValue("DiaChi", txbDiaChi.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                resetFieldCN();
                function.turnOffButton(btnLuuCN);
                function.turnOnButton(btnThemCN);
                function.turnOnButton(btnSuaCN);
                function.turnOnButton(btnXoaCN);
                this.currentButton = null;
            }
            
        }
        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM ChiNhanh WHERE MaCN = @MaCN";
            SqlCommand cmd = new SqlCommand(sqlDELETE, conn);
            cmd.Parameters.AddWithValue("MaCN", clickMaCN);
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickMaCN = dgvChiNhanh.CurrentRow.Cells[0].Value.ToString();
        }
        private void dtgvChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void ucChiNhanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
