using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using EspaceSyndic.UtilsApp;
namespace EspaceSyndic.Formulaires.Utilisateurs
{
    public partial class FindUser : Form
    {
        //public BaseController<BaseEntite> controller;
        bool bInLoad = false;
        public string email = "";
        public string reference = "";
        public string filter = "";
        int TypeSearch = 0;
        protected DataTable source = null;
        public CoproprietaireController controller = new CoproprietaireController();
        public List<ImmeubleEntite> listeImmeubles = new List<ImmeubleEntite>();
        public List<CoproprietaireEntite> listeCopros = new List<CoproprietaireEntite>();
        TextBox tbResult = null;

        //-
        public FindUser()
        {
            InitializeComponent();
            // AdapteControls();
            bInLoad = true;
            cbTypeUser.Items.Add("Tous");
            cbTypeUser.Items.Add("Gerant");
            cbTypeUser.SelectedIndex = 0;
            SyndicData.Common.ParametresDB.getParam1("SERVEUR", "ADDRESSE CONNECTION");
            cbTypeUser.SelectedIndexChanged += cbTypeUser_SelectedIndexChanged;
            FillListFromFilter();
            bInLoad = false;
        }
        //------
        private void cbTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            bInLoad = true;
            TypeSearch = cbTypeUser.SelectedIndex;
            FillListFromFilter();
            bInLoad = false;
        }

        public void FillListFromFilter()
        {
            filter = " 1=1 ";
            filter += " and email <> ''";
            if (TypeSearch == 0)
            {
                tbNomComp.Enabled = false;
                if (tbRef.Text != "")
                    filter += $" and reference like '{tbRef.Text}%' ";
                if (tbNom.Text != "")
                    filter += $" and LOWER(nom) like LOWER('{tbNom.Text}%') ";
            }
            else if (TypeSearch == 1)
            {
                tbNomComp.Enabled = true;
                if (tbRef.Text != "")
                    filter += $" and reference like '{tbRef.Text}%' ";
                if (tbNom.Text != "")
                    filter += $" and LOWER(nom) like LOWER('{tbNom.Text}%') ";
                if (tbNomComp.Text != "")
                    filter += $" and LOWER(nomcomp) like LOWER('{tbNomComp.Text}%') ";
                else
                    filter += String.Format(" and nomcomp  <> ''", tbNomComp.Text);
            }
            source = controller.GetListCopro(filter);
            if (source != null)
            {
                dataGridView.DataSource = source;
                var cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["trimmed_email"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
                dataGridView.ReadOnly = true;
            }
        }
        private void FindStdForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
        }
        //-

