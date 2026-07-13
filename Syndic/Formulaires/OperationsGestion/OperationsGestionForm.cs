using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Formulaires.Fournisseur;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class OperationsGestionForm : Form, ICommonChangedListener
    {
        ImmeubleEntite immeuble;
        bool bLoading;
        string regKey;
        String TitreForm;
        int stdWidth, stdHeight;

        public OperationsGestionForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void cbTypeOpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            commonValidating();
        }
        protected virtual void OrderColumns()
        {
            if (regKey == "")
                return;
            int widthForm = (int)CommonRegistry.getRegistryValue(regKey, "width", -1);
            int heightForm = (int)CommonRegistry.getRegistryValue(regKey, "height", -1);
            if (widthForm != -1)
                this.Width = widthForm;
            else
                this.Width = stdWidth;
            if (heightForm != -1)
                this.Height = heightForm;
            else
                this.Height = stdHeight;
            this.CenterToScreen();
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                int index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
                if (index != -1)
                    col.DisplayIndex = index;
                int width = (int)CommonRegistry.getRegistryValue(regKey + "\\width", col.Name, -1);
                if (width != -1)
                    col.Width = width;
            }
            //System.Windows.Forms.SortOrder sortOrder = dataGridView.SortOrder;
            //if (sortOrder == System.Windows.Forms.SortOrder.None)
            {
                System.Windows.Forms.SortOrder newOrder = (System.Windows.Forms.SortOrder)CommonRegistry.getRegistryValue(regKey, "SortOrder", 0);
                String SortedColumn = (String) CommonRegistry.getAppRegistryValue(regKey, "SortedColumn", "");
                if (newOrder != System.Windows.Forms.SortOrder.None && !String.IsNullOrEmpty(SortedColumn))
                {
                    DataGridViewColumnCollection cols = dataGridView.Columns;
                    if (newOrder == System.Windows.Forms.SortOrder.Ascending)
                        dataGridView.Sort(cols[SortedColumn], ListSortDirection.Ascending);
                    if (newOrder == System.Windows.Forms.SortOrder.Descending)
                        dataGridView.Sort(cols[SortedColumn], ListSortDirection.Descending);
                }
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
            stdWidth = this.Width;
            stdHeight = this.Height;

            int width = (int)CommonRegistry.getRegistryValue(regKey, "width", -1);
            if (width != -1)
                this.Width = width;
            int height = (int)CommonRegistry.getRegistryValue(regKey, "height", -1);
            if (height != -1)
                this.Height = height;
        }
        private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
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
            DateTime dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
            DateTime dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");
            
            DataGridViewColumn sortedCol = dataGridView.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = SaisieFactureController.getController().getListeOperations(tbRefImmeuble.Text, tbNature.Text, dtDeb, dtFin, tbFournisseur.Text, tbLibelle.Text, tbMontant.Text, ckValid.Checked, tbBase.Text);
            DataGridViewColumnCollection cols = dataGridView.Columns;
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

            if ( sortOrder == System.Windows.Forms.SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == System.Windows.Forms.SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

            setRowIndicators();
            OrderColumns();
            bLoading = false;
        }
        private void FillFromAppelsDeFond()
        {
            bLoading = true;
            dataGridView.MultiSelect = false;
            DateTime dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
            DateTime dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

            DataGridViewColumn sortedCol = dataGridView.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = SaisieAppelFondController.getController().getListeViewOperations(tbRefImmeuble.Text, dtDeb, dtFin, tbLibelle.Text, tbMontant.Text, ckValid.Checked, tbBase.Text);
            DataGridViewColumnCollection cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["liasse_id"].Visible = false;

            if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == System.Windows.Forms.SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);
            
            setRowIndicators();
            OrderColumns();
            bLoading = false;
        }
        private void FillFromReglements()
        {
            bLoading = true;
            dataGridView.MultiSelect = false;
            DateTime dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
            DateTime dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

            DataGridViewColumn sortedCol = dataGridView.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = SaisieReglementController.getController().getListeOperations(tbRefImmeuble.Text, tbLot.Text, dtDeb, dtFin, tbNature.Text, tbLibelle.Text, tbMontant.Text, ckValid.Checked);
            DataGridViewColumnCollection cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;

            if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == System.Windows.Forms.SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

            setRowIndicators();
            OrderColumns();
            bLoading = false;
        }

        private void FillFromOperations(string type)
        {
            bLoading = true;

            dataGridView.MultiSelect = true;
            DateTime dtDeb = ckDebut.Checked ? dateDebut.Value : DateTime.Parse("01/01/1970");
            DateTime dtFin = ckFin.Checked ? dateFin.Value : DateTime.Parse("01/01/1970");

            DataGridViewColumn sortedCol = dataGridView.SortedColumn;
            System.Windows.Forms.SortOrder sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = OperationController.getController().getListeOperations(immeuble.id, tbLot.Text, type, ckValid.Checked ? (int) GlobalConstantes.StatutOperation.Valide :-1, dtDeb, dtFin, tbNature.Text, tbBase.Text, tbLibelle.Text, tbMontant.Text);
            DataGridViewColumnCollection cols = dataGridView.Columns;
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

            if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == System.Windows.Forms.SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

            setRowIndicators();
            OrderColumns();
            bLoading = false;
        }

        private void setRowIndicators()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int statut = (int) row.Cells["statut"].Value;
                Color color = Color.White;
                switch (statut )
                {
                    case 0: color = Color.Gray; break;
                    case 8: color = Color.LightGreen; break;
                    case 9: color = Color.Red; break;
                }
                row.DefaultCellStyle.BackColor = color;
            }
        }
        private void commonValidating()
        {
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
//                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.ExerciceCourant.date_deb.ToShortDateString());
            }
            else
                this.Text = TitreForm;
            string selected_id = "";

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (row != null)
                    selected_id = row["id"].ToString();
            }
            if (/*immeuble != null & */cbTypeOpe.SelectedIndex >= 0)
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
                            FillFromOperations(GlobalConstantes.TypeMouvement.Depense.ToString());
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
                            FillFromOperations(GlobalConstantes.TypeMouvement.Recette.ToString());
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
                    DataRowView row = (DataRowView)rowGrid.DataBoundItem;
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
            List<string> colsToHide = new List<string>{"id"};
            BaseApplication.DataGridToExcel( dataGridView, colsToHide, "", new string[] {"montant", "debit", "credit" });
        }

        void AnnuleOperation(string operation_id)
        {
            if (DialogResult.OK != MessageBox.Show("Voulez-vous vraiment annuler cette opération", "Attention", MessageBoxButtons.OKCancel))
                return;
            OperationEntite operation = OperationController.getController().getEntiteById(operation_id);
            if ( operation != null )
            {
                operation.statut = (int) GlobalConstantes.StatutOperation.Supprime;
                OperationController.getController().InsertOrUpdate(operation);
                commonValidating();
            }
        }
        private void EditionOperation()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                int index = dataGridView.SelectedRows[0].Index;
                Form form = null;
                switch (cbTypeOpe.SelectedIndex)
                {
                    case 5:
                    case 4:
                    case 3:
                        //AnnuleOperation(row["id"].ToString());
                        form = new DetailElementOperationForm(row["id"].ToString());
                        break;
                    case 2:
                        form = new DetailReglementForm(row["id"].ToString());
                        break;
                    case 1:
                        form = new DetailAppelDeFondForm(row["id"].ToString());
                        break;
                    case 0:
                        form = new DetailFactureForm(row["id"].ToString());
                        break;
                }
                if (form != null)
                {
                    form.ShowDialog();
                    commonValidating();
                    dataGridView.Rows[0].Selected = false;
                    if (index >= dataGridView.Rows.Count)
                        index--;
                    if ( index >= 0)
                        dataGridView.Rows[index].Selected = true;
//                    dataGridView.SelectedRows[0].Index = index;
                }
            }

        }
        private void lblFournisseur_Click(object sender, EventArgs e)
        {
            FindFournisseurForm form = new FindFournisseurForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbFournisseur.Text = form.reference;
                commonValidating();
            }
        }


        private void lblNature_Click(object sender, EventArgs e)
        {
            FindNatureForm form = new FindNatureForm();
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
                    DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                    SaisieAppelFondEntite appel = SaisieAppelFondController.getController().getEntiteById(row["id"].ToString());
                    ModificationLotForm form = new ModificationLotForm(appel);
                    form.ShowDialog();
                }
                if (cbTypeOpe.SelectedIndex == 0)
                {
                    DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                    SaisieFactureEntite facture = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                    ModificationLotForm form = new ModificationLotForm(facture);
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
                    DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                    if (row["base_repart"].ToString() == "80")
                        modifierNumeroLotToolStripMenuItem.Enabled = true;
                }
                if (cbTypeOpe.SelectedIndex > 2)
                {
//                    genererLaFactureToolStripMenuItem.Enabled = true;
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
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                CreateFacturefromOperationForm form = new CreateFacturefromOperationForm(operation);
                form.ShowDialog();
                commonValidating();
            }
        }

        private void genererLeReglementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                SaisieReglementEntite reglement = new SaisieReglementEntite(operation);
                SaisieReglementController.getController().InsertOrUpdate(reglement);
                commonValidating();
            }
        }

        private void supprimerLesÉlémentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Npgsql.NpgsqlTransaction trx = Database.BeginTransaction();
                OperationController.getController().setTimestampServer();
                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                        OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
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
                CommonRegistry.setRegistryValue(regKey, "width", this.Width);
                CommonRegistry.setRegistryValue(regKey, "height", this.Height);
                if (dataGridView.SortOrder != System.Windows.Forms.SortOrder.None)
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
                this.Height = stdHeight;
                this.Width = stdWidth;
                this.CenterToParent();
                commonValidating();
            }
        }
    }
}
