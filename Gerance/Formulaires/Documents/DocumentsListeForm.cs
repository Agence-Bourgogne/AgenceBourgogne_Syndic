using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Common;
using GeranceData.Common;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using System.IO;
namespace Gerance.Formulaires.Documents
{
    public partial class DocumentsListeForm : CommonProjectsPartners.Utils.ScanUtilForm
    {
        bool bInitialized = false;
        bool bLoading;
        string regKey = "";
        ToolStripMenuItem enregistrerBDToolStripMenuItem;
        public DocumentsListeForm()
        {
            InitializeComponent();
            
            enregistrerBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enregistrerBDToolStripMenuItem.Text = "Enregistrer en Base de Données";
            enregistrerBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.enregistrerBDToolStripMenuItem.Click += new System.EventHandler(SavePictureOnDB);

            fichierToolStripMenuItem.DropDownItems.Add(enregistrerBDToolStripMenuItem);
        }

        private void InitCombos()
        {
            ParametresDB.FillComboFromParams(cbTypeDoc, "TYPE_DOC_LOCATAIRE", "nom", "code");
        }
        private void DocumentsListeForm_Load(object sender, EventArgs e)
        {
            InitCombos();
            FillDataGrid();
  
            bInitialized = true;
            enregistrerToolStripMenuItem.Text = "Enregistrer Sur Fichier";
        }

        private void SavePictureOnDB(object sender, EventArgs e)
        {
            string locataire_id = "";
            string document_type = cbTypeDoc.SelectedValue.ToString();

            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire == null)
            {
                MessageBox.Show("reference Locataire Invalide");
                return;

            }
            locataire_id = locataire.id;
            DocumentEntite document = new DocumentEntite();
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (row != null)
                    document = DocumentController.getController().getEntiteById(row["id"].ToString());
            }
            
            document.document_type = document_type;
            document.reference = locataire_id;
            document.date_document = dtDoc.Value;
            document.libelle = tbLibelle.Text;
            document.Image = pictureBox1.Image;

            DocumentController.getController().InsertOrUpdate(document);
            FillDataGrid();
            if (document.id != null)
            {
                foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                {
                    DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                    if (row["id"].ToString() == document.id)
                    {
                        rowGrid.Selected = true;
                        break;
                    }
                }
            }
        }

        private void cbTypeDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( bInitialized)
                FillDataGrid();
        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowFindForm(new LocataireFindForm(), tbRefLocataire))
                tbRefLocataire_Validating(null, null);
        }

        private void tbRefLocataire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblRefLocataire_Click(null, null);
                    e.SuppressKeyPress = e.Handled = true;
                }
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if ( tbRefLocataire.Text != "")
            {
                LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire == null)
                    tbRefLocataire.BackColor = Color.Red;
                else
                {
                    FillDataGrid();
                }
            }
        }
        protected virtual void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["id"].Visible = false;
            cols["reference"].Visible = false;
            cols["document_type"].Visible = false;
        }
        private void FillDataGrid()
        {
            bLoading = true;
            string locataire_id = "";
            string document_type = cbTypeDoc.SelectedValue.ToString();
            if ( tbRefLocataire.Text != "")
            {
                LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                    locataire_id = locataire.id;
            }

            dataGridView.DataSource = DocumentController.getController().getDocumentsListe( locataire_id, document_type);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                HideAndResizeColumns(cols);
                ControlsWindows.ToTitleCase(cols);
                OrderColumns();
                dataGridView.ClearSelection();
            }
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

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            if (!bLoading)
            {
                DocumentEntite doc = null;
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                    if (row != null)
                    {
                        doc = DocumentController.getController().getEntiteById(row["id"].ToString());
                    }
                }
                pictureBox1.Image = doc != null ? doc.Image : null;
                tbLibelle.Text = doc != null ? doc.libelle : "";
                dtDoc.Value = doc != null ? doc.date_document : DateTime.Now;
            }
        }
    }
}
