using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using Microsoft.Reporting.WinForms;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class ReleveHonorairesProrietairesForm : Gerance.Formulaires.Common.CommonRapportForm
    {
//        NatureEntite natureHono, natureBail, natureNlle;
        
        public ReleveHonorairesProrietairesForm()
        {
            InitializeComponent();
        }

        private void ReleveHonorairesProrietairesForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.Proprietaires.Impressions.ReleveHonorairesProprioMasterReport.rdlc";
            label3.Visible = dtEdition.Visible = false;
            reportViewer1.PrintingBegin += reportViewer1_PrintingBegin;
        
            DateTime dt = DateTime.Now;
            dtDebut.Value = dt.AddDays(1 - dt.Day);
        }
        bool bUpdateRequired = false;
        void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            bUpdateRequired = true;
        }

        private ProprietaireEntite getProprietaire()
        {
            if (tbRefProprio.Text != "")
                return ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
            return null;
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            string proprietaire_id = "";
            if ( tbRefProprio.Text != "")
            {
                ProprietaireEntite proprio = getProprietaire();
                if (proprio == null)
                {
                    MessageBox.Show("Reference Proprietaire invalide");
                    return;
                }
                proprietaire_id = proprio.id;
            }

            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("dtDeb", dtDebut.Value.ToShortDateString()),
                new ReportParameter("dtFin", dtFin.Value.ToShortDateString()),
            };
            reportViewer1.LocalReport.SetParameters(parameters);


            DataTable releves = ReglementsController.getController().getReleveHonorairesProprietaires(dtDebut.Value, dtFin.Value, proprietaire_id);

            if (releves.Rows.Count < 1)
            {
                MessageBox.Show("Pas de données pour ce(s) proprietaire(s) sur cette période");
                return;
            }

            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("releve_honoraire_proprio", releves));
            this.reportViewer1.RefreshReport();

        }
        //private void createFactureFromReglement(FacturesController factureCtl, ReglementEntite reglement, string nature_id, string libelle, decimal montant)
        //{
        //    montant = Math.Round(montant, 2);
        //    if (montant > 0)
        //    {
        //        FactureEntite facture = FacturesController.getController().getFactureHonoraire(reglement, nature_id, libelle, montant);
        //        if (facture != null)
        //        {
        //            if (!factureCtl.InsertOrUpdate(facture))
        //                throw new Exception("Factures");
        //        }
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            CreationFactureHono();
        }

        private void CreationFactureHono()
        {
            string proprietaire_id = "";
            if (tbRefProprio.Text != "")
            {
                ProprietaireEntite proprio = getProprietaire();
                if (proprio == null)
                {
                    MessageBox.Show("Reference Proprietaire invalide");
                    return;
                }
                proprietaire_id = proprio.id;
            }

            CreationFactureHonorairesFraisForm form = new CreationFactureHonorairesFraisForm(dtDebut.Value, dtFin.Value, proprietaire_id);
            form.ShowDialog();
        }

        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            tbRefProprio.BackColor = Color.White;
            if (tbRefProprio.Text != "")
            {
                ProprietaireEntite proprio = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
                if (proprio == null)
                    tbRefProprio.BackColor = Color.Red;
            }
        }

        private void lblProprio_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprio) == DialogResult.OK)
            {
                tbRefProprio.BackColor = Color.White;
            }
        }

        private void tbRefProprio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblProprio_Click(null, null);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
        }

        private void dtDebut_ValueChanged(object sender, EventArgs e)
        {
            dtFin.Value = dtDebut.Value.AddMonths(1).AddDays(-1);
        }

        private void ReleveHonorairesProrietairesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bUpdateRequired)
                CreationFactureHono();
        }
    }
}
