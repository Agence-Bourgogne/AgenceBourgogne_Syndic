using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScan
{
    public partial class TestReportForm : Form
    {
        public TestReportForm()
        {
            InitializeComponent();
        }

        private void TestReportForm_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "c:\\common_reporting\\TestReport.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
