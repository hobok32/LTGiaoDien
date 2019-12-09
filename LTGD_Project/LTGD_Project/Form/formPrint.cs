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
    public partial class formPrint : Form
    {

        List<ReportBill> _reportBills;
        string _total;
        public formPrint(List<ReportBill> reportBills, string total)
        {
            InitializeComponent();
           _reportBills = reportBills;
            _total = total;
        }

        private void formPrint_Load(object sender, EventArgs e)
        {
            crystalReport11.SetDataSource(_reportBills);
            crystalReport11.SetParameterValue("total", _total);
            crystalReportViewer1.ReportSource = crystalReport11;
        }
    }
}
