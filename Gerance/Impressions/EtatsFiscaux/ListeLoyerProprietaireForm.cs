using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gerance.Formulaires.Proprietaires;
using GeranceData.Controller;
using Microsoft.Reporting.WinForms;
using GeranceData.Common;

namespace Gerance.Impressions.EtatsFiscaux
{
    public partial class ListeLoyerProprietaireForm : Formulaires.Common.CommonRapportForm
    {
        public ListeLoyerProprietaireForm()
        {
            InitializeComponent();
        }

        private void lblRefProprietaire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprietaire) == DialogResult.OK)
            {
                tbRefProprietaire_Validating(null, null);
            }

        }

        private void tbRefRoprietaire_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblRefProprietaire_Click(null, null);
                    e.Handled = true;
                }
        }

        private void ListeLoyerProprietaireForm_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            dtEdition.Visible = false;
            btnExport.Visible = false;
            var dt = DateTime.Now;
            dtDebut.Value = new DateTime(dt.Year -1 , 1, 1);
//            dtFin.Value = dtDebut.Value.AddMonths(1).AddDays(-1);
            dtFin.Value = dtDebut.Value.AddYears(1).AddDays(-1);

        }

        private void tbRefProprietaire_Validating(object sender, CancelEventArgs e)
        {
            var proprietaire = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprietaire.Text);
            if ( proprietaire != null )
            {
                tbRefProprietaire.BackColor = Color.White;
            }
            else
                tbRefProprietaire.BackColor = Color.Red;
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            var proprietaire = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprietaire.Text);
            if ( proprietaire != null )
            {
                var NumLoyer = ParametresDB.getParam1("FISCAL", "REF LOYER", "211");
                ;
                reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                var form = new TexteReleveFiscalForm();

                form.ShowDialog();
                if (form.DialogResult != DialogResult.OK)
                    return;
                var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

                var parameters = new ReportParameter[]{
                    new ReportParameter("dateEdition", DateTime.Now.ToShortDateString()),
                    new ReportParameter("dateDeb", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("dateFin", dtFin.Value.ToShortDateString()),
                    new ReportParameter("texteHdr", form.tbText.Text),
                    new ReportParameter("NUM_LIGNE_LOYER", NumLoyer),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RecapFraisLigneFiscale",FacturesController.getController().getRecapFraisLigneFiscale(proprietaire.id, dtDebut.Value, dtFin.Value)));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReleveFiscalProprio", ReglementsController.getController().getReleveFiscalProprietaire(proprietaire.id, dtDebut.Value, dtFin.Value)));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("HdrFiscalProprietaire", ProprietaireController.getController().getHdrFiscalProprietaire(proprietaire.id)));
                reportViewer1.RefreshReport();

            }
        }
    }
}
