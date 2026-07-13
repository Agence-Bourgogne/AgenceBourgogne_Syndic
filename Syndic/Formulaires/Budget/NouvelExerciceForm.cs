using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Budget
{
    public partial class NouvelExerciceForm : Form
    {
        string immeuble_id = "";
        public string exercice_id = "";
        public NouvelExerciceForm(string immeuble_id)
        {
            InitializeComponent();
            this.immeuble_id = immeuble_id;
        }
        private void NouvelExerciceForm_Load(object sender, EventArgs e)
        {
            MinimumSize = MaximumSize = Size;
            if (exercice_id == "")
            {
                var dt = ExerciceComptableController.getController().getNewDateDebutExercice(immeuble_id);
                dtDeb.Value = dt;
                dtFin.Value = dtDeb.Value.AddYears(1).AddDays(-1);
            }
            else
            {
                var exercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
                dtDeb.Value = exercice.date_deb;
                dtFin.Value = exercice.date_fin;
                tbReference.Text = exercice.reference;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ActiveControl == btnOk)
            {
                if ( GenerateBudget())
                    Close();
            }
            else
                ControlsWindows.FocusNextTabbedControl(this);
        }

        private void dtDeb_ValueChanged(object sender, EventArgs e)
        {
            tbReference.Text = dtDeb.Value.Year.ToString();
        }
        private bool GenerateBudget()
        {
//            NpgsqlConnection cnx= Database.Begin();
            var trx = Database.BeginTransaction();
            try
            {
                ExerciceComptableEntite exercice = null;
                if ( exercice_id != "")
                    exercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
                if ( exercice == null )
                {
                    exercice = new ExerciceComptableEntite();
                    exercice.statut = (int)GlobalConstantes.StatutExercice.Ouvert;
                }
                
                exercice.date_deb = dtDeb.Value;
                exercice.date_fin = dtFin.Value;
                exercice.immeuble_id = immeuble_id;
                exercice.reference = tbReference.Text;
                exercice.nom = tbReference.Text;
                if (!ExerciceComptableController.getController().InsertOrUpdate(exercice))
                {
                    throw new Exception("New Exercice");
                }
                exercice_id = exercice.id;

                var budget = BudgetController.getController().getEntiteFromField("exercice_id", exercice.id);

                if (budget == null)
                {
                    budget = new BudgetEntite();
                    budget.exercice_id = exercice.id;
                    budget.reference = exercice.reference;
                    budget.statut = (int)GlobalConstantes.StatutBudget.Brouillard;
                    if ( !BudgetController.getController().InsertOrUpdate(budget))
                    {
                        throw new Exception("New budget");
                    }
                }
                //this.exercice_id = budget.id;

                var controller = BudgetLigneController.getController();


                if (rdReel.Checked)
                {
                    // TODO Revoir le calcul de n-1

                    var realise = SaisieFactureController.getController().getBudgetRealise(immeuble_id, dtDeb.Value.AddYears(-1), dtFin.Value.AddYears(-1));
                    if ( realise.Rows.Count <= 0 )
                    {
                        throw new Exception("Aucune données pour le réalisé n-1");
                    }
                    var coeff = Convertir.ToDecimal(tbCoeff.Text);
                    foreach (DataRow row in realise.Rows)
                    {
                        var budgetLigne = new BudgetLigneEntite();
                        var montant = (decimal) row["montant"];
                        budgetLigne.budget_id = budget.id;
                        budgetLigne.nature_id = row["nature_id"].ToString();
                        budgetLigne.base_repart = row["base_repart"].ToString();
                        budgetLigne.montant = montant + (montant*coeff/100);
                        budgetLigne.statut = (int)GlobalConstantes.StatutBudget.Brouillard;

                        if (!controller.InsertOrUpdate(budgetLigne))
                        {
                            throw new Exception("Budget Line");
                        }                            
                    }
                }
                else
                    if (rdVote.Checked)
                    {
                        var tablePrevExercice = ExerciceComptableController.getController().getExercicePrecedent(exercice_id);
                        if ( tablePrevExercice == null || tablePrevExercice.Rows.Count <= 0)
                        {
                            throw new Exception("Pas d'exercice précédent");
                        }
                        var prev_exercice_id = tablePrevExercice.Rows[0]["id"].ToString();

                        var prevu = BudgetLigneController.getController().getDescriptionLignesBudgetPrevu(prev_exercice_id);
                        
                        
                        if (prevu == null || prevu.Rows.Count <= 0)
                        {
                            throw new Exception("Aucune données pour le réalisé n-1");
                        }
                        var coeff = Convertir.ToDecimal(tbCoeff.Text);
                        foreach (DataRow row in prevu.Rows)
                        {
                            //                        SaisieFactureEntite facture = new SaisieFactureEntite(row);
                            var budgetLigne = new BudgetLigneEntite();
                            var montant = (decimal)row["montant"];
                            budgetLigne.budget_id = budget.id;
                            budgetLigne.nature_id = row["nature_id"].ToString();
                            budgetLigne.base_repart = row["base_repart"].ToString();
                            budgetLigne.montant = montant + (montant * coeff / 100);
                            budgetLigne.statut = (int)GlobalConstantes.StatutBudget.Brouillard;

                            if (!controller.InsertOrUpdate(budgetLigne))
                            {
                                throw new Exception("Insert Budget Line réalisé");
                            }
                        }

                    }
                trx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
