using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGaRanKFC.Model
{
    public class MonAn
    {
        public string maMon { get; set; }
        public string tenMon { get; set; }
        public decimal donGia { get; set; }
        public MonAn() { }
        public MonAn(string maMon, string tenMon, decimal donGia)
        {
            this.maMon = maMon;
            this.tenMon = tenMon;
            this.donGia = donGia;
        }
    }
}
