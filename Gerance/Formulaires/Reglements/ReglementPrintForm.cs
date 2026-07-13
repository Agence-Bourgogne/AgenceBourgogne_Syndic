using System;
using System.Data;
using Microsoft.Reporting.WinForms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Reglements
{
    public partial class ReglementPrintForm : Common.CommonRapportForm
    {
        public ReglementPrintForm()
        {
            InitializeComponent();
        }

        private void ReglementPrintForm_Load(object sender, EventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //DateTime dtDeb = new DateTime (dt.Year, dt.Month, 1);

            //dtDebut.Value = dtDeb;
            //dtFin.Value = dtDeb.AddMonths(1).AddDays(-1);
            fillRapport();
            btnExport.Visible = false;
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            fillRapport();
        }
        private void fillRapport()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            var table = ReglementsController.getController().getPrintReglements(dtDebut.Value, dtFin.Value);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("list_reglements", table));
            var parameters = new ReportParameter[]{
                    new ReportParameter("date_debut", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("date_fin", dtFin.Value.ToShortDateString()),
                };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }
    }
}
