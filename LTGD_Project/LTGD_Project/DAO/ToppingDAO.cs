using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using System.Data;

namespace LTGD_Project.DAO
{
    class ToppingDAO
    {
        private static ToppingDAO instance;
        public static ToppingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ToppingDAO();
                return ToppingDAO.instance;
            }
            private set { ToppingDAO.instance = value; }
        }
        private ToppingDAO() { }

        public List<Topping> SelectToppingByIdProduct(int idProduct)
        {
            List<Topping> toppings = new List<Topping>();
            string query = "select * from product where idProduct in (select idTopping from producttopping where idProduct = "+idProduct+")";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Topping topping = new Topping(item);
                toppings.Add(topping);
            }
            return toppings;
        }
    }
}
