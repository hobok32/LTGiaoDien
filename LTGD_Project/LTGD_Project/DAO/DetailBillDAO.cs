using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LTGD_Project.DTO;
using System.Data;

namespace LTGD_Project.DAO
{
    class DetailBillDAO
    {
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
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM detailbill WHERE idBill ='"+idBill+"'");

            foreach (DataRow item in data.Rows)
            {
                DetailBill detail = new DetailBill(item);
                details.Add(detail);
            }

            return details;
        }
    }
}
