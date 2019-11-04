using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dki.Enabled = false;
            nhapMoi.Enabled = false;
            tongKet.Enabled = false;
        }

        List<KhachHang> kh = new List<KhachHang>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 1 || numericUpDown2.Value == 3 || numericUpDown2.Value == 5 || numericUpDown2.Value == 7 || numericUpDown2.Value == 8 || numericUpDown2.Value == 10 || numericUpDown2.Value == 12)
            {
                numericUpDown1.Maximum = 31;
            }
            else
                numericUpDown1.Maximum = 30;
            bool check = checkEnable(msKH.Text.ToString(), hoTen.Text.ToString(), numericUpDown1.Value.ToString(),numericUpDown2.Value.ToString(), numericUpDown3.Value.ToString(), diaChi.Text.ToString(), domainUpDown1.Text.ToString());
            if (check)
            {
                    dki.Enabled = true;
                    nhapMoi.Enabled = true;
                    tongKet.Enabled = true;
            }
            else
            {
                dki.Enabled = false;
                nhapMoi.Enabled = false;
                tongKet.Enabled = false;
            }
        }

        private bool checkEnable(string msKH, string hoTen, string ngay, string thang, string nam, string diaChi, string ngheNhiep)
        {
            if (msKH.Count() > 0 && hoTen.Count() > 0 && ngay.Count() > 0 && thang.Count() > 0 && nam.Count() > 0 && diaChi.Count() > 0 && ngheNhiep.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        private void msKH_TextChanged(object sender, EventArgs e)
        {
            bool check = checkEnable(msKH.Text.ToString(), hoTen.Text.ToString(), numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), numericUpDown3.Value.ToString(), diaChi.Text.ToString(), domainUpDown1.Text.ToString());
            if (check)
            {
                    dki.Enabled = true;
                    nhapMoi.Enabled = true;
                    tongKet.Enabled = true;
            }
            else
            {
                dki.Enabled = false;
                nhapMoi.Enabled = false;
                tongKet.Enabled = false;
            }
        }

        public bool haveNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (Char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private void dki_Click(object sender, EventArgs e)
        {
            if (haveNumber(hoTen.Text))
               MessageBox.Show("Họ tên không được chứa số!");
            else
            {
                KhachHang newKH = new KhachHang();
                newKH.MsKH = msKH.Text.ToString();
                newKH.TenKH = hoTen.Text.ToString();
                newKH.NgaySinh = numericUpDown1.Value.ToString() + numericUpDown2.Value.ToString() + numericUpDown3.Value.ToString();
                newKH.DiaChi = diaChi.Text.ToString();
                newKH.NgheNghiep = domainUpDown1.Text.ToString();
                kh.Add(newKH);
                MessageBox.Show(string.Format("Chúc mừng bạn: {0} \n Sinh ngày: {1}/{2}/{3} \n Nghề nghiệp: {4} \n Đã đăng ký thành công khách hàng VIP!!! \n Cảm ơn bạn!!!", hoTen.Text.ToString(), numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString(), numericUpDown3.Value.ToString(), domainUpDown1.Text.ToString(), diaChi.Text.ToString()));
            } 
        }

        private void tongKet_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Đã có {0} thành viên là khách hàng VIP!!!", kh.Count()));
        }

        private void nhapMoi_Click(object sender, EventArgs e)
        {
            msKH.Text = "";
            hoTen.Text = "";
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1900;
            diaChi.Text = "";
            domainUpDown1.Text = "Bác sĩ";
            dki.Enabled = false;
            nhapMoi.Enabled = false;
            tongKet.Enabled = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
