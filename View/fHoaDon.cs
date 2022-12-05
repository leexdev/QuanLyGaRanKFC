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

namespace QuanLyGaRanKFC.View
{
    public partial class fHoaDon : Form
    {
        Functions function = new Functions();
        NhanVien NhanVien = new NhanVien();
        KhachHang KhachHang = new KhachHang();
        public fHoaDon(NhanVien nhanVien, KhachHang khachHang)
        {
            InitializeComponent();
            this.KhachHang = khachHang;
            this.NhanVien = nhanVien;
        }

        private void LoadData()
        {
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            dgvHoaDon.Rows.Clear();
            int i = 1;
            List<HoaDon> hoaDons = dAO_HoaDon.GetAll();
            foreach(HoaDon hoaDon in hoaDons)
            {
                if(hoaDon.khachHang.maKH == "KH1")
                {
                    dgvHoaDon.Rows.Add(i, hoaDon.MaHD, hoaDon.nhanVien.maNV, "", hoaDon.ngayTaoHD, hoaDon.tongTien + "VNĐ");
                    i++;
                }
                else
                {
                    dgvHoaDon.Rows.Add(i, hoaDon.MaHD, hoaDon.nhanVien.maNV, hoaDon.khachHang.maKH, hoaDon.ngayTaoHD, hoaDon.tongTien + "VNĐ");
                    i++;
                }
            }

        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns[0].Width = 50;
            dtpkFromDate.Format = DateTimePickerFormat.Custom;
            dtpkFromDate.CustomFormat = "dd/MM/yyyy";
            dtpkFromDate.ShowUpDown = false;
            dtpkToDate.Format = DateTimePickerFormat.Custom;
            dtpkToDate.CustomFormat = "dd/MM/yyyy";
            dtpkToDate.ShowUpDown = false;
            LoadData();
        }
    }
}
