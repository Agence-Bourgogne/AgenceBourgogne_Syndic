using System;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Entites;
using SyndicData.Controller;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    public partial class FicheCoproprietaireForm : Form
    {
        public CoproprietaireEntite entite = new CoproprietaireEntite();
        public CoproprietaireController controller = new CoproprietaireController();
        bool modified = false;
        //------------------------------------------------
        public FicheCoproprietaireForm()
        {
            InitializeComponent();
            ParametresDB.FillComboFromParams(cbCivilite, "CIVILITE");
            ParametresDB.FillComboFromParams(cbCodeEnvoiCompte, "CODEENVOICOMPTE");
        }
        //------------------------------------------------
        private void FicheCoproprietaireForm_Load(object sender, EventArgs e)
        {
            setFicheValues(null);
            btnEnter.Width = 0;
        }
        //------------------------------------------------
        private void setFicheValues(CoproprietaireEntite newEntite)
        {
            if (newEntite != null)
                this.entite = newEntite;
            tbRef.Text = entite.reference;
            tbNom.Text = entite.nom;
            tbPrenom.Text = entite.prenom;
            tbAdresse.Text = entite.adresse;
            tbCodePostal.Text = entite.codepostal;
            tbVille.Text = entite.ville;
            tbTel.Text = entite.telephone;
            cbCivilite.SelectedValue = entite.codenvoi;
            tbPays.Text = entite.pays;

            tbNote.Text = entite.note;
            tbEmail.Text = entite.email;

            ckVente.Checked = entite.huissier ;
            ckDeclaration.Checked = entite.declaration ;
//            ckDrapeau.Checked = (entite.drapeau == "*");
            ckCommerce.Checked = entite.commerce;
// Todo xxxcompte deviendrais xxxgerant
            tbNomCompte.Text = entite.nomcomp;
            tbAdresseCompte.Text = entite.adressecomp;
            tbVilleCompte.Text = entite.villecomp;
            tbCodePostalCompte.Text = entite.codecomp;
            tbTelCompte.Text = entite.telcomp;
            cbCodeEnvoiCompte.SelectedValue = entite.codenvcomp;
            ckDesactiv.Checked = entite.statut == (int)AbstractBaseEntite.StatutEntite.Supprime;
            modified = false;
        }
        //------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveForm(false);
        }
        //------------------------------------------------
        private bool saveForm(bool bShowMessage = false, bool bShowResult = true)
        {
            if (bShowMessage)
            {
                DialogResult result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                    "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.No)
                {
                    return true;
                }
            }

            entite.reference= tbRef.Text;
            entite.nom = tbNom.Text;
            entite.prenom = tbPrenom.Text;
            entite.adresse = tbAdresse.Text;
            entite.codepostal = tbCodePostal.Text;
            entite.ville = tbVille.Text;
            entite.telephone = tbTel.Text;
            entite.pays = tbPays.Text;
            entite.codenvoi = Convert.ToInt32(cbCivilite.SelectedValue);

            entite.note = tbNote.Text;
            entite.email = tbEmail.Text;

            entite.huissier = ckVente.Checked ;
            entite.declaration = ckDeclaration.Checked;
            entite.commerce = ckCommerce.Checked;

            entite.nomcomp = tbNomCompte.Text;
            entite.adressecomp = tbAdresseCompte.Text;
            entite.villecomp = tbVilleCompte.Text;
            entite.codecomp = tbCodePostalCompte.Text;
            entite.telcomp = tbTelCompte.Text;
            entite.codenvcomp = Convert.ToInt32(cbCodeEnvoiCompte.SelectedValue);

            entite.statut = ckDesactiv.Checked ? (int)AbstractBaseEntite.StatutEntite.Supprime : (int)AbstractBaseEntite.StatutEntite.Actif;

            if (controller.InsertOrUpdate(entite))
            {
                if ( bShowResult )
                    MessageBox.Show("Modifications entregistrées");
                modified = false;
                return true;
            }
            return false;
        }
        //------------------------------------------------
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------
        private void getNewEntite(String where, String message)
        {
            if (modified)
                if (!saveForm(true, false))
                    return;
            try
            {
                CoproprietaireEntite entite = controller.getEntite(where);
                if (entite != null)
                    setFicheValues(entite);

            }
            catch (Exception)
            {
                MessageBox.Show(message);
            }
        }
        //------------------------------------------------
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference", "Début de liste atteint");
        }
        //------------------------------------------------
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference < '{0}' order by reference desc", entite.reference), "Début de liste atteint");
        }
        //------------------------------------------------
        protected void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference > '{0}' order by reference ", entite.reference), "Fin de liste atteinte");
        }
        //------------------------------------------------
        protected void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference desc", "Fin de liste atteinte");
        }
        //------------------------------------------------
        private void FicheCoproprietaireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
                saveForm(true);
        }
        //------------------------------------------------
        private void tbTextChanged(object sender, EventArgs e)
        {
            modified = true;
        }
        //------------------------------------------------
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
        //------------------------------------------------
        private void lblRef_Click(object sender, EventArgs e)
        {
            FindCoproprietaireForm form = new FindCoproprietaireForm(tbRef);
            if (DialogResult.Cancel != form.ShowDialog())
            {
                entite = controller.getEntiteFromField("reference", tbRef.Text);
                setFicheValues(entite);
            }
        }

        //private void btnUserWeb_Click(object sender, EventArgs e)
        //{
        //    WebUserCoproprietaire webUserForm = new WebUserCoproprietaire(entite);
        //    webUserForm.ShowDialog();

        //}

      
    }
}