        private void tbRef_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //-
        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //-
        private void tbNomComp_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //-
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
        
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bInLoad)
                return;
            if (dataGridView.SelectedRows.Count > 0)
            {
                CoproprietaireEntite coproprietaire = null;
                var rowView = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (rowView["id"].ToString() != "")
                {
                    listeCopros = new List<CoproprietaireEntite>();
                    coproprietaire = CoproprietaireController.getController().getEntiteById(rowView["id"].ToString());
                    tbCode.Text = coproprietaire.email;
                    listeCopros.Add(coproprietaire);
                    var TmplisteCopros = FillListImmeubleByMail(coproprietaire);
                    if (TmplisteCopros != null && TmplisteCopros.Count > 0)
                        listeCopros.AddRange(TmplisteCopros);
                    FillTreeView();
                }
            }
        }
        
        private List<CoproprietaireEntite> FillListImmeubleByMail(CoproprietaireEntite coproprietaire)
        {
           var TmplisteCopros = new List<CoproprietaireEntite>();
           var email = coproprietaire.email;
           var currentId = coproprietaire.id;
           foreach (DataGridViewRow row in dataGridView.Rows)
           {
               var rowView = (DataRowView)row.DataBoundItem;
               var emailRow = rowView["trimmed_email"].ToString();
               var idRow = rowView["id"].ToString();
               if (emailRow.Equals(email) && idRow != currentId)
               {
                   TmplisteCopros.Add(CoproprietaireController.getController().getEntiteById(idRow));
               }
           }
           return TmplisteCopros;
        }
        
        private void FillTreeView()
        {
            bInLoad = true;
            listeImmeubles = new List<ImmeubleEntite>(); 
            try
            {
                treeView.Nodes.Clear();
                var parent = new TreeNode() { Text = "Immeubles", ImageIndex = 0 };
                var iNode = treeView.Nodes.Add(parent);
                treeView.Nodes[iNode].Checked = true;
                var immeuble_id = "";
                TreeNode current = null;
                foreach(var copro in listeCopros)
                {
                    if (copro != null && copro.Immeuble != null && !listeImmeubles.Contains(copro.Immeuble))
                    {
                        if(listeImmeubles.FirstOrDefault(x=>x.id == copro.Immeuble.id) == null)
                            listeImmeubles.Add(copro.Immeuble);
                    }
                }
                foreach (var immeuble in listeImmeubles)
                {
                        immeuble_id = immeuble.id;
                        current = new TreeNode() { Text = immeuble.nom, ImageIndex = 1, Tag = immeuble.id };
                        var ImmeubleNode = parent.Nodes.Add(current);
                        parent.Nodes[ImmeubleNode].Checked = true;
                        foreach (var copro in listeCopros.FindAll(x => x.Immeuble.id == immeuble.id))
                        {
                            //Console.WriteLine("test " + itemGroup.Key.nom + " : " + copro.nom);
                            var coproNode = current.Nodes.Add(new TreeNode() { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
                            current.Nodes[coproNode].Checked = true; 
                        }
               
                }
               
                //foreach (CoproprietaireEntite copro in listeCopros)
                //{
                //    listeImmeubles = LotDescriptionController.getController().getListImmeublesCoproprietaire(copro.id);
                //    foreach (ImmeubleEntite immeuble in listeImmeubles)
                //    {
                //        immeuble_id = immeuble.id;
                //        current = new TreeNode() { Text = immeuble.nom, ImageIndex = 1, Tag = immeuble };
                //        int ImmeubleNode = parent.Nodes.Add(current);
                //        parent.Nodes[ImmeubleNode].Checked = true;
                //        //if (!String.IsNullOrEmpty(child.Copro_id))
                //        //{
                //        //    CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(child.Copro_id);
                //        //    current.Nodes.Add(new TreeNode() { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
                //        //}
                //        int coproNode = current.Nodes.Add(new TreeNode() { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
                //        current.Nodes[coproNode].Checked = true; 
                //    }
                //}
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
        //-
        private void valid_Click(object sender, EventArgs e)
        {
            if (!RegexUtils.IsValidEmail(tbCode.Text))
                MessageBox.Show(this, "Format Email Invalide");
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show(this, "Le mot de passe est vide");
            }
            else
            {
                var msg = ServiceReferenceUtils.CreateUser(tbCode.Text, tbPassword.Text);
                if (String.Compare(msg, "0", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.IgnoreNonSpace | System.Globalization.CompareOptions.IgnoreCase) == 0)
                {
                    var user = ServiceReferenceUtils.GetInstance().GetUserFromCode(tbCode.Text);
                    foreach (TreeNode node in treeView.Nodes[0].Nodes)
                    {
                        if (node.Checked)
                        {
                            foreach (TreeNode nodeCopro in node.Nodes)
                            {
                                if (nodeCopro.Checked && nodeCopro.Tag != null && (nodeCopro.Tag is CoproprietaireEntite))
                                {
                                    var currentCopro = nodeCopro.Tag as CoproprietaireEntite;
                                    var res = ServiceReferenceUtils.GetInstance().AddCopro(user.Guid, currentCopro.Immeuble.id, currentCopro.id, currentCopro.Immeuble.reference, currentCopro.Immeuble.nom, currentCopro.reference, currentCopro.NomPrenom);

                                }
                            }
                        }
                    }
                    if(ckSendMail.Checked)
                    {
                        MailUtils.SendEMail(tbCode.Text, tbPassword.Text);
                       // SendEMail(tbCode.Text, tbPassword.Text);
                    }
                    MessageBox.Show(this, "Utilisateur crée avec succès");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(this, msg);
                }
            }
        }
      
        //-
        private void cancel_Click(object sender, EventArgs e)
        {
            reference = "";
        }
        //-
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbPassword.Text = CryptoUtils.CreatePassword(8);
        }
    }
}
