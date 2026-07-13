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

        //------------------------------------
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
        //----------------------------------
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
                    filter += String.Format(" and reference like '{0}%' ", tbRef.Text);
                if (tbNom.Text != "")
                    filter += String.Format(" and LOWER(nom) like LOWER('{0}%') ", tbNom.Text);
            }
            else if (TypeSearch == 1)
            {
                tbNomComp.Enabled = true;
                if (tbRef.Text != "")
                    filter += String.Format(" and reference like '{0}%' ", tbRef.Text);
                if (tbNom.Text != "")
                    filter += String.Format(" and LOWER(nom) like LOWER('{0}%') ", tbNom.Text);
                if (tbNomComp.Text != "")
                    filter += String.Format(" and LOWER(nomcomp) like LOWER('{0}%') ", tbNomComp.Text);
                else
                    filter += String.Format(" and nomcomp  <> ''", tbNomComp.Text);
            }
            source = controller.GetListCopro(filter);
            if (source != null)
            {
                //------------------------------------------------------------------------------------  Test insertion par liste
                //    List<CoproprietaireEntite> coproprietaires = new List<CoproprietaireEntite>();
                //    foreach (DataRow row in source.Rows)
                //        coproprietaires.Add(new CoproprietaireEntite(row));
                //    dataGridView.DataSource = coproprietaires;
                //-------------------------------------------------------------------------------------
                dataGridView.DataSource = source;
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["trimmed_email"].Visible = false;
                //  cols["nom"].Width = 250;
                ControlsWindows.ToTitleCase(cols);
                dataGridView.ReadOnly = true;
                //  cols["statut"].Visible = false;
            }
        }
        private void FindStdForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
        }
        //------------------------------------

        private void tbRef_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //------------------------------------
        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //------------------------------------
        private void tbNomComp_TextChanged(object sender, EventArgs e)
        {
            FillListFromFilter();
        }
        //------------------------------------
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
        //----------------------------------------------------------------
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bInLoad)
                return;
            if (dataGridView.SelectedRows.Count > 0)
            {
                CoproprietaireEntite coproprietaire = null;
                DataRowView rowView = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (rowView["id"].ToString() != "")
                {
                    listeCopros = new List<CoproprietaireEntite>();
                    coproprietaire = CoproprietaireController.getController().getEntiteById(rowView["id"].ToString());
                    tbCode.Text = coproprietaire.email;
                    listeCopros.Add(coproprietaire);
                    List<CoproprietaireEntite> TmplisteCopros = FillListImmeubleByMail(coproprietaire);
                    if (TmplisteCopros != null && TmplisteCopros.Count > 0)
                        listeCopros.AddRange(TmplisteCopros);
                    FillTreeView();
                }
            }
        }
        //----------------------------------------------------------------
        private List<CoproprietaireEntite> FillListImmeubleByMail(CoproprietaireEntite coproprietaire)
        {
           List<CoproprietaireEntite> TmplisteCopros = new List<CoproprietaireEntite>();
           string email = coproprietaire.email;
           string currentId = coproprietaire.id;
           foreach (DataGridViewRow row in dataGridView.Rows)
           {
               DataRowView rowView = (DataRowView)row.DataBoundItem;
               string emailRow = rowView["trimmed_email"].ToString();
               string idRow = rowView["id"].ToString();
               if (emailRow.Equals(email) && idRow != currentId)
               {
                   TmplisteCopros.Add(CoproprietaireController.getController().getEntiteById(idRow));
               }
           }
           return TmplisteCopros;
        }
        //----------------------------------------------------------------
        private void FillTreeView()
        {
            bInLoad = true;
            listeImmeubles = new List<ImmeubleEntite>(); 
            try
            {
                treeView.Nodes.Clear();
                TreeNode parent = new TreeNode() { Text = "Immeubles", ImageIndex = 0 };
                int iNode = treeView.Nodes.Add(parent);
                treeView.Nodes[iNode].Checked = true;
                String immeuble_id = "";
                TreeNode current = null;
                foreach(CoproprietaireEntite copro in listeCopros)
                {
                    if (copro != null && copro.Immeuble != null && !listeImmeubles.Contains(copro.Immeuble))
                    {
                        if(listeImmeubles.FirstOrDefault(x=>x.id == copro.Immeuble.id) == null)
                            listeImmeubles.Add(copro.Immeuble);
                    }
                }
                foreach (ImmeubleEntite immeuble in listeImmeubles)
                {
                        immeuble_id = immeuble.id;
                        current = new TreeNode() { Text = immeuble.nom, ImageIndex = 1, Tag = immeuble.id };
                        int ImmeubleNode = parent.Nodes.Add(current);
                        parent.Nodes[ImmeubleNode].Checked = true;
                        foreach (CoproprietaireEntite copro in listeCopros.FindAll(x => x.Immeuble.id == immeuble.id))
                        {
                            //Console.WriteLine("test " + itemGroup.Key.nom + " : " + copro.nom);
                            int coproNode = current.Nodes.Add(new TreeNode() { Text = copro.reference + ":" + copro.NomPrenom, Tag = copro });
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
        //------------------------------------
        private void valid_Click(object sender, EventArgs e)
        {
            if (!CommonProjectsPartners.Utils.RegexUtils.IsValidEmail(tbCode.Text))
                MessageBox.Show(this, "Format Email Invalide");
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show(this, "Le mot de passe est vide");
            }
            else
            {
                string msg = ServiceReferenceUtils.CreateUser(tbCode.Text, tbPassword.Text);
                if (String.Compare(msg, "0", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.CompareOptions.IgnoreNonSpace | System.Globalization.CompareOptions.IgnoreCase) == 0)
                {
                    EspaceSyndic.ServiceReference.UserEntitie user = ServiceReferenceUtils.GetInstance().GetUserFromCode(tbCode.Text);
                    foreach (TreeNode node in treeView.Nodes[0].Nodes)
                    {
                        if (node.Checked)
                        {
                            foreach (TreeNode nodeCopro in node.Nodes)
                            {
                                if (nodeCopro.Checked && nodeCopro.Tag != null && (nodeCopro.Tag is CoproprietaireEntite))
                                {
                                    CoproprietaireEntite currentCopro = nodeCopro.Tag as CoproprietaireEntite;
                                    string res = ServiceReferenceUtils.GetInstance().AddCopro(user.Guid, currentCopro.Immeuble.id, currentCopro.id, currentCopro.Immeuble.reference, currentCopro.Immeuble.nom, currentCopro.reference, currentCopro.NomPrenom);

                                }
                            }
                        }
                    }
                    if(ckSendMail.Checked)
                    {
                        EspaceSyndic.UtilsApp.MailUtils.SendEMail(tbCode.Text, tbPassword.Text);
                       // SendEMail(tbCode.Text, tbPassword.Text);
                    }
                    MessageBox.Show(this, "Utilisateur crée avec succès");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, msg);
                }
            }
        }
      
        //------------------------------------
        private void cancel_Click(object sender, EventArgs e)
        {
            reference = "";
        }
        //------------------------------------
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbPassword.Text = CryptoUtils.CreatePassword(8);
        }
    }
}
