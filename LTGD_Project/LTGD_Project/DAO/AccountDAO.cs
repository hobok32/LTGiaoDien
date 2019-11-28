using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public Account SelectAccount(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where idAccount = '" + username + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool ChangePass(string pass, string username, string name, string phone)
        {
            string strCmd = "update account set passwordAccount = '" + pass + "' , nameUser = '" + name + "' , phoneNum = '" + phone + "' where idAccount = '" + username + "'";
            return DataProvider.Instance.ExecuteNonQuery(strCmd) > 0;
        }
    }
}
