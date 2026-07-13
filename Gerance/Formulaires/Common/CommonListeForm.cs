using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Common
{
    public partial class CommonListeForm : Form
    {
        bool bLoading;
        protected string regKey = "";
        public CommonListeForm()
        {
            InitializeComponent();
        }

        private void CommonListeForm_Load(object sender, EventArgs e)
        {
            //if (ckValidOnly.Visible)
            //{
            //    Point pt = dataGridView.Location;
            //    pt.Y += 10;
            //    dataGridView.Location = pt;
            //    dataGridView.Height -= 10;
            //}
            FillDataGrid();
        }
        protected virtual void HideAndResizeColumns( DataGridViewColumnCollection  cols)
        {
            cols["id"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
        }
        protected virtual DataTable getFormListe()
        {
            return null;
        }
        protected virtual void FillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = getFormListe();
            if (dataGridView.DataSource != null)
            {
                var cols = dataGridView.Columns;
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
                var index = (int) CommonRegistry.getRegistryValue(regKey, col.Name, -1);
                if (index != -1)
                    col.DisplayIndex = index;
            }
        }

        protected virtual void btnNew_Click(object sender, EventArgs e)
        {
            ShowFicheForm(null);
        }

        protected virtual void ShowForm(Form form)
        {
            Enabled = false;
            form.ShowDialog();
            Enabled = true;
            FillDataGrid();
        }

        protected virtual void btnFiche_Click(object sender, EventArgs e)
        {
            ShowFicheFromSelectedRow();
        }

        protected virtual void ShowFicheForm(string entite_id)
        {
            FillDataGrid();
        }
        protected virtual void ShowFicheFromSelectedRow()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row =  (DataRowView) dataGridView.SelectedRows[0].DataBoundItem;
                if (row != null)
                    ShowFicheForm(row["id"].ToString());
            }
        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            ShowFicheFromSelectedRow();
        }

        protected virtual List<string> getExportColsToHide()
        {
            return  new List<string> { "id", "audit_created", "audit_created_by", "audit_updated", "audit_updated_by" };
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            BaseApplication.DataGridToExcel(dataGridView, getExportColsToHide());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!bLoading)
            {
                Console.WriteLine(sender);
                Console.WriteLine("{0}:{1}", e.Column.Name, e.Column.DisplayIndex);
                if ( regKey != "" )
                    CommonRegistry.setRegistryValue(regKey, e.Column.Name, e.Column.DisplayIndex);
            }
        }

        protected virtual void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
