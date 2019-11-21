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

            string query = "SELECT c.uniqueDetailBill as uniqueDetailBill, c.idDetailBill as idDetailBill, a.idProduct, a.nameProduct,c.price, c.quantity, d.idProduct as idTopping,d.nameProduct as nameTopping, d.priceProduct as priceTopping FROM product a, bill b, detailbill c, (select idProduct, nameProduct, priceProduct from product where idProduct in (select c.idTopping from product a, bill b, detailbill c where b.idBill = (select idBill from bill where idxTable = '" + idTable+"' and statusBill = 0) and b.idBill = c.idBill and c.idProduct = a.idProduct)) d WHERE b.idBill = (select idBill from bill where idxTable = '"+idTable+ "' and statusBill = 0) and b.idBill = c.idBill and c.idProduct = a.idProduct and d.idProduct = c.idTopping ORDER BY a.idProduct, c.idDetailBill ASC";

            string queryElse = "SELECT c.uniqueDetailBill as uniqueDetailBill, c.idDetailBill as idDetailBill,a.idProduct, a.nameProduct,c.price, c.quantity, null as idTopping,null as nameTopping, null as priceTopping FROM product a, bill b, detailbill c WHERE b.idBill = (select idBill from bill where idxTable = '" + idTable+"' and statusBill = 0) and b.idBill = c.idBill and c.idProduct = a.idProduct ORDER BY a.idProduct ASC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                menus.Add(menu);
            }

            if (menus.Count > 0)
            {
                int exist = 0;
                DataTable dataElse = DataProvider.Instance.ExecuteQuery(queryElse);
                foreach (DataRow item in dataElse.Rows)
                {
                    Menu menu = new Menu(item);
                    for(int i = 0; i < menus.Count(); i++)
                    {
                        if (menus[i].IdProduct == menu.IdProduct)
                        {
                            exist = 1;
                            break;
                        }
                    }
                    if (exist == 0)
                        menus.Add(menu);
                }
                return menus;
            }
            else
            {
                DataTable dataElse = DataProvider.Instance.ExecuteQuery(queryElse);
                foreach (DataRow item in dataElse.Rows)
                {
                    Menu menu = new Menu(item);
                    menus.Add(menu);
                }
                return menus;
            }
        }
    }
}
