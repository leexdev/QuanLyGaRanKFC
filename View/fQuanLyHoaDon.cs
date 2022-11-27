using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGaRanKFC.View.UserControl
{
    public partial class fQuanLyHoaDon : Form
    {
        Functions function = new Functions();
        
        public fQuanLyHoaDon()
        {
            InitializeComponent();
        }


        private void ucQuanLyHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {

        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            this.Close();
            fChiTietHoaDon f = new fChiTietHoaDon();
            f.Show();
        }
    }
}
