using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LTGD_Project.DAO
{
    class CoffeeDAO
    {
        private static CoffeeDAO instance;

        public static CoffeeDAO Instance
        {
            get { if (instance == null) instance = new CoffeeDAO(); return instance; }
            private set { instance = value; }
        }

        private CoffeeDAO() { }

        public bool Login(string username, string password)
        {
            string query = "SELECT * from Account WHERE idAccount='"+username+"' AND passwordAccount = '"+password+"' AND role='Admin'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count>0;
        }
        public bool Regist(string username, string password)
        {
            string img = "https://www.cohindia.com/wp-content/uploads/2018/06/Worship-Mumbai.jpeg";
            string query = "insert into account values ( @username , @password , 'Hihi', '012345', 'Admin', @img );";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password, img }) > 0;
            
        }
    }
}
