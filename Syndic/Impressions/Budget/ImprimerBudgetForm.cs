using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Impressions.RelevesIndividuels;
using EspaceSyndic.UtilsApp;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.Budget;

public partial class ImprimerBudgetForm : Form
{
    private ImmeubleEntite immeuble;
    private readonly string exercice_id;
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
            tbRefImmeuble_Validating();
        }
    }
    private void FillCbExercice(string exercice_id = "")
    {
        var exercices = ExerciceComptableController.getController().getListExerciceFromImmeuble(immeuble.id);
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
                var row = (DataRowView)cbExercice.SelectedItem;
                dtDeb.Value = (DateTime)row["date_deb"];
                dtFin.Value = (DateTime)row["date_fin"];
                btnRapport_Click(null, null);
            }
    }
    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating();
        }
    }
    private void tbRefImmeuble_Validating()
    {
        if (!tbRefImmeuble.Enabled)
            return;
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
            FillCbExercice(exercice_id);
        }
        else
        {
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
        }
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        CreateReport();
    }

    private void CreateReport()
    {
        var row = (DataRowView)cbExercice.SelectedItem;

        if (row != null)
        {
            var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            var parameters = new ReportParameter[]{
                new("DateEntete", dtEdition.Value.ToShortDateString()),
                new("Header_Description", hdr_descr),
                new("Header_Agence", hdr_agence),
                new("Exercice", row["reference"].ToString())
            };
            var budgets = BudgetController.getController().getViewBudgets(immeuble.id, cbExercice.SelectedValue.ToString());
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BudgetAnnexe3", budgets));
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (immeuble == null) return;
        var dlg = new ExportCopro();
        try
        {
            dlg.Show(this);
            dlg.Activate();
            CreateReport();
            ServiceReferenceUtils.SendReportPDF(reportViewer1, "Budget exercice " + cbExercice.Text, Guid.NewGuid().ToString(), immeuble.id, "");
            dlg.Close();
        }
        catch (Exception ex)
        {
            dlg.Close();
            MessageBox.Show(ex.Message);
        }
    }
}