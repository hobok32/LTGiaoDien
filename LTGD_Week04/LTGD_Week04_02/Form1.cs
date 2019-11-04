using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week04_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        int a = 50;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Location.X >= this.Width - label1.Width || label1.Location.X <= 0)
                a *= -1;

            label1.Location = new Point(label1.Location.X + a, label1.Location.Y);
        }
    }
}
