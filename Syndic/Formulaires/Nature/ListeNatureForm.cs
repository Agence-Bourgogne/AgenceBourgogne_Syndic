using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Nature;

public partial class ListeNatureForm : Form
{
    public readonly NatureController controller = new();

    public ListeNatureForm()
    {
        InitializeComponent();
    }

    private void ListeNatureForm_Load(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void FillDataGrid()
    {
        if (ckActif.Checked)
            dataGridView.DataSource = controller.GetList();
        else
            dataGridView.DataSource = controller.GetAllEntite();
        if (dataGridView.DataSource != null)
        {
            var cols = dataGridView.Columns;
            //if ( cols["type_charge_cb"] == null )
            ParametresDB.bindGridComboColumn(cols, "TYPECHARGE", "type_charge");
            cols["id"].Visible = false;
            cols["nom"].MinimumWidth = 140;
            cols["type_charge_cb"].MinimumWidth = 80;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;
            //cols["charge_locative"].Width = 40;
            //cols["declaration"].Width = 40;
            cols["budgetisable"].MinimumWidth = 40;
            ControlsWindows.ToTitleCase(cols);
        }

        BtnSave.Enabled = false;
    }

    private void ListeNatureForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!controller.SaveList((DataTable)dataGridView.DataSource))
            e.Cancel = true;
    }

    private void editionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (controller.SaveList((DataTable)dataGridView.DataSource))
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (row.Row.RowState != DataRowState.Detached)
                edition(new NatureEntite(row.Row));
        }
    }

    private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
    {
        edition(new NatureEntite());
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        updateEditMode(true);
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (controller.SaveList((DataTable)dataGridView.DataSource)) updateEditMode(false);
    }

    private void updateEditMode(bool bEdit)
    {
        dataGridView.AllowUserToAddRows = bEdit;
        //            dataGridView.AllowUserToDeleteRows = bEdit;
        dataGridView.ReadOnly = !bEdit;
        BtnSave.Enabled = bEdit;
    }

    private void edition(NatureEntite entite)
    {
        try
        {
            var form = new FicheNatureForm();
            form.entite = entite;
            form.ShowDialog();
            dataGridView.DataSource = controller.GetList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Convert.ToInt16(e.KeyChar) == 32)
        {
            e.Handled = true;
            editionToolStripMenuItem_Click(null, null);
        }

        if (Convert.ToInt16(e.KeyChar) == 27)
        {
            e.Handled = true;
            updateEditMode(false);
        }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string>
            { "id", "audit_created_by", "audit_created", "audit_updated", "audit_updated_by" };
        BaseApplication.DataGridToExcel(dataGridView, colsToHide);
    }

    private void btnFiltre_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm();
        var source = new BindingSource(); // (BindingSource)dataGridView.DataSource;
        source.DataSource = dataGridView.DataSource;
        if (DialogResult.Cancel != form.ShowDialog())
        {
            var action = (int)CommonRegistry.getRegistryValue("Parametres", "ActionFiltre", 0);
            if (action == 1)
            {
                source.Filter = $"reference = '{form.reference}'";
            }
            else
            {
                var fiche = new FicheNatureForm();
                fiche.entite = controller.getEntiteFromField("reference", form.reference);
                fiche.ShowDialog();
            }
        }
        else
        {
            source.Filter = "";
        }
    }

    private void ckActif_CheckedChanged(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        var row = dataGridView.Rows[e.RowIndex];
        if ((int)row.Cells["statut"].Value == 9)
            dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
    }
}