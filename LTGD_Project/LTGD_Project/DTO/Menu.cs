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
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public int PriceProduct { set; get; }
        public int Quantity { set; get; }
        public int? IdTopping { set; get; }
        public string NameTopping { set; get; }
        public int? PriceTopping { set; get; }
        public int Total { set; get; }

        public Menu(DataRow row)
        {
            this.IdProduct = (int)row["idProduct"];
            this.NameProduct = (string)row["nameProduct"];
            this.PriceProduct = (int)row["price"];
            this.Quantity = (int)row["quantity"];

            var IdToppingTemp = row["idTopping"];
            if (IdToppingTemp.ToString() != "")
                this.IdTopping = (int?)IdToppingTemp;
            else
                this.IdTopping = 0;

            var NameToppingTemp = row["nameTopping"];
            if (NameToppingTemp.ToString() != "")
                this.NameTopping = (string)NameToppingTemp;
            else
                this.NameTopping = "Không có Topping";

            var PriceToppingTemp = row["priceTopping"];
            if (PriceToppingTemp.ToString() != "")
                this.PriceTopping = (int?)PriceToppingTemp;
            else
                this.PriceTopping = 0;

            this.Total = ((int)(row["price"]) + (int)this.PriceTopping) * (int)row["quantity"];
        }
    }
}
