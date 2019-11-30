using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    class ProductRateDAO
    {
        private static ProductRateDAO instance;
        public static ProductRateDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductRateDAO();
                return ProductRateDAO.instance;
            }
            private set { ProductRateDAO.instance = value; }
        }
        private ProductRateDAO() { }

        public void UpdateRateProduct(List<ProductRate> productRates)
        {
            for(int i = 0; i < productRates.Count(); i++)
            {
                string strCmd = "UPDATE product SET rate = rate + @rate WHERE idProduct = @idProduct ";
                DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { productRates[i].Rate, productRates[i].IdProduct });
            }
        }
    }
}
