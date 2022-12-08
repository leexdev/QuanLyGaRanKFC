namespace QuanLyGaRanKFC.View
{
    partial class fHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTienHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._chitiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.btnLocHD = new System.Windows.Forms.Button();
            this.pnCTHD = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvDanhSachMon = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(80)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 60);
            this.panel1.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(345, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "HÓA ĐƠN";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.maHD,
            this.maNV,
            this.maKH,
            this.NgayMua,
            this.tongTienHD,
            this._chitiet});
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 127);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 82;
            this.dgvHoaDon.RowTemplate.Height = 25;
            this.dgvHoaDon.Size = new System.Drawing.Size(879, 239);
            this.dgvHoaDon.TabIndex = 71;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // stt
            // 
            this.stt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 10;
            this.stt.Name = "stt";
            this.stt.ReadOnly = true;
            // 
            // maHD
            // 
            this.maHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maHD.HeaderText = "Mã Hóa Đơn";
            this.maHD.MinimumWidth = 10;
            this.maHD.Name = "maHD";
            this.maHD.ReadOnly = true;
            // 
            // maNV
            // 
            this.maNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maNV.HeaderText = "Mã Nhân Viên";
            this.maNV.Name = "maNV";
            this.maNV.ReadOnly = true;
            // 
            // maKH
            // 
            this.maKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maKH.HeaderText = "Mã KH";
            this.maKH.MinimumWidth = 10;
            this.maKH.Name = "maKH";
            this.maKH.ReadOnly = true;
            // 
            // NgayMua
            // 
            this.NgayMua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayMua.HeaderText = "Ngày Mua";
            this.NgayMua.MinimumWidth = 10;
            this.NgayMua.Name = "NgayMua";
            this.NgayMua.ReadOnly = true;
            // 
            // tongTienHD
            // 
            this.tongTienHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongTienHD.HeaderText = "Tổng Tiền";
            this.tongTienHD.Name = "tongTienHD";
            this.tongTienHD.ReadOnly = true;
            // 
            // _chitiet
            // 
            this._chitiet.HeaderText = "";
            this._chitiet.Name = "_chitiet";
            this._chitiet.ReadOnly = true;
            this._chitiet.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._chitiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(345, 100);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(193, 24);
            this.label18.TabIndex = 72;
            this.label18.Text = "Danh Sách Hóa Đơn";
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkFromDate.Location = new System.Drawing.Point(160, 68);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 23);
            this.dtpkFromDate.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(103, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 74;
            this.label1.Text = "Từ Ngày:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(383, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 76;
            this.label3.Text = "Đến Ngày:";
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkToDate.Location = new System.Drawing.Point(445, 68);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(200, 23);
            this.dtpkToDate.TabIndex = 75;
            // 
            // btnLocHD
            // 
            this.btnLocHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLocHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.btnLocHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocHD.ForeColor = System.Drawing.Color.White;
            this.btnLocHD.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_funnel_16;
            this.btnLocHD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocHD.Location = new System.Drawing.Point(666, 65);
            this.btnLocHD.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLocHD.Name = "btnLocHD";
            this.btnLocHD.Size = new System.Drawing.Size(82, 29);
            this.btnLocHD.TabIndex = 77;
            this.btnLocHD.Text = "Lọc";
            this.btnLocHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocHD.UseVisualStyleBackColor = false;
            this.btnLocHD.Click += new System.EventHandler(this.btnLocHD_Click);
            // 
            // pnCTHD
            // 
            this.pnCTHD.Controls.Add(this.btnThoat);
            this.pnCTHD.Controls.Add(this.dgvDanhSachMon);
            this.pnCTHD.Controls.Add(this.label4);
            this.pnCTHD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCTHD.Location = new System.Drawing.Point(0, 372);
            this.pnCTHD.Name = "pnCTHD";
            this.pnCTHD.Size = new System.Drawing.Size(879, 253);
            this.pnCTHD.TabIndex = 78;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_close_window_16;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(367, 218);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(145, 29);
            this.btnThoat.TabIndex = 79;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDanhSachMon
            // 
            this.dgvDanhSachMon.AllowUserToAddRows = false;
            this.dgvDanhSachMon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachMon.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.tenMon,
            this.soLuong,
            this.donGia,
            this.thanhTien});
            this.dgvDanhSachMon.Location = new System.Drawing.Point(0, 27);
            this.dgvDanhSachMon.Name = "dgvDanhSachMon";
            this.dgvDanhSachMon.RowHeadersVisible = false;
            this.dgvDanhSachMon.RowTemplate.Height = 25;
            this.dgvDanhSachMon.Size = new System.Drawing.Size(879, 187);
            this.dgvDanhSachMon.TabIndex = 74;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // tenMon
            // 
            this.tenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenMon.HeaderText = "Tên Món";
            this.tenMon.Name = "tenMon";
            // 
            // soLuong
            // 
            this.soLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soLuong.HeaderText = "Số Lượng";
            this.soLuong.Name = "soLuong";
            // 
            // donGia
            // 
            this.donGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.donGia.HeaderText = "Đơn Giá";
            this.donGia.Name = "donGia";
            // 
            // thanhTien
            // 
            this.thanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thanhTien.HeaderText = "Thành Tiền";
            this.thanhTien.Name = "thanhTien";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(374, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 73;
            this.label4.Text = "Chi Tiết Hóa Đơn";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(43)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_repeat_16;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.Location = new System.Drawing.Point(752, 65);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(82, 29);
            this.btnLamMoi.TabIndex = 79;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 625);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.pnCTHD);
            this.Controls.Add(this.btnLocHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpkToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpkFromDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.panel1);
            this.Name = "fHoaDon";
            this.Text = "fHoaDon";
            this.Load += new System.EventHandler(this.fHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnCTHD.ResumeLayout(false);
            this.pnCTHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DataGridView dgvHoaDon;
        private Label label18;
        private DateTimePicker dtpkFromDate;
        private Label label1;
        private Label label3;
        private DateTimePicker dtpkToDate;
        private Button btnLocHD;
        private Panel pnCTHD;
        private Label label4;
        private Button btnThoat;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn maHD;
        private DataGridViewTextBoxColumn maNV;
        private DataGridViewTextBoxColumn maKH;
        private DataGridViewTextBoxColumn NgayMua;
        private DataGridViewTextBoxColumn tongTienHD;
        private DataGridViewButtonColumn _chitiet;
        private DataGridView dgvDanhSachMon;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn tenMon;
        private DataGridViewTextBoxColumn soLuong;
        private DataGridViewTextBoxColumn donGia;
        private DataGridViewTextBoxColumn thanhTien;
        private Button btnLamMoi;
    }
}