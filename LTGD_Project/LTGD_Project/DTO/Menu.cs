using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class Menu
    {
        public string NameProduct { set; get; }
        public int PriceProduct { set; get; }
        public int Quantity { set; get; }
        public int Total { set; get; }

        public Menu(DataRow row)
        {
            this.NameProduct = (string)row["nameProduct"];
            this.PriceProduct = (int)row["price"];
            this.Quantity = (int)row["quantity"];
            this.Total = (int)(row["price"]) * (int)row["quantity"];
        }
    }
}
