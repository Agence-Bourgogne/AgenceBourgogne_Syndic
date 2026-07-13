using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Entites;
using SyndicData.Controller;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;
namespace EspaceSyndic.Formulaires.Fournisseur
{
    public partial class FicheFournisseurForm : Form
    {
        public FournisseurEntite entite;
        public FournisseurController controller = new FournisseurController();
        private bool modified = false;
        public FicheFournisseurForm(bool bShowNav = true)
        {
            InitializeComponent();
            btnFirst.Visible = btnLast.Visible = btnNext.Visible = btnPrev.Visible = bShowNav; 
        }

        private void FicheFournisseurForm_Load(object sender, EventArgs e)
        {
            ParametresDB.FillComboFromParams(cbReglement, "FACTURE_REGLEMENT");
            setFicheValues(null);
            btnEnter.Width = 0;
        }

        private void setFicheValues(FournisseurEntite newEntite)
        {
            if (newEntite != null)
                this.entite = newEntite;

	        tbRef.Text = entite.reference;
	        tbNom.Text = entite.nom;
	        tbInterlocuteur.Text = entite.interlocuteur;
	        tbTel.Text = entite.telephone;
	        tbAdresse.Text = entite.adresse;
	        tbCodePostal.Text = entite.codepostal;
	        tbVille.Text= entite.ville;
            cbReglement.SelectedValue = entite.reglement;
	        tbComment.Text = entite.commentaire;
	        tbSiret.Text = entite.siret;
	        tbSecu.Text = entite.numsecu;
	        tbApe.Text = entite.codeape;
            tbUrsaff.Text= entite.numurs;
            ckDesactiv.Checked = entite.statut == (int)AbstractBaseEntite.StatutEntite.Supprime;

            modified = false;
        }
        private void getNewEntite(String where, String message)
        {
            if (modified)
                if (!saveForm(true))
                    return;

            try
            {
                FournisseurEntite newEntite = controller.getEntite(where);
                if (newEntite != null)
                    setFicheValues(newEntite);
            }
            catch (Exception)
            {
                MessageBox.Show(message);
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveForm();
        }
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


            entite.reference = tbRef.Text.ToString();
            if (entite.reference == "")
            {
                MessageBox.Show("Référence invalide");
                return false;
            }
            entite.nom = tbNom.Text;
            entite.interlocuteur = tbInterlocuteur.Text;
            entite.telephone = tbTel.Text;
            entite.adresse = tbAdresse.Text;
            entite.ville = tbVille.Text;
            entite.codepostal = tbCodePostal.Text;
            entite.reglement = Convert.ToInt32(cbReglement.SelectedValue);
//            entite.codereg = tbCodeRegion.Text.Equals("") ? 0 : Convert.ToInt32(tbCodeRegion.Text);
            entite.commentaire = tbComment.Text;
            entite.siret = tbSiret.Text;
            entite.numsecu = tbSecu.Text;
            entite.codeape = tbApe.Text;
            entite.numurs = tbUrsaff.Text;
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
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference::integer", "Début de liste atteint");
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference::integer < {0} order by reference::integer desc", entite.reference), "Début de liste atteint");
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference::integer > {0} order by reference::integer ", entite.reference), "Fin de liste atteinte");
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference::integer desc", "Fin de liste atteinte");
        }

        private void FicheFournisseurForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
                if (!saveForm(true))
                    e.Cancel = true;
        }

        private void tbTextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
//            btnEnter.Width = 0;
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void lblRef_Click(object sender, EventArgs e)
        {
            FindFournisseurForm form = new FindFournisseurForm(tbRef);
            if (DialogResult.Cancel != form.ShowDialog())
            {
                entite = controller.getEntiteFromField("reference", tbRef.Text);
                setFicheValues(entite);
            }
        }
    }
}
