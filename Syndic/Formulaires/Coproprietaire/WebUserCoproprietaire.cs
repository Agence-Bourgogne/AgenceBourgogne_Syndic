using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.ServiceReference;
using EspaceSyndic.UtilsApp;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire;

public partial class WebUserCoproprietaire : Form
{
    private bool bInLoad;
    public readonly CoproprietaireEntite currentCoproprietaire = new();
    private List<DocumentEntitie> docs;
    public WebUserCoproprietaire(CoproprietaireEntite copro)
    {
        InitializeComponent();
        currentCoproprietaire = copro;
        // _currentUsr = 
    }
    //---
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
    //---
    private void RefreshAll()
    {
        btnDelCopro.Enabled = false;
        btnDelDoc.Enabled = false;
        listDoc.DataSource = null;
        FillTreeView();
    }
    //---
    private void FillTreeView()
    {
        bInLoad = true;
        try
        {
            treeView.Nodes.Clear();
            var parent = new TreeNode { Text = "Immeubles", ImageIndex = 0 };
            treeView.Nodes.Add(parent);

            //     EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
            var immeubles = ServiceReferenceUtils.GetInstance().GetCoproChildrens(currentCoproprietaire.id).OrderBy(x => x.Immeuble_id).ToList();

            //   List<EspaceSyndic.ServiceReference.ChildrenEntitie> immeubles = ServiceReferenceUtils.GetInstance().GetUserCoproprietaires(_currentUsr.Guid).OrderBy(x => x.Immeuble_id).ToList();
            var immeuble_id = "";
            TreeNode current = null;
            foreach (var child in immeubles)
            {
                if (immeuble_id != child.Immeuble_id)
                {
                    var immeuble = ImmeubleController.getController().getEntiteById(child.Immeuble_id);
                    immeuble_id = child.Immeuble_id;
                    current = new TreeNode { Text = immeuble.nom, ImageIndex = 1, Tag = immeuble };
                    parent.Nodes.Add(current);
                }
                if (!string.IsNullOrEmpty(child.Copro_id))
                {
                    var copro = CoproprietaireController.getController().getEntiteById(child.Copro_id);
                    current.Nodes.Add(new TreeNode { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
                }
            }
            treeView.ExpandAll();
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
        bInLoad = false;
    }
    //---
    private void FillLvDocs()
    {
        bInLoad = true;
        listDoc.DataSource = null;
        var row = 0;
        var table = new DataTable();
        table.Columns.Add("Document");
        table.Columns.Add("Guid");
        var current = treeView.SelectedNode;
        var immeuble_id = "";
        var copro_id = "";
        var listdocs = new List<DocumentEntitie>();
        if (current != null && current.Tag != null)
        {
            var immeublesByUsers = ServiceReferenceUtils.GetInstance().GetCoproChildrens(currentCoproprietaire.id).OrderBy(x => x.Immeuble_id).ToList();
            //List<EspaceSyndic.ServiceReference.ChildrenEntitie> immeublesByUsers = ServiceReferenceUtils.GetInstance().GetUserCoproprietaires(_currentUsr.Guid).OrderBy(x => x.Immeuble_id).ToList();
            if (current.Tag is ImmeubleEntite immeuble)
            {
                immeuble_id = immeuble.getId();
                if (immeublesByUsers.Exists(x=>x.Immeuble_id == immeuble_id))
                {
                    foreach (var doc in docs)
                    {
                        if(doc.immeuble_id == immeuble_id && ( doc.copro_id == "" || immeublesByUsers.Exists(x=>x.Immeuble_id == immeuble_id && x.Copro_id == doc.copro_id )) )
                            listdocs.Add(doc);
                    }
                    //if (docs.Exists(x => x.immeuble_id == immeuble_id))
                    //    listdocs = docs.FindAll(x => x.immeuble_id == immeuble_id );

                }
                   
            }
            else if (current.Tag is CoproprietaireEntite copro)
            {
                copro_id = copro.getId();
                immeuble_id = copro.Immeuble.getId();
                if (immeublesByUsers.Exists(x=>x.Immeuble_id == immeuble_id))
                {
                    foreach (var doc in docs)
                    {
                        if(doc.immeuble_id == immeuble_id &&  immeublesByUsers.Exists(x=>x.Immeuble_id == immeuble_id && x.Copro_id == doc.copro_id ))
                            listdocs.Add(doc);
                    }
                    //if (docs.Exists(x => x.immeuble_id == immeuble_id))
                    //    listdocs = docs.FindAll(x => x.immeuble_id == immeuble_id );

                }
                //if (docs.Exists(x => x.immeuble_id == immeuble_id && x.copro_id == copro_id ))
                //    listdocs = docs.FindAll(x => x.immeuble_id == immeuble_id && x.copro_id == copro_id);
            }
        }

        foreach (var doc in listdocs)
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
    private void btnNewCopro_Click(object sender, EventArgs e)
    {

        var form = new FindCoproprietaireForm();
        if (DialogResult.Cancel != form.ShowDialog())
        {
            UserEntitie usr = null;// (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
            var entite = CoproprietaireController.getController().getEntiteFromField("reference", form.reference);
            try
            {
                if (entite != null)
                {
                    var immeuble = entite.Immeuble;
                    var res = ServiceReferenceUtils.GetInstance().AddCopro(usr.Guid, immeuble.id, entite.id, immeuble.reference, immeuble.nom, entite.reference, entite.NomPrenom);
                    if (string.IsNullOrEmpty(res))
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
    //-----

    private void btnDelCopro_Click(object sender, EventArgs e)
    {
        if (DialogResult.OK == MessageBox.Show("Voulez vous vraiment supprimer la copropriete", "Opération irreversible", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
        {
            var current = treeView.SelectedNode;
            if (current?.Tag != null && current.Tag is CoproprietaireEntite copro)
            {
                MessageBox.Show(ServiceReferenceUtils.DeleteCopro(copro.id));
                RefreshAll();
            }
        }

    }
    //-----
    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (bInLoad)
            return;
        btnDelCopro.Enabled = false;
        btnDelDoc.Enabled = false;
        var current = treeView.SelectedNode;
        if (current?.Tag != null && current.Tag is CoproprietaireEntite)
            btnDelCopro.Enabled = true;
        FillLvDocs();
    }

    //private void UpdateUser(object sender, EventArgs e)
    //{
    //    EspaceSyndic.ServiceReference.UserEntitie usr = (EspaceSyndic.ServiceReference.UserEntitie)dataGridView.SelectedRows[0].DataBoundItem;
    //    if (usr != null)
    //    {
    //        NewUserWebForm form = new NewUserWebForm(usr, "Modifier l'utilisateur");
    //        if (form.ShowDialog() == DialogResult.OK)
    //            RefreshAll();
    //        //                MessageBox.Show(ServiceReferenceUtils.UpateUser(usr.Guid));
    //        RefreshAll();
    //    }

    //}

    private void listDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (bInLoad)
            return;
        if (listDoc.SelectedItems.Count <= 0)
        {
            btnDelDoc.Enabled = false;
            return;
        }
        var drv = (DataRowView)listDoc.SelectedItems[0];
        var docGuid = drv["Guid"].ToString();

        var doc = docs.FirstOrDefault(x => x.Guid == docGuid);
        if (doc != null)
        {
            btnDelDoc.Enabled = true;
        }
    }

    private void btnDelDoc_Click(object sender, EventArgs e)
    {
        if (listDoc.SelectedItems.Count > 0)
        {
            if (DialogResult.OK == MessageBox.Show("Voulez vous vraiment supprimer le(s) document(s)", "Opération irreversible", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                var messageRetour = "";
                for (var i = 0; i < listDoc.SelectedItems.Count; i++)
                {
                    var drv = (DataRowView)listDoc.SelectedItems[i];
                    var docGuid = drv["Guid"].ToString();

                    var doc = docs.FirstOrDefault(x => x.Guid == docGuid);
                    if (doc != null)
                    {
                        messageRetour +=  ServiceReferenceUtils.DeleteDocument(docGuid) + "\n";
                    }
                }
                MessageBox.Show(this,"Résultat de la suppréssion des documents : \n" + messageRetour,"Suppression des documents");
                docs = ServiceReferenceUtils.GetInstance().GetListDocuments("", "").ToList();
                FillLvDocs();
            }
        }

    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
        tbPassword.Text = CryptoUtils.CreatePassword(8);
    }

}