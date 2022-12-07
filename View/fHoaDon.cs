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

        private void LoadDataHD()
        {
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            dgvHoaDon.Rows.Clear();
            int i = 1;
            List<HoaDon> hoaDons = dAO_HoaDon.GetAll();
            foreach(HoaDon hoaDon in hoaDons)
            {
                if(hoaDon.khachHang.maKH == "KH1")
                {
                    dgvHoaDon.Rows.Add(i, hoaDon.MaHD, hoaDon.nhanVien.maNV, "", hoaDon.ngayTaoHD, hoaDon.tongTien + "VNĐ", "Chi tiết");
                    i++;
                }
                else
                {
                    dgvHoaDon.Rows.Add(i, hoaDon.MaHD, hoaDon.nhanVien.maNV, hoaDon.khachHang.maKH, hoaDon.ngayTaoHD, hoaDon.tongTien + "VNĐ", "Chi tiết");
                    i++;
                }
            }
        }
        private void LoadDataCTHD()
        {
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            dgvDanhSachMon.Rows.Clear();
            int i = 1;
            List<CTHD> cTHDs = dAO_CTHD.GetList(dgvHoaDon.CurrentRow.Cells[1].Value.ToString());
            foreach(CTHD cTHD in cTHDs)
            {
                dgvDanhSachMon.Rows.Add(i, cTHD.MonAn.tenMon, cTHD.soLuong, cTHD.MonAn.donGia, cTHD.thanhTien);
                i++;
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
            pnCTHD.Hide();
            dgvHoaDon.Dock = DockStyle.Bottom;
            dgvHoaDon.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            LoadDataHD();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {

            }
            else if (e.ColumnIndex == dgvHoaDon.Columns["_chitiet"].Index)
            {
                pnCTHD.Show();
                dgvHoaDon.Dock = DockStyle.None;
                LoadDataCTHD();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnCTHD.Hide();
        }

        private void btnLocHD_Click(object sender, EventArgs e)
        {
            dgvHoaDon.Rows.Clear();
            int i = 1;
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();

            List<HoaDon> hoaDons = dAO_HoaDon.GetByDate(dtpkFromDate.Value, dtpkToDate.Value);
            foreach(HoaDon hoaDon in hoaDons)
            {
                dgvHoaDon.Rows.Add(i, hoaDon.MaHD, hoaDon.nhanVien.maNV, hoaDon.khachHang.maKH, hoaDon.ngayTaoHD.ToString(), hoaDon.tongTien, "Chi tiết");
                i++;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            fHoaDon_Load(sender, e);
        }
    }
}
