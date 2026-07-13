using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;

namespace Gerance.Formulaires.Reglements
{
    public partial class ReglementPartielForm : Gerance.Formulaires.Common.BaseFicheForm
    {
        ReglementEntite reglement;
        // TODO à Paramétrer
        decimal taux_tva = 20, taux_bail = (decimal)0;
        //        ReglementPartielEntite reglement;
        public ReglementPartielForm()
        {
            InitializeComponent();
        }
        public ReglementPartielForm(ReglementEntite reglement)
        {
            InitializeComponent();
            this.reglement = reglement;
        }

        private void ReglementPartielForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ReglementPartielForm_Load(object sender, EventArgs e)
        {
            tbReglement.Text = reglement.credit.ToString();

            foreach (Control ctl in gbMontant.Controls)
            {
                if (ctl is TextBox)
                    if (ctl.Enabled)
                        ctl.TextChanged += new System.EventHandler(this.tbPaiementTextChanged);
            }

            LocataireEntite locataire = reglement.Locataire;
            if (locataire != null)
            {
                BienEntite bien = locataire.Bien;
                if ( bien != null )
                {
                    tbShowLoyer.Text = locataire.Bien.montant_loyer.ToString();
                    tbShowCharges.Text = locataire.Bien.montant_charges.ToString();
                    tbShowHono.Text = locataire.Bien.honoraires_locataire.ToString();
                    tbShowTaxes.Text = locataire.Bien.valeur_taxe.ToString();
                    tbShowFrais.Text = locataire.Bien.frais_bail.ToString();
                    tbShowEtatLieux.Text = locataire.Bien.etat_lieux.ToString();

                    tbDiv1.Text = locataire.Bien.divers1;
                    tbDiv2.Text = locataire.Bien.divers2;
                    tbDiv3.Text = locataire.Bien.divers3;
                    tbDiv4.Text = locataire.Bien.divers4;
                    tbDiv5.Text = locataire.Bien.divers5;

                    tbShowMontant1.Text = locataire.Bien.montant_divers1.ToString();
                    tbShowMontant2.Text = locataire.Bien.montant_divers2.ToString();
                    tbShowMontant3.Text = locataire.Bien.montant_divers3.ToString();
                    tbShowMontant4.Text = locataire.Bien.montant_divers4.ToString();
                    tbShowMontant5.Text = locataire.Bien.montant_divers5.ToString();
                }
            }

            if (reglement.id != "")
            {
                tbLoyer.Text = reglement.base_honoraire.ToString();
                tbCharges.Text = reglement.charges.ToString();
                tbHonoLoc.Text = reglement.honoraire_locataire.ToString();
                tbTaxes.Text = reglement.valeur_taxe.ToString();
                tbFraisBail.Text = reglement.frais_bail.ToString();
                tbEtatLieux.Text = reglement.etat_lieux.ToString();
                tbLibelle.Text = reglement.libelle;
                tbDiv1.Text = reglement.divers1;
                tbDiv2.Text = reglement.divers2;
                tbDiv3.Text = reglement.divers3;
                tbDiv4.Text = reglement.divers4;
                tbDiv5.Text = reglement.divers5;

                tbMontantDiv1.Text = reglement.montant_divers1.ToString();
                tbMontantDiv2.Text = reglement.montant_divers2.ToString();
                tbMontantDiv3.Text = reglement.montant_divers3.ToString();
                tbMontantDiv4.Text = reglement.montant_divers4.ToString();
                tbMontantDiv5.Text = reglement.montant_divers5.ToString();
            }
            else
            {
                tbLibelle.Text = reglement.libelle;
                //lblLibelle.Visible = false;
                //tbLibelle.Visible = false;
            }
            setModified(false);
        }
        private void tbPaiementTextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            decimal montantReg = Convertir.ToDecimal(tbReglement.Text);
            total += Convertir.ToDecimal(tbLoyer.Text);
            
            if ( sender == tbLoyer)
            {
                decimal newTaxe = Math.Round(Convertir.ToDecimal(tbLoyer.Text) * ((reglement.Bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
                tbTaxes.Text = newTaxe.ToString();
            }
            total += Convertir.ToDecimal(tbCharges.Text);
            total += Convertir.ToDecimal(tbHonoLoc.Text);
            total += Convertir.ToDecimal(tbTaxes.Text);
            total += Convertir.ToDecimal(tbFraisBail.Text);
            total += Convertir.ToDecimal(tbEtatLieux.Text);

            total += Convertir.ToDecimal(tbMontantDiv1.Text);
            total += Convertir.ToDecimal(tbMontantDiv2.Text);
            total += Convertir.ToDecimal(tbMontantDiv3.Text);
            total += Convertir.ToDecimal(tbMontantDiv4.Text);
            total += Convertir.ToDecimal(tbMontantDiv5.Text);

            tbRepart.Text = total.ToString();
            tbDiff.Text = (montantReg - total).ToString();
            if (montantReg - total != 0)
            {
                tbDiff.BackColor = Color.Red;
            }
            else
                tbDiff.BackColor = tbShowFrais.BackColor;
        }
        protected override bool saveValue()
        {
            if ( Convertir.ToDecimal(tbDiff.Text) != 0)
            {
                DialogResult result = MessageBox.Show("Le montant du règlement ne correspond pas à la répartition\nVoulez vous Continuer", "Attention", MessageBoxButtons.YesNo);
                if ( result == DialogResult.No)
                    return false;
            }
            reglement.credit = Convertir.ToDecimal(tbReglement.Text);
            reglement.base_honoraire = Convertir.ToDecimal(tbLoyer.Text);
            reglement.charges = Convertir.ToDecimal(tbCharges.Text);
            reglement.honoraire_locataire = Convertir.ToDecimal(tbHonoLoc.Text);
            reglement.valeur_taxe = Convertir.ToDecimal(tbTaxes.Text);
            reglement.frais_bail = Convertir.ToDecimal(tbFraisBail.Text);
            reglement.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text);

            reglement.libelle = tbLibelle.Text;

            reglement.divers1 = tbDiv1.Text;
            reglement.divers2 = tbDiv2.Text;
            reglement.divers3 = tbDiv3.Text;
            reglement.divers4 = tbDiv4.Text;
            reglement.divers5 = tbDiv5.Text;

            reglement.montant_divers1 = Convertir.ToDecimal(tbMontantDiv1.Text);
            reglement.montant_divers2 = Convertir.ToDecimal(tbMontantDiv2.Text);
            reglement.montant_divers3 = Convertir.ToDecimal(tbMontantDiv3.Text);
            reglement.montant_divers4 = Convertir.ToDecimal(tbMontantDiv4.Text);
            reglement.montant_divers5 = Convertir.ToDecimal(tbMontantDiv5.Text);
            return true;
        }
    }
}
