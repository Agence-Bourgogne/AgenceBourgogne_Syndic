using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
namespace EspaceSyndic.Formulaires.Utilisateurs
{
    public partial class UtilisateursListeForm : Form
    {
        bool bLoading;
        protected string regKey = "";
        public UtilisateursListeForm()
        {
            InitializeComponent();
        }

        private void UtilisateursListeForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        protected void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["id"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;
            cols["roles_id"].Visible = false;
            cols["password"].Visible = false;
            cols["resources_id"].Visible = false;
        }

        protected void FillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = getFormListe();
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                HideAndResizeColumns(cols);
                ControlsWindows.ToTitleCase(cols);
                OrderColumns();
            }
            bLoading = false;
        }
        protected  DataTable getFormListe()
        {
            return UsersController.getController().getListeUsers();
        }
        protected void ShowFicheForm(string entite_id)
        {
            UtilisateurFicheForm form = new UtilisateurFicheForm(entite_id);
            ShowForm(form);
        }
        protected void OrderColumns()
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ShowFicheForm(null);
        }

        protected void ShowForm(Form form)
        {
            this.Enabled = false;
            form.ShowDialog();
            this.Enabled = true;
            FillDataGrid();
        }

        protected void btnFiche_Click(object sender, EventArgs e)
        {
            ShowFicheFromSelectedRow();
        }

        protected void ShowFicheFromSelectedRow()
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

        protected List<string> getExportColsToHide()
        {
            return new List<string> { "id", "audit_created", "audit_created_by", "audit_updated", "audit_updated_by" };
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            BaseApplication.DataGridToExcel(dataGridView, getExportColsToHide());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
