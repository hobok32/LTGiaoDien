using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class Product
    {
        public int IdProduct { set; get; }
        public int IdCat { set; get; }
        public string NameProduct { set; get; }
        public int? PriceSmallProduct { set; get; }
        public int? PriceMediumProduct { set; get; }
        public int? PriceLargeProduct { set; get; }
        public int? PriceProduct { set; get; }
        public string DescriptionProduct { set; get; }
        public string ImgProduct { set; get; }

        public Product(DataRow row)
        {
            this.IdProduct = (int)row["idProduct"];
            this.IdCat = (int)row["idCat"];
            this.NameProduct = (string)row["nameProduct"];

            var PriceSmallProductTemp = row["priceSmallProduct"];
            if (PriceSmallProduct.ToString() != "")
                this.PriceSmallProduct = (int?)PriceSmallProductTemp;

            var PriceMediumProductTemp = row["priceMediumProduct"];
            if (PriceMediumProductTemp.ToString() != "")
                this.PriceMediumProduct = (int?)PriceMediumProductTemp;

            var PriceLargeProductTemp = row["priceLargeProduct"];
            if (PriceLargeProductTemp.ToString() != "")
                this.PriceLargeProduct = (int?)PriceLargeProductTemp;

            var PriceProductTemp = row["priceProduct"];
            if (PriceProductTemp.ToString() != "")
                this.PriceProduct = (int?)PriceProductTemp;

            this.DescriptionProduct = (string)row["descriptionProduct"];
            this.ImgProduct = (string)row["imgProduct"];
        }
    }
}
