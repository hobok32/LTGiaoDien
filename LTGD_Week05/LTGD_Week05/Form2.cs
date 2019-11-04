using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week05
{
    public partial class Form2 : Form
    {
        int h1 = 0;
        int h2 = 0;
        int m1 = 0;
        int m2 = 0;
        int m = 0;
        int h = 0;
        int pay = 0;
        public Form2()
        {
            InitializeComponent();
            start.Enabled = true;
            end.Enabled = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            timeStart.Text = DateTime.Now.ToString("HH:mm:ss tt");
            h1 = Int32.Parse(DateTime.Now.ToString("HH"));
            m1 = Int32.Parse(DateTime.Now.ToString("mm"));
            end.Enabled = true;
            start.Enabled = false;
        }

        private void end_Click(object sender, EventArgs e)
        {
            timeEnd.Text = DateTime.Now.ToString("HH:mm:ss tt");
            h2 = Int32.Parse(DateTime.Now.ToString("HH"));
            m2= Int32.Parse(DateTime.Now.ToString("mm"));
            h = h2 - h1;
            m = m2 - m1;
            pay = h * 3000 + m * 50;
            MessageBox.Show(String.Format("So gio thue la: {0} gio {1} phut\nSo tien phai tra: {2} dong",h,m,pay));
            timeStart.Text = "";
            timeEnd.Text = "";
            end.Enabled = false;
            start.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (start.Enabled == false)
            {
                string message = "Ban con may dang thue, ban chac chan mun thoat ko?";
                string caption = "Thong bao";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
            else
                this.Close();
        }
    }
}
