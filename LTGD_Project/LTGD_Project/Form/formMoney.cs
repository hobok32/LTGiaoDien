using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using LTGD_Project.DAO;
using System.Globalization;

namespace LTGD_Project
{
    public partial class formMoney : Form
    {
        float total = 0;
        public formMoney()
        {
            InitializeComponent();
            var dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day - 1);
            LoadBillByDate(dateTime.ToString("yyyyMMdd"));
        }
        void LoadBillByDate(string date)
        {
            totalTxt.Text = "";
            total = 0;
            DataTable data = BillDAO.Instance.SelectBillByDate(date);
            dataGridViewBill.DataSource = data;
            foreach (DataRow item in data.Rows)
            {
                total += (float)item["Tổng tiền x1000 đ"];
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            totalTxt.Text = (total * 1000).ToString("c", culture);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime;
            if (dateTimePickerBill.Value.Day == 1 && (dateTimePickerBill.Value.Month - 1 == 4 || dateTimePickerBill.Value.Month - 1 == 6 || dateTimePickerBill.Value.Month - 1 == 9 || dateTimePickerBill.Value.Month - 1 == 11))
            {
                dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 30);
            }
            else if (dateTimePickerBill.Value.Day == 1 && (dateTimePickerBill.Value.Month - 1 == 1 || dateTimePickerBill.Value.Month - 1 == 3 || dateTimePickerBill.Value.Month - 1 == 5 || dateTimePickerBill.Value.Month - 1 == 7 || dateTimePickerBill.Value.Month - 1 == 8 || dateTimePickerBill.Value.Month - 1 == 10 || dateTimePickerBill.Value.Month - 1 == 12))
            {
                dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 31);
            }
            else if (dateTimePickerBill.Value.Day == 1 && dateTimePickerBill.Value.Month - 1 == 2)
            {
                dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month - 1, 28);
            }
            else
            {
                dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day - 1);
            }
            LoadBillByDate(dateTime.ToString("yyyyMMdd"));
        }
    }
}
