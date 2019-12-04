using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSingleton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SingleTon singleTon = new SingleTon();//Tạo 1 thực thể mới
            //SingleTon singleTon1 = new SingleTon();//Tạo 1 thực thể mới

            SingleTon.Instance.Demo();//Sử dụng nhưng hàm trong class SingleTon thông qua duy nhất 1 thực thể Instance
            SingleTon.Instance.Demo1();

            //Muốn sử dụng class SingleTon chỉ có thể thông qua 1 thực thể duy nhất: Instance

        }
    }
}
