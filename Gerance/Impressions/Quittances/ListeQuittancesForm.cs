using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gerance.Formulaires.Common;
using Microsoft.Reporting.WinForms;
using GeranceData.Controller;
namespace Gerance.Impressions.Quittances
{
    public partial class ListeQuittancesForm : Gerance.Formulaires.Common.CommonRapportForm
    {
        public ListeQuittancesForm()
        {
            InitializeComponent();
        }

        private void ListeQuittancesForm_Load(object sender, EventArgs e)
        {
            int h = this.gbHeader.Height;
            gbHeader.Visible = false;
            reportViewer1.Location = gbHeader.Location;
            reportViewer1.Height += h;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("list_quittances", BienController.getController().getListeQuittances() ));
            reportViewer1.RefreshReport();
        }
    }
}
