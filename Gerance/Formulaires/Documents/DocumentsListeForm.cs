using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Common;
using GeranceData.Common;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Documents
{
    public partial class DocumentsListeForm : ScanUtilForm
    {
        bool bInitialized = false;
        bool bLoading;
        string regKey = "";
        ToolStripMenuItem enregistrerBDToolStripMenuItem;
        public DocumentsListeForm()
        {
            InitializeComponent();
            
            enregistrerBDToolStripMenuItem = new ToolStripMenuItem();
            enregistrerBDToolStripMenuItem.Text = "Enregistrer en Base de Données";
            enregistrerBDToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.B)));
            enregistrerBDToolStripMenuItem.Click += new EventHandler(SavePictureOnDB);

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
            var locataire_id = "";
            var document_type = cbTypeDoc.SelectedValue.ToString();

            var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire == null)
            {
                MessageBox.Show("reference Locataire Invalide");
                return;

            }
            locataire_id = locataire.id;
            var document = new DocumentEntite();
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
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
                    var row = (DataRowView)rowGrid.DataBoundItem;
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
            var res = form.ShowDialog();
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
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
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
            var locataire_id = "";
            var document_type = cbTypeDoc.SelectedValue.ToString();
            if ( tbRefLocataire.Text != "")
            {
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                    locataire_id = locataire.id;
            }

            dataGridView.DataSource = DocumentController.getController().getDocumentsListe( locataire_id, document_type);
            if (dataGridView.DataSource != null)
            {
                var cols = dataGridView.Columns;
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
                var index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
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
                    var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
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
