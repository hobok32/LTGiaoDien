using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LTGD_Project.DAO
{
    class DetailBillDAO
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        private static DetailBillDAO instance;
        public static DetailBillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetailBillDAO();
                return DetailBillDAO.instance;
            }
            private set { DetailBillDAO.instance = value; }
        }
        private DetailBillDAO() { }

        public List<DetailBill> SelectDetailBill(int idBill)
        {
            List<DetailBill> details = new List<DetailBill>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM detailbill WHERE idBill ='" + idBill + "'");

            foreach (DataRow item in data.Rows)
            {
                DetailBill detail = new DetailBill(item);
                details.Add(detail);
            }

            return details;
        }

        public int SelectIdDetailBillLast()
        {
            string strCmd2 = "SELECT idDetailBill FROM detailbill ORDER BY idDetailBill DESC LIMIT 1;";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(strCmd2);
            }
            catch
            {
                return 1;
            }
        }

        public bool CheckIsProductExist(int idProduct, int idBill)
        {
            string strCmd = "select idProduct from detailbill where idProduct = " + idProduct + " and idBill = " + idBill + " limit 1;";
            int id = 0;
            try
            {
                id = (int)DataProvider.Instance.ExecuteScalar(strCmd);
            }
            catch
            {
                id = 0;
            }
            if (id != 0)
                return true;
            else
                return false;
        }

        public List<DetailBillTopping> SelectDetailBillByIdBill(int idBill)
        {
            int temp = 0;
            int tempIdProduct = 0;
            int i = 0;
            List<DetailBillTopping> detailBills = new List<DetailBillTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "select * from detailbill where idBill = '" + idBill + "' order by idBill, idProduct asc;";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetailBillTopping detailBill = new DetailBillTopping();
                detailBill.IdDetailBill = (int)dr["idDetailBill"];
                detailBill.IdProduct = (int)dr["idProduct"];
                detailBill.IdBill = idBill;
                if (tempIdProduct != (int)dr["idProduct"])
                {
                    temp = (int)dr["idDetailBill"];
                    detailBill.IdProduct = (int)dr["idProduct"];
                    tempIdProduct = (int)dr["idProduct"];
                    detailBill.Quantity = (int)dr["quantity"];
                    detailBill.Price = (int)dr["price"];
                    ToppingDetail topping = new ToppingDetail
                    {
                        IdProduct = dr.IsDBNull(dr.GetOrdinal("idTopping")) ? 0 : (int)dr["idTopping"],
                        PriceProduct = dr.IsDBNull(dr.GetOrdinal("priceTopping")) ? 0 : (int)dr["priceTopping"]
                    };
                    detailBill.Topping.Add(topping);
                    i = 0;
                    detailBills.Add(detailBill);
                }
                else
                {
                    int unique = 0;
                    unique = dr.IsDBNull(dr.GetOrdinal("uniqueDetailBill")) ? 0 : (int)dr["uniqueDetailBill"];
                    if (temp == unique)
                    {
                        i++;
                        ToppingDetail topping = new ToppingDetail
                        {
                            IdProduct = dr.IsDBNull(dr.GetOrdinal("idTopping")) ? 0 : (int)dr["idTopping"],
                            PriceProduct = dr.IsDBNull(dr.GetOrdinal("priceTopping")) ? 0 : (int)dr["priceTopping"]
                        };
                        detailBills[i - 1].Topping.Add(topping);
                    }
                    else
                    {
                        temp = (int)dr["idDetailBill"];
                        detailBill.IdProduct = (int)dr["idProduct"];
                        tempIdProduct = (int)dr["idProduct"];
                        detailBill.Quantity = (int)dr["quantity"];
                        detailBill.Price = (int)dr["price"];
                        ToppingDetail topping = new ToppingDetail
                        {
                            IdProduct = dr.IsDBNull(dr.GetOrdinal("idTopping")) ? 0 : (int)dr["idTopping"],
                            PriceProduct = dr.IsDBNull(dr.GetOrdinal("priceTopping")) ? 0 : (int)dr["priceTopping"]
                        };
                        detailBill.Topping.Add(topping);
                        i = 0;
                        detailBills.Add(detailBill);
                    }
                }
            }
            con.Close();
            return detailBills;
        }

        public List<int> Sort(List<int> list)
        {
            int tmp = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = i + 1; j < list.Count(); j++)
                {
                    if (list[i] < list[j])
                    {
                        //cach trao doi gia tri
                        tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                }
            }
            return list;
        }

        public bool CheckIsToppingListEqual(List<int> topping1, List<int> topping2)
        {
            for(int i = 0; i < topping1.Count(); i++)
            {
                if (topping1[i] != topping2[i])
                    return false;
            }
            return true;
        }

        public int CheckIsToppingEqual(List<Topping> toppings, int idProduct, int price, int idBill)
        {
            //Có price, idProduct -> lấy được idDetailBill của sản phẩm trùng giá + trùng size -> lấy số phần tử (s)
            List<int> idDetailBills = DetailToppingDAO.Instance.SelectIdDetailBillTrungSize(price, idProduct, idBill);
            List<int> checkTopping = new List<int>();
            List<int> topping = new List<int>();
            for (int z = 0; z < toppings.Count; z++)
            {
                topping.Add(toppings[z].IdProduct);
            }
            //Có idDetailBill -> Kiểm tra trong bảng detailtopping -> list[{idDetailBills}](s)
            for (int i = 0; i < idDetailBills.Count(); i++)
            {
                List<DetailTopping> detailToppings = DetailToppingDAO.Instance.SelectListDetailToppingById(idDetailBills[i]);
                if (detailToppings.Count == toppings.Count())
                {
                    for (int j = 0; j < detailToppings.Count(); j++)
                        checkTopping.Add(detailToppings[j].IdTopping);
                    List<int> newCheckTopping = Sort(checkTopping);
                    List<int> newTopping = Sort(topping);
                    if (CheckIsToppingListEqual(newCheckTopping, newTopping) == true)
                    {
                        return idDetailBills[i];
                    }
                }
            }
            return 0;
            //Check toppings.Count == list[i].idDetailBills.Count()
            //true -> sort 2 mảng -> check các phần tử trùng nhau -> kết quả
        }

        public List<int> SelectIdTopping(List<Topping> toppings, int idProduct, int price, int idBill)
        {
            List<DetailBillTopping> detailBillToppings = SelectDetailBillByIdBill(idBill);
            List<int> topping1 = new List<int>();
            List<int> topping2 = new List<int>();
            List<int> toppingFalse = new List<int>();
            for (int i = 0; i < detailBillToppings.Count(); i++)
            {
                if (detailBillToppings[i].IdProduct == idProduct)
                {
                    if (detailBillToppings[i].Topping.Count() == toppings.Count())
                    {
                        for (int j = 0; j < toppings.Count(); j++)
                        {
                            topping1.Add(detailBillToppings[i].Topping[j].IdProduct);
                            topping2.Add(toppings[j].IdProduct);
                        }
                        List<int> newTopping1 = Sort(topping1);
                        List<int> newTopping2 = Sort(topping2);
                        if(CheckIsToppingListEqual(topping1, topping2) == true)
                        {
                            return topping1;
                        }
                    }
                }
            }
            return toppingFalse;
        }

        public bool CheckIsPriceEqual(int idProduct, int price, int idBill)
        {
            string strCmd = "select price from detailbill where idProduct = " + idProduct + " and price = " + price + " and idBill = " + idBill + " limit 1;";
            int priceCheck = 0;
            try
            {
                priceCheck = (int)DataProvider.Instance.ExecuteScalar(strCmd);
            }
            catch
            {
                priceCheck = 0;
            }
            if (priceCheck != 0)
                return true;
            else
                return false;
        }

        public void AddDetailBill(int idBill, int idProduct, int quantity, int price, List<Topping> toppings, int quantityTopping)
        {
            string strCmd = "INSERT INTO detailbill VALUES (null, @idBill , @idProduct , @quantity , @price );";
            string strCmdTopping = "INSERT INTO detailtopping VALUES (null, @idDetailBill , @idTopping , @quantityTopping , @priceTopping );";
            DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idBill, idProduct, quantity, price });
            int idDetailBill = SelectIdDetailBillLast();
            
            for(int i = 0; i < toppings.Count(); i++)
            {
                DataProvider.Instance.ExecuteNonQuery(strCmdTopping, new object[] { idDetailBill, toppings[i].IdProduct, quantityTopping, toppings[i].PriceProduct });
            }
        }

        public List<int> SelectIdDetailBill(List<int> toppings, int idProduct, int price, int idBill)
        {
            List<DetailUpdateBill> details = new List<DetailUpdateBill>();
            List<int> idDetailBill = new List<int>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            if (toppings.Count() == 0)
            {
                string strCmd = "select * from detailbill where idProduct= @idProduct and price = @price and idBill = @idBill;";

                MySqlCommand cmd = new MySqlCommand(strCmd, con);
                cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
                cmd.Parameters.Add(new MySqlParameter("@price", price));
                cmd.Parameters.Add(new MySqlParameter("@idBill", idBill));
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idDetailBill.Add((int)dr["idDeTailBill"]);
                }
                con.Close();
                return idDetailBill;
            }
            else
            {
                string strCmd = "select * from detailbill where idProduct= @idProduct and price = @price and idBill = @idBill and idTopping in ({0})";

                string[] paramNames = toppings.Select((s, i) => "@tag" + i.ToString()).ToArray();

                string inClause = string.Join(",", paramNames);
                using (var cmd = new MySqlCommand(string.Format(strCmd, inClause), con))
                {
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paramNames[i], toppings[i]);
                    }
                    cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
                    cmd.Parameters.Add(new MySqlParameter("@price", price));
                    cmd.Parameters.Add(new MySqlParameter("@idBill", idBill));
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DetailUpdateBill detail = new DetailUpdateBill();
                        detail.IdDeTailBill = (int)dr["idDeTailBill"];
                        detail.IdBill = (int)dr["idBill"];
                        detail.IdProduct = (int)dr["idProduct"];
                        detail.Quantity = (int)dr["quantity"];
                        detail.Price = (int)dr["price"];
                        detail.IdTopping = (int)dr["idTopping"];
                        detail.UniqueDetailBill = (dr.IsDBNull(dr.GetOrdinal("uniqueDetailBill"))) ? 0 : (int?)dr["uniqueDetailBill"];
                        details.Add(detail);
                    }
                    con.Close();
                }
                if (toppings.Count > 1)
                {
                    for (int i = 0; i < details.Count(); i++)
                    {
                        for (int j = i + 1; j < details.Count(); j++)
                        {
                            if (j == details.Count())
                                break;
                            if (details[i].UniqueDetailBill == 0 && details[j].UniqueDetailBill == details[i].IdDeTailBill)
                            {
                                idDetailBill.Add(details[i].IdDeTailBill);
                                idDetailBill.Add(details[j].IdDeTailBill);
                            }
                            else if (details[j].UniqueDetailBill == details[i].IdDeTailBill)
                                idDetailBill.Add(details[j].IdDeTailBill);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < details.Count(); i++)
                    {
                        if (details[i].UniqueDetailBill == 9999)
                            idDetailBill.Add(details[i].IdDeTailBill);
                    }
                }
                return idDetailBill;
            }
        }

        public void UpdateQuantityDetailBill(int quantity,int idDetailBill, int quantityTopping)
        {
            DataProvider.Instance.ExecuteNonQuery("update detailbill set quantity = quantity +" + quantity + " where idDetailBill = " + idDetailBill);
            DataProvider.Instance.ExecuteNonQuery("update detailtopping set quantityTopping = quantityTopping + " + quantityTopping + " where idDetailBill = " + idDetailBill);
        }
    }
}
