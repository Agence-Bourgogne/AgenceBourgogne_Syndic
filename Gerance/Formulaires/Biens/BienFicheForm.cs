using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using GeranceData.Entites;
using GeranceData.Controller;
using GeranceData.Common;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Proprietaires;
namespace Gerance.Formulaires.Biens
{
    public partial class BienFicheForm : Common.BaseFicheForm
    {
        BienEntite bien;

        bool bCombosInitialized = false;
        public BienFicheForm()
        {
            InitializeComponent();
        }
        public BienFicheForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                bien = (BienEntite)entite;
            else
                bien = new BienEntite();

//            currentReference = String.Format("{0}-{1}", bien.reference, bien.numero_lot.ToString("0000"));
            currentReference = String.Format("{0}-{1}", bien.reference, bien.id);
            InitializeCombos();

            tbReference.Text = bien.reference;
            tbNom.Text = bien.nom;
            tbAdresse.Text = bien.adresse;
            tbCodePostal.Text = bien.codepostal;
            tbVille.Text = bien.ville;
            tbNumLot.Text = bien.numero_lot.ToString();
            tbBatiment.Text = bien.batiment;
            tbEscalier.Text = bien.escalier;
            tbEtage.Text = bien.etage;
            tbRefProprio.Text = bien.Proprietaire.reference;
            tbRefLocataire.Text = bien.Locataire.reference;

            tbDateEntree.Text = bien.date_entree.ToShortDateString();

            tbTaxe.Text = bien.taxe.ToString();
            tbLoyer.Text = bien.montant_loyer.ToString();
            tbCharge.Text = bien.montant_charges.ToString();
            tbCaution.Text = bien.montant_caution.ToString();
            tbIndice.Text = bien.dernier_indice.ToString();
            cbMoisAugm.SelectedIndex = bien.mois_augmentation - 1;
            cbPeriodiciteLoyer.SelectedValue = bien.periodicite_loyer;
            tbDureeBail.Text = bien.duree_bail.ToString();
            tbPeriodiciteAugmentation.Text = bien.periodicite_augmentation.ToString();
            ckGul.Checked = (bien.garantie_universelle == 1);
            tbRefLocataire_Validating(null, null);
            tbRefProprio_Validating(null, null);
            ckActif.Checked = bien.statut == 1 || entite == null;
            base.setFicheValues(bien);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return BienController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return BienController.getController().getEntite(where);
        }
        // TODO à Paramétrer
        decimal taux_tva = 20, taux_bail = (decimal)0;

