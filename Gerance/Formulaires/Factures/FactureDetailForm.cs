using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Entites;
using GeranceData.Controller;
using GeranceData.Common;
using CommonProjectsPartners.Utils;
namespace Gerance.Formulaires.Factures
{
    public partial class FactureDetailForm : Form
    {
        string facture_id;
        public FactureDetailForm()
        {
            InitializeComponent();
        }
        public FactureDetailForm(string facture_id)
        {
            InitializeComponent();
            this.facture_id = facture_id;
        }
        protected  void InitializeCombos()
        {
            ParametresDB.FillComboFromParams(cbReglement, "REGLEMENTS", "nom");
            cbReglement.SelectedIndex = 1;
        }
        private void FactureDetailForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            InitializeCombos();
            ShowFicheValues(facture_id);
        }
        private void ShowFicheValues(string entite_id)
        {
            FactureEntite entite = null;
            if (entite_id != null)
                entite = FacturesController.getController().getEntiteById(entite_id);
            if (entite != null)
            {
//                decimal montant = entite.debit == 0 ? entite.credit * -1 : entite.debit;
                decimal montant = entite.debit == 0 ? entite.credit : entite.debit;
                tbMontant.Text = montant.ToString();

                dtEcriture.Value = entite.date_facture;
                tbLibelle.Text = entite.libelle;
                cbReglement.SelectedValue = entite.code_reglement;
                ShowInfoImmeuble(entite.Bien);
                ShowInfoLocataire(entite.Locataire);
                ShowInfoProprio(entite.Proprietaire);
                ShowInfoNature(entite.Nature);
                ShowInfoFournisseur(entite.Fournisseur);
                tbNature_Validating(null, null);
                tbDesiFournisseur.Text = entite.libelle_fournisseur;
                cbReglement.SelectedValue = entite.code_reglement;
            }
            else
            {
            }
        }
        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            tbNature.BackColor = Color.White;
            tbLibNature.Text = "";

            if (tbNature.Text == "")
                return;

            NatureEntite entite = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (entite != null)
            {
                tbLibNature.Text = entite.nom;
            }
            else
                tbNature.BackColor = Color.Red;
        }
        private void tbFournisseur_Validating(object sender, CancelEventArgs e)
        {
            tbFournisseur.BackColor = Color.White;
            tbNomFournisseur.Text = "";
            tbDesiFournisseur.Text = "";

            if (tbFournisseur.Text == "")
                return;

            FournisseurEntite entite = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);

            if (entite != null)
            {
                tbNomFournisseur.Text = entite.nom;
                tbDesiFournisseur.Visible = (entite.reference == "999");
            }
            else
                tbNature.BackColor = Color.Red;
        }

        private void ShowInfoProprio(ProprietaireEntite proprio)
        {
            if (proprio != null)
            {
                tbRefProprio.Text = proprio.reference;
                tbNomProprio.Text = proprio.nom;
                tbPrenomProprio.Text = proprio.prenom;
            }
            else
                tbRefProprio.Text = tbNomProprio.Text = tbRefImmeuble.Text = "";
        }
        private void ShowInfoImmeuble(BienEntite bien)
        {
            if (bien != null)
            {
                tbRefImmeuble.Text = bien.reference;
                tbNomImmeuble.Text = bien.nom;
                tbNumLot.Text = bien.numero_lot.ToString();
            }
            else
                tbNomImmeuble.Text = tbRefImmeuble.Text = tbNumLot.Text = "";
        }

        private void ShowInfoLocataire(LocataireEntite locataire)
        {
            if (locataire != null)
            {
                tbRefLocataire.Text = locataire.reference;
                tbNomLocataire.Text = locataire.nom;
                tbPrenomLocataire.Text = locataire.prenom;
            }
            else
                tbRefLocataire.Text = tbNomLocataire.Text = tbNomLocataire.Text = "";
        }

        private void ShowInfoNature(NatureEntite nature)
        {
            if (nature != null)
            {
                tbNature.Text = nature.reference;
                tbLibNature.Text = nature.nom;
            }
            else
                tbNature.Text = tbLibNature.Text = "";

        }
        private void ShowInfoFournisseur(FournisseurEntite fournisseur)
        {
            if (fournisseur != null)
            {
                tbFournisseur.Text = fournisseur.reference;
                tbNomFournisseur.Text = fournisseur.nom;
                tbDesiFournisseur.Visible = (fournisseur.reference == "999");
            }
            else
                tbFournisseur.Text = tbNomFournisseur.Text = "";
        }
        NatureEntite nature;
        FournisseurEntite fournisseur;

        protected bool ValideDatas()
        {
            nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (nature == null)
            {
                MessageBox.Show("Reference Nature Invalide");
                return false;
            }

            fournisseur = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);
            if (fournisseur == null)
            {
                MessageBox.Show("Reference Fournisseur Invalide");
                return false;
            }

            if (cbReglement.SelectedIndex < 0)
            {
                MessageBox.Show("Vous devez définir un mode de règlement");
                return false;
            }
            return true;
        }

        protected bool saveValue()
        {
            if (!ValideDatas())
                return false;
            FactureEntite facture = FacturesController.getController().getEntiteById(facture_id);
            LocataireEntite locataire = facture.Locataire;

            decimal montant = Convertir.ToDecimal(tbMontant.Text);

            facture.credit = facture.debit = 0;
            if (montant < 0)
                facture.credit = montant;
            else
                facture.debit = montant;
            facture.Bien = locataire.Bien;
            facture.Proprietaire = locataire.Bien.Proprietaire;
            facture.Locataire = locataire;
            facture.date_facture = dtEcriture.Value;
            facture.code_reglement = (int)cbReglement.SelectedValue;
            facture.libelle = tbLibelle.Text;
            facture.Nature = nature;
            facture.Fournisseur = fournisseur;
            if (fournisseur.reference == "999")
                facture.libelle_fournisseur = tbDesiFournisseur.Text;
            else
                facture.libelle_fournisseur = "";

            if (!FacturesController.getController().InsertOrUpdate(facture))
                return false;
            this.Close();
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveValue();
        }
    }
}
