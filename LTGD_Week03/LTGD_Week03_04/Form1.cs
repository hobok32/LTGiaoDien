using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week03_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_04\cheese.jpg");
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(trackBar1.Value*10, trackBar2.Value*-10);
        }
    }
}
