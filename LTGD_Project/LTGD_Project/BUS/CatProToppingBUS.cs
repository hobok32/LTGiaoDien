using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DAO;
using LTGD_Project.DTO;

namespace LTGD_Project.BUS
{
    class CatProToppingBUS
    {
        public CatProductTopping SelectCatProductToppingByIdCat(int idCat)
        {
            Category cat = new GlobalDAO().SelectCatByIdCat(idCat);
            List<ProductTopping> products = new GlobalDAO().SelectAllProductToppingByIdCat(idCat);
            CatProductTopping catProduct = new CatProductTopping(products, cat);
            return catProduct;
        }
    }
}
