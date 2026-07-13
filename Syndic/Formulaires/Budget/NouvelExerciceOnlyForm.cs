using System;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Formulaires.Budget
{
    public partial class NouvelExerciceOnlyForm : Form
    {
        string immeuble_id = "";
        public string exercice_id = "";
        
        public NouvelExerciceOnlyForm()
        {
            InitializeComponent();
        }

        public NouvelExerciceOnlyForm(string immeuble_id)
        {
            InitializeComponent();
            this.immeuble_id = immeuble_id;
        }

        private void NouvelExerciceOnlyForm_Load(object sender, EventArgs e)
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
                if (GenerateBudget())
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
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();
            try
            {
                ExerciceComptableEntite exercice = null;
                if (exercice_id != "")
                    exercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
                if (exercice == null)
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
                    if (!BudgetController.getController().InsertOrUpdate(budget))
                    {
                        throw new Exception("New budget");
                    }
                }
                //this.exercice_id = budget.id;

                var controller = BudgetLigneController.getController();


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
