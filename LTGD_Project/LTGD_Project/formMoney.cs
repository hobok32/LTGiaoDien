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

namespace LTGD_Project
{
    public partial class formMoney : Form
    {
        public formMoney()
        {
            InitializeComponent();
            var dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day - 1);
            LoadBillByDate(dateTime.ToString("yyyyMMdd"));
        }
        void LoadBillByDate(string date)
        {
            dataGridViewBill.DataSource = BillDAO.Instance.SelectBillByDate(date);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            var dateTime = new DateTime(dateTimePickerBill.Value.Year, dateTimePickerBill.Value.Month, dateTimePickerBill.Value.Day - 1);
            LoadBillByDate(dateTime.ToString("yyyyMMdd"));
        }
    }
}
