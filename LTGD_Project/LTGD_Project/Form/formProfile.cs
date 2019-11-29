using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DTO;
using LTGD_Project.DAO;
using System.Net;

namespace LTGD_Project
{
    public partial class formProfile : Form
    {
        Account account;
        public formProfile(string username) : this()
        {
            account = AccountDAO.Instance.SelectAccount(username);
            LoadInfo();
        }

        public formProfile()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadInfo()
        {
            var request = WebRequest.Create(account.ImgAccount.ToString());
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBoxAccount.Image = Bitmap.FromStream(stream);
            }
            usernameTxt.Text = account.IdAccount.ToString();
            nameTxt.Text = account.NameUser.ToString();
            phoneTxt.Text = account.PhoneNum.ToString();
        }
        

        private void changeBtn_Click(object sender, EventArgs e)
        {
            if (pass.Text.Trim() != "" && nameTxt.Text.Trim() != "" && phoneTxt.Text.Trim() != "")
            {
                if (pass.Text != confirmPass.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận hông đúng", "Thông báo");
                }
                else
                {
                    if (MessageBox.Show("Bạn đã chắc chắn muốn đổi mật khẩu chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (AccountDAO.Instance.ChangePass(pass.Text, account.IdAccount.ToString(), nameTxt.Text, phoneTxt.Text))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                            pass.Text = "";
                            confirmPass.Text = "";
                        }
                        else
                            MessageBox.Show("Thất bại", "Thông báo");
                    }
                }
            }
            else
                MessageBox.Show("Xin mời nhập đủ thông tin", "Thông báo");
        }
    }
}
