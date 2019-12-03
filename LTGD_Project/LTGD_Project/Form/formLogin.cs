using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DAO;

namespace LTGD_Project
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text.Trim();
            string password = passTxt.Text.Trim();
            if (Login(username, password))
            {
                formTable f = new formTable(username);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập!");
            }
        }

        bool Login(string username, string password)
        {
            return CoffeeDAO.Instance.Login(username, password);
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn đã chắc chắn muốn thoát chưa?", "Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void registBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text.Trim() != "" && passTxt.Text.Trim() != "")
            {
                try
                {
                    if (MessageBox.Show("Bạn đã chắc chắn đăng ký " + usernameTxt.Text + " chưa?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (CoffeeDAO.Instance.Regist(usernameTxt.Text.Trim(), passTxt.Text.Trim()))
                            MessageBox.Show("Đăng ký thành công", "Thông báo");
                        else
                            MessageBox.Show("Thất bại", "Thông báo");
                    }
                }
                catch
                {
                    MessageBox.Show("Thất bại", "Thông báo");
                }
            }
            else
                MessageBox.Show("Xin mời nhập đủ thông tin", "Thông báo");
        }
    }
}
