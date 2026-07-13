using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Controller;
using SyndicData.Entites;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using EspaceSyndic.Impressions.RelevesComptes;
using EspaceSyndic.Formulaires;

namespace EspaceSyndic.Impressions.Balances
{
    public partial class BalanceImmeublePrintForm : Form
    {
        ImmeubleEntite immeuble;
        public int typeBalance;
        BindingSource sourceData = new BindingSource();
        string TitreForm;

        public BalanceImmeublePrintForm()
        {
            InitializeComponent();
        }

        public void RefreshTypeReport ( int type )
        {
            cbBalance.SelectedIndex = typeBalance = type;
        }
        private void BalanceImmeubleProntForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            TitreForm = this.Text;
            cbBalance.SelectedIndex = typeBalance;
            this.reportViewer1.Visible = false;
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Validating(null, null);
            }
        }
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null & cbBalance.SelectedIndex >= 0)
            {
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                loadData();
            }
            else
            {
                this.Text = TitreForm;
            }
        }

        private void cbBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbRefImmeuble_Validating(sender, null);
        }

        private void loadData()
        {
            switch (cbBalance.SelectedIndex)
            {
                case 0:
                    sourceData.DataSource = SaisieFactureController.getController().GetBalanceReglementsFactures(immeuble.id);
                    break;
                case 1:
                    sourceData.DataSource = OperationController.getController().GetBalanceReglementAppelsDeFond(immeuble.id);
                    break;
            }
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            this.reportViewer1.Visible = true;
            this.dataGridView.Visible = false;

            string titre = "Balance Règlements Factures";
            if (cbBalance.SelectedIndex == 1)
                titre = "Balance Règlements Appels de Fond";

            ReportParameter[] reportParams = new ReportParameter[]{
                    new ReportParameter("Titre", titre),
                    new ReportParameter("RefImmeuble", immeuble.reference)
                };
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("balance", sourceData));
            this.reportViewer1.LocalReport.SetParameters(reportParams);
            this.reportViewer1.RefreshReport();
        }


        private void btnGrid_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            this.reportViewer1.Visible = false;
            this.dataGridView.Visible = true;
            dataGridView.DataSource = sourceData;
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols["type"].Visible = false;
            cols["debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cols["credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cols["date_reference"].Width = 80;
            cols["debit"].Width = 80;
            cols["credit"].Width = 80;
            cols["date_reference"].Width = 80;
            ControlsWindows.ToTitleCase(cols);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = sourceData;
            List<string> cols = new List<string>{"type"};
            BaseApplication.DataGridToExcel(dataGridView, cols, "", new string[] {"debit", "credit"});
        }

        private void btnCompte_Click(object sender, EventArgs e)
        {
            ReleveCompteCoproPrintForm form = (ReleveCompteCoproPrintForm) MainForm.getInstance().ShowForm("EspaceSyndic.Impressions.RelevesComptes.ReleveCompteCoproPrintForm");
            form.RefreshImmeuble(immeuble.reference);
            form.Activate();
        }

    }
}
