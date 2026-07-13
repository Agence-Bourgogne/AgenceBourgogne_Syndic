using System;
using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;

namespace Gerance.Formulaires.Taches
{
    public partial class SuiviTacheMensuelleForm : Common.CommonGridviewForm
    {
        public SuiviTacheMensuelleForm()
        {
            InitializeComponent();
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);
        }
        protected override void InitializeCombos()
        {
            dateDebut.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);
        }
        protected override DataTable getFormListe()
        {
            return WorkflowController.getController().getMonthListWorkflow(dateDebut.Value);
        }
        protected override void FillDataGrid()
        {
            base.FillDataGrid();
            dataGridView.ClearSelection();
        }
        protected override void ShowFicheForm(string entite_id)
        {
            ShowForm ( new DetailTacheMensuelleForm(entite_id));
            FillDataGrid();
        }

        private void dateDebut_ValueChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void SuiviTacheMensuelleForm_Load(object sender, EventArgs e)
        {
            WorkflowController.getController().WorkFlowChanged += SuiviTacheMensuelleForm_WorkFlowChanged;
        }

        void SuiviTacheMensuelleForm_WorkFlowChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            cols["reference"].Visible = false;
            cols["statut"].Visible = false;
            cols["revision"].DisplayIndex = cols.Count - 1;
            cols["revision"].Width=40;
            cols["nombre_elements"].Width = 40;
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView.Columns[e.ColumnIndex];
            if (col.Name == "utilisateur")
            {
                e.Value = CommonProjectsPartners.Utils.ControlsWindows.userComputer(e.Value.ToString());
            }
        }

        private void SuiviTacheMensuelleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WorkflowController.getController().WorkFlowChanged -= SuiviTacheMensuelleForm_WorkFlowChanged;
        }
    }
}
