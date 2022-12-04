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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHoaDon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTienHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.btnLocHD = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
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
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt,
            this.maHD,
            this.maNV,
            this.maKH,
            this.NgayMua,
            this.tongTienHD});
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 127);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 82;
            this.dgvHoaDon.RowTemplate.Height = 25;
            this.dgvHoaDon.Size = new System.Drawing.Size(879, 498);
            this.dgvHoaDon.TabIndex = 71;
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
            this.dtpkFromDate.Location = new System.Drawing.Point(184, 68);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(200, 23);
            this.dtpkFromDate.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(127, 72);
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
            this.label3.Location = new System.Drawing.Point(407, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 76;
            this.label3.Text = "Đến Ngày:";
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkToDate.Location = new System.Drawing.Point(469, 68);
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
            this.btnLocHD.Image = ((System.Drawing.Image)(resources.GetObject("btnLocHD.Image")));
            this.btnLocHD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocHD.Location = new System.Drawing.Point(690, 65);
            this.btnLocHD.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLocHD.Name = "btnLocHD";
            this.btnLocHD.Size = new System.Drawing.Size(82, 29);
            this.btnLocHD.TabIndex = 77;
            this.btnLocHD.Text = "Lọc";
            this.btnLocHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocHD.UseVisualStyleBackColor = false;
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(879, 625);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label2;
        private DataGridView dgvHoaDon;
        private DataGridViewTextBoxColumn stt;
        private DataGridViewTextBoxColumn maHD;
        private DataGridViewTextBoxColumn maNV;
        private DataGridViewTextBoxColumn maKH;
        private DataGridViewTextBoxColumn NgayMua;
        private DataGridViewTextBoxColumn tongTienHD;
        private Label label18;
        private DateTimePicker dtpkFromDate;
        private Label label1;
        private Label label3;
        private DateTimePicker dtpkToDate;
        private Button btnLocHD;
    }
}