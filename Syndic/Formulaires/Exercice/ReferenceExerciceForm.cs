using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
namespace EspaceSyndic.Formulaires.Exercice
{
    public partial class ReferenceExerciceForm : Form
    {
        ExerciceComptableEntite exercice;
        bool bLoading = false;

        public ReferenceExerciceForm()
        {
            InitializeComponent();
        }
        //public ReferenceExerciceForm(ExerciceComptableEntite exercice)
        //{
        //    InitializeComponent();
        //    this.exercice = exercice;
        //}
        public ReferenceExerciceForm(ImmeubleEntite immeuble)
        {
            InitializeComponent();

            exercice = immeuble.ExerciceCourant;
            if (exercice == null)
            {
                exercice = new ExerciceComptableEntite();
                exercice.immeuble_id = immeuble.id;

            }
        }

        private void ReferenceExerciceForm_Load(object sender, EventArgs e)
        {
            if ( exercice != null )
            {
                if (exercice.id != "")
                {
                    dtDeb.ValueChanged -= dtDeb_ValueChanged;
                    dtFin.Value = exercice.date_fin;
                    dtDeb.Value = exercice.date_deb;
                    dtDeb.ValueChanged += dtDeb_ValueChanged;
                }
                tbReference.Text = exercice.reference;
                fillDataGrid();
            }
            else
            {
                dtDeb_ValueChanged(null, null);
            }
        }

        private void fillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = ExerciceComptableController.getController().getListExerciceFromImmeuble(exercice.immeuble_id);
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols["id"].Visible = false;
            cols["budget_id"].Visible = false;
            cols["statut"].Visible = false;
            cols["statut_budget"].Visible = false;
            cols["montant"].Visible = false;
            ControlsWindows.ToTitleCase(cols);

            dataGridView.ClearSelection();
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                DataRowView row = (DataRowView) rowGrid.DataBoundItem;
                if (row["id"].ToString() == exercice.id)
                {
                    rowGrid.Selected = true;
                    dataGridView_SelectionChanged(null, null);
                    break;
                }
            }
            bLoading = false;
        }

        private void dtDeb_ValueChanged(object sender, EventArgs e)
        {
            dtFin.Value = dtDeb.Value.AddYears(1).AddDays(-1);
            tbReference.Text = dtDeb.Value.Year.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl == btnOk)
            {
                if (UpdateExercice())
                    this.Close();
            }
            else
                ControlsWindows.FocusNextTabbedControl(this);
        }
        private bool UpdateExercice()
        {
            bool bResult = false;

            if (exercice == null)
                exercice = new ExerciceComptableEntite();

            exercice.reference = exercice.nom = tbReference.Text;
            exercice.date_deb = dtDeb.Value;
            exercice.date_fin = dtFin.Value;
            bResult = ExerciceComptableController.getController().InsertOrUpdate(exercice);

            ImmeubleEntite immeuble = ImmeubleController.getController().getEntiteById(exercice.immeuble_id);
            if (immeuble != null)
            {
                immeuble.datecloture = exercice.date_fin;
                bResult &= ImmeubleController.getController().InsertOrUpdate(immeuble);
            }
            return bResult;
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            ExerciceComptableEntite entite = ExerciceComptableController.getController().getEntiteById(row["id"].ToString());

            if ( entite != null )
            {
                int statut = Convertir.ToInt(entite.statut);
                if (statut == (int) GlobalConstantes.StatutExercice.Clos)
                {
                    MessageBox.Show("Exercice Cloturé impossible de le supprimer");
                    return;
                }
                ExerciceComptableController.getController().deleteEntite(entite);
                fillDataGrid();
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!bLoading && dataGridView.SelectedRows.Count > 0 )
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                ExerciceComptableEntite entite = ExerciceComptableController.getController().getEntiteById(row["id"].ToString());
                tbReference.Text = entite.reference;
                dtDeb.Value = entite.date_deb;
                dtFin.Value = entite.date_fin;
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bLoading && dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                exercice = ExerciceComptableController.getController().getEntiteById(row["id"].ToString());
                UpdateExercice();
                fillDataGrid();
            }
        }
    }
}
