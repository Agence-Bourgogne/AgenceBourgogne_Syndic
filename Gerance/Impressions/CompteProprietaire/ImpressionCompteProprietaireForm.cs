using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gerance.Formulaires.Proprietaires;
using GeranceData.Entites;
using GeranceData.Controller;
using Microsoft.Reporting.WinForms;

namespace Gerance.Impressions.CompteProprietaire
{
    public partial class ImpressionCompteProprietaireForm : Gerance.Formulaires.Common.CommonGridviewForm
    {
        public ImpressionCompteProprietaireForm()
        {
            InitializeComponent();
            regKey = "listes\\ImpressionCompteProprietaire";
        }

        private void ImpressionCompteProprietaireForm_Load(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;
            btnDetail.Visible = false;
            btnPrint.Location = btnDetail.Location;
        }
        protected override DataTable getFormListe()
        {
//            Console.WriteLine("FillDataGrid");
            return ProprietaireController.getController().getListeCompteProprietaire(tbRefProprio.Text);
        }



        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["id"].Visible = false;
            cols["reference"].Width = 60;
            cols["nom"].MinimumWidth  = 180;
            cols["adresse"].MinimumWidth = 180;
//            cols["ville"].MinimumWidth = 140;

            cols["debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cols["debit"].DefaultCellStyle.Format = "n2";
            cols["credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cols["credit"].DefaultCellStyle.Format = "n2";
            cols["reference"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void lblProprio_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprio) == DialogResult.OK)
            {
                tbRefProprio_Validating(null, null);
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

        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            tbRefProprio.BackColor = Color.White;
            if (tbRefProprio.Text != "")
            {
                ProprietaireEntite locataire = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
                if (locataire == null)
                {
                    tbRefProprio.BackColor = Color.Red;
                    e.Cancel = true;
                }
            }
        }
        protected override void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!bLoading && dataGridView.SelectedRows.Count > 0 )
            {
                Console.WriteLine("selectionChanged");
                DataGridViewRow row = dataGridView.SelectedRows[0];
                tbRefProprio.Text = row.Cells["reference"].Value.ToString();
            }
        }
        protected override void FillDataGrid()
        {
            reportViewer1.Visible = false;
            base.FillDataGrid();
            dataGridView_SelectionChanged(null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string ref_proprio = tbRefProprio.Text;
            if ( ref_proprio != "" )
            {

                reportViewer1.Location = gbFactures.Location;
                reportViewer1.Width = gbFactures.Width;
                reportViewer1.Height = gbFactures.Height;
                reportViewer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                reportViewer1.Visible = true;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ImpressionCompteProprietaire", CompteProprioController.getController().getDetailCompteProprietaire(ref_proprio)));
                reportViewer1.RefreshReport();
            }

        }
    }
}
