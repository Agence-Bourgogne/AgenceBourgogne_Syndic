using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerance.Formulaires.Common;
using Gerance.Formulaires.Locataires;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
using GeranceData.Entites;
using Npgsql;
namespace Gerance.Formulaires.Reglements
{
    public partial class ReglementsListeForm : Form
    {
        public ReglementsListeForm()
        {
            InitializeComponent();
        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }
        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowFindForm(new LocataireFindForm(), tbRefLocataire))
                tbRefLocataire_Validating(null, null);

        }
        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void dtDebut_Validating(object sender, CancelEventArgs e)
        {
            dtFin.Value = dtDebut.Value.AddMonths(1);
        }
        void FillDataGrid()
        {
            dataGridView.DataSource = ReglementsController.getController().getReglements(dtDebut.Value, dtFin.Value, tbRefLocataire.Text);

            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["locataire"].MinimumWidth = 120;
                cols["libelle"].MinimumWidth = 120;
                cols["ref_immeuble"].Width = 40;
                cols["ref_locataire"].Width = 50;
                cols["date_reglement"].Width = 70;
                cols["id"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
                dataGridView.ClearSelection();
            }

        }
        private void ReglementsListeForm_Load(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dt = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtDebut.Value = dt;
            dtFin.Value = dt.AddMonths(1).AddDays(-1);
            btnEnter.Width = 0;
            FillDataGrid();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            string CurrentId = "";
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                Console.WriteLine(row["id"]);
                CurrentId = row["id"].ToString();
                ReglementEntite reglement = ReglementsController.getController().getEntiteById(row["id"].ToString());
                LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", row["ref_locataire"].ToString());
                if (locataire == null)
                {
                    MessageBox.Show("Locataire Invalide");
                    return;
                }
                Decimal oldTotal_du = reglement.credit;

                ReglementPartielForm form = new ReglementPartielForm(reglement);
                this.Enabled = false;
                DialogResult result = form.ShowDialog();
                this.Enabled = true;

                if (result != DialogResult.OK)
                    return ;

                NpgsqlConnection cnx = Database.GetInstance();
                NpgsqlTransaction trx = cnx.BeginTransaction(); 

                try
                {

                    if (!ReglementsController.getController().InsertOrUpdate(reglement))
                        throw new Exception("Erreur Reglement");

                    Console.WriteLine("{0} : {1} {2}", locataire.total_du, oldTotal_du ,  reglement.credit);
                    locataire.total_du = locataire.total_du + oldTotal_du - reglement.credit;

                    if (!LocataireController.getController().InsertOrUpdate(locataire))
                        throw new Exception("Erreur Locataire");
                    //WorkflowEntite workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtReg.Value);
                    //WorkflowDetailController.getController().WriteRecord(workflow, reglement.id, "Reglement");
                    //WorkflowController.FireWorkflowChanged();

                    trx.Commit();
                    

//                    ShowFicheValues(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    trx.Rollback();
                }
                FillDataGrid();
                // Mantis 254
                if (!String.IsNullOrWhiteSpace(CurrentId))
                {
                    foreach (DataGridViewRow r in dataGridView.Rows)
                    {
                        DataRowView dbRow = (DataRowView)r.DataBoundItem;
                        if (dbRow != null)
                        {
                            if (dbRow["id"].ToString() == CurrentId)
                            {
                                Console.WriteLine("OK");
                                r.Selected = true;
                                dataGridView.FirstDisplayedScrollingRowIndex = r.Index;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id"};
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                ReglementsController.DeleteReglement(row["id"].ToString());
            }
            FillDataGrid();
        }
    }
}
