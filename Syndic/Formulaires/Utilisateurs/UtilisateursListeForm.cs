using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Utilisateurs;

public partial class UtilisateursListeForm : Form
{
    public UtilisateursListeForm()
    {
        InitializeComponent();
    }

    private void UtilisateursListeForm_Load(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private static void HideAndResizeColumns(DataGridViewColumnCollection cols)
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

    private void FillDataGrid()
    {
        dataGridView.DataSource = GetFormListe();
        if (dataGridView.DataSource != null)
        {
            var cols = dataGridView.Columns;
            HideAndResizeColumns(cols);
            ControlsWindows.ToTitleCase(cols);
        }
    }

    private static DataTable GetFormListe()
    {
        return UsersController.getController().getListeUsers();
    }

    private void ShowFicheForm(string entiteId)
    {
        var form = new UtilisateurFicheForm(entiteId);
        ShowForm(form);
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        ShowFicheForm(null);
    }

    private void ShowForm(Form form)
    {
        Enabled = false;
        form.ShowDialog();
        Enabled = true;
        FillDataGrid();
    }

    private void btnFiche_Click(object sender, EventArgs e)
    {
        ShowFicheFromSelectedRow();
    }

    private void ShowFicheFromSelectedRow()
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (row != null)
                ShowFicheForm(row["id"].ToString());
        }
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        ShowFicheFromSelectedRow();
    }

    private List<string> GetExportColsToHide()
    {
        return ["id", "audit_created", "audit_created_by", "audit_updated", "audit_updated_by"];
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        BaseApplication.DataGridToExcel(dataGridView, GetExportColsToHide());
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
        Close();
    }
}