        protected override bool saveValue()
        {
            bien.reference = tbReference.Text;
            bien.nom = tbNom.Text;
            bien.adresse = tbAdresse.Text;
            bien.codepostal = tbCodePostal.Text;
            bien.ville = tbVille.Text;
            bien.numero_lot = Convertir.ToInt(tbNumLot.Text);
            bien.batiment = tbBatiment.Text;
            bien.escalier = tbEscalier.Text;
            bien.etage = tbEtage.Text;
            bien.date_entree = DateTime.Parse(tbDateEntree.Text);
            bien.taxe = Convertir.ToInt(tbTaxe.Text);
            bien.montant_loyer = Convertir.ToDecimal(tbLoyer.Text);
            bien.montant_charges = Convertir.ToDecimal(tbCharge.Text);
            bien.montant_caution = Convertir.ToDecimal(tbCaution.Text);
            bien.dernier_indice = Convertir.ToInt(tbIndice.Text);
            bien.mois_augmentation = cbMoisAugm.SelectedIndex + 1;
            if (cbPeriodiciteLoyer.SelectedValue != null)
                bien.periodicite_loyer = (int) cbPeriodiciteLoyer.SelectedValue;
            bien.duree_bail = Convertir.ToInt(tbDureeBail.Text);
            bien.periodicite_augmentation = Convertir.ToInt(tbPeriodiciteAugmentation.Text);
            bien.statut = 1;
            bien.garantie_universelle = ckGul.Checked ? 1 : 0;

            bien.valeur_taxe = Math.Round((bien.montant_loyer + bien.montant_augmentation) * ((bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
            //if (bien.isNew)
            //    bien.montant_du = bien.montant_loyer + bien.montant_charges + bien.valeur_taxe;
            bien.statut = ckActif.Checked ? 1 : 9;
            return BienController.getController().InsertOrUpdate(bien);
        }

        protected override void InitializeCombos()
        {
            if (bCombosInitialized)
                return;

            Console.WriteLine("InitializeCombo");
            // 
            DateTime dt = DateTime.Parse("01/01/2000");

            for (int i = 0; i < 12; i++)
            {
                String[] lDate = dt.ToLongDateString().Split(' ');
                cbMoisAugm.Items.Add(lDate[2]);
                dt = dt.AddMonths(1);
            }
            ParametresDB.FillComboFromParams(cbPeriodiciteLoyer, "PERIODICITE", "nom");
            cbPeriodiciteLoyer.SelectedIndexChanged += cbPeriodiciteLoyer_SelectedIndexChanged;
            bCombosInitialized = true;
        }

        void cbPeriodiciteLoyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModified(true);
        }

        private void lblProprietaire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprio) == DialogResult.OK)
            {
                tbRefProprio_Validating(null, null);
            }
        }

        private void lblLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK )
            {
                tbRefLocataire_Validating(null, null);
            }
        }

        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            tbRefProprio.BackColor = Color.White;
            if ( tbRefProprio.Text != "" )
                if (tbRefProprio.Text != bien.Proprietaire.reference)
                {
                    ProprietaireEntite proprietaire = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);

                    if (proprietaire == null)
                        tbRefProprio.BackColor = Color.Red;
                    bien.Proprietaire = proprietaire;
                }
            tbNomProprio.Text = bien.Proprietaire.nom;
            tbPrenomProprio.Text = bien.Proprietaire.prenom;
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if ( tbRefLocataire.Text != "")
                if (tbRefLocataire.Text != bien.Locataire.reference)
                {
                    LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                    if (locataire == null)
                        tbRefLocataire.BackColor = Color.Red;
                    bien.Locataire = locataire;
                }
            tbNomLocataire.Text = bien.Locataire.nom;
            tbPrenomLocataire.Text = bien.Locataire.prenom;
        }
        protected override void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format(" b where {0} < '{1}' order by {0} desc", BienController.ORDER, currentReference), "Début de liste atteint");
        }
        protected override void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format(" b where {0} > '{1}'  order by {0} ", BienController.ORDER, currentReference ), "Fin de liste atteinte");
        }
        protected void ShowFindFromReference()
        {
            if (DialogResult.OK == ShowFindForm(new BienFindForm(), tbReference))
            {
                bien = BienController.getController().getEntiteFromField("reference", tbReference.Text);
                setFicheValues(bien);
            }
            else
                setFicheValues(bien);
        }

        private void lblReference_Click(object sender, EventArgs e)
        {
            ShowFindFromReference();
        }

        private void btnProprioAdd_Click(object sender, EventArgs e)
        {
            ProprietaireFicheForm form = new ProprietaireFicheForm();
            form.ShowDialog();
            if (form.proprietaire != null)
            {
                tbRefProprio.Text = form.proprietaire.reference;
                tbRefProprio_Validating(null, null);
            }
            tbRefProprio.Focus();
        }

        private void btnLocataireAdd_Click(object sender, EventArgs e)
        {
            LocataireFicheForm form = new LocataireFicheForm();
            form.ShowDialog();
            if (form.locataire != null)
            {
                tbRefLocataire.Text = form.locataire.reference;
                tbRefLocataire_Validating(null, null);
            }
            tbRefLocataire.Focus();
        }

        private void tbReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblReference_Click(null, null);
        }

        private void tbRefProprio_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblProprietaire_Click(null, null);
        }

        private void tbRefLocataire_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblLocataire_Click(null, null);
        }

        private void ckGul_CheckedChanged(object sender, EventArgs e)
        {
            setModified(true);
        }

        private void ckActif_CheckedChanged(object sender, EventArgs e)
        {
            setModified(true);
        }
    }
}
