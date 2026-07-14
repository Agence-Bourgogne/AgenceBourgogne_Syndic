using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Fournisseur;

public partial class ListeFournisseurForm : Form
{
    private readonly FournisseurController controller = new();
    private bool bLoading;
    private readonly string regKey;

    public ListeFournisseurForm()
    {
        InitializeComponent();
        regKey = "listes\\fournisseurs";
    }
    private void ListeFournisseurForm_Load(object sender, EventArgs e)
    {
        FillDataGrid();
    }
    private void FillDataGrid()
    {
        bLoading = true;
        if ( ckActif.Checked )
            dataGridView.DataSource = controller.GetList();
        else
            dataGridView.DataSource = controller.GetAllEntite();
        if (dataGridView.DataSource != null)
        {
            var cols = dataGridView.Columns;

            cols["id"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;

            cols["codepostal"].HeaderText = "Code Postal";
            cols["numsecu"].HeaderText = "N° Sécu";
            cols["numurs"].HeaderText = "N° Urssaf";
            cols["compte_banque"].HeaderText = "N° Compte";
            cols["codeape"].HeaderText = "Code Ape";
            cols["reglement"].HeaderText = "Règlement";

            ControlsWindows.ToTitleCase(cols);
            OrderColumns();
        }
        else
            Close();
        updateEditMode(false);
        bLoading = false;
    }

    private void OrderColumns()
    {
        if (regKey == "")
            return;
        foreach (DataGridViewColumn col in dataGridView.Columns)
        {
            var index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
            if (index != -1)
                col.DisplayIndex = index;
        }
    }
    private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    {
        if (!bLoading)
        {
            if (regKey != "")
                CommonRegistry.setRegistryValue(regKey, e.Column.Name, e.Column.DisplayIndex);
        }
    }

    private void ListeFournisseurForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!controller.SaveList((DataTable)dataGridView.DataSource))
            e.Cancel = true;
    }
    private void BtnSave_Click(object sender, EventArgs e)
    {
        controller.SaveList((DataTable)dataGridView.DataSource, false);
        updateEditMode(false);
    }

    private void BtnEdit_click(object sender, EventArgs e)
    {
        updateEditMode(true);
    }

    private void updateEditMode(bool bEdit)
    {
        dataGridView.AllowUserToAddRows = bEdit;
        dataGridView.ReadOnly = !bEdit;
        BtnSave.Enabled = bEdit;
    }

    private void editerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!dataGridView.ReadOnly)
        {
            return;
        }

        if (controller.SaveList((DataTable)dataGridView.DataSource))
        {
            updateEditMode(false);
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (row.Row.RowState != DataRowState.Detached)
            {
                edition(controller.getEntiteById(row.Row["id"].ToString()));
            }
        }
    }

    private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
    {
        edition(new FournisseurEntite());
    }

    private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }
    private void edition(FournisseurEntite entite)
    {
        try
        {
            updateEditMode(false);
            var form = new FicheFournisseurForm();

            form.entite = entite;
            if ( !"".Equals(entite.id))
                form.entite = controller.getEntiteById(entite.id);

            form.Icon = Icon;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ControlBox = true;
            form.Show();
                
            //dataGridView.DataSource = controller.GetList();
            FillDataGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ( Convert.ToInt16(e.KeyChar) == 32 )
        {
            e.Handled = true;
            editerToolStripMenuItem_Click(null, null);
        }
        if (Convert.ToInt16(e.KeyChar) == 27)
        {
            e.Handled = true;
            updateEditMode(false);
        }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string> { "id", "note", "declaration", "vente", "drapeau", "commerce", "audit_created_by", "audit_created", "audit_updated", "audit_updated_by" };
        BaseApplication.DataGridToExcel(dataGridView, colsToHide);
    }

    private void btnFiltre_Click(object sender, EventArgs e)
    {
        var form = new FindFournisseurForm();
        var source = new BindingSource();// (BindingSource)dataGridView.DataSource;
        source.DataSource = dataGridView.DataSource;
        if (DialogResult.Cancel != form.ShowDialog())
        {
            var action = (int)CommonRegistry.getRegistryValue("Parametres", "ActionFiltre", 0);
            if (action == 1)
                source.Filter = $"reference = '{form.reference}'";
            else
            {
                var fiche = new FicheFournisseurForm();
                fiche.entite = controller.getEntiteFromField("reference", form.reference);
                fiche.ShowDialog();
            }
        }
        else
            source.Filter = "";
    }

    private void ckActif_CheckedChanged(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        var row = dataGridView.Rows[e.RowIndex];
        if ((int)row.Cells["statut"].Value == 9)
        {
            dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;
        }
    }

}