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

            string query = "select a.idProduct, a.nameProduct, b.quantity, b.price, b.iddetailbill, null as idDetailTopping, null as idTopping, null as quantityTopping, null as priceTopping, null as nameTopping from product a, (select * from detailbill where idBill = (select idBill from bill a, tablewinform b where a.idxTable = b.idTable and b.idTable = " + idTable + " and a.statusBill = 0)) b where a.idProduct = b.idProduct; ";

            string queryTopping = "select b.*, a.nameProduct as nameTopping from product a, (select a.idProduct, a.nameProduct, b.quantity, b.price, b.iddetailbill, c.idDetailTopping, c.idTopping, c.quantityTopping, c.priceTopping from product a, (select * from detailbill where idBill = (select idBill from bill a, tablewinform b where a.idxTable = b.idTable and b.idTable = " + idTable + " and a.statusBill = 0)) b, detailtopping c where a.idProduct = b.idProduct and b.idDetailBill = c.idDetailBill) b where a.idProduct = b.idTopping";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            DataTable dataTopping = DataProvider.Instance.ExecuteQuery(queryTopping);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                menus.Add(menu);
            }

            foreach (DataRow item in dataTopping.Rows)
            {
                Menu menu = new Menu(item);
                for (int i = 0; i < menus.Count(); i++)
                {
                    if (menu.IdDetailBill == menus[i].IdDetailBill && menu.IdDetailTopping != menus[i].IdDetailTopping && menus[i].IdDetailTopping == 0)
                    {
                        menus[i].IdDetailTopping = menu.IdDetailTopping;
                        menus[i].IdTopping = menu.IdTopping;
                        menus[i].QuantityTopping = menu.QuantityTopping;
                        menus[i].PriceTopping = menu.PriceTopping;
                        menus[i].NameTopping = menu.NameTopping;
                    }
                    else if (menu.IdDetailBill == menus[i].IdDetailBill && menu.IdDetailTopping != menus[i].IdDetailTopping && menus[i].IdDetailTopping != 0)
                        menus.Add(menu);
                }
            }
            List<Menu> sortMenus = menus.OrderBy(o => o.IdDetailBill).ToList();
            for(int x = 0; x < sortMenus.Count(); x++)
            {
                if (x < sortMenus.Count - 1)
                {
                    if (sortMenus[x].IdDetailBill == sortMenus[x + 1].IdDetailBill && sortMenus[x].IdDetailTopping == sortMenus[x + 1].IdDetailTopping)
                    {
                        sortMenus.RemoveAt(x + 1);
                        x--;
                    }
                }
            }
            return sortMenus;
        }
    }
}
