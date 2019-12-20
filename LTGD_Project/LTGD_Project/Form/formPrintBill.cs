using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LTGD_Project.DTO;

namespace LTGD_Project
{
    public partial class formPrintBill : Form
    {
        List<PrintBill> _printBills;
        int _idBill;
        string _nameTable;
        DateTime _date;
        string _nameAccount;
        string _total;
        string _totalDiscount;
        int _discount;
        public formPrintBill()
        {
            InitializeComponent();
        }

        public formPrintBill(List<PrintBill> printBills, int idBill, string nameTable, DateTime date, string nameAccount, string total, string totalDiscount, int discount)
        {
            InitializeComponent();
            _printBills = printBills;
            _idBill = idBill;
            _nameTable = nameTable;
            _date = date;
            _nameAccount = nameAccount;
            _total = total;
            _totalDiscount = totalDiscount;
            _discount = discount;
        }

        private void formPrintBill_Load(object sender, EventArgs e)
        {
            crystalReportBill1.SetDataSource(_printBills);
            crystalReportBill1.SetParameterValue("pIdBill", _idBill);
            crystalReportBill1.SetParameterValue("pNameAccount", _nameAccount);
            crystalReportBill1.SetParameterValue("pNameTable", _nameTable);
            crystalReportBill1.SetParameterValue("pDate", _date);
            crystalReportBill1.SetParameterValue("pTotal", _total);
            crystalReportBill1.SetParameterValue("pDiscount", _discount);
            crystalReportBill1.SetParameterValue("pTotalDiscount", _totalDiscount);
            crystalReportViewer.ReportSource = crystalReportBill1;
        }
    }
}
