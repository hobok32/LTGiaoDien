using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LTGD_Week01_Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int isEclipse = 0;

        private void borderStyle_Click(object sender, EventArgs e)
        {
            Array array = Enum.GetValues(typeof(FormBorderStyle));
            var rand = new Random();
            FormBorderStyle = (FormBorderStyle) array.GetValue(rand.Next(array.Length));
        }

        private void reSize_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            Size = new Size(rand.Next(300,400), rand.Next(200,300));
        }

        private void Opacity_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            this.Opacity = (double)rand.Next(1,10)/10;
        }

        private void NRF_Click(object sender, EventArgs e)
        {
            GraphicsPath a = new GraphicsPath();
            if (isEclipse == 0)
            {
                a.AddEllipse(0, 0, 200, 100);
                this.Region = new Region(a);
                isEclipse = 1;
            }
            else
            {
                Rectangle b = new Rectangle(0,0,this.Width,this.Height);
                a.AddRectangle(b);
                this.Region = new Region(a);
                isEclipse = 0;
            }
        }
    }
}
