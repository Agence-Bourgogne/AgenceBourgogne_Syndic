using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
using GeranceData.Entites;
using GeranceData.Common;
namespace Gerance.Formulaires.AppelALoyer
{
    public partial class AppelALoyerFicheForm : Common.BaseFicheForm
    {
        private DataGridView datagridView;
        private bool bComboInitialized = false;
        // TODO à Paramétrer
        decimal taux_tva = 20, taux_bail = (decimal)0;
        BienEntite bien;

        public AppelALoyerFicheForm()
        {
            InitializeComponent();
        }
        public AppelALoyerFicheForm( string element_id, DataGridView datagridView):base(element_id)
        {
            InitializeComponent();
            this.datagridView = datagridView;
        }

        private void AppelALoyerFicheForm_Load(object sender, EventArgs e)
        {
            btnFirst.Visible = btnLast.Visible = btnPrev.Visible = btnNext.Visible = true;
        }
        private void InitCombo()
        {
            if (bComboInitialized)
                return;
            var dt = DateTime.Parse("01/01/2000");

            for (var i = 0; i < 12; i++)
            {
                var lDate = dt.ToLongDateString().Split(' ');
                cbMoisAugment.Items.Add(lDate[2]);

                dt = dt.AddMonths(1);
            }

            ParametresDB.FillComboFromParams(cbPeriodiciteAugmentation, "PERIOD_AUGMENTATION", "nom");
        }
        protected void setTotal()
        {
            var total = Convertir.ToDecimal(tbReste.Text);

            total += Convertir.ToDecimal(tbLoyer.Text);
            total += Convertir.ToDecimal(tbAugment.Text);
            total += Convertir.ToDecimal(tbTVA.Text);
            total += Convertir.ToDecimal(tbCharges.Text);
            total += Convertir.ToDecimal(tbFraisBail.Text);
            total += Convertir.ToDecimal(tbHonoLoc.Text);
            total += Convertir.ToDecimal(tbMontant1.Text);
            total += Convertir.ToDecimal(tbMontant2.Text);
            total += Convertir.ToDecimal(tbMontant3.Text);
            total += Convertir.ToDecimal(tbMontant4.Text);
            total += Convertir.ToDecimal(tbMontant5.Text);

            tbTotal.Text = total.ToString();

        }
        protected override void tbTextChanged(object sender, EventArgs e)
        {
            setTotal();            
            base.tbTextChanged(sender, e);
        }

        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            var entite = BienController.getController().getEntiteById(entite_id);
            return entite;
        }
        protected override void setFicheValues(AbstractBaseEntite abstract_entite)
        {
            bien = (BienEntite)abstract_entite;
            if (bien != null)
            {

                InitCombo();
                
                var locataire = bien.Locataire;
                decimal reste_du = 0;
                tbRefImmeuble.Text = bien.reference;
                tbLot.Text = bien.numero_lot.ToString();
                tbRefProprio.Text = bien.Proprietaire.reference;
                tbNomProprio.Text = bien.Proprietaire.NomPrenom;
                if (locataire != null)
                {
                    tbRefLocataire.Text = locataire.reference;
                    tbNomLocataire.Text = locataire.NomPrenom;
                    reste_du = locataire.total_du;// -bien.total_du;
                    tbReste.Text = reste_du.ToString();
                }
                tbNomImmeuble.Text = bien.nom;
                cbMoisAugment.SelectedIndex = bien.mois_augmentation -1 ;
                cbPeriodiciteAugmentation.SelectedValue = bien.periodicite_augmentation;

                tbLoyer.Text = bien.montant_loyer.ToString();
                tbAugment.Text = bien.montant_augmentation.ToString();
//               tbTVA.Text = entite.
                tbTVA.Text = bien.valeur_taxe.ToString();
                tbCharges.Text = bien.montant_charges.ToString();
                
                tbMontant1.Text = bien.montant_divers1.ToString();
                tbMontant2.Text = bien.montant_divers2.ToString();
                tbMontant3.Text = bien.montant_divers3.ToString();
                tbMontant4.Text = bien.montant_divers4.ToString();
                tbMontant5.Text = bien.montant_divers5.ToString();

                tbPresta1.Text = bien.divers1.Trim();
                tbPresta2.Text = bien.divers2.Trim();
                tbPresta3.Text = bien.divers3.Trim();
                tbPresta4.Text = bien.divers4.Trim();
                tbPresta5.Text = bien.divers5.Trim();

                tbFraisBail.Text = bien.frais_bail.ToString();
                tbIndice.Text = bien.dernier_indice.ToString();
                tbHonoLoc.Text = bien.honoraires_locataire.ToString();
                setTotal();
            }
            else
            {

            }
            base.setFicheValues(bien);
        }
        protected enum SensDeplacement { Top, Previous, Next, Bottom };
        protected void getNewEntite(SensDeplacement sens)
        {
            if (saveForm(true, false) == DialogResult.Cancel)
                return;

            try
            {
                if (datagridView != null)
                {
                    if ( datagridView.SelectedRows.Count > 0 )
                    {
                        var current = datagridView.SelectedRows[0].Index;
                        datagridView.Rows[current].Selected = false;
                        switch (sens)
                        {
                            case SensDeplacement.Top:
                                current = 0;
                                break;
                            case SensDeplacement.Previous:
                                current = Math.Max(0, current - 1);
                                break;
                            case SensDeplacement.Next:
                                current = Math.Min(current + 1, datagridView.Rows.Count - 1);
                                break;
                            case SensDeplacement.Bottom:
                                current = datagridView.Rows.Count - 1;
                                break;
                        }

                        datagridView.Rows[current].Selected = true;
                        var row = datagridView.Rows[current];
                        entite_id = row.Cells["id"].Value.ToString();
                        var entite = (BienEntite)getCurrentEntite(entite_id);
                        if (entite != null)
                            setFicheValues(entite);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override bool saveValue()
        {
            var rc = false;
            var entite = (BienEntite)getCurrentEntite(entite_id);
            if (entite != null)
            {
                entite.montant_loyer = Convertir.ToDecimal(tbLoyer.Text);
                entite.montant_augmentation = Convertir.ToDecimal(tbAugment.Text);
                entite.valeur_taxe = Convertir.ToDecimal(tbTVA.Text);
                entite.montant_charges = Convertir.ToDecimal(tbCharges.Text);
                entite.frais_bail = Convertir.ToDecimal(tbFraisBail.Text);
                entite.montant_divers1= Convertir.ToDecimal(tbMontant1.Text);
                entite.montant_divers2 = Convertir.ToDecimal(tbMontant2.Text);
                entite.montant_divers3 = Convertir.ToDecimal(tbMontant3.Text);
                entite.montant_divers4 = Convertir.ToDecimal(tbMontant4.Text);
                entite.montant_divers5 = Convertir.ToDecimal(tbMontant5.Text);
                entite.honoraires_locataire = Convertir.ToDecimal(tbHonoLoc.Text);
                entite.divers1 = tbPresta1.Text;
                entite.divers2 = tbPresta2.Text;
                entite.divers3 = tbPresta3.Text;
                entite.divers4 = tbPresta4.Text;
                entite.divers5 = tbPresta5.Text;

                entite.dernier_indice = Convertir.ToInt(tbIndice.Text);

                // TODO  Gérer Dernier indice et Variation
                
                return BienController.getController().InsertOrUpdate(entite);
            }
            return rc;
        }
        
        protected override void btnFirst_Click(object sender, EventArgs e)
        {
            getNewEntite(SensDeplacement.Top);

        }
        protected override void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(SensDeplacement.Previous);
        }
        protected override void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(SensDeplacement.Next);
        }
        protected override void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite(SensDeplacement.Bottom);
        }

        private void btnGetCoeff_Click(object sender, EventArgs e)
        {
            var form = new Indices.IndicesForm( tbCoeff, tbIndice);
            form.ShowDialog(this);
            if (Convertir.ToDecimal(tbCoeff.Text) != (decimal)0.0)
            {
                btnAugment_Click(null, null);
            }
        }
        private void btnUpdateLoyer_Click(object sender, EventArgs e)
        {
            var loyer = Convertir.ToDecimal(tbLoyer.Text);
            var augment = Convertir.ToDecimal(tbAugment.Text);
            var new_loyer = loyer+augment;

            tbLoyer.Text = new_loyer.ToString();
            tbAugment.Text = "0";
        }

        private void btnAugment_Click(object sender, EventArgs e)
        {
            if (Convertir.ToDecimal(tbCoeff.Text) == (decimal) 0.0)
            {
                MessageBox.Show("Vous devez définir le Coefficient d'augmentation");
            }
            else
            {
                var variation = Convertir.ToDecimal(tbCoeff.Text) / 100;
                var loyer = Convertir.ToDecimal(tbLoyer.Text);
                var augment = variation * loyer;
                tbAugment.Text = $"{augment:N2}";
                tbLoyer_Validating(null, null);
            }
        }

        private void tbCoeff_Validating(object sender, CancelEventArgs e)
        {
            btnAugment_Click(null, null);
        }

        private void tbLoyer_Validating(object sender, CancelEventArgs e)
        {
            var loyer = Convertir.ToDecimal(tbLoyer.Text) + Convertir.ToDecimal(tbAugment.Text);
            var tva = Math.Round((loyer) * ((bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
            tbTVA.Text = tva.ToString();
        }

        private void lblPresta5_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            switch (lbl.Name)
            {
                case "lblPresta1":
                    tbPresta1.Text = tbMontant1.Text = "";
                    break;
                case "lblPresta2":
                    tbPresta2.Text = tbMontant2.Text = "";
                    break;
                case "lblPresta3":
                    tbPresta3.Text = tbMontant3.Text = "";
                    break;
                case "lblPresta4":
                    tbPresta4.Text = tbMontant4.Text = "";
                    break;
                case "lblPresta5":
                    tbPresta5.Text = tbMontant5.Text = "";
                    break;
            }
        }

        private void lblPrestaAll_Click(object sender, EventArgs e)
        {
            tbPresta1.Text = tbMontant1.Text = "";
            tbPresta2.Text = tbMontant2.Text = "";
            tbPresta3.Text = tbMontant3.Text = "";
            tbPresta4.Text = tbMontant4.Text = "";
            tbPresta5.Text = tbMontant5.Text = "";
        }
    }
}
