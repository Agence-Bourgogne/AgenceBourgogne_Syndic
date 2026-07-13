using System;
using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using Microsoft.Reporting.WinForms;

namespace Gerance.Formulaires.AppelALoyer
{
    public partial class ImprimerQuittanceForm : Form
    {
        QuittanceEntite quittance;
        public ImprimerQuittanceForm()
        {
            InitializeComponent();
        }

        public ImprimerQuittanceForm(QuittanceEntite quittance)
        {
            InitializeComponent();
            this.quittance = quittance;
            btnEnter.Width = 0;
            btnExport.Visible = false;
        }

        private void ImprimerQuittanceForm_Load(object sender, EventArgs e)
        {
            DataTable table;
            table = QuittancesController.getController().getDetailQuittanceForImpression(quittance.id);
            var detailQuittance = new BindingSource();

            var row = table.Rows[0];
            row["imm_adress"] = row["imm_adress"].ToString().Replace("\n", " ");
            detailQuittance.DataSource = table;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("QuittanceLoyerLocataire", detailQuittance));
            var dtFin = new DateTime(quittance.date_quittance.Year, quittance.date_quittance.Month, 1).AddMonths(1).AddDays(-1);
            var hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            var hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            var hdr_description_small = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION_SMALL");
            var parameters = new ReportParameter[]{
                    new ReportParameter("typeReport", "1"),
                    new ReportParameter("dateEdition", DateTime.Now.ToShortDateString()),
                    new ReportParameter("dateDebut", quittance.date_quittance.ToShortDateString()),
                    new ReportParameter("dateFin", dtFin.ToShortDateString()),
                    new ReportParameter("bien_id", quittance.bien_id),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                    new ReportParameter("Header_Description_Small", hdr_description_small),
                };

            try
            {
                reportViewer1.LocalReport.SetParameters(parameters);

                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
