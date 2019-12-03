using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DAO;
using LTGD_Project.DTO;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dapper;

namespace LTGD_Project
{
    public partial class formMoney : Form
    {
        float total = 0;
        public formMoney()
        {
            InitializeComponent();
            //DateTime dateTime1 = ReturnDate1();
            //DateTime dateTime2 = ReturnDate2();
            //LoadBillByDate(dateTime1.ToString("yyyyMMdd"), dateTime2.ToString("yyyyMMdd"));
        }
        void LoadBillByDate(string date, string to)
        {
            totalTxt.Text = "";
            total = 0;
            DataTable data = BillDAO.Instance.SelectBillByDate(date, to);
            dataGridViewBill.DataSource = data;
            foreach (DataRow item in data.Rows)
            {
                total += (float)item["Tổng tiền x1000 đ"];
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            totalTxt.Text = (total * 1000).ToString("c", culture);
        }

        DateTime ReturnDate1()
        {
            DateTime dateTime;
            if (dateTimePickerBill.Value.Day == 1 && (dateTimePickerBill.Value.Month - 1 == 4 || dateTimePickerBill.Value.Month - 1 == 6 || dateTimePickerBill.Value.Month - 1 == 9 || dateTimePickerBill.Value.Month - 1 == 11))
            {
                return dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 30);
            }
            else if (dateTimePickerBill.Value.Day == 1 && (dateTimePickerBill.Value.Month - 1 == 1 || dateTimePickerBill.Value.Month - 1 == 3 || dateTimePickerBill.Value.Month - 1 == 5 || dateTimePickerBill.Value.Month - 1 == 7 || dateTimePickerBill.Value.Month - 1 == 8 || dateTimePickerBill.Value.Month - 1 == 10 || dateTimePickerBill.Value.Month - 1 == 12))
            {
                return dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 31);
            }
            else if (dateTimePickerBill.Value.Day == 1 && dateTimePickerBill.Value.Month - 1 == 2)
            {
                return dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 28);
            }
            else
            {
                return dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day - 1);
            }
        }

        DateTime ReturnDate2()
        {
            DateTime dateTime;
            if (dateTimePicker1.Value.Day == 1 && (dateTimePicker1.Value.Month - 1 == 4 || dateTimePicker1.Value.Month - 1 == 6 || dateTimePicker1.Value.Month - 1 == 9 || dateTimePicker1.Value.Month - 1 == 11))
            {
                return dateTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month - 1, 30);
            }
            else if (dateTimePicker1.Value.Day == 1 && (dateTimePicker1.Value.Month - 1 == 1 || dateTimePicker1.Value.Month - 1 == 3 || dateTimePicker1.Value.Month - 1 == 5 || dateTimePicker1.Value.Month - 1 == 7 || dateTimePicker1.Value.Month - 1 == 8 || dateTimePicker1.Value.Month - 1 == 10 || dateTimePicker1.Value.Month - 1 == 12))
            {
                return dateTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month - 1, 31);
            }
            else if (dateTimePicker1.Value.Day == 1 && dateTimePicker1.Value.Month - 1 == 2)
            {
                return dateTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month - 1, 28);
            }
            else
            {
                return dateTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day - 1);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //DateTime dateTime1 = ReturnDate1();
            //DateTime dateTime2 = ReturnDate2();
            //LoadBillByDate(dateTime1.ToString("yyyyMMdd"), dateTime2.ToString("yyyyMMdd"));
            DateTime dateTime1 = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day);
            DateTime dateTime2 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            LoadBillByDate(dateTime1.ToString("yyyyMMdd"), dateTime2.ToString("yyyyMMdd"));
        }

        private void totalTxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            //LoadBillByDate(dateTime1.ToString("yyyyMMdd"), dateTime2.ToString("yyyyMMdd"));
            DateTime dateTime1 = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day);
            DateTime dateTime2 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            //LoadBillByDate(dateTime1.ToString("yyyyMMdd"), dateTime2.ToString("yyyyMMdd"));
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                string query = "select b.idbill as 'IdBill', a.nameTable as 'NameTable', b.idAccount as 'IdAccount', b.discount as 'Discount', b.total as 'Total', b.dateBill as 'DateBill' from tablewinform a, (select * from bill where statusBill = 1 and dateBill >= '" + dateTime1.ToString("yyyyMMdd") + "' and dateBill <= '" + dateTime2.ToString("yyyyMMdd") + "') b where a.idTable = b.idxTable; ";
                List<ReportBill> reportBills = db.Query<ReportBill>(query, commandType: CommandType.Text).ToList();
                using (formPrint f = new formPrint(reportBills, totalTxt.Text))
                {
                    f.ShowDialog();
                }
            }
        }
    }
}
