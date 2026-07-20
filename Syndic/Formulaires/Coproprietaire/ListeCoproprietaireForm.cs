using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire;

public partial class ListeCoproprietaireForm : Form
{
    private readonly CoproprietaireController controller = new();
    private readonly string regKey;
    private bool bLoading;

    public ListeCoproprietaireForm()
    {
        InitializeComponent();
        regKey = "listes\\coproprietaires";
    }

    private void ListeCoproprietaireForm_Load(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void FillDataGrid()
    {
        bLoading = true;

        dataGridView.DataSource = ckActif.Checked ? controller.GetListCopro() : controller.GetListCopro(false);

        if (dataGridView.DataSource != null)
        {
            var cols = dataGridView.Columns;
            cols["id"].Visible = false;

            ParametresDB.bindGridComboColumn(cols, "CIVILITE", "codenvoi");
            ParametresDB.bindGridComboColumn(cols, "CODEENVOICOMPTE", "codenvcomp");
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;
            cols["telcomp"].Visible = false;
            cols["drapeau"].Visible = false;

            cols["codenvoi_cb"].HeaderText = "Civilite";

            cols["codepostal"].HeaderText = "Code Postal";
            cols["nomcomp"].HeaderText = "Agence";

            cols["codecomp"].HeaderText = "CP Agence";
            cols["adressecomp"].HeaderText = "Adrss Agence";
            cols["villecomp"].HeaderText = "Ville Agence";
            cols["codenvcomp_cb"].HeaderText = "Civilité Agence";

            cols["dateappel"].HeaderText = "Dernier Appel";
            cols["daterel1"].HeaderText = "Date Rel. 1";
            cols["daterel2"].HeaderText = "Date Rel. 2";
            cols["daterel3"].HeaderText = "Date Rel. 3";


            ControlsWindows.ToTitleCase(cols);
            OrderColumns();
        }
        else
        {
            Close();
        }

        BtnSave.Enabled = false;
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

    private void FormListClosing(object sender, FormClosingEventArgs e)
    {
        if (!controller.SaveList((DataTable)dataGridView.DataSource))
            e.Cancel = true;
    }

    private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
    {
        edition(new CoproprietaireEntite());
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        controller.SaveList((DataTable)dataGridView.DataSource, false);
        updateEditMode(false);
    }

    private void BtnEdit_Click(object sender, EventArgs e)
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
        ShowCopro(dataGridView.SelectedRows[0].Index);
    }

    private void ShowCopro(int index)
    {
        if (!dataGridView.ReadOnly) return;

        if (controller.SaveList((DataTable)dataGridView.DataSource))
        {
            var row = (DataRowView)dataGridView.Rows[index].DataBoundItem;
            if (row.Row.RowState != DataRowState.Detached)
                edition(new CoproprietaireEntite(row.Row));
        }
    }

    private void edition(CoproprietaireEntite entite)
    {
        try
        {
            var form = new FicheCoproprietaireForm();
            form.entite = entite;
            if (!"".Equals(entite.id))
                form.entite = controller.getEntiteById(entite.id);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Icon = Icon;
            form.ControlBox = true;
            form.Show();

            FillDataGrid();
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
            editerToolStripMenuItem_Click(null, null);
        }

        if (Convert.ToInt16(e.KeyChar) == 27)
        {
            e.Handled = true;
            updateEditMode(false);
        }

        if (e.KeyChar == 0x0D && dataGridView.ReadOnly)
        {
            e.Handled = true;
            var index = dataGridView.SelectedRows[0].Index;
            index = Math.Max(index - 1, 0);
            ShowCopro(index);
        }
    }

    private void ListeCoproprietaireForm_Shown(object sender, EventArgs e)
    {
        var cols = dataGridView.Columns;
        cols["codenvoi"].Width = 80;
        cols["codenvoi"].MinimumWidth = 80;
        dataGridView.Refresh();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var type = (int)CommonRegistry.getRegistryValue("export_copro", "type", 0);

        var table = CoproprietaireController.getController().getListeCoproForExport(type == 1);

        if (type == 1)
        {
            var colsToHide = new List<string>();
            BaseApplication.DataTableToExcel(table, colsToHide);
        }
        else
        {
            var fileName = (string)CommonRegistry.getRegistryValue("export_copro", "fichier",
                (object)"c:\\syndic_modeles\\csv\\copro_export.csv");
            try
            {
                BaseApplication.GenerateDataSource(table, fileName, Encoding.UTF8);
                MessageBox.Show($"""
                                 Export Terminé
                                 Le Fichier {fileName} à été créé 
                                 """);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void btnFiltre_Click(object sender, EventArgs e)
    {
        var form = new FindCoproprietaireForm();
        var source = new BindingSource();
        source.DataSource = dataGridView.DataSource;
        if (DialogResult.Cancel != form.ShowDialog())
        {
            var fiche = new FicheCoproprietaireForm();
            fiche.entite = controller.getEntiteFromField("reference", form.reference);
            fiche.ShowDialog();
        }
        else
        {
            source.Filter = "";
        }
    }

    private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
    {
        if (!bLoading)
            if (regKey != "")
                CommonRegistry.setRegistryValue(regKey, e.Column.Name, e.Column.DisplayIndex);
    }

    private void ckActif_CheckedChanged(object sender, EventArgs e)
    {
        FillDataGrid();
    }
}