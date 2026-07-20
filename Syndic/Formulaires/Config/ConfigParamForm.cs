using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Config;

public partial class ConfigParamForm : Form
{
    private ParametreEntite groupe;
    public string groupe_selected = "";
    private bool initialized;
    public string param_selected = "";

    public ConfigParamForm()
    {
        InitializeComponent();
    }

    private void tabPage1_Enter(object sender, EventArgs e)
    {
        //Console.WriteLine(tabControl.SelectedIndex);
    }

    private void cbGroupe_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Console.WriteLine(cbGroupe.SelectedValue);
        if (!initialized)
            return;
        var row = ((DataRowView)cbGroupe.SelectedItem).Row;
        ParametreController.controller.SaveList((DataTable)dataGridView.DataSource);
        groupe = new ParametreEntite(row);
        dataGridView.DataSource = ParametreController.controller.getListFromEntiteGroupe(groupe);
        var cols = dataGridView.Columns;
        cols["id"].Visible = false;
        cols["groupe"].Visible = false;
        cols["code"].Visible = false;
        cols["nom"].Visible = false;
        cols["param_1"].Visible = false;
        cols["param_2"].Visible = false;
        cols["param_3"].Visible = false;
        cols["iparam_1"].Visible = false;
        cols["iparam_2"].Visible = false;
        cols["iparam_3"].Visible = false;
        cols["audit_created"].Visible = false;
        cols["audit_created_by"].Visible = false;
        cols["audit_updated"].Visible = false;
        cols["audit_updated_by"].Visible = false;
        var columnsDef = groupe.param_1.Split(',');
        foreach (var coldef in columnsDef)
        {
            var paramCol = coldef.Replace(" as ", ":").Split(':');
            var colName = paramCol[0].ToLower().Trim();
            if (cols[colName] == null) continue;
            cols[colName].Visible = true;
            if (paramCol.Length > 1)
                cols[colName].HeaderText = paramCol[1];
            else
                cols[colName].HeaderText = colName;
        }

        ControlsWindows.ToTitleCase(cols);

        if (param_selected != "")
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                var data_row = (DataRowView)rowGrid.DataBoundItem;
                if (data_row != null)
                    if (data_row["code"].ToString() == param_selected)
                    {
                        dataGridView.ClearSelection();
                        rowGrid.Selected = true;
                        break;
                    }
            }
    }

    private void ConfigParamForms_Load(object sender, EventArgs e)
    {
        ParametresDB.FillComboFromParams(cbGroupe, "HDR_GROUPE", "nom", "code");

        if (groupe_selected != "") cbGroupe.SelectedValue = groupe_selected;
        cbGroupe_SelectedIndexChanged(null, null);
        initialized = true;
    }

    private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
    {
//            Console.WriteLine("new");
        e.Row.Cells["groupe"].Value = groupe.code;
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        ParametreController.controller.SaveList((DataTable)dataGridView.DataSource, false);
    }

    private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        Console.WriteLine(e.ColumnIndex);
        var row = dataGridView.Rows[e.RowIndex];
        if (row != null)
        {
            var form = new ZoomParamForm();
            form.txtParam = row.Cells[e.ColumnIndex].Value.ToString();
            if (form.ShowDialog() == DialogResult.OK)
            {
                row.Cells[e.ColumnIndex].Value = form.txtParam;
                var ctx = new DataGridViewDataErrorContexts();
                dataGridView.CommitEdit(ctx);
                if (((DataTable)dataGridView.DataSource).GetChanges() != null)
                    Console.WriteLine(((DataTable)dataGridView.DataSource).GetChanges().Rows.Count);
            }
        }
    }

    private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var row = dataGridView.Rows[e.RowIndex];
        if (row != null)
            Console.WriteLine(row.Cells[e.ColumnIndex].Value);
        if (((DataTable)dataGridView.DataSource).GetChanges() != null)
            Console.WriteLine(((DataTable)dataGridView.DataSource).GetChanges().Rows.Count);
    }
}