using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_Project.DTO
{
    public class ReportBill
    {
        public int IdBill { set; get; }
        public string NameTable { set; get; }
        public string IdAccount { set; get; }
        public int Discount { set; get; }
        public int Total { set; get; }
        public DateTime DateBill { set; get; }
    }
}
