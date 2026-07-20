using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Impressions.Budget;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Budget;

public partial class BudgetSruForm : Form
{
    private readonly string TitreForm;

    private bool bLoaded;
    private ImmeubleEntite immeuble;
    private NatureEntite nature;

    public BudgetSruForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void BudgetSruForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
    }

    private string getExerciceSelected()
    {
        var exercice_id = "";

        if (cbExercice.SelectedIndex >= 0)
        {
            var row = (DataRowView)cbExercice.SelectedItem;
            Console.Write(cbExercice.SelectedItem);
            exercice_id = row["id"].ToString();
        }

        return exercice_id;
    }

    private void FillDataGrid()
    {
        if (!bLoaded)
            return;
        dataGridView.DataSource = "";
        if (immeuble == null)
            return;
        dataGridView.DataSource = BudgetController.getController().getViewBudgets(immeuble.id, getExerciceSelected());

        var cols = dataGridView.Columns;
        cols["nature"].MinimumWidth = 160;
        cols["id"]?.Visible = false;
        cols["prevu_suivant"].HeaderText = "Prevu N+1";
        cols["prevu_suivant_1"].HeaderText = "Prevu N+2";
        ControlsWindows.ToTitleCase(cols);
        dataGridView.ClearSelection();
    }

    private void FillComboExercice()
    {
        bLoaded = false;

        var exercices = ExerciceComptableController.getController()
            .getListExerciceFromImmeuble(immeuble != null ? immeuble.id : "");
        cbExercice.DataSource = exercices;

        cbExercice.DisplayMember = "reference";
        cbExercice.ValueMember = "e.id";
        if (immeuble != null)
        {
            var exercice = ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
            cbExercice.SelectedValue = exercice.id;
        }

        bLoaded = true;

        FillDataGrid();
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        tbRefImmeuble.BackColor = Color.White;
        if (immeuble != null)
        {
            tbNom.Text = immeuble.nom;
            tbAdresse.Text = immeuble.Adresse;
            FillComboExercice();
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
        }
        else
        {
            if (tbRefImmeuble.Text != "")
                tbRefImmeuble.BackColor = Color.Red;
            tbNom.Text = tbAdresse.Text = "";
            Text = TitreForm;
        }
    }

    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }
    }

    private void lblNature_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbNature.Text = form.reference;
            tbNature_Validating(null, null);
        }
    }

    private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(null, null);
                if (sender.Equals(tbNature))
                    lblNature_Click(null, null);
            }
    }

    private void tbNature_Validating(object sender, CancelEventArgs e)
    {
        nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
        tbNature.BackColor = Color.White;
        if (nature != null)
        {
            tbLibNature.Text = nature.nom;
        }
        else
        {
            if (tbNature.Text != "")
                tbNature.BackColor = Color.Red;
            tbLibNature.Text = "";
        }
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void cbExercice_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void dataGridViewBudget_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex > 2)
        {
            var dgv = (DataGridView)sender;
            _ = dgv.Columns[e.ColumnIndex];
            if (e.Value.ToString() == "0")
                e.Value = "";
        }
    }

    private void dataGridViewBudget_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            tbBase.Text = row["base"].ToString();
            tbNature.Text = row["compte"].ToString();
            tbMontant.Text = row["prevu"].ToString();
            btnAdd.Text = "&Modifier";
            btnDel.Enabled = true;
        }
        else
        {
            tbBase.Text = "";
            tbMontant.Text = "";
            tbNature.Text = "";
            btnAdd.Text = "&Ajouter";
            btnDel.Enabled = false;
        }

        tbNature_Validating(null, null);
    }

    private string CreateBudget()
    {
        var id = "";

        var exercice_id = getExerciceSelected();
        var budget = BudgetController.getController().getEntiteFromField("exercice_id", exercice_id);
        if (budget == null)
        {
            var exercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
            if (exercice != null)
            {
                budget = new BudgetEntite
                {
                    exercice_id = exercice_id,
                    statut = (int)GlobalConstantes.StatutBudget.Brouillard,
                    reference = exercice.reference
                };
                if (BudgetController.getController().InsertOrUpdate(budget))
                    id = budget.id;
            }
        }
        else
        {
            id = budget.id;
        }

        return id;
    }

    private string getBudgetExerciceSelected()
    {
        var budget_id = "";

        if (cbExercice.SelectedIndex >= 0)
        {
            var row = (DataRowView)cbExercice.SelectedItem;
            budget_id = row["budget_id"].ToString();
        }

        return budget_id;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbBase.Text == "") return;
        if (tbNature.Text == "") return;
        if (tbMontant.Text == "") return;

        var budgetLine = new BudgetLigneEntite();

        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (row["id"].ToString() != "")
                budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());
        }
        else
        {
            budgetLine.budget_id = getBudgetExerciceSelected();
            budgetLine.statut = (int)GlobalConstantes.StatutBudget.Brouillard;
        }

        if (string.IsNullOrEmpty(budgetLine.budget_id)) budgetLine.budget_id = CreateBudget();

        budgetLine.base_repart = tbBase.Text;
        budgetLine.nature_id = nature.id;
        budgetLine.montant = Convertir.ToDecimal(tbMontant.Text);
        try
        {
            BudgetLigneController.getController().InsertOrUpdate(budgetLine);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        FillDataGrid();
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());

            if (budgetLine != null)
            {
                budgetLine.statut = (int)GlobalConstantes.StatutBudget.Supprime;
                BudgetLigneController.getController().InsertOrUpdate(budgetLine);
                FillDataGrid();
            }
        }
    }

    private void btnNouvelExerciceAdd_Click(object sender, EventArgs e)
    {
        if (immeuble == null)
            return;
        if ((int)CommonRegistry.getRegistryValue("", "", 0) == 0)
        {
            var form = new NouvelExerciceOnlyForm(immeuble.id);
            form.ShowDialog();
        }
        else
        {
            var form = new NouvelExerciceForm(immeuble.id);
            form.ShowDialog();
        }

        FillComboExercice();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var form = new ImprimerBudgetForm(immeuble, getExerciceSelected());
        form.ShowDialog();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string> { "id" };
        BaseApplication.DataGridToExcel(dataGridView, colsToHide);
    }
}