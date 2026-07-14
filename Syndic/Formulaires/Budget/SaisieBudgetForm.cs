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
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Budget;

public partial class SaisieBudgetForm : Form
{
    private ImmeubleEntite immeuble;
    private NatureEntite nature;

    public SaisieBudgetForm()
    {
        InitializeComponent();
    }
    private void SaisieBudgetForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        btnExerciceAdd.Enabled = false;
        btnPrint.Enabled = false;
        btnPrint.Enabled = false;
        FillDataGridViewExercice();
        btnExerciceAdd.Visible = false;
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
    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        if (!tbRefImmeuble.Enabled)
            return;
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
            FillDataGridViewExercice();
            btnExerciceAdd.Enabled = true;
            tbBase.Enabled = true;
        }
        else
        {
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            btnExerciceAdd.Enabled = false;
            tbBase.Text = "";
            tbBase.Enabled = false;
        }
    }

    private bool bLoaded;
    private void FillDataGridViewExercice()
    {
        bLoaded = false;

        var exercices = ExerciceComptableController.getController().getListExerciceFromImmeuble(immeuble != null ? immeuble.id:"");
        dataGridViewExercice.DataSource = exercices;
        bLoaded = true;

        if (exercices != null)
        {
            var cols = dataGridViewExercice.Columns;
            cols["budget_id"].Visible= false;
            cols["id"]?.Visible = false;

            ControlsWindows.ToTitleCase(cols);
            FillDataGridViewBudget();
        }
    }

    private string getBudgetExerciceSelected()
    {
        var budget_id = "";

        if ( dataGridViewExercice.SelectedRows.Count > 0 )
        {
            var row = (DataRowView)dataGridViewExercice.SelectedRows[0].DataBoundItem;
            budget_id = row["budget_id"].ToString();
        }
        return budget_id;
    }
    private string getExerciceSelected()
    {
        var exercice_id = "";

        if (dataGridViewExercice.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridViewExercice.SelectedRows[0].DataBoundItem;
            exercice_id = row["id"].ToString();
            if (bLoaded)
            {
                //decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble.id, (DateTime)row["date_deb"], (DateTime)row["date_fin"]);
            }
        }
        return exercice_id;
    }
    private void btnExerciceAdd_Click(object sender, EventArgs e)
    {
        var form = new NouvelExerciceForm(immeuble.id);
        form.exercice_id = getExerciceSelected();
        form.ShowDialog();
        if ( form.exercice_id != "")
        {
            FillDataGridViewExercice();
            dataGridViewExercice_SelectionChanged(null, null);
        }
    }
    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void FillDataGridViewBudget()
    {
        if (!bLoaded)
            return;
        dataGridViewBudget.DataSource = "";
        if (immeuble == null)
            return;
        dataGridViewBudget.DataSource = BudgetController.getController().getViewBudgets(immeuble.id, getExerciceSelected());

        var cols = dataGridViewBudget.Columns;
        cols["nature"].MinimumWidth = 160;
        cols["id"]?.Visible = false;
        cols["prevu_suivant"].HeaderText = "Prevu N+1";
        cols["prevu_suivant_1"].HeaderText = "Prevu N+2";
        ControlsWindows.ToTitleCase(cols);
        dataGridViewBudget.ClearSelection();
    }
    private void dataGridViewBudget_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridViewBudget.SelectedRows.Count > 0)
        {
            var row = (DataRowView) dataGridViewBudget.SelectedRows[0].DataBoundItem;
//                Console.WriteLine(row);
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
            if ( exercice != null )
            {
                budget = new BudgetEntite
                {
                    exercice_id = exercice_id,
                    statut = (int) GlobalConstantes.StatutBudget.Brouillard,
                    reference = exercice.reference
                };
                if (BudgetController.getController().InsertOrUpdate(budget))
                    id = budget.id;
            }
        }
        else
            id = budget.id;
        return id;
    }


    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (tbBase.Text == "") return;
        if (tbNature.Text == "") return;
        if (tbMontant.Text == "") return;

        var budgetLine = new BudgetLigneEntite();

        if (dataGridViewBudget.SelectedRows.Count > 0)
        {
            var row = (DataRowView) dataGridViewBudget.SelectedRows[0].DataBoundItem;
            if (row["id"].ToString() != "")
                budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());
        }
        else
        {
            budgetLine.budget_id = getBudgetExerciceSelected();
            budgetLine.statut = (int) GlobalConstantes.StatutBudget.Brouillard;
        }
        if (string.IsNullOrEmpty(budgetLine.budget_id))
        {
            budgetLine.budget_id = CreateBudget();
        }

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
        FillDataGridViewBudget();
    }

    private void tbBase_Validating(object sender, CancelEventArgs e)
    {
        //if (baseAuto.Contains(tbBase.Text))
        //{
        //    tbBase.BackColor = Color.White;
        //}
        //else
        //{
        //    tbBase.BackColor = tbBase.Text != "" ? Color.Red : Color.White;
        //}
    }

    private void tbNature_Validating(object sender, CancelEventArgs e)
    {
        var parameters = new List<NpgsqlParameter>
        {
            new("reference", tbNature.Text)
        }; 

        nature = NatureController.getController().getEntite("where reference = @reference and budgetisable=true", parameters);
        if (nature != null)
        {
            tbNature.BackColor = Color.White;
            tbLibNature.Text = nature.nom;
        }
        else
        {
            tbNature.BackColor = tbNature.Text != "" ? Color.Red : Color.White;
            tbLibNature.Text = "";
        }
    }

    private void lblNature_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm();
        form.filter = "budgetisable = true";
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbNature.Text = form.reference;
            tbNature_Validating(null, null);
        }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        if (dataGridViewBudget.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridViewBudget.SelectedRows[0].DataBoundItem;
            var budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());

            if (budgetLine != null)
            {
                budgetLine.statut = (int) GlobalConstantes.StatutBudget.Supprime;
                BudgetLigneController.getController().InsertOrUpdate(budgetLine);
                FillDataGridViewBudget();
                tbRefImmeuble.Enabled = false;
                tbRefImmeuble.Enabled = true;
            }
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var form = new ImprimerBudgetForm(immeuble, getExerciceSelected());
        form.ShowDialog();
    }

    private void dataGridViewExercice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var dgv = (DataGridView)sender;
        var col = dgv.Columns[e.ColumnIndex];

        try
        {
            if (col.Name == "statut_budget")
                if ( dgv[e.ColumnIndex, e.RowIndex].Value.ToString() != "" )
                {
                    var statut = (GlobalConstantes.StatutBudget)dgv[e.ColumnIndex, e.RowIndex].Value;
                    e.Value = statut.ToString().Replace("_", " ");
                    e.FormattingApplied = true;
                }
            if (col.Name == "statut")
                if (dgv[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                {
                    var statut = (GlobalConstantes.StatutExercice)dgv[e.ColumnIndex, e.RowIndex].Value;
                    e.Value = statut.ToString().Replace("_", " ");
                    e.FormattingApplied = true;
                }
        }
        catch (Exception)
        {
        }
    }

    private void dataGridViewExercice_SelectionChanged(object sender, EventArgs e)
    {
        if ( bLoaded )
            FillDataGridViewBudget();
        btnPrint.Enabled = getExerciceSelected() != "";
        btnAdd.Enabled = getExerciceSelected() != "";
    }

    private LiasseEntite createLiasseReprise(decimal valueSoldeImm)
    {
        var liasse = new LiasseEntite
        {
            //liasse.id = liasse.get_uuid();
            isNew = true,
            montant = valueSoldeImm,
            type_ecriture = nameof(GlobalConstantes.TypeOperation.Facture),
            statut = (int)GlobalConstantes.StatutOperation.Brouillon,
            reference = $"{BaseApplication.ComputerName} du {DateTime.Now}"
        };
        if (!LiasseController.getController().InsertOrUpdate(liasse))
            throw new Exception("Creation Liasse");
        return liasse;
    }
    private SaisieFactureEntite createFactureReprise(LiasseEntite liasse, DateTime dateDeb, decimal valueSoldeImm)
    {
        var facture = new SaisieFactureEntite
        {
            base_repart = "0"
        };

        facture.date_operation = facture.date_reference = dateDeb;
        facture.numero_operation = 1;
        facture.nature_id = nature.id;
        facture.liasse_id = liasse.id;
        facture.montant = valueSoldeImm;
        facture.libelle = ParametresDB.getParam1("CLOTURE", "LIBELLE FACTURE");
        //facture.libelle = "SOLDE DE COPROPRIETE";
        facture.statut = (int)GlobalConstantes.StatutOperation.Valide;

        return facture;
    }
    private FournisseurEntite getFournisseurCloture()
    {
        var reference = ParametresDB.getParam1("CLOTURE", "FOURNISSEUR");
        return FournisseurController.getController().getEntiteFromField("reference", reference);
    }
    private NatureEntite getNatureCloture()
    {
        var reference = ParametresDB.getParam1("CLOTURE", "NATURE");
        return NatureController.getController().getEntiteFromField("reference", reference);
    }
    private void cloturerExerciceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var exercice_id = getExerciceSelected();
        if ( exercice_id != "" )
        {
            nature = getNatureCloture();
            var fournisseur = getFournisseurCloture();
            var libelle = ParametresDB.getParam1("CLOTURE","LIBELLE OPERATION");

//                LiasseEntite liasse = 
            var currExercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
            var exercice_suivant = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
            if ( exercice_suivant.Rows.Count <= 0 )
            {
                dataGridViewExercice.ClearSelection();

                btnExerciceAdd_Click(null, null);
                exercice_suivant = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
            }
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();
            try
            {
                // TODO Voir pour TimestampServer
                // TODO Revoir la gestion exception
                if (exercice_suivant != null && exercice_suivant.Rows.Count > 0 )
                {
                    var exerciceSuivantEntite = new ExerciceComptableEntite( exercice_suivant.Rows[0]);
                    var soldeImm = SaisieFactureController.getController().getCurrentSoldeImmeuble(exerciceSuivantEntite.immeuble_id, exerciceSuivantEntite.date_deb, exerciceSuivantEntite.date_fin  );

                    if ( soldeImm.Rows.Count <= 0 )
                    {
                        var valueSoldeImm = OperationController.getController().getSoldeImmeuble(currExercice.immeuble_id, currExercice.date_deb, currExercice.date_fin);
                        var liasse = createLiasseReprise(valueSoldeImm);

                        var facture = createFactureReprise(liasse, exerciceSuivantEntite.date_deb, valueSoldeImm);
                        facture.fournisseur_id = fournisseur.id;
                        facture.immeuble_id = currExercice.immeuble_id;
                        if (!SaisieFactureController.getController().InsertOrUpdate(facture))
                            throw new Exception("Creation Facture");

                        var repart = LotDescriptionController.getController().getListeLot(immeuble.id);
                        var numero_ligne = 0;
                        foreach (DataRow row in repart.Rows)
                        {
                            var repimm = new LotDescriptionEntite(row);
                            var soldeCopro = OperationController.getController().getSoldeImmeuble(immeuble.id, currExercice.date_deb, currExercice.date_fin, repimm.coproprietaire_id);
                            var operation = new OperationEntite(facture)
                            {
                                numero_ligne = numero_ligne++,
                                coproprietaire_id = repimm.coproprietaire_id,
                                lot_id = repimm.id,
                                libelle = libelle, //"SOLDE BILAN";
                                type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette),
                                type_operation = nameof(GlobalConstantes.TypeOperation.SoldeBilan)
                            };
                            if (soldeCopro <= 0)
                                operation.debit = soldeCopro;
                            else
                                operation.credit = soldeCopro;
                            operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
                            if ( !OperationController.getController().InsertOrUpdate(operation))
                                throw new Exception("Creation Operation");
                        }
                    }

                    if (!SaisieFactureController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime) || !SaisieAppelFondController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime) || !SaisieReglementController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime) || !OperationController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime))
                        throw new Exception("Cloture Facture");

                    currExercice.statut = (int)GlobalConstantes.StatutExercice.Clos;
                    if (!ExerciceComptableController.getController().InsertOrUpdate(currExercice))
                        throw new Exception("Statut exercice");
                }
                trx.Commit();
                tbRefImmeuble_Validating(null, null);
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void budget_a_VoterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var budget_id = getBudgetExerciceSelected();
        BudgetController.getController().UpdateStatus(budget_id, GlobalConstantes.StatutBudget.A_Voter);
        FillDataGridViewExercice();
    }

    private void budgetApprouveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var budget_id = getBudgetExerciceSelected();
        BudgetController.getController().UpdateStatus(budget_id, GlobalConstantes.StatutBudget.Approuve);
        FillDataGridViewExercice();
    }

    private void nouvelExerciceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new NouvelExerciceForm(immeuble.id);
        form.exercice_id = "";
        form.ShowDialog();
        if (form.exercice_id != "")
        {
            FillDataGridViewExercice();
            dataGridViewExercice_SelectionChanged(null, null);
        }
    }

    private void modifierExerciceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new NouvelExerciceForm(immeuble.id);
        form.exercice_id = getExerciceSelected(); 
        form.ShowDialog();
        if (form.exercice_id != "")
        {
            FillDataGridViewExercice();
            dataGridViewExercice_SelectionChanged(null, null);
        }
    }

    private void dataGridViewBudget_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        //Console.WriteLine(e.ColumnIndex);
        if ( e.ColumnIndex > 2 )
        {
            if (e.Value.ToString() == "0")
                e.Value = "";
        }
    }
}