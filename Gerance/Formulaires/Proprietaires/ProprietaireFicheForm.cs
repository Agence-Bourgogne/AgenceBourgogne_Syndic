using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Comptables;
using GeranceData.Common;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class ProprietaireFicheForm : Common.CommonFicheForm
    {
        public ProprietaireEntite proprietaire;
        public ProprietaireFicheForm()
        {
            InitializeComponent();
            ParametresDB.FillComboFromParams(cbCivilite, "CIVILITE");
        }
        public ProprietaireFicheForm(string entite_id) : base (entite_id)
        {
            InitializeComponent();
            ParametresDB.FillComboFromParams(cbCivilite, "CIVILITE");
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                proprietaire = (ProprietaireEntite) entite;
            else
                proprietaire = new ProprietaireEntite();

            currentReference = proprietaire.reference;
            
            tbReference.Text = proprietaire.reference;
            cbCivilite.SelectedValue = proprietaire.civilite;
            tbNom.Text = proprietaire.nom;
            tbPrenom.Text = proprietaire.prenom;
            tbAdresse.Text = proprietaire.adresse;
            tbCodePostal.Text = proprietaire.codepostal;
            tbVille.Text = proprietaire.ville;
            tbTelephone.Text = proprietaire.telephone;
            tbEmail.Text = proprietaire.email;
            tbPays.Text = proprietaire.pays;
            tbNote.Text = proprietaire.note;

            tbHono.Text = proprietaire.taux_honoraire.ToString();

            tbRefComptable.Text = proprietaire.Comptable.reference;
            tbRefComptable_Validating(null, null);

            ckVirement.Checked = proprietaire.paiement_type == 1;
            //tbBanque.Text = proprietaire.banque;
            //tbRib.Text = proprietaire.rib;
            ckVirement_CheckedChanged(null, null);
            ckActif.Checked = proprietaire.statut == 1 || entite == null;
            tbSolde.Text = proprietaire.credit == 0 ? (proprietaire.debit*-1).ToString() : proprietaire.credit.ToString();

            base.setFicheValues(proprietaire);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return ProprietaireController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return ProprietaireController.getController().getEntite(where);
        }
        private void tbRefComptable_Validating(object sender, CancelEventArgs e)
        {
            if (tbRefComptable.Text != proprietaire.Comptable.reference)
            {
                var comptable = ComptableController.getController().getEntiteFromField("reference", tbRefComptable.Text);
                proprietaire.Comptable = comptable;
            }
            tbNomComptable.Text = proprietaire.Comptable.nom;
            tbPrenomComptable.Text = proprietaire.Comptable.prenom;
            tbAdresseComptable.Text = proprietaire.Comptable.adresse;
            tbCodePostalComptable.Text = proprietaire.Comptable.codepostal;
            tbVilleComptable.Text = proprietaire.Comptable.ville;
            tbTelComptable.Text = proprietaire.Comptable.telephone;
            tbEmailComptable.Text = proprietaire.Comptable.email;
        }
        protected override bool saveValue()
        {
            currentReference = tbReference.Text;

            proprietaire.reference = tbReference.Text;
            proprietaire.nom = tbNom.Text;
            proprietaire.civilite = (int) cbCivilite.SelectedValue;
            proprietaire.prenom = tbPrenom.Text;
            proprietaire.adresse = tbAdresse.Text;
            proprietaire.codepostal = tbCodePostal.Text;
            proprietaire.ville = tbVille.Text;
            proprietaire.telephone = tbTelephone.Text;
            proprietaire.email = tbEmail.Text;
            proprietaire.note = tbNote.Text;
            proprietaire.pays = tbPays.Text;

            proprietaire.paiement_type = ckVirement.Checked ? 1 : 0;
            proprietaire.rib = tbRib.Text;
            proprietaire.banque = tbBanque.Text;
            proprietaire.statut = ckActif.Checked ? 1 : 9;

            proprietaire.taux_honoraire = Convertir.ToInt(tbHono.Text);
            var solde = Convertir.ToDecimal(tbSolde.Text);
            if (solde < 0)
                proprietaire.debit = Math.Abs(solde);
            else
                proprietaire.credit = Math.Abs(solde);

            return ProprietaireController.getController().InsertOrUpdate(proprietaire);
        }
        private void lblRefComptable_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ComptableFindForm(), tbRefComptable) == DialogResult.OK)
            {
                tbRefComptable_Validating(null, null);
            }
        }
        private void btnComptableAdd_Click(object sender, EventArgs e)
        {
            btnTypedAdd_Click(new ComptableFicheForm(), tbRefComptable);
            tbRefComptable_Validating(null, null);
        }

        private void ckVirement_CheckedChanged(object sender, EventArgs e)
        {
            if ( ckVirement.Checked)
            {
                tbRib.Text = proprietaire.rib;
                tbBanque.Text = proprietaire.banque;
                tbRib.Enabled = tbBanque.Enabled = true;
                tbRib.ReadOnly = tbBanque.ReadOnly = false;
            }
            else
            {
                tbRib.Text = "";
                tbBanque.Text = "";
                tbRib.Enabled = tbBanque.Enabled = false;
                tbRib.ReadOnly = tbBanque.ReadOnly = true;
            }
        }
        protected override void ShowFindFromReference()
        {
            if (DialogResult.OK == ShowFindForm(new ProprietaireFindForm(), tbReference))
            {
                proprietaire = ProprietaireController.getController().getEntiteFromField("reference", tbReference.Text);
                setFicheValues(proprietaire);
            }
            else
                setFicheValues(proprietaire);
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
