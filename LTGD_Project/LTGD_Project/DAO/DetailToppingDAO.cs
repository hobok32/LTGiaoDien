using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    class DetailToppingDAO
    {
        private static DetailToppingDAO instance;
        public static DetailToppingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetailToppingDAO();
                return DetailToppingDAO.instance;
            }
            private set { DetailToppingDAO.instance = value; }
        }
        private DetailToppingDAO() { }

        public List<int> SelectIdDetailBillTrungSize(int price, int idProduct, int idBill)
        {
            List<int> idDetailBills = new List<int>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from detailbill where idProduct = " + idProduct + " and price = " + price + " and idBill = " + idBill);
            foreach (DataRow item in data.Rows)
            {
                DetailBill detailTopping = new DetailBill(item);
                idDetailBills.Add(detailTopping.IdDeTailBill);
            }
            return idDetailBills;
        }

        public List<DetailTopping> SelectListDetailToppingById(int idDetailBill)
        {
            List<DetailTopping> detailToppings = new List<DetailTopping>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from detailtopping where idDetailBill = " + idDetailBill);
            foreach (DataRow item in data.Rows)
            {
                DetailTopping detailTopping = new DetailTopping(item);
                detailToppings.Add(detailTopping);
            }
            return detailToppings;
        }
    }
}
