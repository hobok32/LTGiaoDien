using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void regular_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void text_Click(object sender, EventArgs e)
        {
        }

        private void bold_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void italic_CheckedChanged(object sender, EventArgs e)
        {
               
        }

        private void boldanditalic_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void regular_Click(object sender, EventArgs e)
        {
            text.Font = new Font(text.Font, FontStyle.Regular);
            bold.Checked = false;
            italic.Checked = false;
            boldanditalic.Checked = false;
        }

        private void bold_Click(object sender, EventArgs e)
        {
            text.Font = new Font(text.Font, FontStyle.Bold);
            regular.Checked = false;
            italic.Checked = false;
            boldanditalic.Checked = false;
        }

        private void italic_Click(object sender, EventArgs e)
        {
            text.Font = new Font(text.Font, FontStyle.Italic);
            regular.Checked = false;
            bold.Checked = false;
            boldanditalic.Checked = false;
        }

        private void boldanditalic_Click(object sender, EventArgs e)
        {
            text.Font = new Font(text.Font, FontStyle.Bold | FontStyle.Italic);
            regular.Checked = false;
            bold.Checked = false;
            italic.Checked = false;
        }

        private void auto_Click(object sender, EventArgs e)
        {
            text.ForeColor = Color.Black;
            red.Checked = false;
            green.Checked = false;
            blue.Checked = false;
        }

        private void red_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void red_Click(object sender, EventArgs e)
        {
            text.ForeColor = Color.Red;
            green.Checked = false;
            auto.Checked = false;
            blue.Checked = false;
        }

        private void green_Click(object sender, EventArgs e)
        {
            text.ForeColor = Color.Green;
            red.Checked = false;
            auto.Checked = false;
            blue.Checked = false;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            text.ForeColor = Color.Blue;
            red.Checked = false;
            auto.Checked = false;
            green.Checked = false;
        }

        private void left_Click(object sender, EventArgs e)
        {
            text.TextAlign = ContentAlignment.MiddleLeft;
            right.Checked = false;
            center.Checked = false;
        }

        private void right_Click(object sender, EventArgs e)
        {
            text.TextAlign = ContentAlignment.MiddleRight;
            left.Checked = false;
            center.Checked = false;
        }

        private void center_Click(object sender, EventArgs e)
        {
            text.TextAlign = ContentAlignment.MiddleCenter;
            left.Checked = false;
            right.Checked = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            text.Font = new Font(text.Font.FontFamily, (float)numericUpDown1.Value, text.Font.Style);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
