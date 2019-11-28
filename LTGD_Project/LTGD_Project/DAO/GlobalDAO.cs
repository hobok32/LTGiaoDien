using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using MySql.Data.MySqlClient;

namespace LTGD_Project.DAO
{
    public class DetailBillTopping
    {
        public int IdDetailBill { set; get; }
        public int IdBill { set; get; }
        public int IdProduct { set; get; }
        public int Quantity { set; get; }
        public int Price { set; get; }
        public List<ToppingDetail> Topping = new List<ToppingDetail>();
    }

    public class ToppingDetail
    {
        public int IdProduct { set; get; }
        public int PriceProduct { set; get; }
    }

    public class GlobalDAO
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        //Lấy Category theo idCat
        public Category SelectCatByIdCat(int idCat)
        {
            Category cat = new Category();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Category WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cat.IdCat = (int)dr["idCat"];
                cat.NameCat = (string)dr["nameCat"];
            }
            con.Close();
            return cat;
        }

        //Lấy Topping bằng idProduct
        public List<Topping> SelectToppingByIdProduct(int idProduct)
        {
            List<Topping> listTop = new List<Topping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT idProduct, nameProduct, priceProduct, imgProduct FROM product where idProduct IN (SELECT b.idTopping FROM product a, producttopping b WHERE a.idProduct = b.idProduct AND a.idProduct = @idProduct )";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Topping top = new Topping();
                top.IdProduct = (int)dr["idProduct"];
                top.NameProduct = (string)dr["nameProduct"];
                top.PriceProduct = (int)dr["priceProduct"];
                top.ImgProduct = (string)dr["imgProduct"];
                listTop.Add(top);
            }
            con.Close();
            if (listTop.Count() > 0)
                return listTop;
            else
            {
                Topping top = new Topping();
                top.IdProduct = 0;
                top.NameProduct = "Không có topping";
                top.PriceProduct = 0;
                top.ImgProduct = "no";
                listTop.Add(top);
                return listTop;
            }
        }


        //Lấy tất cả sản phẩm + topping theo Category
        public List<ProductTopping> SelectAllProductToppingByIdCat(int idCat)
        {
            List<ProductTopping> products = new List<ProductTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductTopping pro = new ProductTopping();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
                pro.rating = (int)dr["rate"];

                List<Topping> top = SelectToppingByIdProduct((int)dr["idProduct"]);
                pro.Topping = top;

                products.Add(pro);

            }
            con.Close();
            return products;
        }
    }
}

