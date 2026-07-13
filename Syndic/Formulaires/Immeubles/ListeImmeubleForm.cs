using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Common;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;

using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Immeubles
{
    public partial class ListeImmeubleForm : Form
    {
        public ImmeubleController controller = new ImmeubleController();
        bool bLoading;
        string regKey;
        public ListeImmeubleForm()
        {
            InitializeComponent();
            regKey = "listes\\immeubles";
        }
        private void ListeImmeubleForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        private void FillDataGrid() 
        {
            bLoading = true;
//            dataGridView.DataSource = controller.GetList();
            if (ckActif.Checked)
                dataGridView.DataSource = controller.GetList();
            else
                dataGridView.DataSource = controller.GetAllEntite();
            
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
//                cols["agence"].Visible = false;
                cols["audit_created"].Visible = false;
                cols["audit_created_by"].Visible = false;
                cols["audit_updated"].Visible = false;
                cols["audit_updated_by"].Visible = false;
                cols["statut"].Visible = false;
                cols["note"].Visible = false;
                cols["note_repart"].Visible = false;


                cols["reference"].Width = 40;
                cols["codepostal"].Width = 40;
                cols["nombrelots"].Width = 40;

                cols["dateass"].HeaderText = "Date Assemblée";
                cols["codepostal"].HeaderText = "Code Postal";
                cols["nombrelots"].HeaderText = "Nombre Lots";
                cols["datecreation"].HeaderText = "Date création";
                cols["datecloture"].HeaderText = "Date Clôture";
                cols["dateass"].HeaderText = "Date Assemblée";
                cols["lieuconv"].HeaderText = "Lieu Assemblée";
                cols["soldeinitial"].HeaderText = "Solde Initial";
                cols["soldefin"].HeaderText = "Solde Final";
                cols["comptebanque"].HeaderText = "N° Compte";



                ControlsWindows.ToTitleCase(cols);
                OrderColumns();
            }
            else
                this.Close();
            BtnSave.Enabled = false;
            bLoading = false;
        }
        protected virtual void OrderColumns()
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

        private void FormListClosing(object sender, FormClosingEventArgs e)
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
//            dataGridView.AllowUserToDeleteRows = bEdit;
            dataGridView.ReadOnly = !bEdit;
            BtnSave.Enabled = bEdit;
        }


        private void editionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowImmeuble ( dataGridView.SelectedRows[0].Index);
        }

        private void ShowImmeuble(int index)
        {
            if (!dataGridView.ReadOnly)
            {
                return;
            }
            if (controller.SaveList((DataTable)dataGridView.DataSource))
            {
                DataRowView row = (DataRowView)dataGridView.Rows[index].DataBoundItem;
                if ( row.Row.RowState != DataRowState.Detached )
                    edition(new ImmeubleEntite(row.Row));
            }
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edition(new ImmeubleEntite());
        }
        private void edition(ImmeubleEntite entite)
        {
            try
            {
                FicheImmeubleForm form = new FicheImmeubleForm();
                form.immeuble = entite;
                if (!"".Equals(entite.id))
                    form.immeuble = controller.getEntiteById(entite.id);

                form.StartPosition = FormStartPosition.CenterScreen;
                form.Icon = this.Icon;
                form.ControlBox = true;
                form.Show();

//                form.ShowDialog();
//                dataGridView.DataSource = controller.GetList();
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
                editionToolStripMenuItem_Click(null, null);
            }
            if (Convert.ToInt16(e.KeyChar) == 27)
            {
                e.Handled = true;
                updateEditMode(false);
            }
            if (e.KeyChar == 0x0D && dataGridView.ReadOnly )
            {
                e.Handled = true;
                int index = dataGridView.SelectedRows[0].Index;
                index = Math.Max(index - 1, 0);
                ShowImmeuble(index);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id", "note", "codenvoi","codenvcomp", "declaration","note_repart", "audit_created", "audit_created_by", "audit_updated", "audit_updated_by" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            BindingSource source = new BindingSource();// (BindingSource)dataGridView.DataSource;
            source.DataSource = dataGridView.DataSource;
            if (DialogResult.Cancel != form.ShowDialog())
            {
                int action = (int)CommonRegistry.getRegistryValue("Parametres", "ActionFiltre", 0);
                if (action == 1)
                    source.Filter = String.Format("reference = '{0}'", form.reference);
                else
                {
                    FicheImmeubleForm fiche = new FicheImmeubleForm();
                    fiche.immeuble = controller.getEntiteFromField("reference", form.reference);
                    fiche.ShowDialog();
                }
            }
            else
                source.Filter = "";

        }
        private void dataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (!bLoading)
            {
                if (regKey != "")
                    CommonRegistry.setRegistryValue(regKey, e.Column.Name, e.Column.DisplayIndex);
            }

        }

        private void ckActif_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

    }
}
