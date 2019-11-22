using System;
using System.Collections.Generic;
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
}

