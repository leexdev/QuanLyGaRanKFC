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
    public partial class fThanhToan : Form
    {
        HoaDon HoaDon = new HoaDon();
        List<CTHD> ListChitietHD = new List<CTHD>();
        ChiNhanh ChiNhanh = new ChiNhanh();
        NhanVien NhanVien = new NhanVien();
        DanhMuc DanhMuc = new DanhMuc();
        NguyenLieu_ChiNhanh NguyenLieu_ChiNhanh = new NguyenLieu_ChiNhanh();
        Functions function = new Functions();
        public fThanhToan(HoaDon HoaDon, ChiNhanh ChiNhanh, NhanVien NhanVien, DanhMuc DanhMuc, CTHD cTHD, NguyenLieu_ChiNhanh nguyenLieu_ChiNhanh)
        {
            InitializeComponent();
            this.HoaDon = HoaDon;
            this.ChiNhanh = ChiNhanh;
            this.NhanVien = NhanVien;
            this.DanhMuc = DanhMuc;
            this.NguyenLieu_ChiNhanh = nguyenLieu_ChiNhanh;
            function.turnOffButton(btnLuu);
            function.turnOffButton(btnIn);
        }
        public void LoadData(bool isFromVal = false)
        {
            dgvThanhToan.Rows.Clear();
            int i = 1;
            decimal tongTien = 0;
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            List<CTHD> cTHDs;
            if(!isFromVal)
            {
                cTHDs = dAO_CTHD.GetList(HoaDon.MaHD);
            }
            else
            {
                cTHDs = this.ListChitietHD;
            }
            foreach (CTHD cthd in cTHDs)
            {
                dgvThanhToan.Rows.Add(i, cthd.MonAn.tenMon, cthd.soLuong, cthd.MonAn.donGia, cthd.thanhTien, "Xóa");
                tongTien += cthd.thanhTien;
                i++;
            }
            txbTongTien.Text = tongTien.ToString();
            txbMaHD.Enabled = false;
        }

        private void fThanhToan_Load(object sender, EventArgs e)
        {
            dgvThanhToan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvThanhToan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtpkNgayTaoHD.Format = DateTimePickerFormat.Custom;
            dtpkNgayTaoHD.CustomFormat = "dd/MM/yyyy";
            dtpkNgayTaoHD.ShowUpDown = false;
            dgvThanhToan.Columns[0].Width = 50;
            dgvThanhToan.Columns[1].Width = 250;
            dgvThanhToan.Columns[2].Width = 80;

            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            if (NhanVien.quyen == 2)
            {
                cbChiNhanh.DataSource = dAO_ChiNhanh.GetAll();
                cbChiNhanh.ValueMember = "maCN";
                cbChiNhanh.DisplayMember = "tenCN";
            }
            else
            {
                cbChiNhanh.Text = dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN;
            }
            txbNhanVien.Enabled = false;
            txbTenKH.Enabled = false;
            KhachHang khachHang = dAO_KhachHang.GetByPhone(txbSdtKH.Text);
            txbTenKH.Text = khachHang.tenKH;
            txbNhanVien.Text = NhanVien.tenNV;
            cbDanhMuc.DataSource = dAO_DanhMuc.GetAll();
            cbDanhMuc.ValueMember = "maDM";
            cbDanhMuc.DisplayMember = "tenDM";
            resetFieldHD();
        }
        private void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void txbSdtKH_TextChanged(object sender, EventArgs e)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            KhachHang khachHang = dAO_KhachHang.GetByPhone(txbSdtKH.Text);
            txbTenKH.Text = khachHang.tenKH;
        }

        private void cbDanhMuc_TextChanged(object sender, EventArgs e)
        {
            DAO_DanhMuc dAO_DanhMuc = new DAO_DanhMuc();
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            DanhMuc danhMuc = dAO_DanhMuc.GetByID(cbDanhMuc.SelectedValue.ToString());
            cbMonAn.DataSource = dAO_MonAn.GetList(danhMuc.maDM);
            cbMonAn.ValueMember = "maMon";
            cbMonAn.DisplayMember = "tenMon";
            nmrupSoLuong.Value = 1;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            DAO_MonAn dAO_MonAn = new DAO_MonAn();
            MonAn monAn = dAO_MonAn.GetByID(cbMonAn.SelectedValue.ToString());
            CTHD cTHD = new CTHD(Convert.ToInt32(nmrupSoLuong.Value), monAn);
            this.ListChitietHD.Add(cTHD);
            function.turnOnButton(btnLuu);
            function.turnOnButton(btnIn);
            LoadData(true);
        }
        private void resetFieldHD()
        {
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            txbMaHD.Text = "HD" + dAO_HoaDon.AutoId();
            nmrupSoLuong.Value = 1;
            txbSdtKH.Text = "";
            txbTongTien.Text = "";
            dgvThanhToan.Rows.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txbSdtKH.Text.Length > 0 && txbTenKH.Text == "")
            {
                MessageBox.Show("Khách Hàng không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbSdtKH.Text = "";
                return;
            }
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_HoaDon dAO_HoaDon = new DAO_HoaDon();
            DAO_CTHD dAO_CTHD = new DAO_CTHD();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            HoaDon.MaHD = txbMaHD.Text;
            HoaDon.ngayTaoHD = dtpkNgayTaoHD.Value;
            HoaDon.khachHang.maKH = dAO_KhachHang.GetByPhone(txbSdtKH.Text).maKH;
            HoaDon.nhanVien.maNV = NhanVien.maNV;
            dAO_HoaDon.Add(HoaDon);
            foreach(CTHD cthd in ListChitietHD)
            {
                dAO_CTHD.Add(cthd, HoaDon.MaHD);
                if (NhanVien.quyen == 2)
                {
                    dAO_CTHD.XoaNguyenLieu(cthd, dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString()).maCN);
                }
                else
                {
                    dAO_CTHD.XoaNguyenLieu(cthd, dAO_ChiNhanh.GetByUserID(NhanVien.maNV).maCN);
                }
            }
            MessageBox.Show("Lưu thành công!");
            resetFieldHD();
            ListChitietHD.Clear();
            function.turnOffButton(btnLuu);
            function.turnOffButton(btnIn);
        }

        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {

            }
            else if (e.ColumnIndex == dgvThanhToan.Columns["_xoa"].Index)
            {
                DAO_MonAn dAO_MonAn = new DAO_MonAn();
                this.ListChitietHD.RemoveAt(e.RowIndex);
                LoadData(true);
            }
            if (dgvThanhToan.Rows.Count == 0)
            {
                function.turnOffButton(btnLuu);
                function.turnOffButton(btnIn);
            }
        }

        private void cbDanhMuc_MouseClick(object sender, MouseEventArgs e)
        {
            cbDanhMuc.DroppedDown = true;
        }

        private void cbMonAn_MouseClick(object sender, MouseEventArgs e)
        {
            cbMonAn.DroppedDown = true;
        }

        Bitmap bmp;
        private void btnIn_Click(object sender, EventArgs e)
        {
            int height = dgvThanhToan.Height;
            dgvThanhToan.Height = dgvThanhToan.RowCount * dgvThanhToan.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvThanhToan.Width, dgvThanhToan.Height);
            dgvThanhToan.DrawToBitmap(bmp, new Rectangle(0, 0 , dgvThanhToan.Width - 100, dgvThanhToan.Height));
            dgvThanhToan.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DAO_ChiNhanh dAO_ChiNhanh = new DAO_ChiNhanh();
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            e.Graphics.DrawString("PHIẾU TÍNH TIỀN", new Font("Verdana", 18, FontStyle.Regular), Brushes.Black, new Point(325, 30));
            e.Graphics.DrawString("Cty LD TNHH KFC Việt Nam", new Font("Verdana", 18, FontStyle.Regular), Brushes.Black, new Point(260, 60));
            if( NhanVien.quyen == 2)
            {
                e.Graphics.DrawString(dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString()).tenCN, new Font("Verdana", 16, FontStyle.Regular), Brushes.Black, new Point(330, 90));
            }
            else
            {
                e.Graphics.DrawString(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).tenCN, new Font("Verdana", 16, FontStyle.Regular), Brushes.Black, new Point(330, 90));
            }
            if (NhanVien.quyen == 2)
            {
                if (dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString()).diaChi.Length < 60)
                {
                    e.Graphics.DrawString(dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString()).diaChi, new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(170, 120));
                }
                else
                {
                    e.Graphics.DrawString(dAO_ChiNhanh.GetByID(cbChiNhanh.SelectedValue.ToString()).diaChi, new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(45, 120));
                }
            }
            else
            {
                if (dAO_ChiNhanh.GetByUserID(NhanVien.maNV).diaChi.Length < 60)
                {
                    e.Graphics.DrawString(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).diaChi, new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(170, 120));
                }
                else
                {
                    e.Graphics.DrawString(dAO_ChiNhanh.GetByUserID(NhanVien.maNV).diaChi, new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(45, 120));
                }
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------", new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(45, 140));
            e.Graphics.DrawString("MÃ HĐ: " + txbMaHD.Text, new Font("Verdana", 18, FontStyle.Regular), Brushes.Black, new Point(340, 160));
            e.Graphics.DrawString("----------------------------------------------------------------------------------", new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(45, 190));
            e.Graphics.DrawString("Nhân Viên: " + NhanVien.maNV + " " + NhanVien.tenNV, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, new Point(25, 220));
            if (txbSdtKH.Text == "")
            {
                e.Graphics.DrawString("Khách Hàng: " + dAO_KhachHang.GetByPhone(txbSdtKH.Text).tenKH, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, new Point(25, 235));
            }
            else
            {
                e.Graphics.DrawString("Khách Hàng: " + dAO_KhachHang.GetByPhone(txbSdtKH.Text).maKH + " " + dAO_KhachHang.GetByPhone(txbSdtKH.Text).tenKH, new Font("Verdana", 8, FontStyle.Regular), Brushes.Black, new Point(25, 235));
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------", new Font("Verdana", 14, FontStyle.Regular), Brushes.Black, new Point(45, 245));
            e.Graphics.DrawString("DANH SÁCH MÓN ", new Font("Verdana", 15, FontStyle.Regular), Brushes.Black, new Point(340, 265));
            e.Graphics.DrawImage(bmp, 10, 300);
            e.Graphics.DrawString("TỔNG TIỀN: " + txbTongTien.Text + " VNĐ", new Font("Verdana", 15, FontStyle.Regular), Brushes.Black, new Point(550, 800));

        }

        private void cbChiNhanh_MouseClick(object sender, MouseEventArgs e)
        {
            cbChiNhanh.DroppedDown = true;
        }

        private void cbMonAn_TextChanged(object sender, EventArgs e)
        {
            nmrupSoLuong.Value = 1;
        }
    }
}
