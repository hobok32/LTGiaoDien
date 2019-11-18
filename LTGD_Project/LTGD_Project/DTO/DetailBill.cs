using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class DetailBill
    {
        public int IdDeTailBill { set; get; }
        public int IdBill { set; get; }
        public int IdProduct { set; get; }
        public int Quantity { set; get; }
        public int Price { set; get; }

        public DetailBill(DataRow row)
        {
            this.IdDeTailBill = (int)row["idDeTailBill"];
            this.IdBill = (int)row["idBill"];
            this.IdProduct = (int)row["idProduct"];
            this.Quantity = (int)row["quantity"];
            this.Price = (int)row["price"];
        }
    }
}
