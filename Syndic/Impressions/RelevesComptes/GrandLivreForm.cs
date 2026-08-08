using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using SyndicData.Controller;
using SyndicData.Entites.ExerciceComptable;

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
                    exerciceComptable.NomImmeuble,
                    exerciceComptable.Reference,
                    exerciceComptable.DateDebut,
                    exerciceComptable.DateFin);

                exercices.Rows[rowIndex].Tag = exerciceComptable;
            }
        }

        private async void editerBtn_Click(object sender, EventArgs e)
        {
            editerBtn.Enabled = false;
            exercices.Enabled = false;
            anneeMinimale.Enabled = false;
            anneeMaximale.Enabled = false;
            progressExport.Visible = true;

            try
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

                BringToFront();
                Activate();

                var exercicesSelectionnes = exercices.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => row.Tag as ExerciceComptableSelector)
                    .Where(x => x != null)
                    .ToList();

                var nombreExercices = exercicesSelectionnes.Count;

                if (nombreExercices == 0)
                {
                    MessageBox.Show(
                        "Aucun exercice sélectionné.",
                        "Grand Livre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                progressExport.Minimum = 0;
                progressExport.Maximum = nombreExercices + 1;
                progressExport.Value = 1;

                var progress = new Progress<int>(i => progressExport.Value = i);

                await GenerateurGrandLivre.GenerateurPdfGrandLivre.GénérerDansAsync(
                    dossierDestination,
                    exercicesSelectionnes, 
                    progress);

                MessageBox.Show(
                    "Export terminé.",
                    "Grand Livre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk
                );
            }
            finally
            {
                editerBtn.Enabled = true;
                exercices.Enabled = true;
                anneeMinimale.Enabled = true;
                anneeMaximale.Enabled = true;
                progressExport.Visible = false;
            }
            
        }
    }
}
