namespace QuanLyGaRanKFC.View.UserControl
{
    partial class ucChiNhanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChiNhanh));
            this.label14 = new System.Windows.Forms.Label();
            this.btnTimKiemCN = new System.Windows.Forms.Button();
            this.dgvChiNhanh = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoaCN = new System.Windows.Forms.Button();
            this.btnThemCN = new System.Windows.Forms.Button();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTenCN = new System.Windows.Forms.TextBox();
            this.btnLuuCN = new System.Windows.Forms.Button();
            this.btnSuaCN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbMaCN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTimKiemCN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiNhanh)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(498, 285);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(205, 1);
            this.label14.TabIndex = 56;
            // 
            // btnTimKiemCN
            // 
            this.btnTimKiemCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiemCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnTimKiemCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemCN.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemCN.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemCN.Image")));
            this.btnTimKiemCN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemCN.Location = new System.Drawing.Point(707, 260);
            this.btnTimKiemCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnTimKiemCN.Name = "btnTimKiemCN";
            this.btnTimKiemCN.Size = new System.Drawing.Size(106, 27);
            this.btnTimKiemCN.TabIndex = 9;
            this.btnTimKiemCN.Text = "Tìm kiếm";
            this.btnTimKiemCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiemCN.UseVisualStyleBackColor = false;
            this.btnTimKiemCN.Click += new System.EventHandler(this.btnTimKiemCN_Click);
            // 
            // dgvChiNhanh
            // 
            this.dgvChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiNhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiNhanh.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiNhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiNhanh.Location = new System.Drawing.Point(0, 302);
            this.dgvChiNhanh.Name = "dgvChiNhanh";
            this.dgvChiNhanh.RowTemplate.Height = 25;
            this.dgvChiNhanh.Size = new System.Drawing.Size(826, 355);
            this.dgvChiNhanh.TabIndex = 0;
            this.dgvChiNhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvChiNhanh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChiNhanh_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnXoaCN);
            this.panel2.Controls.Add(this.btnThemCN);
            this.panel2.Controls.Add(this.txbDiaChi);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txbTenCN);
            this.panel2.Controls.Add(this.btnLuuCN);
            this.panel2.Controls.Add(this.btnSuaCN);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txbMaCN);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 249);
            this.panel2.TabIndex = 52;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(80)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 63);
            this.panel1.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(312, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "CHI NHÁNH";
            // 
            // btnXoaCN
            // 
            this.btnXoaCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnXoaCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoaCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCN.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXoaCN.ForeColor = System.Drawing.Color.Black;
            this.btnXoaCN.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_trash_16;
            this.btnXoaCN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaCN.Location = new System.Drawing.Point(632, 184);
            this.btnXoaCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXoaCN.Name = "btnXoaCN";
            this.btnXoaCN.Size = new System.Drawing.Size(118, 38);
            this.btnXoaCN.TabIndex = 7;
            this.btnXoaCN.Text = "Xóa";
            this.btnXoaCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaCN.UseVisualStyleBackColor = false;
            this.btnXoaCN.Click += new System.EventHandler(this.btnXoaCN_Click);
            // 
            // btnThemCN
            // 
            this.btnThemCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnThemCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThemCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCN.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThemCN.ForeColor = System.Drawing.Color.Black;
            this.btnThemCN.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_add_new_16;
            this.btnThemCN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemCN.Location = new System.Drawing.Point(81, 185);
            this.btnThemCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThemCN.Name = "btnThemCN";
            this.btnThemCN.Size = new System.Drawing.Size(118, 38);
            this.btnThemCN.TabIndex = 4;
            this.btnThemCN.Text = "Thêm";
            this.btnThemCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemCN.UseVisualStyleBackColor = false;
            this.btnThemCN.Click += new System.EventHandler(this.btnThemCN_Click_1);
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbDiaChi.BackColor = System.Drawing.Color.White;
            this.txbDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txbDiaChi.Location = new System.Drawing.Point(533, 92);
            this.txbDiaChi.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(238, 16);
            this.txbDiaChi.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(441, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(330, 1);
            this.label6.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(441, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 87;
            this.label7.Text = "Địa chỉ";
            // 
            // txbTenCN
            // 
            this.txbTenCN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbTenCN.BackColor = System.Drawing.Color.White;
            this.txbTenCN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTenCN.ForeColor = System.Drawing.Color.Black;
            this.txbTenCN.Location = new System.Drawing.Point(149, 134);
            this.txbTenCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txbTenCN.Name = "txbTenCN";
            this.txbTenCN.Size = new System.Drawing.Size(238, 16);
            this.txbTenCN.TabIndex = 2;
            // 
            // btnLuuCN
            // 
            this.btnLuuCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLuuCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLuuCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCN.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLuuCN.ForeColor = System.Drawing.Color.Black;
            this.btnLuuCN.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_save_as_16;
            this.btnLuuCN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuCN.Location = new System.Drawing.Point(256, 184);
            this.btnLuuCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLuuCN.Name = "btnLuuCN";
            this.btnLuuCN.Size = new System.Drawing.Size(118, 38);
            this.btnLuuCN.TabIndex = 5;
            this.btnLuuCN.Text = "Lưu";
            this.btnLuuCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuCN.UseVisualStyleBackColor = false;
            this.btnLuuCN.Click += new System.EventHandler(this.btnLuuCN_Click);
            // 
            // btnSuaCN
            // 
            this.btnSuaCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSuaCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSuaCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCN.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuaCN.ForeColor = System.Drawing.Color.Black;
            this.btnSuaCN.Image = global::QuanLyGaRanKFC.Properties.Resources.icons8_repair_16;
            this.btnSuaCN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaCN.Location = new System.Drawing.Point(449, 184);
            this.btnSuaCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSuaCN.Name = "btnSuaCN";
            this.btnSuaCN.Size = new System.Drawing.Size(121, 38);
            this.btnSuaCN.TabIndex = 6;
            this.btnSuaCN.Text = "Sửa";
            this.btnSuaCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaCN.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(57, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 1);
            this.label4.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(57, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "Tên chi nhánh";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 1);
            this.label3.TabIndex = 81;
            // 
            // txbMaCN
            // 
            this.txbMaCN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbMaCN.BackColor = System.Drawing.Color.White;
            this.txbMaCN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMaCN.ForeColor = System.Drawing.Color.Black;
            this.txbMaCN.Location = new System.Drawing.Point(149, 92);
            this.txbMaCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txbMaCN.Name = "txbMaCN";
            this.txbMaCN.ReadOnly = true;
            this.txbMaCN.Size = new System.Drawing.Size(238, 16);
            this.txbMaCN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(57, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "Mã chi nhánh";
            // 
            // txbTimKiemCN
            // 
            this.txbTimKiemCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTimKiemCN.BackColor = System.Drawing.Color.White;
            this.txbTimKiemCN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTimKiemCN.ForeColor = System.Drawing.Color.Black;
            this.txbTimKiemCN.Location = new System.Drawing.Point(498, 266);
            this.txbTimKiemCN.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txbTimKiemCN.Name = "txbTimKiemCN";
            this.txbTimKiemCN.Size = new System.Drawing.Size(205, 16);
            this.txbTimKiemCN.TabIndex = 8;
            // 
            // ucChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(825, 658);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnTimKiemCN);
            this.Controls.Add(this.dgvChiNhanh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txbTimKiemCN);
            this.Name = "ucChiNhanh";
            this.Text = "ucChiNhanh";
            this.Load += new System.EventHandler(this.ucChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiNhanh)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label14;
        private Button btnTimKiemCN;
        private DataGridView dgvChiNhanh;
        private Panel panel2;
        private TextBox txbTimKiemCN;
        private Button btnXoaCN;
        private Button btnThemCN;
        private TextBox txbDiaChi;
        private Label label6;
        private Label label7;
        private TextBox txbTenCN;
        private Button btnLuuCN;
        private Button btnSuaCN;
        private Label label4;
        private Label label5;
        private Label label3;
        private TextBox txbMaCN;
        private Label label1;
        private Panel panel1;
        private Label label2;
    }
}