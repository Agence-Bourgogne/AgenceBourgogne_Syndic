using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gerance.Formulaires.Locataires;
using GeranceData.Controller;
using GeranceData.Entites;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Common;

namespace Gerance.Impressions.Loyers
{
    public partial class ListeLoyerForm : Formulaires.Common.CommonRapportForm
    {
        public ListeLoyerForm()
        {
            InitializeComponent();
        }
        private void ListeLoyerForm_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            dtEdition.Visible = false;
            DateTime dt = DateTime.Now;
            dtDebut.Value = new DateTime(dt.Year, dt.Month, 1);
            dtFin.Value = dtDebut.Value.AddMonths(1).AddDays(-1);
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
                tbRefLocataire_Validating(null, null);
            }
        }

        private void tbRefLocataire_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblRefLocataire_Click(null, null);
                    e.Handled = true;
                }
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            if (tbRefLocataire.Text == "")
                return;
            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire != null)
            {
                tbRefLocataire.BackColor = Color.White;
            }
            else
            {
                tbRefLocataire.BackColor = Color.Red;
            }
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire != null)
            {
                reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                string hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                string hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");


                ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("dateDebut", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("dateFin", dtFin.Value.ToShortDateString()),
                    new ReportParameter("dateEdition", DateTime.Now.ToShortDateString()),
                    new ReportParameter("reference", locataire.reference),
                    new ReportParameter("nom", locataire.NomPrenom),
                    new ReportParameter("adresse", locataire.adresse),
                    new ReportParameter("dateEntree", locataire.Bien.date_entree.ToShortDateString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),

                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("reglement_locataire", ReglementsController.getController().getReglementLocataire(locataire.id, dtDebut.Value, dtFin.Value)));
                reportViewer1.RefreshReport();
            }
        }
        protected virtual List<string> getExportColsToHide()
        {
            return new List<string> { "id", "audit_created", "audit_created_by", "audit_updated", "audit_updated_by" };
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire != null)
            {
                DataTable table = ReglementsController.getController().getReglementLocataire(locataire.id, dtDebut.Value, dtFin.Value);
                BaseApplication.DataTableToExcel(table, getExportColsToHide());
            }
        }
    }
}
