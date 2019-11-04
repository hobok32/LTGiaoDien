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
    public partial class Form1 : Form
    {

        int time = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 1500)
            {
                timer1.Stop();
                this.Opacity = 0;
                Form2 f = new Form2();
                f.Show();
            }
            else
                progressBar1.PerformStep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
                Form2 f = new Form2();
                f.Show();
        }
    }
}
