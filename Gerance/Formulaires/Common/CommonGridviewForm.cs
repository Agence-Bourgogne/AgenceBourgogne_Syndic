using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
namespace Gerance.Formulaires.Common
{
    public partial class CommonGridviewForm : Form
    {
        protected bool bLoading;
        protected string regKey = "";
        public CommonGridviewForm()
        {
            InitializeComponent();
        }
        protected virtual void InitializeCombos()
        {

        }
        private void CommonGridviewForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            InitializeCombos();
            FillDataGrid();
        }
        protected virtual void btnFiche_Click(object sender, EventArgs e)
        {
            ShowFicheFromSelectedRow();
        }
        protected virtual DataTable getFormListe()
        {
            return null;
        }
        protected virtual void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {

            if (cols["id"] != null) cols["id"].Visible = false;
            if (cols["audit_created"] != null) cols["audit_created"].Visible = false;
            if (cols["audit_created_by"] != null) cols["audit_created_by"].Visible = false;
            if (cols["audit_updated"] != null) cols["audit_updated"].Visible = false;
            if (cols["audit_updated_by"] != null) cols["audit_updated_by"].Visible = false;
        }

        protected virtual void FillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = getFormListe();
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                HideAndResizeColumns(cols);
                //                cols["numero_lot"].DisplayIndex = 2;
                ControlsWindows.ToTitleCase(cols);
                OrderColumns();
            }
            bLoading = false;
        }
        protected virtual void OrderColumns()
        {
            if (regKey == "")
                return;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                int index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
                if (index != -1)
                    col.DisplayIndex = index;
            }
        }

        protected virtual void ShowFicheForm(string entite_id)
        {
            FillDataGrid();
        }
        protected virtual void ShowFicheFromSelectedRow()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (row != null)
                    ShowFicheForm(row["id"].ToString());
            }
        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            ShowFicheFromSelectedRow();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            CommonProjectsPartners.Utils.ControlsWindows.FocusNextTabbedControl(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);

        }
        private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!bLoading)
            {
                if (regKey != "")
                    CommonRegistry.setRegistryValue(regKey, e.Column.Name, e.Column.DisplayIndex);
            }
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        protected virtual void ShowForm(Form form)
        {
            this.Enabled = false;
            form.ShowDialog();
            this.Enabled = true;
            FillDataGrid();
        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }

        protected virtual void dataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }

    }
}
