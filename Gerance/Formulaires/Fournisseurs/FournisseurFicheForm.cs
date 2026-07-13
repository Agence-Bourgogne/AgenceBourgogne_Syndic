using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using GeranceData.Entites;

namespace Gerance.Formulaires.Fournisseurs
{
    public partial class FournisseurFicheForm : Common.CommonFicheForm
    {
        FournisseurEntite fournisseur;
        public FournisseurFicheForm()
        {
            InitializeComponent();
        }
        public FournisseurFicheForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                fournisseur = (FournisseurEntite)entite;
            else
                fournisseur = new FournisseurEntite();

            currentReference = fournisseur.reference;

            tbReference.Text = fournisseur.reference;
            tbNom.Text = fournisseur.nom;
            tbAdresse.Text = fournisseur.adresse;
            tbCodePostal.Text = fournisseur.codepostal;
            tbVille.Text = fournisseur.ville;
            tbTelephone.Text = fournisseur.telephone;
            tbNote.Text = fournisseur.commentaire;

            tbSiret.Text = fournisseur.siret;
            tbSecu.Text = fournisseur.numsecu;
            tbAPE.Text = fournisseur.codeape;
            tbUrsaf.Text = fournisseur.numurs;
            
            lblPrenom.Visible = false;
            tbPrenom.Visible = false;
            lblEmail.Visible = false;
            tbEmail.Visible = false;
            lblPays.Visible = false;
            tbPays.Visible = false;

            base.setFicheValues(fournisseur);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return FournisseurController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return FournisseurController.getController().getEntite(where);
        }
        protected override void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite($"where reference::integer < {currentReference} order by reference::integer desc", "Début de liste atteint");
        }
        protected override void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite($"where reference::integer > {currentReference} order by reference::integer ", "Fin de liste atteinte");
        }
        protected override void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference::integer desc", "Fin de liste atteinte");
        }

        protected override bool saveValue()
        {
            currentReference = tbReference.Text;

            fournisseur.reference = tbReference.Text;
            fournisseur.nom = tbNom.Text;
            fournisseur.adresse = tbAdresse.Text;
            fournisseur.codepostal = tbCodePostal.Text;
            fournisseur.ville = tbVille.Text;
            fournisseur.telephone = tbTelephone.Text;

            fournisseur.siret = tbSiret.Text;
            fournisseur.numsecu = tbSecu.Text;
            fournisseur.codeape = tbAPE.Text;
            fournisseur.numurs = tbUrsaf.Text;
            fournisseur.statut = 1;
            return FournisseurController.getController().InsertOrUpdate(fournisseur);
        }
        protected override void ShowFindFromReference()
        {
            if (DialogResult.OK == ShowFindForm(new FournisseurFindForm(), tbReference))
            {
                fournisseur = FournisseurController.getController().getEntiteFromField("reference", tbReference.Text);
                setFicheValues(fournisseur);
            }
            else
                setFicheValues(fournisseur);
        }

    }
}
