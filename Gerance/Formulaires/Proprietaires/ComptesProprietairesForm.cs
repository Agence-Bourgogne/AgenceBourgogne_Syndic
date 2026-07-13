using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using Microsoft.Reporting.WinForms;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class ComptesProprietairesForm : Common.CommonRapportForm
    {
        public ComptesProprietairesForm()
        {
            InitializeComponent();
        }

        private void lblProprio_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprio) == DialogResult.OK)
            {
//                tbRefProprio_Validating(null, null);
            }
        }
        BindingSource releve_compte = new BindingSource();
        BindingSource facture_compte = new BindingSource();
        BindingSource hdr_proprio = new BindingSource();

        public static decimal getSomme(BindingSource source, int type)
        {
            decimal solde = 0;

            var list = (DataView)source.List;
            foreach (DataRowView rowView in list)
            {
                var row = rowView.Row;
                decimal montant = 0;
                if ( type == 1)
                {
                    var credit = (decimal)row["credit"];
                    var debit = (decimal)row["debit"];

                    montant = credit - debit;

                    montant = (decimal)row["credit"] - (decimal)row["debit"];
                }
                else
                {
                    if ( row["base_honoraire"] != null )
                        montant += (decimal)row["base_honoraire"];
                    montant += (decimal)row["charges"];
                    montant += (decimal)row["valeur_taxe"];
                    montant += (decimal)row["montant_divers1"];
                    montant += (decimal)row["montant_divers2"];
                    montant += (decimal)row["montant_divers3"];
                    montant += (decimal)row["montant_divers4"];
                    montant += (decimal)row["montant_divers5"];
                }
                solde += montant;
            }
            //Console.WriteLine(solde);
            return solde;
        }

        void SetReferenceProprio( List<String> list , DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var reference = row["p_reference"].ToString();
                if (!list.Contains(reference))
                    list.Add(reference);
            }
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            var form = new TexteReleveForm();
            DataTable hdr;

            form.ShowDialog();
            if (form.DialogResult != DialogResult.OK)
                return;
            var proprio_id = "";

            if (tbRefProprio.Text != "")
            {
                var proprio = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
                if (proprio != null)
                    proprio_id = proprio.id;
            }
            
            var idsProprio = new List<string>();

            reportViewer1.LocalReport.DataSources.Clear();
            var reglements = ReglementsController.getController().getReleveCompteProprio(dtDebut.Value, dtFin.Value, proprio_id);
            releve_compte.DataSource = reglements;
            var factures = FacturesController.getController().getDeductionProprio(dtDebut.Value, dtFin.Value, proprio_id);
            var soldes = FacturesController.getController().getSoldeProprio(proprio_id);

            factures.Merge(soldes);
            //soldes.Merge(factures);

//            if (String.IsNullOrWhiteSpace(tbRefProprio.Text))
            {
                SetReferenceProprio(idsProprio, reglements);
                SetReferenceProprio(idsProprio ,factures);
                hdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut.Value, dtFin.Value, idsProprio);
            }
            //else
            //    hdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut.Value, dtFin.Value, tbRefProprio.Text);

            facture_compte.DataSource = factures;
//            facture_compte.DataSource = soldes;

            if ( reglements.Rows.Count < 1 && factures.Rows.Count < 1)
            {
                MessageBox.Show("Pas de données pour ce(s) proprietaire(s) sur cette période");
                return;
            }

            hdr_proprio.DataSource = hdr;

            //if ( hdr.Rows.Count < 1)
            //{
            //    reglements = ReglementsController.getController().getReleveCompteProprioVide(proprio_id);
            //    releve_compte.DataSource = reglements;
            //    hdr = ReglementsController.getController().getHdrReleveCompteProprioVide(dtDebut.Value, dtFin.Value, tbRefProprio.Text);
            //}
            var hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            var hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            var parameters = new ReportParameter[]{
                new ReportParameter("texte_releve", form.tbText.Text),
                new ReportParameter("dateEdition", dtEdition.Value.ToShortDateString()),
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
            };

            reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("hdr_compte_proprio", hdr));
            soldes.Clear();
            reportViewer1.RefreshReport();
        }


        void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            //UpdateSoldeProprio();
            bUpdateRequired = true;
        }


        List<SoldeProprio> soldes = new List<SoldeProprio>();
        private void CompteProprietaireForm_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.LocalReport.ReportEmbeddedResource= "Gerance.Formulaires.Proprietaires.Impressions.CompteProprioMasterReport.rdlc";
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            reportViewer1.PrintingBegin += reportViewer1_PrintingBegin;

            var dt = DateTime.Now;
            dtDebut.Value = dt.AddDays(1 - dt.Day); 
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            var refProprio = e.Parameters[0].Values[0];
            e.DataSources.Clear();
            releve_compte.Filter = $"p_reference = '{refProprio}'";
            facture_compte.Filter = $"p_reference = '{refProprio}'";
            facture_compte.Sort = "date_facture";
            hdr_proprio.Filter = $"p_reference = '{refProprio}'";

            Console.WriteLine(refProprio);

            var loyers = getSomme(releve_compte, 0);
            var deduction = getSomme(facture_compte, 1);
            soldes.Add(new SoldeProprio(refProprio, loyers, deduction));
            
            e.DataSources.Add(new ReportDataSource("hdr_compte_proprio", hdr_proprio));
            e.DataSources.Add(new ReportDataSource("releve_compte", releve_compte));
            e.DataSources.Add(new ReportDataSource("deduction_proprio", facture_compte));
        }

        private void btnExport_Click(object sender, EventArgs e) 
        {
            UpdateSoldeProprio();
        }
        private void UpdateSoldeProprio()
        {
            var form = new UpdateSoldeProprietairesForm(dtDebut.Value, dtFin.Value, tbRefProprio.Text);
            form.ShowDialog();
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
        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            tbRefProprio.BackColor = Color.White;
            if (tbRefProprio.Text != "")
            {
                var proprio = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
                if (proprio == null)
                    tbRefProprio.BackColor = Color.Red;
            }
        }

        private void dtDebut_ValueChanged(object sender, EventArgs e)
        {
            dtFin.Value = dtDebut.Value.AddMonths(1).AddDays(-1);
        }
        bool bUpdateRequired = false;
        private void ComptesProprietairesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( bUpdateRequired)
                UpdateSoldeProprio();
        }

    }

}
