using System;
using System.Windows.Forms;
using SyndicData.Controller;

namespace EspaceSyndic.Impressions.RelevesComptes
{
    public partial class GrandLivreForm : Form
    {
        public GrandLivreForm()
        {
            InitializeComponent();

            anneeMinimale.ValueChanged += AnneeMinimaleValueChanged;
            anneeMaximale.ValueChanged += AnneeMaximaleValueChanged;

            exercices.Columns.Add("immeuble", "Immeuble");
            exercices.Columns.Add("exercice", "Exercice");
            exercices.Columns.Add("debut_exercice", "Début de l'exercice");
            exercices.Columns.Add("fin_exercice", "Fin de l'exercice");

            exercices.AllowUserToAddRows = false;
            exercices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            exercices.MultiSelect = true;
            exercices.SelectionChanged += ExercicesOnSelectionChanged;
            exercices.ReadOnly = true;

            anneeMinimale.Value = DateTime.Now.Year - 1;
            anneeMaximale.Value = DateTime.Now.Year;

            OnAnyYearChanged();
        }

        private void ExercicesOnSelectionChanged(object sender, EventArgs e)
        {
            var count = exercices.SelectedRows.Count;
            editerBtn.Enabled = count > 0;

            editerBtn.Text = count == 1 
                ? @"Éditer un Grand Livre" 
                : $@"Éditer {count} Grands Livres";
        }

        private void AnneeMinimaleValueChanged(object sender, EventArgs e)
        {
            var minimumMax = anneeMinimale.Value + 1;

            if (anneeMaximale.Minimum != minimumMax)
                anneeMaximale.Minimum = minimumMax;

            OnAnyYearChanged();
        }

        private void AnneeMaximaleValueChanged(object sender, EventArgs e)
        {
            var maximumMin = anneeMaximale.Value - 1;

            if (anneeMinimale.Maximum != maximumMin)
                anneeMinimale.Maximum = maximumMin;

            OnAnyYearChanged();
        }

        private void OnAnyYearChanged()
        {
            var dateMinimale = new DateOnly(Convert.ToInt32(anneeMinimale.Value), 1, 1);
            var dateMaximale = new DateOnly(Convert.ToInt32(anneeMaximale.Value), 12, 31);

            var data = ExerciceComptableController
                .GetController()
                .GetExercicesIncludedInDates(dateMinimale, dateMaximale);

            exercices.Rows.Clear();

            foreach (var exerciceComptable in data)
            {
                exercices.Rows.Add(
                    exerciceComptable.ReferenceImmeuble,
                    exerciceComptable.ReferenceExercice,
                    exerciceComptable.DateDebutExercice,
                    exerciceComptable.DateFinExercice);
            }
        }

        private void editerBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Soon.");
        }
    }
}
