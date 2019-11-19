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
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM product where ");
            foreach (DataRow item in data.Rows)
            {
                Product pro = new Product(item);
                pros.Add(pro);
            }
            return pros;
        }
    }
}





