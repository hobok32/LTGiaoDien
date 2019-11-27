using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace LTGD_Project.DAO
{
    public class TableDAO
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return TableDAO.instance;
            }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tables = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tablewinform");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tables.Add(table);
            }
            return tables;
        }

        public void UpdateStatusTable(int idxTable, string status)
        {
            string strCmd = "update tablewinform set statusTable = @statusTable where idTable = @idTable ";
            DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { status, idxTable });
        }

        public void SwitchTable(int idBillSwitch, List<int> idDetailBillCurrent)
        {
            string strCmd = "update detailbill set idBill = @idBillSwitch where idDetailBill in ({0}) ";
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string[] paramNames = idDetailBillCurrent.Select((s, i) => "@tag" + i.ToString()).ToArray();
            string inClause = string.Join(",", paramNames);
            using (var cmd = new MySqlCommand(string.Format(strCmd, inClause), con))
            {
                for (int i = 0; i < paramNames.Length; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], idDetailBillCurrent[i]);
                }
                cmd.Parameters.Add(new MySqlParameter("@idBillSwitch", idBillSwitch));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
