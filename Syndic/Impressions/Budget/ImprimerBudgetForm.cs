using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;
using EspaceSyndic.Formulaires.Immeubles;

namespace EspaceSyndic.Impressions.Budget
{
    public partial class ImprimerBudgetForm : Form
    {
        ImmeubleEntite immeuble;
        //string immeuble_id;
        string exercice_id;
        public ImprimerBudgetForm(ImmeubleEntite immeuble, string exercice_id)
        {
            InitializeComponent();
            this.immeuble = immeuble;
            this.exercice_id = exercice_id;
            
        }

        private void ImprimerBudgetForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            if (immeuble != null)
            {
                tbRefImmeuble.Text = immeuble.reference;
                tbRefImmeuble_Validating(null, null);
            }
        }
        private void FillCbExercice(string exercice_id = "")
        {
            DataTable exercices = ExerciceComptableController.getController().getListExerciceFromImmeuble(immeuble.id);
            cbExercice.Enabled = false;
            cbExercice.DataSource = exercices;
            cbExercice.ValueMember = "id";
            cbExercice.DisplayMember = "reference";
            cbExercice.Enabled = true;
            if (exercice_id != "")
                cbExercice.SelectedValue = exercice_id;
            cbExercice_SelectedIndexChanged(null, null);
        }
        private void cbExercice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExercice.SelectedValue != null)
                if (cbExercice.Enabled && cbExercice.SelectedValue.ToString() != "")
                {
                    DataRowView row = (DataRowView)cbExercice.SelectedItem;
                    string budget_id = row["budget_id"].ToString();
                    //                    DateTime dt = (DateTime) row["date_deb"];
                    dtDeb.Value = (DateTime)row["date_deb"];
                    dtFin.Value = (DateTime)row["date_fin"];
                    btnRapport_Click(null, null);
                }
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
            if (!tbRefImmeuble.Enabled)
                return;
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                FillCbExercice(this.exercice_id);
            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }

        void CreateReport(string num_lot = "")
        {
            DataRowView row = (DataRowView)cbExercice.SelectedItem;

            if (row != null)
            {
                string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
                ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("DateEntete", dtEdition.Value.ToShortDateString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                    new ReportParameter("Exercice", row["reference"].ToString()),
                };
                DataTable budgets = BudgetController.getController().getViewBudgets(immeuble.id, cbExercice.SelectedValue.ToString());
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BudgetAnnexe3", budgets));
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (immeuble == null) return;
           // List<LotDescriptionEntite> lots = LotDescriptionController.getController().getListeLotDescription(immeuble.id);
            EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro dlg = new EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro();
            try
            {
                dlg.Show(this);
                dlg.Activate();
                CreateReport();
                UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, "Budget exercice " + cbExercice.Text, Guid.NewGuid().ToString(), immeuble.id, "");
                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
