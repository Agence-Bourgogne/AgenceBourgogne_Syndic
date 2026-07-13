using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.UtilsApp;

namespace EspaceSyndic.Formulaires.Utilisateurs
{
    public partial class WebUserForm : Form
    {
        bool bInLoad = false;
        EspaceSyndic.ServiceReference.UserEntitie _currentUsr;
        List<EspaceSyndic.ServiceReference.DocumentEntitie> docs;
        //----------------------------------------------------------------
        public WebUserForm()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------
        private void WebUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                docs = ServiceReferenceUtils.GetInstance().GetListDocuments("", "").ToList();
                RefreshAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-----------------------------------------------------------
        private void RefreshAll()
        {
            btnDelCopro.Enabled = false;
            btnAddDoc.Enabled = false;
            btnDelDoc.Enabled = false;
            List<EspaceSyndic.ServiceReference.UserEntitie> users = ServiceReferenceUtils.GetInstance().GetAllUsers().ToList();
            dataGridView.DataSource = users;
            DataGridViewColumnCollection cols = dataGridView.Columns;
            HideAndResizeColumns(cols);
            dataGridView_SelectionChanged(null, null);
        }

        //----------------------------------------------------------------
        void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            //cols["id"].Visible = false;
            cols["guid"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["password"].Visible = false;
            cols["code"].Width = 240;
        }
        //----------------------------------------------------------------
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bInLoad)
                return;
            btnDelCopro.Enabled = false;
            btnAddDoc.Enabled = false;
            btnDelDoc.Enabled = false;
            listDoc.DataSource = null;
            if (dataGridView.SelectedRows.Count > 0)
            {
                FillTreeView();
            }
        }
        //----------------------------------------------------------------
        private void FillTreeView()
        {
            bInLoad = true;
            try
            {
                treeView.Nodes.Clear();
                TreeNode parent = new TreeNode() { Text = "Immeubles", ImageIndex = 0 };
                treeView.Nodes.Add(parent);

                EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
                _currentUsr = usr;
                List<EspaceSyndic.ServiceReference.ChildrenEntitie> immeubles = ServiceReferenceUtils.GetInstance().GetUserCoproprietaires(usr.Guid).OrderBy(x => x.Immeuble_id).ToList();
                String immeuble_id = "";
                TreeNode current = null;
                foreach (EspaceSyndic.ServiceReference.ChildrenEntitie child in immeubles)
                {
                    if (immeuble_id != child.Immeuble_id)
                    {
                        ImmeubleEntite immeuble = ImmeubleController.getController().getEntiteById(child.Immeuble_id);
                        immeuble_id = child.Immeuble_id;
                        current = new TreeNode() { Text = immeuble.nom, ImageIndex = 1, Tag = immeuble };
                        parent.Nodes.Add(current);
                    }
                    if (!String.IsNullOrEmpty(child.Copro_id))
                    {
                        CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(child.Copro_id);
                        if (copro != null)
                            current.Nodes.Add(new TreeNode() { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
                    }
                }
                treeView.ExpandAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                bInLoad = false;
            }
        }
        //-----------------------------------------------------------
        private void FillLvDocs()
        {
            bInLoad = true;
            listDoc.DataSource = null;
            int row = 0;
            DataTable table = new DataTable();
            table.Columns.Add("Document");
            table.Columns.Add("Guid");
            TreeNode current = treeView.SelectedNode;
            string immeuble_id = "";
            string copro_id = "";
            List<EspaceSyndic.ServiceReference.DocumentEntitie> listdocs = new List<ServiceReference.DocumentEntitie>();
            if (current != null && current.Tag != null)
            {
                List<EspaceSyndic.ServiceReference.ChildrenEntitie> immeublesByUsers = ServiceReferenceUtils.GetInstance().GetUserCoproprietaires(_currentUsr.Guid).OrderBy(x => x.Immeuble_id).ToList();
                if (current.Tag is ImmeubleEntite)
                {

                    ImmeubleEntite immeuble = (ImmeubleEntite)current.Tag;
                    immeuble_id = immeuble.getId();
                    if (immeublesByUsers.Exists(x => x.Immeuble_id == immeuble_id))
                    {
                        foreach (EspaceSyndic.ServiceReference.DocumentEntitie doc in docs)
                        {
                            if (doc.immeuble_id == immeuble_id && doc.copro_id == "" )
                                listdocs.Add(doc);
                        }
                    }

                }
                else if (current.Tag is CoproprietaireEntite)
                {
                    CoproprietaireEntite copro = (CoproprietaireEntite)current.Tag;
                    copro_id = copro.getId();
                    immeuble_id = copro.Immeuble.getId();
                    if (immeublesByUsers.Exists(x => x.Immeuble_id == immeuble_id))
                    {
                        foreach (EspaceSyndic.ServiceReference.DocumentEntitie doc in docs)
                        {
                            if (doc.immeuble_id == immeuble_id && doc.copro_id == copro_id)
                                listdocs.Add(doc);
                        }
                    }
                }
            }

            foreach (EspaceSyndic.ServiceReference.DocumentEntitie doc in listdocs)
            {

                table.Rows.Add();
                table.Rows[row]["Document"] = doc.text;
                table.Rows[row]["Guid"] = doc.Guid;
                row++;
            }
            listDoc.DataSource = table;
            listDoc.DisplayMember = "Document";
            listDoc.ValueMember = "Guid";
            listDoc.SelectedIndex = -1;
            bInLoad = false;
        }
        //---------------------------------------------------------
        private void btnNewCopro_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                FindCoproprietaireForm form = new FindCoproprietaireForm();
                if (DialogResult.Cancel != form.ShowDialog())
                {
                    EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
                    CoproprietaireEntite entite = CoproprietaireController.getController().getEntiteFromField("reference", form.reference);
                    try
                    {
                        if (entite != null)
                        {
                            SyndicData.Entites.ImmeubleEntite immeuble = entite.Immeuble;
                            string res = ServiceReferenceUtils.GetInstance().AddCopro(usr.Guid, immeuble.id, entite.id, immeuble.reference, immeuble.nom, entite.reference, entite.NomPrenom);
                            if (res == "0")
                            {
                                FillTreeView();
                            }
                            else
                                MessageBox.Show(res);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        //----------------------------------------------------------------
        private void btnNew_Click(object sender, EventArgs e)
        {
            //NewUserWebForm form = new NewUserWebForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //    RefreshAll();

            FindUser searchUserForm = new FindUser();
            if (searchUserForm.ShowDialog() == DialogResult.OK)
            {
                RefreshAll();
                // tbCode.Text = searchUserForm.email;
            }
        }
        //----------------------------------------------------------------
        private void btnDelUser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Voulez vous vraiment supprimer l'utilisateur", "Opération irreversible", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
                if (usr != null)
                {
                    string msg = ServiceReferenceUtils.DeleteUser(usr.Guid);
                    if (msg == "0")
                    {
                        MessageBox.Show(this, "Utilisateur supprimé avec succès");
                        RefreshAll();
                    }
                }
            }
        }
        //----------------------------------------------------------------
        private void btnDelCopro_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Voulez vous vraiment supprimer la copropriete", "Opération irreversible", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                TreeNode current = treeView.SelectedNode;
                if (current != null)
                    if (current.Tag != null && (current.Tag is CoproprietaireEntite))
                    {
                        CoproprietaireEntite copro = (CoproprietaireEntite)current.Tag;
                        string msg = ServiceReferenceUtils.DeleteCopro(copro.id);
                        if (msg == "0")
                        {
                            MessageBox.Show(this, "Copropriété supprimé avec succès");
                            RefreshAll();
                        }
                    }
            }
        }
        //----------------------------------------------------------------
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (bInLoad)
                return;
            btnDelCopro.Enabled = false;
            btnAddDoc.Enabled = false;
            btnDelDoc.Enabled = false;
            TreeNode current = treeView.SelectedNode;

            if (current != null && current.Tag != null && (current.Tag is CoproprietaireEntite))
            {
                btnAddDoc.Enabled = true;
                btnDelCopro.Enabled = true;
            }

            FillLvDocs();
        }
        //----------------------------------------------------------------
        private void UpdateUser(object sender, EventArgs e)
        {
            EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
            if (usr != null)
            {
                NewUserWebForm form = new NewUserWebForm(usr, "Modifier l'utilisateur");
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshAll();
                //MessageBox.Show(ServiceReferenceUtils.UpateUser(usr.Guid));
            }
        }
        //----------------------------------------------------------------
        private void listDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bInLoad)
                return;
            if (listDoc.SelectedItems.Count <= 0)
            {
                btnDelDoc.Enabled = false;
                return;
            }
            DataRowView drv = (DataRowView)listDoc.SelectedItems[0];
            string docGuid = drv["Guid"].ToString();

            EspaceSyndic.ServiceReference.DocumentEntitie doc = docs.FirstOrDefault(x => x.Guid == docGuid);
            if (doc != null)
            {
                btnDelDoc.Enabled = true;
            }
        }
        //----------------------------------------------------------------
        private void btnDelDoc_Click(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count > 0)
            {
                if (DialogResult.OK == MessageBox.Show("Voulez vous vraiment supprimer le(s) document(s)", "Opération irreversible", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    string messageRetour = "";
                    Common.LogForm logDialog = new Common.LogForm();
                    logDialog.Show(this);
                    logDialog.Activate();
                    logDialog.rtLog.Text = "Résultat de la suppréssion des documents : \n";
                    logDialog.rtLog.Refresh();
                    for (int i = 0; i < listDoc.SelectedItems.Count; i++)
                    {
                        DataRowView drv = (DataRowView)listDoc.SelectedItems[i];
                        string docGuid = drv["Guid"].ToString();

                        EspaceSyndic.ServiceReference.DocumentEntitie doc = docs.FirstOrDefault(x => x.Guid == docGuid);
                        if (doc != null)
                        {
                            messageRetour += ServiceReferenceUtils.DeleteDocument(docGuid) + "\n";
                            logDialog.rtLog.Text +=   messageRetour;
                            logDialog.rtLog.Refresh();
                        }
                    }
                    
                   // MessageBox.Show(this, "Résultat de la suppréssion des documents : \n" + messageRetour, "Suppression des documents");
                    docs = ServiceReferenceUtils.GetInstance().GetListDocuments("", "").ToList();
                    FillLvDocs();
                }
            }
        }
        //----------------------------------------------------------------
        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            TreeNode current = treeView.SelectedNode;
            ImmeubleEntite immeuble = null;
            CoproprietaireEntite copro = null;
            if (current != null && current.Tag != null)
            {
                if (current.Tag is ImmeubleEntite)
                    immeuble = (ImmeubleEntite)current.Tag;
                else if (current.Tag is CoproprietaireEntite)
                {
                    copro = (CoproprietaireEntite)current.Tag;
                    immeuble = copro.Immeuble;
                }
                Extranet.PublishDocument publishForm = new Extranet.PublishDocument(immeuble, copro);
                if (publishForm.ShowDialog() == DialogResult.OK)
                {
                    docs = ServiceReferenceUtils.GetInstance().GetListDocuments("", "").ToList();
                    FillLvDocs();
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------------------------------------------------
    }
}
