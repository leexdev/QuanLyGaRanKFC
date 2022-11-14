using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGaRanKFC.View
{
    public class Functions
    {
        public Functions()
        {

        }
        public void turnOffButton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = Color.FromArgb(238, 238, 238);
        }
        public void turnOnButton(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = Color.FromArgb(23, 162, 139);
        }
        public string CreateID(string _lastID)
        {
            string firstSubID = _lastID.Substring(0, _lastID.Length - 5);
            string secondSubID = _lastID.Substring(_lastID.Length - 5);
            int secondSubIdNew = Convert.ToInt32(secondSubID) + 1;
            string newId = firstSubID + Convert.ToString(secondSubIdNew);
            return newId;
        }
        public string GetMD5(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("X2"));
            }
            return strBuilder.ToString();
        }
    }
}
