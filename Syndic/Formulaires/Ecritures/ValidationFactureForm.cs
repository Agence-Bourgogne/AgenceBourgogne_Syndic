using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using EspaceSyndic.Impressions.Facture;
using EspaceSyndic.Formulaires.OperationsGestion;
namespace EspaceSyndic.Formulaires.Ecritures
{
    public partial class ValidationFactureForm : Form
    {
        public ValidationFactureForm()
        {
            InitializeComponent();
        }

        private void ValidationFactureForm_Load(object sender, EventArgs e)
        {
//            ControlsWindows.FillComboFromParams(cbType, "TYPE_VALIDATION", "nom");
            FillDataGrid();
//            this.MinimumSize = this.MaximumSize = this.Size;

        }

        private void FillDataGrid()
        {
            DataTable source = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.Facture, false);
            dataGridViewLiasse.DataSource = source;
            if (dataGridViewLiasse.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridViewLiasse.Columns;
                cols["id"].Visible = false;
                cols["audit_created"].Visible = false;
                cols["audit_created_by"].Visible = false;
                cols["audit_updated"].Visible = false;
                cols["audit_updated_by"].Visible = false;
                cols["audit_created"].Visible = false;
                cols["statut"].Visible = false;
                cols["type_ecriture"].Visible = false;
                cols["valider"].MinimumWidth = cols["valider"].Width = 20;
                cols["valider"].ReadOnly = false;

                ControlsWindows.ToTitleCase(cols);
            }
        }

        private void dataGridViewLiasse_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLiasse.SelectedRows.Count < 1)
                return;
            DataRowView rowGrid = (DataRowView) dataGridViewLiasse.SelectedRows[0].DataBoundItem;
            string liasse_id = rowGrid["id"].ToString();
            DataTable source = SaisieFactureController.getController().getListeFactures(liasse_id);
            dataGridViewEcriture.DataSource = source;
            if (source != null)
            {
                DataGridViewColumnCollection cols = dataGridViewEcriture.Columns;
                cols["id"].Visible = false;
                cols["immeuble_id"].Visible = false;
                cols["fournisseur_id"].Visible = false;
                cols["nature_id"].Visible = false;
                cols["liasse_id"].Visible = false;
                //cols["immeuble_ref"].Visible = false;
                //cols["nature_ref"].Visible = false;
                //cols["fournisseur_ref"].Visible = false;
                cols["date_operation"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
            }
            if (dataGridViewEcriture.Rows.Count > 0)
                dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            else
                dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewLiasse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("{0}:{1}", e.RowIndex, e.ColumnIndex);
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = dataGridViewLiasse.Rows[e.RowIndex];
                if (row.Cells[e.ColumnIndex].Value == null)
                    row.Cells[e.ColumnIndex].Value = false;
                row.Cells[e.ColumnIndex].Value = !((bool)row.Cells[e.ColumnIndex].Value);
            }
        }
        private void btnValid_Click(object sender, EventArgs e)
        {
//            bool bAllValide = true;
            List<string> liasses = new List<string>();

            foreach (DataGridViewRow rowGrid in dataGridViewLiasse.Rows)
            {
                if (rowGrid.Cells["valider"].Value != null)
                    if (((bool)rowGrid.Cells["valider"].Value) == true)
                    {
                        DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                        string liasse_id = row["id"].ToString();
                        //if (!OperationController.getController().ValidateFacture(liasse_id))
                        //{
                        //    bAllValide = false;
                        //    break;
                        //}
                        liasses.Add(liasse_id);
//                        Console.WriteLine(row["id"]);
                    }
            }
            if ( liasses.Count < 1)
            {
                MessageBox.Show("Pas de liasse à valider");
            }
            else
                if (OperationController.getController().ValidateFacture(liasses))
                {
    //                MessageBox.Show("Validation OK");

                    try
                    {
                        ImprimerListeFacturationForm form = new ImprimerListeFacturationForm(liasses);
                        form.ShowDialog();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            FillDataGrid();
        }

        private void dataGridViewEcriture_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
//                Console.WriteLine(row["id"]);
                DetailFactureForm form = new DetailFactureForm(row["id"].ToString());
                form.ShowDialog();
            }
        }
    }
}
