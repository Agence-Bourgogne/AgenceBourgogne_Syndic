using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using SyndicData.Controller;
using SyndicData.Entites;

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
                var rowIndex = exercices.Rows.Add(
                    exerciceComptable.ReferenceImmeuble,
                    exerciceComptable.ReferenceExercice,
                    exerciceComptable.DateDebutExercice,
                    exerciceComptable.DateFinExercice);

                exercices.Rows[rowIndex].Tag = exerciceComptable;
            }
        }

        private void editerBtn_Click(object sender, EventArgs e)
        {
            using var dialog = new CommonOpenFileDialog();

            dialog.IsFolderPicker = true;
            dialog.Title = "Sélectionnez le dossier de destination";

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                MessageBox.Show(
                    "Aucune destination sélectionnée.",
                    "Destination",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var dossierDestination = new DirectoryInfo(dialog.FileName);

            if (!dossierDestination.Exists)
            {
                MessageBox.Show(
                    "Destination inexistante sélectionnée.",
                    "Destination",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var exercicesSelectionnes = exercices.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.Tag as ExerciceComptableSelector)
                .Where(x => x != null)
                .ToList();

            if (exercicesSelectionnes.Count == 0)
            {
                MessageBox.Show(
                    "Aucun exercice sélectionné.",
                    "Grand Livre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var idsExercices = exercicesSelectionnes.Select(ex => ex.IdExercice);

            GenerateurGrandLivre.GenerateurGrandLivre.GénérerDans(dossierDestination, idsExercices);
        }
    }
}
