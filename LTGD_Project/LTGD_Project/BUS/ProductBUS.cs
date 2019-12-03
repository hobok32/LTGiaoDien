using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DAO;

namespace LTGD_Project.BUS
{
    class ProductBUS
    {
        public bool AddProduct(int idCatUpdate, string name, int? priceSmall, int? priceMedium, int? priceLarge, int? price, string description, string img)
        {
            return ProductDAO.Instance.AddProduct(idCatUpdate, name, priceSmall, (int?)priceMedium, (int?)priceLarge, (int?)price, description, img);
        }

        public bool DelProduct(int idProduct)
        {
            return ProductDAO.Instance.DelProduct(idProduct);
        }

        public bool EditProduct(int idCatUpdate, string name, int? priceSmall, int? priceMedium, int? priceLarge, int? price, string description, string img, int idProduct)
        {
            return ProductDAO.Instance.UpdateProduct(idCatUpdate, name, priceSmall, priceMedium, priceLarge, price, description, img, idProduct);
        }
    }
}
