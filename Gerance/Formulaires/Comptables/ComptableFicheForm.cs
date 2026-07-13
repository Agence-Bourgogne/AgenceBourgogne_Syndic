using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using GeranceData.Entites;

namespace Gerance.Formulaires.Comptables
{
    public partial class ComptableFicheForm : Gerance.Formulaires.Common.CommonFicheForm
    {
        private ComptableEntite comptable;
        public ComptableFicheForm()
        {
            InitializeComponent();
        }
        public ComptableFicheForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                comptable = (ComptableEntite)entite;
            else
                comptable = new ComptableEntite();

            currentReference = comptable.reference;

            tbReference.Text = comptable.reference;
            tbNom.Text = comptable.nom;
            tbPrenom.Text = comptable.prenom;
            tbAdresse.Text = comptable.adresse;
            tbCodePostal.Text = comptable.codepostal;
            tbVille.Text = comptable.ville;
            tbTelephone.Text = comptable.telephone;
            tbEmail.Text = comptable.email;
            tbNote.Text = comptable.note;

            base.setFicheValues(comptable);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return ComptableController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return ComptableController.getController().getEntite(where);
        }

        protected override bool saveValue()
        {
            if ( String.IsNullOrEmpty(tbReference.Text ))
            {
                MessageBox.Show("La référence ne peux pas être vide");
                return false;
            }
            this.currentReference = tbReference.Text;

            comptable.reference = tbReference.Text;
            comptable.nom = tbNom.Text;
            comptable.prenom = tbPrenom.Text;
            comptable.adresse = tbAdresse.Text;
            comptable.codepostal = tbCodePostal.Text;
            comptable.ville = tbVille.Text;
            comptable.telephone = tbTelephone.Text;
            comptable.email = tbEmail.Text;
            comptable.note = tbNote.Text;
            comptable.statut = 1;

            return ComptableController.getController().InsertOrUpdate(comptable);
        }
    }
}
