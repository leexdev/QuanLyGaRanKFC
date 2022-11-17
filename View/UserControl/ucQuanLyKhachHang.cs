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
        private string currentButton;
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
            dgvKhachHang.Columns[2].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhachHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhachHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void addKhachHang(object sender, EventArgs e)
        {
            txbTenKH.Text = "";
            txbSdtKH.Text = "";

            int count = 0;
            count = dgvKhachHang.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            chuoi1 = Convert.ToString(dgvKhachHang.Rows[count - 1].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
            {
                txbMaKH.Text = "KH00" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txbMaKH.Text = "KH0" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 1000)
            {
                txbMaKH.Text = "KH" + (chuoi2 + 1).ToString();
            }
            function.turnOnButton(btnLuu);
            function.turnOffButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
            this.currentButton = btnThemKH.Name;
        }

        private void resetFields()
        {
            txbMaKH.Text = "";
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
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
            string sdtKh = txbSdtKH.Text;
            KhachHang newKhachHang = new KhachHang(maKh, tenKh, sdtKh);
            
            if (this.currentButton == btnThemKH.Name)
            {
                if(txbMaKH.Text == "" || txbTenKH.Text == "" || txbSdtKH.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                }
                else
                {
                    this.repository.Add(newKhachHang);
                    MessageBox.Show("Thêm thành công!", "Thông báo!");
                    this.LoadData();
                    resetFields();
                    function.turnOffButton(btnLuu);
                    function.turnOnButton(btnThemKH);
                    function.turnOnButton(btnSuaKH);
                    function.turnOnButton(btnXoaKH);
                    this.currentButton = null;
                }
            }
            else if(this.currentButton == btnSuaKH.Name)
            {
                this.repository.Update(newKhachHang);
                MessageBox.Show("Sửa thành công!", "Thông báo!");
                this.LoadData();
                resetFields();
                function.turnOffButton(btnLuu);
                function.turnOnButton(btnThemKH);
                function.turnOnButton(btnSuaKH);
                function.turnOnButton(btnXoaKH);
                this.currentButton = null;
            }
            
        }
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            function.turnOffButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOnButton(btnLuu);
            function.turnOffButton(btnXoaKH);
            txbMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txbTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txbSdtKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            this.currentButton = btnSuaKH.Name;
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            List<KhachHang> list = this.repository.GetAll();
            dgvKhachHang.DataSource = list;
            string maKh = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            this.repository.Delete(maKh);
            this.LoadData();
        }
    }
}
