using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int SelectIdBill(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idxTable='" + id + "'AND statusBill=0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IdBill;
            }
            else
                return -1;
        }

        public void AddBill(int idxTable, string idAccount)
        {
            string strCmd = "INSERT INTO bill VALUES (null, @idAccount , @idxTable , now(), 0, 0);";
            DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idAccount, idxTable });
        }

        public int SelectIdBillLast()
        {
            string strCmd2 = "SELECT idBill FROM bill ORDER BY idBill DESC LIMIT 1;";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(strCmd2);
            }
            catch
            {
                return 1;
            }
        }

        public void ThanhToanBill(int idBill, int discount)
        {
            string strCmd = "update bill set statusBill = 1, discount = " + discount + " where idBill = " + idBill;
            DataProvider.Instance.ExecuteNonQuery(strCmd);
        }
    }
}
