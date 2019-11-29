using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return ProductDAO.instance;
            }
            private set { ProductDAO.instance = value; }
        }
        private ProductDAO() { }

        public List<Product> SelectProductByIdCat(int idCat)
        {
            List<Product> pros = new List<Product>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM product where idCat ="+idCat);
            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                pros.Add(pro);
            }
            return pros;
        }

        public List<Product> SelectAllProduct()
        {
            List<Product> pros = new List<Product>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM product ");
            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                pros.Add(pro);
            }
            return pros;
        }

        public bool AddProduct(int idCat, string name, int? small, int? medium, int? large, int? free, string des, string img)
        {
            if (small == 0)
                small = null;
            else if (medium == 0)
                medium = null;
            else if (large == 0)
                large = null;
            else if (free == 0)
                free = null;
            string strCmd = "INSERT INTO Product VALUES (null, @idCat , @nameProduct , @priceSmallProduct , @priceMediumProduct , @priceLargeProduct , @priceProduct , @descriptionProduct , @imgProduct , 1)";
            return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idCat, name, small, medium, large, free, des, img }) > 0;    
        }
    }
}





