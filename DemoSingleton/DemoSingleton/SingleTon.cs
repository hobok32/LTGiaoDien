using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSingleton
{
    class SingleTon
    {
        private static volatile SingleTon instance;//Tạo thực thể instance static + tránh đụng độ

        static object key = new object();

        public static SingleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)//Tránh chiếm dụng tài nguyên
                    {
                        instance = new SingleTon();
                    }
                }
                return instance;
            }
            //Chỉ có thể get chứ không được set
        }

        private SingleTon() { } //Ngăn tạo ra thực thể khác ở bất cứ nơi nào

        public void Demo()
        {
            MessageBox.Show("DEMO");
        }
        public void Demo1()
        {
            MessageBox.Show("DEMO");
        }
    }
}
