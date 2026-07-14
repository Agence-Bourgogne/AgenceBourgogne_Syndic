using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Immeubles;

public partial class TitreRepartImmeubleForm : Form
{
    public string immeuble_id = "";
    private bool bInit;
    private bool bChangeInProgress;
    public TitreRepartImmeubleForm()
    {
        InitializeComponent();
    }

    private void TitreRepartImmeubleForm_Load(object sender, EventArgs e)
    {
        var repartitions = ImmeubleRepartitionController.getController().getRepartitionImmeuble(immeuble_id);
        foreach ( DataRow row in repartitions.Rows)
        {
            var idx = dataGridView.Rows.Add();
            var rowGrid = dataGridView.Rows[idx];
            rowGrid.Tag = row;
            var cells = rowGrid.Cells;

            cells[0].Value = row["reference"];

            cells[1].Value = (int)row["type_ventilation"] switch
            {
                (int)GlobalConstantes.TypeRepartition.Millieme => GlobalConstantes.TypeRepartition.Millieme,
                (int)GlobalConstantes.TypeRepartition.Individuelle => GlobalConstantes.TypeRepartition.Individuelle,
                _ => cells[1].Value
            };
            cells[1].Tag = (int)row["type_ventilation"];
            cells[2].Value = row["nom"];
            cells[3].Value = row["ligne"];
            cells[4].Value = row["colonne"];
        }
        cbRepart.Items.Add( GlobalConstantes.TypeRepartition.Millieme);
        cbRepart.Items.Add(GlobalConstantes.TypeRepartition.Individuelle);
        bInit = true;
        dataGridView_SelectionChanged(null, null);
    }

    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (!bInit)
            return;
        var rowGrid = dataGridView.SelectedRows[0];
        var row = (DataRow) rowGrid.Tag;
        bChangeInProgress = true;
        tbBase.Text = rowGrid.Cells["reference"].Value.ToString();
        tbTitre.Text = rowGrid.Cells["nom"].Value.ToString();
        tbLigne.Text = rowGrid.Cells["ligne"].Value.ToString();
        tbColonne.Text = rowGrid.Cells["colonne"].Value.ToString();
        cbRepart.SelectedIndex = (int)rowGrid.Cells["repartition"].Tag;

        if (row != null)
        {
            tbBase.Enabled = tbLigne.Enabled = tbColonne.Enabled = false;
        }
        else
            tbBase.Enabled = tbLigne.Enabled = tbColonne.Enabled = true;
        bChangeInProgress = false;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var bOk = true;
        var controller = ImmeubleRepartitionController.getController();
        foreach (DataGridViewRow rowGrid in dataGridView.Rows)
        {
            var row = (DataRow)rowGrid.Tag;
            var entite = new ImmeubleRepartitionEntite(row);

            if (row == null)
            {
                entite.reference = rowGrid.Cells["reference"].Value.ToString();
                if (controller.ExistRepartitionReference ( immeuble_id, entite.reference))
                {
                    MessageBox.Show ( string.Format("Base Existante pour cet immeuble", entite.reference));
                    return;
                }
                if (rowGrid.Cells["reference"].Value.ToString() == "")
                {
                    MessageBox.Show(@"Vous devez définir la base");
                    return;
                }
                entite.immeuble_id = immeuble_id;
            }
            entite.nom = rowGrid.Cells["nom"].Value.ToString();
            entite.type_ventilation = (int) rowGrid.Cells["repartition"].Tag;
            entite.ligne = Convertir.ToInt(rowGrid.Cells["ligne"].Value.ToString());
            entite.colonne = Convertir.ToInt(rowGrid.Cells["colonne"].Value.ToString());
            if (entite.ligne <= 0)
                entite.ligne = 1;
            bOk = controller.InsertOrUpdate(entite);
            if (!bOk)
                break;
        }
        if (bOk)
            Close();
    }

    private void cbRepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (bChangeInProgress || !bInit)
            return;

        var rowGrid = dataGridView.SelectedRows[0];

        rowGrid.Cells["repartition"].Tag = cbRepart.SelectedIndex;
        if (cbRepart.SelectedIndex >= 0)
        {
            rowGrid.Cells["repartition"].Value = cbRepart.SelectedItem.ToString();
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var idx = dataGridView.Rows.Add();
        var row = dataGridView.Rows[idx];
        row.Cells["reference"].Value = "";
        row.Cells["nom"].Value = "";
        row.Cells["ligne"].Value = "";
        row.Cells["colonne"].Value = "";
        row.Cells["repartition"].Value = "";
        row.Cells["repartition"].Tag = -1;
        row.Selected = true;
        dataGridView.CurrentCell = row.Cells[0];
        dataGridView_SelectionChanged(null, null);
    }

    private void tbBase_TextChanged(object sender, EventArgs e)
    {
        if (bChangeInProgress || !bInit)
            return;

        var rowGrid = dataGridView.SelectedRows[0];

        rowGrid?.Cells["reference"].Value = tbBase.Text;
    }
    private void tbTitre_TextChanged(object sender, EventArgs e)
    {
        if (bChangeInProgress || !bInit)
            return;
        var rowGrid = dataGridView.SelectedRows[0];

        rowGrid?.Cells["nom"].Value = tbTitre.Text;
    }


    private void tbLigne_TextChanged(object sender, EventArgs e)
    {
        if (bChangeInProgress || !bInit)
            return;
        var rowGrid = dataGridView.SelectedRows[0];

        rowGrid?.Cells["ligne"].Value = tbLigne.Text;
    }

    private void tbColonne_TextChanged(object sender, EventArgs e)
    {
        if (bChangeInProgress || !bInit)
            return;
        var rowGrid = dataGridView.SelectedRows[0];

        rowGrid?.Cells["colonne"].Value = tbColonne.Text;
    }
}