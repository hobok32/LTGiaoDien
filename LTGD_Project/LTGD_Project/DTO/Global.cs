using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_Project.DTO
{
    class Global
    {
    }
    public class ProductTopping
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
        public int rating { set; get; }
        public List<Topping> Topping { set; get; }
    }

    public class CatProductTopping
    {
        public CatProductTopping(List<ProductTopping> product, Category category)
        {
            data = product;
            Category = category;
        }
        public List<ProductTopping> data { set; get; }
        public Category Category { set; get; }
    }
}
