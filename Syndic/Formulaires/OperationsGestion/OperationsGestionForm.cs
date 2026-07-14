using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Fournisseur;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion;

public partial class OperationsGestionForm : Form, ICommonChangedListener
{
    private ImmeubleEntite immeuble;
    private bool bLoading;
    private string regKey;
    private readonly string TitreForm;
    private int stdWidth, stdHeight;

    public OperationsGestionForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void cbTypeOpe_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonValidating();
    }

    private void OrderColumns()
    {
        if (regKey == "")
            return;
        var widthForm = (int)CommonRegistry.getRegistryValue(regKey, "width", -1);
        var heightForm = (int)CommonRegistry.getRegistryValue(regKey, "height", -1);
        Width = widthForm != -1 ? widthForm : stdWidth;
        Height = heightForm != -1 ? heightForm : stdHeight;
        CenterToScreen();
        foreach (DataGridViewColumn col in dataGridView.Columns)
        {
            var index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
            if (index != -1)
                col.DisplayIndex = index;
            var width = (int)CommonRegistry.getRegistryValue(regKey + "\\width", col.Name, -1);
            if (width != -1)
                col.Width = width;
        }

        var newOrder = (SortOrder)CommonRegistry.getRegistryValue(regKey, "SortOrder", 0);
        var SortedColumn = (string) CommonRegistry.getAppRegistryValue(regKey, "SortedColumn", "");
        if (newOrder != SortOrder.None && !string.IsNullOrEmpty(SortedColumn))
        {
            var cols = dataGridView.Columns;
            if (newOrder == SortOrder.Ascending)
                dataGridView.Sort(cols[SortedColumn], ListSortDirection.Ascending);
            if (newOrder == SortOrder.Descending)
                dataGridView.Sort(cols[SortedColumn], ListSortDirection.Descending);
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

    private void OperationsGestion_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        stdWidth = Width;
        stdHeight = Height;

        var width = (int)CommonRegistry.getRegistryValue(regKey, "width", -1);
        if (width != -1)
            Width = width;
        var height = (int)CommonRegistry.getRegistryValue(regKey, "height", -1);
        if (height != -1)
            Height = height;
    }
    private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }

    }
    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void FillFromFacture()
    {
        bLoading = true;
        dataGridView.MultiSelect = false;
        var dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
        var dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");
            
        var sortedCol = dataGridView.SortedColumn;
        var sortOrder = dataGridView.SortOrder;

        dataGridView.DataSource = SaisieFactureController.getController().getListeOperations(tbRefImmeuble.Text, tbNature.Text, dtDeb, dtFin, tbFournisseur.Text, tbLibelle.Text, tbMontant.Text, ckValid.Checked, tbBase.Text);
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);

        cols["base_repart"].Width = 40;
        cols["ref_nature"].Width = 40;
        cols["ref_immeuble"].Width = 40;
        cols["ref_fourn"].Width = 40;
        cols["nature"].MinimumWidth = 120;
        cols["fournisseur"].MinimumWidth = 120;
        cols["libelle"].MinimumWidth = 160;
        cols["statut"].Visible = false;
        cols["id"].Visible = false;

        if ( sortOrder == SortOrder.Ascending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
        if (sortOrder == SortOrder.Descending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

        setRowIndicators();
        OrderColumns();
        bLoading = false;
    }
    private void FillFromAppelsDeFond()
    {
        bLoading = true;
        dataGridView.MultiSelect = false;
        var dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
        var dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

        var sortedCol = dataGridView.SortedColumn;
        var sortOrder = dataGridView.SortOrder;

        dataGridView.DataSource = SaisieAppelFondController.getController().getListeViewOperations(tbRefImmeuble.Text, dtDeb, dtFin, tbLibelle.Text, tbMontant.Text, ckValid.Checked, tbBase.Text);
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        cols["statut"].Visible = false;
        cols["id"].Visible = false;
        cols["liasse_id"].Visible = false;

        if (sortOrder == SortOrder.Ascending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
        if (sortOrder == SortOrder.Descending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);
            
        setRowIndicators();
        OrderColumns();
        bLoading = false;
    }
    private void FillFromReglements()
    {
        bLoading = true;
        dataGridView.MultiSelect = false;
        var dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
        var dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

        var sortedCol = dataGridView.SortedColumn;
        var sortOrder = dataGridView.SortOrder;

        dataGridView.DataSource = SaisieReglementController.getController().getListeOperations(tbRefImmeuble.Text, tbLot.Text, dtDeb, dtFin, tbNature.Text, tbLibelle.Text, tbMontant.Text, ckValid.Checked);
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        cols["statut"].Visible = false;
        cols["id"].Visible = false;

        if (sortOrder == SortOrder.Ascending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
        if (sortOrder == SortOrder.Descending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

        setRowIndicators();
        OrderColumns();
        bLoading = false;
    }

    private void FillFromOperations(string type)
    {
        bLoading = true;

        dataGridView.MultiSelect = true;
        var dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
        var dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

        var sortedCol = dataGridView.SortedColumn;
        var sortOrder = dataGridView.SortOrder;

        dataGridView.DataSource = OperationController.getController().getListeOperations(immeuble.id, tbLot.Text, type, ckValid.Checked ? (int) GlobalConstantes.StatutOperation.Valide :-1, dtDeb, dtFin, tbNature.Text, tbBase.Text, tbLibelle.Text, tbMontant.Text);
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        cols["statut"].Visible = false;
        cols["id"].Visible = false;
        cols["base_repart"].Width = 20;
        cols["ref_nature"].Width = 40;
        cols["date_relance"].Width = 50;
        cols["ref_copro"].Width = 50;
        cols["debit"].Width = 50;
        cols["credit"].Width = 50;
        cols["global"].Width = 50;

        if (sortOrder == SortOrder.Ascending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
        if (sortOrder == SortOrder.Descending)
            dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

        setRowIndicators();
        OrderColumns();
        bLoading = false;
    }

    private void setRowIndicators()
    {
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            var statut = (int) row.Cells["statut"].Value;
            var color = statut switch
            {
                0 => Color.Gray,
                8 => Color.LightGreen,
                9 => Color.Red,
                _ => Color.White
            };
            row.DefaultCellStyle.BackColor = color;
        }
    }
    private void commonValidating()
    {
        if (tbRefImmeuble.Text != "")
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
                Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
        }
        else
            Text = TitreForm;
        var selected_id = "";

        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (row != null)
                selected_id = row["id"].ToString();
        }
        if (cbTypeOpe.SelectedIndex >= 0)
        {
            switch ( cbTypeOpe.SelectedIndex )
            {
                case 0:
                    regKey = "listes\\factures";
                    tbLot.Enabled = false;
                    tbNature.Enabled = true;
                    tbFournisseur.Enabled = true;
                    btnDetail.Enabled = true;
                    FillFromFacture();
                    break;
                case 1:
                    regKey = "listes\\appels";
                    tbLot.Enabled = false;
                    tbNature.Enabled = false;
                    tbFournisseur.Enabled = false;
                    btnDetail.Enabled = true;
                    FillFromAppelsDeFond();
                    break;
                case 2:
                    regKey = "listes\\reglements";
                    tbLot.Enabled = true;
                    tbNature.Enabled = true;
                    tbFournisseur.Enabled = false;
                    btnDetail.Enabled = true;
                    FillFromReglements();
                    break;
                case 3:
                    regKey = "listes\\operations";
                    tbLot.Enabled = true;
                    tbNature.Enabled = true;
                    tbFournisseur.Enabled = false;
                    if (immeuble != null)
                    {
                        FillFromOperations("");
                    }
                    else
                        dataGridView.DataSource = null;
                    break;
                case 4:
                    regKey = "listes\\operations";
                    tbLot.Enabled = true;
                    tbNature.Enabled = true;
                    btnDetail.Enabled = false;
                    if (immeuble != null)
                    {
                        FillFromOperations(nameof(GlobalConstantes.TypeMouvement.Depense));
                    }
                    else
                        dataGridView.DataSource = null;
                    break;
                case 5:
                    regKey = "listes\\operations";
                    tbLot.Enabled = true;
                    tbNature.Enabled = true;
                    tbFournisseur.Enabled = false;
                    btnDetail.Enabled = false;
                    if (immeuble != null)
                    {
                        FillFromOperations(nameof(GlobalConstantes.TypeMouvement.Recette));
                    }
                    else
                        dataGridView.DataSource = null;
                    break;
            }

        }
        if (selected_id != "")
        {
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                var row = (DataRowView)rowGrid.DataBoundItem;
                if (row["id"].ToString() == selected_id)
                {
                    rowGrid.Selected = true;
                    if (!rowGrid.Displayed)
                        dataGridView.FirstDisplayedScrollingRowIndex = rowGrid.Index;
                    break;
                }
            }
        }
    }
    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        setRowIndicators();
    }

    private void btnGrid_Click(object sender, EventArgs e)
    {
        commonValidating();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string>{"id"};
        BaseApplication.DataGridToExcel( dataGridView, colsToHide, "", ["montant", "debit", "credit"]);
    }

    private void EditionOperation()
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var index = dataGridView.SelectedRows[0].Index;
            Form form = cbTypeOpe.SelectedIndex switch
            {
                5 or 4 or 3 =>
                    new DetailElementOperationForm(row["id"].ToString()),
                2 => new DetailReglementForm(row["id"].ToString()),
                1 => new DetailAppelDeFondForm(row["id"].ToString()),
                0 => new DetailFactureForm(row["id"].ToString()),
                _ => null
            };
            if (form != null)
            {
                form.ShowDialog();
                commonValidating();
                dataGridView.Rows[0].Selected = false;
                if (index >= dataGridView.Rows.Count)
                    index--;
                if ( index >= 0)
                    dataGridView.Rows[index].Selected = true;
            }
        }

    }
    private void lblFournisseur_Click(object sender, EventArgs e)
    {
        var form = new FindFournisseurForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbFournisseur.Text = form.reference;
            commonValidating();
        }
    }


    private void lblNature_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbNature.Text = form.reference;
            commonValidating();
        }
    }

    private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        EditionOperation();
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        EditionOperation();
    }

    private void btnDetail_Click(object sender, EventArgs e)
    {
        EditionOperation();
    }

    private void tbNature_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }
    public void ChangedReference(object sender, CommonEventArgs e)
    {
        tbRefImmeuble.Text = e.newRef;
        tbLot.Text = e.newRef2;
        commonValidating();
    }

    private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
    {
        EditionOperation();
    }

    private void tbBase_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void ckValid_CheckedChanged(object sender, EventArgs e)
    {
        commonValidating();
    }

    private void tbMontant_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void tbLibelle_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void tbFournisseur_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void modifierNumeroLotToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            if (cbTypeOpe.SelectedIndex == 1)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                var appel = SaisieAppelFondController.getController().getEntiteById(row["id"].ToString());
                var form = new ModificationLotForm(appel);
                form.ShowDialog();
            }
            if (cbTypeOpe.SelectedIndex == 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                var facture = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                var form = new ModificationLotForm(facture);
                form.ShowDialog();
            }
        }
    }

    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        modifierNumeroLotToolStripMenuItem.Enabled = false;
        genererLaFactureToolStripMenuItem.Enabled = false;
        supprimerLesÉlémentsToolStripMenuItem.Enabled = false;
        if (dataGridView.SelectedRows.Count > 0)
        {
            if (cbTypeOpe.SelectedIndex <= 1)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (row["base_repart"].ToString() == "80")
                    modifierNumeroLotToolStripMenuItem.Enabled = true;
            }

            if (dataGridView.SelectedRows.Count > 0)
            {
                supprimerLesÉlémentsToolStripMenuItem.Enabled = true;
            }
        }
    }

    private void genererLaFactureToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var operation = OperationController.getController().getEntiteById(row["id"].ToString());
            var form = new CreateFacturefromOperationForm(operation);
            form.ShowDialog();
            commonValidating();
        }
    }

    private void genererLeReglementToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var operation = OperationController.getController().getEntiteById(row["id"].ToString());
            var reglement = new SaisieReglementEntite(operation);
            SaisieReglementController.getController().InsertOrUpdate(reglement);
            commonValidating();
        }
    }

    private void supprimerLesÉlémentsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var trx = Database.BeginTransaction();
            OperationController.getController().setTimestampServer();
            try
            {
                foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                {
                    var row = (DataRowView)rowGrid.DataBoundItem;
                    var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                    if (operation != null)
                    {
                        operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                        if (!OperationController.getController().doInsertOrUpdate(operation))
                            throw new Exception("Delete Operation failed");
                    }
                }
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        commonValidating();
    }

    private void enregistrerLaPrésentationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (regKey != "")
        {
            CommonRegistry.setRegistryValue(regKey, "width", Width);
            CommonRegistry.setRegistryValue(regKey, "height", Height);
            if (dataGridView.SortOrder != SortOrder.None)
            {
                CommonRegistry.setRegistryValue(regKey, "SortOrder", (int) dataGridView.SortOrder);
                CommonRegistry.setRegistryValue(regKey, "SortedColumn", dataGridView.SortedColumn.Name);
            }

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                CommonRegistry.setRegistryValue(regKey, col.Name, col.DisplayIndex);
                CommonRegistry.setRegistryValue(regKey + "\\width", col.Name, col.Width);
            }
        }
    }

    private void présentationParDéfautToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (regKey != "")
        {
            CommonRegistry.deleteRegistry(regKey);
            Height = stdHeight;
            Width = stdWidth;
            CenterToParent();
            commonValidating();
        }
    }
}