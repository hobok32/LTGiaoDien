using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_Project.DTO
{
    public class PrintBill
    {
        public string NameProduct { set; get; }
        public string Price { set; get; }
        public int Quantity { set; get; }
        public string Topping { set; get; }
        public string Total { set; get; }
        public PrintBill() { }
    }
}