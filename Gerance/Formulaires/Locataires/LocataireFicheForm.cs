using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using GeranceData.Entites;
using Gerance.Formulaires.Comptables;
using Gerance.Formulaires.Common;
using GeranceData.Common;
namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireFicheForm : Gerance.Formulaires.Common.CommonFicheForm
    {
        public LocataireEntite locataire;
        public LocataireFicheForm()
        {
            InitializeComponent();
            ParametresDB.FillComboFromParams(cbCivilite, "CIVILITE");
        }
        public LocataireFicheForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
            ParametresDB.FillComboFromParams(cbCivilite, "CIVILITE");
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                locataire = (LocataireEntite)entite;
            else
                locataire = new LocataireEntite();

            currentReference = locataire.reference;

            tbReference.Text = locataire.reference;
            cbCivilite.SelectedValue = locataire.civilite;
            tbNom.Text = locataire.nom;
            tbPrenom.Text = locataire.prenom;
            tbAdresse.Text = locataire.adresse;
            tbCodePostal.Text = locataire.codepostal;
            tbVille.Text = locataire.ville;
            tbTelephone.Text = locataire.telephone;
            tbEmail.Text = locataire.email;
            tbNote.Text = locataire.note;
            tbSolde.Text = locataire.total_du.ToString();
            tbRefComptable.Text = locataire.Comptable.reference;
            tbRefComptable_Validating(null, null);
            ckActif.Checked = ( locataire.statut == 1 || entite == null);
            base.setFicheValues(locataire);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return LocataireController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return LocataireController.getController().getEntite(where);
        }

        private void lblRefComptable_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ComptableFindForm(), tbRefComptable) == DialogResult.OK)
            {
                tbRefComptable_Validating(null, null);
            }
        }

        private void tbRefComptable_Validating(object sender, CancelEventArgs e)
        {
            if (tbRefComptable.Text != locataire.Comptable.reference)
            {
                ComptableEntite comptable = ComptableController.getController().getEntiteFromField("reference", tbRefComptable.Text);
                locataire.Comptable = comptable;
            }
            tbNomComptable.Text = locataire.Comptable.nom;
            tbPrenomComptable.Text = locataire.Comptable.prenom;
            tbAdresseComptable.Text = locataire.Comptable.adresse;
            tbCodePostalComptable.Text = locataire.Comptable.codepostal;
            tbVilleComptable.Text = locataire.Comptable.ville;
            tbTelComptable.Text = locataire.Comptable.telephone;
            tbEmailComptable.Text = locataire.Comptable.email;
        }
        protected override bool saveValue()
        {
            this.currentReference = tbReference.Text;

            locataire.reference = tbReference.Text;
            locataire.civilite = (int) cbCivilite.SelectedValue;
            locataire.nom = tbNom.Text;
            locataire.prenom = tbPrenom.Text;
            locataire.adresse = tbAdresse.Text;
            locataire.codepostal = tbCodePostal.Text;
            locataire.ville = tbVille.Text;
            locataire.telephone = tbTelephone.Text;
            locataire.email = tbEmail.Text;
            locataire.note = tbNote.Text;
            locataire.statut = 1;
            locataire.total_du = Convertir.ToDecimal(tbSolde.Text);
            locataire.statut = ckActif.Checked ? 1 : 9;
            return LocataireController.getController().InsertOrUpdate(locataire);
        }

        private void btnComptableAdd_Click(object sender, EventArgs e)
        {
            btnTypedAdd_Click ( new ComptableFicheForm() , tbRefComptable);
            tbRefComptable_Validating(null, null);
        }
        protected override void ShowFindFromReference()
        {
            if (DialogResult.OK == ShowFindForm(new LocataireFindForm(), tbReference))
            {
                locataire = LocataireController.getController().getEntiteFromField("reference", tbReference.Text);
                setFicheValues(locataire);
            }
            else
                setFicheValues(locataire);
        }
        private void form_SavePicture(object send, EventArgs e)
        {
            MessageBox.Show("Save");
        }
        private void label2_Click(object sender, EventArgs e)
        {

            ScanUtilForm form = new ScanUtilForm(ScanMethod.TWAIN);
            form.SavePicture += form_SavePicture;
            form.ShowDialog();
//            ScanUtils.WIAAcquire();
        }

        private void ckActif_CheckedChanged(object sender, EventArgs e)
        {
            setModified(true);
        }

        private void cbCivilite_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModified(true);
        }

    }
}
