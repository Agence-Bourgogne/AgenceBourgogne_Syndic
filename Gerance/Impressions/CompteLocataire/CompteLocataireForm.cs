using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Entites;
using GeranceData.Controller;
using Gerance.Formulaires.Locataires;
using Microsoft.Reporting.WinForms;

namespace Gerance.Impressions.CompteLocataire
{
    public partial class CompteLocataireForm : Formulaires.Common.CommonGridviewForm
    {
        public CompteLocataireForm()
        {
            InitializeComponent();
            regKey = "listes\\CompteLocataire";
        }
        protected override DataTable getFormListe()
        {
            Console.WriteLine("FillDataGrid");
            reportViewer1.Visible = false;
            return LocataireController.getController().getSoldeLocataire(tbRefLocataire.Text);
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["id"].Visible = false;
            cols["reference"].Width = 60;
            cols["locataire"].Width = 180;
            cols["adresse"].Width = 180;
            DataGridViewCellStyle style = cols["debit"].DefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style.Format = "n2";
            style = cols["credit"].DefaultCellStyle;
            style.Format = "n2";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style = cols["solde"].DefaultCellStyle;
            style.Format = "n2";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            style = cols["reference"].DefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
                tbRefLocataire_Validating(null, null);
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

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if (tbRefLocataire.Text != "")
            {
                LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire == null)
                    tbRefLocataire.BackColor = Color.Red;
                else
                {
                    FillDataGrid();
                    if (reportViewer1.Visible)
                        btnPrint_Click(null, null);
                }
                    
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string ref_locataire = "";

            if ( dataGridView.SelectedRows.Count > 0 )
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                ref_locataire = row.Cells["reference"].Value.ToString();

                reportViewer1.Location = new Point(0, 0);
                reportViewer1.Width = gbFactures.Width;
                reportViewer1.Height = gbFactures.Height;
                reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                reportViewer1.Visible = true;

                //reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReleveCompteLocataire", LocataireController.getController().getDetailCompteLocataire(ref_locataire)));
                reportViewer1.RefreshReport();
            }

        }

        private void CompteLocataireForm_Load(object sender, EventArgs e)
        {
            btnDetail.Visible = false;
            btnPrint.Location = btnDetail.Location;
        }
    }
}
