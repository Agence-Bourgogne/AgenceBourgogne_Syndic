using System;
using Microsoft.Reporting.WinForms;
using GeranceData.Controller;
namespace Gerance.Impressions.Quittances
{
    public partial class ListeQuittancesForm : Formulaires.Common.CommonRapportForm
    {
        public ListeQuittancesForm()
        {
            InitializeComponent();
        }

        private void ListeQuittancesForm_Load(object sender, EventArgs e)
        {
            var h = gbHeader.Height;
            gbHeader.Visible = false;
            reportViewer1.Location = gbHeader.Location;
            reportViewer1.Height += h;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("list_quittances", BienController.getController().getListeQuittances() ));
            reportViewer1.RefreshReport();
        }
    }
}
