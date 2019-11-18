using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;

using System.Data;

namespace LTGD_Project.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return MenuDAO.instance;
            }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        public List<Menu> SelectMenu(int idTable)
        {
            List<Menu> menus = new List<Menu>();

            string query = "select a.nameProduct, c.price, c.quantity, (c.price*c.quantity) as total from product a, bill b, detailbill c where b.idBill = (select idBill from bill where idxTable = '"+idTable+"' and statusBill = 0) and b.idBill = c.idBill and c.idProduct = a.idProduct";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                menus.Add(menu);
            }

            return menus;
        }
    }
}
