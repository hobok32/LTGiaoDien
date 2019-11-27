using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class Topping
    {
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public int PriceProduct { set; get; }
        public string ImgProduct { set; get; }

        public Topping(DataRow row)
        {
            this.IdProduct = (int)row["idProduct"];
            this.NameProduct = (string)row["nameProduct"];
            this.PriceProduct = (int)row["priceProduct"];
            this.ImgProduct = (string)row["imgProduct"];
        }
        public Topping() { }
    }
}
