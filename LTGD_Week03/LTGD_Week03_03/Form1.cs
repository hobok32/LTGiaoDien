using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week03_03
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
            if (radio.Text == "Cheese")
            {
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_03\cheese.jpg");
                textBox1.Text = "Recipe 1";
                textBox2.Text = "Ingredient 1";
            }
            if (radio.Text == "Veg Crunchy")
            {
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_03\veg.jpg");
                textBox1.Text = "Recipe 2";
                textBox2.Text = "Ingredient 2";
            }
            if(radio.Text == "Chinese")
            {
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_03\chinese.jpg");
                textBox1.Text = "Recipe 3";
                textBox2.Text = "Ingredient 3";
            }
            if (radio.Text == "Italian")
            {
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_03\italian.jpg");
                textBox1.Text = "Recipe 4";
                textBox2.Text = "Ingredient 4";
            }
            if (radio.Text == "Vegetable")
            {
                pictureBox1.Load(@"C:\Users\MiAn\Documents\GitHub\LTGiaoDien\LTGiaoDien\LTGD_Week03\LTGD_Week03_03\vegetable.jpg");
                textBox1.Text = "Recipe 5";
                textBox2.Text = "Ingredient 5";
            }
        }
    }
}
