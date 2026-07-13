using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gerance.Formulaires.Biens;
using Gerance.Formulaires.Locataires;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;
using GeranceData.Common;
using Microsoft.Reporting.WinForms;
using Npgsql;

namespace Gerance.Formulaires.AppelALoyer
{
    public partial class AnnulationQuittanceForm : Gerance.Formulaires.Common.BaseFicheForm
    {
        BienEntite bien;
        QuittanceEntite quittance;
        // TODO à Paramétrer
        decimal taux_tva = 20, taux_bail = (decimal)0;

        public AnnulationQuittanceForm()
        {
            InitializeComponent();
        }
        public AnnulationQuittanceForm(string quittance_id)
        {
            InitializeComponent();
            quittance = QuittancesController.getController().getEntiteById(quittance_id);
            bien = quittance.Bien;
            ShowInfoImmeuble(quittance.Bien);
            ShowInfoProprio(bien.Proprietaire);
            ShowInfoLocataire(bien.Locataire, false);
        }

        private void AnnulationQuittanceForm_Load(object sender, EventArgs e)
        {
            btnDelete.Location = btnFirst.Location;
            btnPrev.Visible = true;
            tbRefImmeuble.TextChanged -= tbTextChanged;
            tbNumLot.TextChanged -= tbTextChanged;
            tbRefLocataire.TextChanged -= tbTextChanged;
            tbTVA.TextAlignChanged -= tbTextChanged;
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
//            tbRefImmeuble.BackColor = Color.White;
            if (tbRefImmeuble.Text == "")
                return;

            bien = BienController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (bien != null)
            {
                ControlsWindows.setAutoControle(tbNumLot, ImmeubleController.getImmeubleController().getLots(bien.reference));
                ControlsWindows.setAutoControle(tbRefLocataire, ImmeubleController.getImmeubleController().getReferencesLocataires(bien.reference));
            }
            else
                tbRefImmeuble.BackColor = Color.Red;
            ShowInfoImmeuble(bien);
            if (bien != null)
                ShowInfoProprio(bien.Proprietaire);
            else
                ShowInfoProprio(new ProprietaireEntite());
            setModified(false);
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new BienFindForm(), tbRefImmeuble) == DialogResult.OK)
            {

            }
        }

        private void tbNumLot_Validating(object sender, CancelEventArgs e)
        {
            tbNumLot.BackColor = Color.White;
            if (tbNumLot.Text == "")
                return;
            if (!tbNumLot.AutoCompleteCustomSource.Contains(tbNumLot.Text))
                tbNumLot.BackColor = Color.Red;
            else
            {
                bien = BienController.getController().getBien(tbRefImmeuble.Text, Convertir.ToInt(tbNumLot.Text));
                ShowInfoImmeuble(bien);
                ShowInfoProprio(bien.Proprietaire);
                ShowInfoLocataire(bien.Locataire);
            }

        }

        private void lblLocataire_Click(object sender, EventArgs e)
        {
            if (tbRefImmeuble.Text == "")
            {
                if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
                {
                    tbRefLocataire_Validating(null, null);
                }

            }
            else
                if (ShowFindForm(new LocatairesImmeubleFindForm(tbRefImmeuble.Text), tbRefLocataire) == DialogResult.OK)
                {
                    tbRefLocataire_Validating(null, null);
                }
        }

        private void tbCommon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    if (sender == tbRefImmeuble)
                        lblImmeuble_Click(sender, null);
                    if (sender == tbRefLocataire)
                        lblLocataire_Click(sender, null);
                    if (sender == tbNumLot)
                        lblLot_Click(sender, null);
                }
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if (tbRefLocataire.Text != "")
            {
                LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                {
                    bien = locataire.Bien;
                    if (bien != null)
                    {
                        ShowInfoImmeuble(bien);
                        ShowInfoProprio(bien.Proprietaire);
                        ShowInfoLocataire(locataire);
                    }
                }
                else
                    tbRefLocataire.BackColor = Color.Red;
            }
            setModified(false);
        }
        private void ShowInfoProprio(ProprietaireEntite proprio)
        {
            if (proprio != null)
            {
                tbRefProprio.Text = proprio.reference;
                tbNomProprio.Text = proprio.NomPrenom;
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
                setFicheValues(bien);
                tbRefImmeuble.BackColor = Color.White;
            }
            else
                tbNomImmeuble.Text = tbNumLot.Text = "";
        }
        private void ShowInfoLocataire(LocataireEntite locataire, bool bGetQuittance = true)
        {
            if (bGetQuittance)
                quittance = null;
            if (locataire != null)
            {
                tbRefLocataire.Text = locataire.reference;
                tbNomLocataire.Text = locataire.NomPrenom;
                if ( bGetQuittance)
                    quittance = QuittancesController.getController().getDerniereQuittance(locataire.id);
            }
            else
                tbRefLocataire.Text = tbNomLocataire.Text = tbNomLocataire.Text = "";
            ShowFicheValue(quittance);
        }
        private void ShowFicheValue(QuittanceEntite quittance)
        {
            if ( quittance != null )
            {
                dtQuittance.Value = quittance.date_quittance;
                tbHdrQuittance.Text = String.Format("Quittance du {0}", quittance.date_quittance.ToShortDateString());

                tbLoyer.Text = quittance.montant_loyer.ToString();
                tbCharges.Text = quittance.montant_charge.ToString();
                tbAugment.Text = quittance.montant_augmentation.ToString();
                tbTVA.Text = quittance.valeur_taxe.ToString();
                tbFraisBail.Text = quittance.frais_bail.ToString();
                tbHonoLoc.Text = quittance.honoraire_locataire.ToString();
//                tbEtatLieux.Text = (quittance.etat_lieux * 2).ToString();
                tbEtatLieux.Text = (quittance.etat_lieux).ToString();

                tbPresta1.Text = quittance.divers1;
                tbPresta2.Text = quittance.divers2;
                tbPresta3.Text = quittance.divers3;
                tbPresta4.Text = quittance.divers4;
                tbPresta5.Text = quittance.divers5;

                tbMontant1.Text = quittance.montant_divers1.ToString();
                tbMontant2.Text = quittance.montant_divers2.ToString();
                tbMontant3.Text = quittance.montant_divers3.ToString();
                tbMontant4.Text = quittance.montant_divers4.ToString();
                tbMontant5.Text = quittance.montant_divers5.ToString();
            }
            else
            {
                tbHdrQuittance.Text = "";
            }
            setModified(false);
        }

        protected override bool saveValue()
        {
            if (quittance != null)
            {
                decimal old_montant = quittance.montant_quittance;
                
                quittance.date_quittance = dtQuittance.Value;

                quittance.montant_loyer = Convertir.ToDecimal(tbLoyer.Text);
                quittance.montant_augmentation = Convertir.ToDecimal(tbAugment.Text);
                quittance.valeur_taxe = Convertir.ToDecimal(tbTVA.Text);
                quittance.montant_charge = Convertir.ToDecimal(tbCharges.Text);
                quittance.frais_bail = Convertir.ToDecimal(tbFraisBail.Text);
                quittance.honoraire_locataire = Convertir.ToDecimal(tbHonoLoc.Text);
//                quittance.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text) / 2;
                quittance.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text);

                quittance.montant_divers1 = Convertir.ToDecimal(tbMontant1.Text);
                quittance.montant_divers2 = Convertir.ToDecimal(tbMontant2.Text);
                quittance.montant_divers3 = Convertir.ToDecimal(tbMontant3.Text);
                quittance.montant_divers4 = Convertir.ToDecimal(tbMontant4.Text);
                quittance.montant_divers5 = Convertir.ToDecimal(tbMontant5.Text);
                quittance.divers1 = tbPresta1.Text;
                quittance.divers2 = tbPresta2.Text;
                quittance.divers3 = tbPresta3.Text;
                quittance.divers4 = tbPresta4.Text;
                quittance.divers5 = tbPresta5.Text;
                quittance.statut = (int)GlobalConstantes.StatutQuittance.Modifie;
                decimal new_montant = quittance.SumMontant();
                quittance.montant_quittance = new_montant;

                NpgsqlTransaction trx = Database.BeginTransaction();
                try
                {
                    if (!QuittancesController.getController().InsertOrUpdate(quittance))
                        throw new Exception("Mise à jour Quittance");

                    BienEntite bien = quittance.Bien;
                    quittance.SetValueFromQuittance();

                    BienController.getController().InsertOrUpdate(bien);

                    LocataireEntite locataire = LocataireController.getController().getEntiteById(quittance.locataire_id);
                    if ( locataire == null )
                        throw new Exception ("Locataire Inconnu");
                    locataire.total_du = locataire.total_du - old_montant + new_montant;
                    if ( !LocataireController.getController().InsertOrUpdate(locataire))
                        throw new Exception("Mise à jour locataire");

                    trx.Commit();
                    setModified(false);
//                    MessageBox.Show("Modifications enregistrées");
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            return true;
        }

        private void tbLoyer_Validating(object sender, CancelEventArgs e)
        {
            if (bien != null)
            {
                decimal loyer = Convertir.ToDecimal(tbLoyer.Text);
                decimal tva = Math.Round((loyer) * ((bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
                if (Convertir.ToDecimal(tbTVA.Text) != tva)
                    tbTVA.Text = tva.ToString();
            }
        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (quittance != null)
//            {
//                if (DialogResult.Yes != MessageBox.Show("Opération irréversible\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
//                    return;

//                decimal old_montant = quittance.montant_quittance;
//                LocataireEntite locataire = quittance.Locataire;

//                // TODO C'est moins ou Plus ??
////                locataire.total_du += old_montant;
//                locataire.total_du -= old_montant;
//                NpgsqlTransaction trx = Database.BeginTransaction();
//                try
//                {
//                    if ( !QuittancesController.getController().deleteEntite(quittance))
//                        throw new Exception("Annulation Quittance");
//                    if (!LocataireController.getController().InsertOrUpdate(locataire))
//                        throw new Exception("Mise à jour locataire");
//                    trx.Commit();
//                    setModified(false);
//                    MessageBox.Show("Modifications enregistrées");
//                    this.Close();
//                }
//                catch (Exception ex)
//                {
//                    trx.Rollback();
//                    MessageBox.Show(ex.Message);
//                }
//            }
//        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (quittance != null)
            {
                if (DialogResult.Yes != MessageBox.Show("Opération irréversible\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
                    return;
                NpgsqlTransaction trx = Database.BeginTransaction();

                if ( QuittancesController.DeleteQuittance(quittance))
                {
                    trx.Commit();
                    setModified(false);
                    MessageBox.Show("Modifications enregistrées");
                    this.Close();
                }
                else
                {
                    trx.Rollback();
                }
            }
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            if (tbRefImmeuble.Text != "")
            {
                LocataireLotFindForm form = new LocataireLotFindForm();
                form.ref_immeuble = tbRefImmeuble.Text;
                if (ShowFindForm(form, tbNumLot) == DialogResult.OK)
                    tbNumLot_Validating(sender, null);
            }
        }

        private void lblPresta5_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
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
        // Impression
        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            ImprimerQuittanceForm form = new ImprimerQuittanceForm(quittance);
            form.ShowDialog();
        }

        private void dtQuittance_ValueChanged(object sender, EventArgs e)
        {
            setModified(true);
        }
    }
}
