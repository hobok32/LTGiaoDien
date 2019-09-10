using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTGD_Week01_Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void add_Click(object sender, EventArgs e)
        {
            int result = 0;
            int isFalse = 0;
            string num1 = textBox1.Text;
            string num2 = textBox2.Text;

            foreach (Char c in num1)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox1, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            foreach (Char c in num2)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox2, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            if (isFalse == 0)
            {
                errorProvider1.Clear();
                result = int.Parse(num1) + int.Parse(num2);
                textBox3.Text = result.ToString();
            }
        }

        private void tru_Click(object sender, EventArgs e)
        {
            int result = 0;
            int isFalse = 0;
            string num1 = textBox1.Text;
            string num2 = textBox2.Text;

            foreach (Char c in num1)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox1, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            foreach (Char c in num2)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox2, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            if (isFalse == 0)
            {
                errorProvider1.Clear();
                result = int.Parse(num1) - int.Parse(num2);
                textBox3.Text = result.ToString();
            }
        }

        private void nhan_Click(object sender, EventArgs e)
        {
            int result = 0;
            int isFalse = 0;
            string num1 = textBox1.Text;
            string num2 = textBox2.Text;

            foreach (Char c in num1)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox1, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            foreach (Char c in num2)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox2, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            if (isFalse == 0)
            {
                errorProvider1.Clear();
                result = int.Parse(num1) * int.Parse(num2);
                textBox3.Text = result.ToString();
            }
        }

        private void chia_Click(object sender, EventArgs e)
        {
            int result = 0;
            int isFalse = 0;
            string num1 = textBox1.Text;
            string num2 = textBox2.Text;

            foreach (Char c in num1)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox1, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            foreach (Char c in num2)
            {
                if (!Char.IsDigit(c))
                {
                    errorProvider1.SetError(textBox2, "sai rui hihi!");
                    isFalse = 1;
                }
            }

            if (isFalse == 0)
            {
                errorProvider1.Clear();
                result = int.Parse(num1) / int.Parse(num2);
                textBox3.Text = result.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chon = comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (chon == "Cộng")
            {
                this.add_Click(sender, e);
            }
            else if (chon == "Trừ")
            {
                this.tru_Click(sender, e);
            }
            else if (chon == "Nhân")
            {
                this.nhan_Click(sender, e);
            }
            else
            {
                this.chia_Click(sender, e);
            }
        }
    }
}
