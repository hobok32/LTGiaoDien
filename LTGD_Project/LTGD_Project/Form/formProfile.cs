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
using System.IO;
using System.Drawing.Imaging;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace LTGD_Project
{
    public partial class formProfile : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dHDi653cpD0hHaOOrAwgtlTahn7FC9ZBhYoDjeWV",
            BasePath = "https://cafe-4b7dd.firebaseio.com/"
        };

        IFirebaseClient client;
        Account account;
        string img = "https://www.cohindia.com/wp-content/uploads/2018/06/Worship-Mumbai.jpeg";
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
            if (account.ImgAccount.Substring(0, 4) == "http")
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
            else
            {
                try
                {
                    byte[] b = Convert.FromBase64String(account.ImgAccount.ToString());

                    MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(b, 0, Convert.ToInt32(b.Length));

                    Bitmap bm = new Bitmap(memoryStream, false);
                    memoryStream.Dispose();
                    pictureBoxAccount.Image = bm;
                    usernameTxt.Text = account.IdAccount.ToString();
                    nameTxt.Text = account.NameUser.ToString();
                    phoneTxt.Text = account.PhoneNum.ToString();
                }
                catch
                {
                    usernameTxt.Text = account.IdAccount.ToString();
                    nameTxt.Text = account.NameUser.ToString();
                    phoneTxt.Text = account.PhoneNum.ToString();
                }
            }
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
                    if (MessageBox.Show("Bạn đã chắc chắn muốn thay đổi thông tin chưa?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (AccountDAO.Instance.ChangePass(pass.Text, account.IdAccount.ToString(), nameTxt.Text, phoneTxt.Text, img))
                        {
                            MessageBox.Show("Đổi thông tin thành công", "Thông báo");
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

        private async void pickBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Chọn hình ảnh";
            open.Filter = "Image Files(*.jpg) | *.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image img = new Bitmap(open.FileName);
                pictureBoxAccount.Image = img;
            }
            changeBtn.Enabled = false;
            MemoryStream ms = new MemoryStream();
            pictureBoxAccount.Image.Save(ms, ImageFormat.Jpeg);

            byte[] byteConvert = ms.GetBuffer();

            string output = Convert.ToBase64String(byteConvert);

            var data = new DTO.Image
            {
                Img = output
            };

            SetResponse response = await client.SetTaskAsync("Image/", data);

            DTO.Image result = response.ResultAs<DTO.Image>();
            img = result.Img;
            changeBtn.Enabled = true;
        }

        private void formProfile_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Access to Firebase :3 :3 :3", "Yayyy");
            }
        }
    }
}
