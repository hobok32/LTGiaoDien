using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_ThuyetTrinh
{
    class Coffee
    {
        
    }
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
        public string imgProduct { set; get; }
    }
    public class ProductLocal
    {
        public int IdProduct { set; get; }
        public int IdCat { set; get; }
        public string NameProduct { set; get; }
        public string DescriptionProduct { set; get; }
        public string ImgProduct { set; get; }
    }
}
