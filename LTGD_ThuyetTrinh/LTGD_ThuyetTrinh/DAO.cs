using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace LTGD_ThuyetTrinh
{
    class DAO
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        private static List<ProductLocal> FromDBToLocal(List<Product> pros)
        {
            List<ProductLocal> proslocal = new List<ProductLocal>();
            int i = 0;
            while (i < pros.Count)
            {
                ProductLocal p = new ProductLocal();
                p.IdProduct = pros[i].IdProduct;
                p.NameProduct = pros[i].NameProduct;
                p.DescriptionProduct = (pros[i].IdCat==1) ? "Cà phê": 
                    (pros[i].IdCat == 2) ? "Đá xay" : 
                    (pros[i].IdCat == 3) ? "Trà trái cây" : 
                    (pros[i].IdCat == 4) ? "Sinh tố" : 
                    (pros[i].IdCat == 5) ? "Macchiato" : 
                    (pros[i].IdCat == 6) ? "Khác" : 
                    (pros[i].IdCat == 7) ? "Topping" : "Snack";
                p.ImgProduct = pros[i].imgProduct;
                p.IdCat = pros[i].IdCat;
                proslocal.Add(p);
                i++;
            }
            return proslocal;
        }

        //Lấy tất cả sản phẩm
        public List<ProductLocal> SelectAllProduct()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product pro = new Product();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
                products.Add(pro);
            }
            con.Close();

            List<ProductLocal> proslocal = FromDBToLocal(products);
            return proslocal;
        }

        //Lấy tất cả sản phẩm
        public List<Category> SelectAllCategory()
        {
            List<Category> cats = new List<Category>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Category";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Category cat = new Category();
                cat.IdCat = (int)dr["idCat"];
                cat.NameCat = (string)dr["nameCat"];
                cat.ImgCat = (string)dr["imgCat"];
                cats.Add(cat);
            }
            con.Close();
            return cats;
        }
    }
}
