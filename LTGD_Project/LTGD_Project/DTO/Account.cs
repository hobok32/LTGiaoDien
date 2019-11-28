using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
namespace LTGD_Project.DTO
{
    class Account
    {
        public  string IdAccount { set; get; }
        public string PasswordAccount { set; get; }
        public string NameUser { set; get; }
        public string PhoneNum { set; get; }
        public string Role { set; get; }
        public string ImgAccount { set; get; }

        public Account(DataRow row)
        {
            this.IdAccount = (string)row["idAccount"];
            this.PasswordAccount = (string)row["passwordAccount"];
            this.NameUser = (string)row["nameUser"];
            this.ImgAccount = (string)row["imgAccount"];
            this.PhoneNum = (string)row["phoneNum"];
            this.Role = (string)row["role"];
        }
    }
}
