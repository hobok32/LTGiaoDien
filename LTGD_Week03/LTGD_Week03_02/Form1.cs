using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Text == "VN")
                pictureBox1.Load("C:\\Users\\MiAn\\Documents\\GitHub\\LTGiaoDien\\LTGiaoDien\\LTGD_Week03\\LTGD_Week03_02\\Picture\\vn.png");
            if (radio.Text == "USA")
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_02\Picture\usa.png");
            if (radio.Text == "Italian")
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_02\Picture\italian.jpg");
            if (radio.Text=="Philippine")
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_02\Picture\philip.jpg");
        }
    }
}
