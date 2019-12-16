using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using MySql.Data.MySqlClient;

namespace LTGD_Project.DAO
{
    class KitchenDAO
    {
        private static KitchenDAO instance;
        public static KitchenDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KitchenDAO();
                return KitchenDAO.instance;
            }
            private set { KitchenDAO.instance = value; }
        }
        private KitchenDAO() { }

        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public KitchenBill SelectKitchenFirebase(int idDetailBill)
        {
            KitchenBill kitchenBill = new KitchenBill();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "select b.nameProduct, if(a.price=b.priceSmallProduct,'S',if(a.price=b.priceMediumProduct,'M',if(a.price=b.priceLargeProduct,'L',if(a.price=b.priceProduct,'F',' ??? ')))) as size, a.quantity from detailbill a, product b where a.idDetailBill = " + idDetailBill + " and a.idProduct = b.idProduct; ";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kitchenBill.NameProduct = (string)dr["nameProduct"];
                kitchenBill.Size = (string)dr["size"];
                kitchenBill.SoLuong = (int)dr["quantity"];
                if (SelectKitchenTopping(idDetailBill) != null)
                    kitchenBill.Topping = SelectKitchenTopping(idDetailBill);
            }
            con.Close();
            return kitchenBill;
        }

        public List<KitchenTopping> SelectKitchenTopping(int idDetailBill)
        {
            List<KitchenTopping> kitchenToppings = new List<KitchenTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "select a.quantityTopping, b.nameProduct from detailtopping a, product b where iddetailbill = " + idDetailBill + " and a.idTopping=b.idproduct;";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KitchenTopping kitchenTopping = new KitchenTopping();
                kitchenTopping.ToppingName = (string)dr["nameProduct"];
                kitchenTopping.SoLuong = (string)dr["quantityTopping"];
                kitchenToppings.Add(kitchenTopping);
            }
            con.Close();
            if (kitchenToppings.Count > 0)
                return kitchenToppings;
            else
                return null;
        }
    }
}
