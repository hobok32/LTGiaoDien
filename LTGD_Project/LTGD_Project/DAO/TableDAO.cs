using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LTGD_Project.DTO;

namespace LTGD_Project.DAO
{
    public class TableDAO
    {
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
    }
}
