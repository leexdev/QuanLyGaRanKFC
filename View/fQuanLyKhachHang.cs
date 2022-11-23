﻿using System;
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
        private void maKHTuTang()
        {
            int count = 0;
            count = dgvKhachHang.Rows.Count;
            string chuoi1 = "";
            int chuoi2 = 0;
            if (dgvKhachHang.Rows.Count == 0)
            {
                chuoi1 = "KH000";
            }
            else
            {
                chuoi1 = Convert.ToString(dgvKhachHang.Rows[count - 1].Cells[0].Value);
                chuoi2 = Convert.ToInt32((chuoi1.Remove(0, 2)));
            }
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
            List<KhachHang> list = this.repository.GetAll();
            dgvKhachHang.DataSource = list;
            string maKh = txbMaKH.Text;
            string tenKh = txbTenKH.Text;
            string sdtKh = txbSdtKH.Text;
            KhachHang newKhachHang = new KhachHang(maKh, tenKh, sdtKh);
            if (txbTenKH.Text == "" || txbSdtKH.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Có lỗi xảy ra", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                this.repository.Add(newKhachHang);
                this.LoadData();
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                resetFieldsKH();
                maKHTuTang();
            }
        }

        private void resetFieldsKH()
        {
            txbMaKH.Text = "";
            txbTenKH.Text = "";
            txbSdtKH.Text = "";
            txbTimKiemKH.Text = "";
        }

        private void ucQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            maKHTuTang();
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            List<KhachHang> list = this.repository.GetAll();
            dgvKhachHang.DataSource = list;
            string maKh = txbMaKH.Text;
            string tenKh = txbTenKH.Text;
            string sdtKh = txbSdtKH.Text;
            KhachHang newKhachHang = new KhachHang(maKh, tenKh, sdtKh);
            this.repository.Update(newKhachHang);
            this.LoadData();
            MessageBox.Show("Sửa thành công!", "Thông báo!");
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
            function.turnOnButton(btnThemKH);
            resetFieldsKH();
            maKHTuTang();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.repository.Delete(txbMaKH.Text);
                this.LoadData();
                resetFieldsKH();
                function.turnOffButton(btnSuaKH);
                function.turnOffButton(btnXoaKH);
                function.turnOnButton(btnThemKH);
                maKHTuTang();
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang.Rows.Count == 0)
            {
                txbMaKH.Text = "";
                txbTenKH.Text = "";
                maKHTuTang();
            }
            else
            {
                txbMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txbTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txbSdtKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                function.turnOnButton(btnSuaKH);
                function.turnOnButton(btnXoaKH);
                function.turnOffButton(btnThemKH);
            }
        }

        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            resetFieldsKH();
            maKHTuTang();
            this.LoadData();
            function.turnOnButton(btnThemKH);
            function.turnOffButton(btnSuaKH);
            function.turnOffButton(btnXoaKH);
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (txbTimKiemKH.Text == "")
            {
                LoadData();
            }
            else 
            { 
                dgvKhachHang.DataSource = this.repository.Search(txbTimKiemKH.Text);
            }
        }
    }
}