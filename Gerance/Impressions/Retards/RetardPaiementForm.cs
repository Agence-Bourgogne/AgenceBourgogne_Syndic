using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using GeranceData.Common;
using GeranceData.Controller;
using GeranceData.Entites;
using Gerance.Formulaires.Locataires;
using Microsoft.Reporting.WinForms;
namespace Gerance.Impressions.Retards
{
    public partial class RetardPaiementForm : Gerance.Formulaires.Common.BaseFicheForm
    {
        string regKey;
        public RetardPaiementForm()
        {
            InitializeComponent();
            regKey = "listes\\retard_paiements";
        }

        private void RetardPaiementForm_Load(object sender, EventArgs e)
        {
            tbSeuil.Text = ParametresDB.getParam1("RETARDS", "SEUIL");
            reportViewer1.Visible = false;
            FillDataGrid();
            btnPrint.Location = btnFirst.Location;
            btnSave.Visible = false;
            btnPrev.Visible = true;
            btnNext.Visible = true;
            setModified(false);
        }
        protected override void tbTextChanged(object sender, EventArgs e)
        {
        }
        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
            }
        }

        private void tbRefLocataire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblRefLocataire_Click(null, null);
                    e.SuppressKeyPress = true;
                }
        }
        private void FillDataGrid()
        {
            decimal seuil = Convertir.ToDecimal(tbSeuil.Text );
            BindingSource source = new BindingSource();// (BindingSource)dataGridView.DataSource;
            source.DataSource = LocataireController.getController().getListeRetardPaiements(seuil, tbRefLocataire.Text);
            if ( seuil != 0 )
                source.Filter = String.Format(" total_du > {0}", seuil);

            dataGridView.DataSource = source;//LocataireController.getController().getListeRetardPaiements(seuil, tbRefLocataire.Text);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                HideAndResizeColumns(cols);
                ControlsWindows.ToTitleCase(cols);
                OrderColumns();
            }
            setModified(false);
        }
        protected virtual void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["id"].Visible = false;
            DataGridViewCellStyle style = cols["total_du"].DefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style = cols["date_reglement"].DefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        protected virtual void OrderColumns()
        {
            if (regKey == "")
                return;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                int index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
                if (index != -1)
                    col.DisplayIndex = index;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Width = gbList.Width;
            reportViewer1.Height = gbList.Bottom - gbList.Top;
            reportViewer1.Visible = true;
            reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ckAll.Visible = false;

            string montant_rappel = ParametresDB.getParam1("RETARD","MONTANT_RAPPEL");
            if ( montant_rappel == "")
                montant_rappel="5";
	        string hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.Retards.RetardPaiementReport.rdlc";
            ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("dateEdition", dateEcriture.Value.ToShortDateString()),
                    new ReportParameter("montant_rappel", montant_rappel),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            BindingSource selected = new BindingSource();
            bool bHaveRows = false;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if ( row.Cells["select"].Value != null ) 
                    if ((bool) row.Cells["select"].Value == true)
                    {
                        selected.Add(row.DataBoundItem);
                        bHaveRows = true;
                    }
            }
            if (!bHaveRows)
            {
                MessageBox.Show("Aucune Locataire n'est Séléctionné");
                reportViewer1.Visible = false;
                ckAll.Visible = true;
                return;
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetardPaiement", selected));
//            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetardPaiement", dataGridView.DataSource));
            reportViewer1.RefreshReport();
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
            reportViewer1.Visible = false;
            setModified(false);
        }

        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;
            ckAll.Visible = true;
            FillDataGrid();
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAll.Checked)
                ckAll.Text = "&Tout décocher";
            else
                ckAll.Text = "&Tout cocher";
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["select"].Value = ckAll.Checked;
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Width = gbList.Width;
            reportViewer1.Height = gbList.Bottom - gbList.Top;
            reportViewer1.Visible = true;
            reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ckAll.Visible = false;
            string montant_rappel = ParametresDB.getParam1("RETARD", "MONTANT_DEMEURE");
            if (montant_rappel == "")
                montant_rappel = "46";
            string hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("dateEdition", dateEcriture.Value.ToShortDateString()),
                    new ReportParameter("montant_rappel", montant_rappel),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Impressions.Retards.MiseEnDemeureReport.rdlc";
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            BindingSource selected = new BindingSource();
            bool bHaveRows = false;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["select"].Value != null)
                    if ((bool)row.Cells["select"].Value == true)
                    {
                        selected.Add(row.DataBoundItem);
                        bHaveRows = true;
                    }
            }
            if (!bHaveRows)
            {
                MessageBox.Show("Aucune Locataire n'est Séléctionné");
                reportViewer1.Visible = false;
                ckAll.Visible = true;
                return;
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetardPaiement", selected));
            //            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetardPaiement", dataGridView.DataSource));
            reportViewer1.RefreshReport();

        }
    }
}