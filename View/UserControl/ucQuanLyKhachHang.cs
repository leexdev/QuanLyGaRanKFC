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
        private readonly DAO_KhachHang repository;
        Functions function = new Functions();
        public ucQuanLyKhachHang()
        {
            InitializeComponent();
            this.repository = new DAO_KhachHang();
            this.LoadData();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadData()
        {
            List<KhachHang> list = this.repository.GetAll();
            dgvKhachHang.DataSource = list;
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhachHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhachHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhachHang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void addKhachHang(object sender, EventArgs e)
        {
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
            txbDiaChiKH.Text = "";

            int count = 0;
            count = dgvKhachHang.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvKhachHang.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
            if (chuoi2 + 1 < 10)
            {
                txbMaKH.Text = "KH00" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txbMaKH.Text = "KH0" + (chuoi2 + 1).ToString();
            }
            function.turnOnButton(btnLuu);
            function.turnOffButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
        }

        private void resetFields()
        {
            txbMaKH.Text = "";
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
            txbDiaChiKH.Text = "";
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            function.turnOffButton(btnLuu);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<KhachHang> list = this.repository.GetAll();
            dgvKhachHang.DataSource = list;
            string maKh = txbMaKH.Text;
            string tenKh = txbTenKH.Text;
            string diachiKh = txbDiaChiKH.Text;
            string sdtKh = txbSdtKH.Text;
            KhachHang newKhachHang = new KhachHang(maKh, tenKh, diachiKh, sdtKh);
            this.repository.Add(newKhachHang);
            if (this.repository.Update(newKhachHang) == )
            { 

            }

                function.turnOffButton(btnLuu);
                function.turnOnButton(btnThemKH);
                function.turnOnButton(btnSuaKH);
                function.turnOnButton(btnXoaKH);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            function.turnOffButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOnButton(btnLuu);
            function.turnOnButton(btnXoaKH);
            txbMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txbTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txbDiaChiKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txbSdtKH.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {

        }
    }
}
