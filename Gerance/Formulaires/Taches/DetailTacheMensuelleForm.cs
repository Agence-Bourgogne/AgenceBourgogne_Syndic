using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
namespace Gerance.Formulaires.Taches
{
    public partial class DetailTacheMensuelleForm : Common.BaseFicheForm
    {
        public DetailTacheMensuelleForm()
        {
            InitializeComponent();
        }
        public DetailTacheMensuelleForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
            btnFirst.Visible = btnLast.Visible = btnPrev.Visible = btnNext.Visible = false;
        }

        WorkflowEntite entite;
        protected override void setFicheValues(CommonProjectsPartners.Entites.AbstractBaseEntite newEntite)
        {
            entite = (WorkflowEntite)newEntite;
            if (entite != null )
            {
                tbNom.Text = entite.nom;
                tbCreat.Text = entite.audit_created.ToString("g");
                tbCreatBy.Text = ControlsWindows.userComputer(entite.audit_created_by);
                if (entite.audit_updated_by != "")
                {
                    tbUpdate.Text = entite.audit_updated.ToString("g");
                    tbUpdateBy.Text = ControlsWindows.userComputer(entite.audit_updated_by);
                }
                switch (entite.reference)
                {
                    case 0: ShowDetailSoldesLocataires(entite.id);
                        break;
                    case 1:
                        ShowDetailFactures(entite.id);
                        break;
                    case 6:
                    case 2: ShowDetailSoldesProprietaires(entite.id);
                        break;
                    case 3: ShowDetailsReglements(entite.id);
                        break;
                    case 4:
                    case 5: ShowDetailImpressionQuittance(entite.id);
                        break;
                }
            }
            dataGridView.ClearSelection();
            //base.setFicheValues(newEntite);
        }

        
        private void ShowDetailFactures(string entite_id)
        {
            dataGridView.DataSource = WorkflowDetailController.getController().getListeDetailFacturesProprietaires(entite_id);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 60;
                cols["statut"].Width = 20;
                cols["debit"].Width = 50;
                cols["credit"].Width = 50;
                cols["utilisateur"].HeaderText = "par";
                cols["date_reference"].Width = 100;
                cols["proprietaire"].Width = 120;
                cols["utilisateur"].Width = 120;
                ControlsWindows.ToTitleCase(cols);
            }
        }
        protected override CommonProjectsPartners.Entites.AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return WorkflowController.getController().getEntiteById(entite_id);
        }

        private void ShowDetailSoldesProprietaires(string entite_id)
        {
            dataGridView.DataSource = WorkflowDetailController.getController().getListeDetailSoldesProprietaires(entite_id);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 60;
                cols["utilisateur"].HeaderText = "par";
                cols["date_reference"].Width = 100;
                ControlsWindows.ToTitleCase(cols);
            }
        }
        private void ShowDetailImpressionQuittance(string entite_id)
        {
            dataGridView.DataSource = WorkflowDetailController.getController().getListeDetailImpressionQuittance(entite_id);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 60;
                cols["utilisateur"].HeaderText = "par";
                cols["date_reference"].Width = 100;
                ControlsWindows.ToTitleCase(cols);
            }
        }
        private void ShowDetailSoldesLocataires(string entite_id)
        {
            dataGridView.DataSource = WorkflowDetailController.getController().getListeDetailSoldesLocataires(entite_id);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 60;
                cols["total_du"].Width = 80;
                cols["utilisateur"].HeaderText = "par";
                cols["date_reference"].Width = 100;
                ControlsWindows.ToTitleCase(cols);
            }
        }
        private void ShowDetailsReglements(string entite_id)
        {
            dataGridView.DataSource = WorkflowDetailController.getController().getListeDetailReglements(entite_id);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 60;
                cols["credit"].Width = 80;
                cols["utilisateur"].HeaderText = "par";
                cols["date_reference"].Width = 100;
                ControlsWindows.ToTitleCase(cols);
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (entite != null)
            {
                DataGridViewColumn col = dataGridView.Columns[e.ColumnIndex];
                if (col.Name == "utilisateur" )
                {
                    e.Value = ControlsWindows.userComputer(e.Value.ToString());
                }
                if (col.Name == "statut")
                {
                    if ((int)e.Value == 9)
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
