using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gerance.Formulaires.Biens;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;
using GeranceData.Common;
using Microsoft.Reporting.WinForms;

namespace Gerance.Formulaires.Locataires
{
    public partial class EntreeLocataireFicheForm : Common.BaseFicheForm
    {
        BienEntite bien;
        public EntreeLocataireFicheForm()
        {
            InitializeComponent();
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new BienFindForm(), tbRefImmeuble) == DialogResult.OK)
            {

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
                    tbRefLocataire.Focus();
                    tbRefLocataire_Validating(null, null);
                }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
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
            if ( bien != null )
                ShowInfoProprio(bien.Proprietaire);
            else
                ShowInfoProprio(new ProprietaireEntite());
            setModified(false);
        }

        private void tbLot_Validating(object sender, CancelEventArgs e)
        {
            tbNumLot.BackColor = Color.White;
            if (tbNumLot.Text == "")
                return;
            if (!tbNumLot.AutoCompleteCustomSource.Contains(tbNumLot.Text))
                tbNumLot.BackColor = Color.Red;
            else
            {
                //BienEntite bien = BienController.getController().getBien(tbRefImmeuble.Text, Convertir.ToInt(tbNumLot.Text));
                bien = BienController.getController().getBien(tbRefImmeuble.Text, Convertir.ToInt(tbNumLot.Text));
                ShowInfoImmeuble(bien);
                ShowInfoProprio(bien.Proprietaire);
                ShowInfoLocataire(bien.Locataire);
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
//                    BienEntite bien = locataire.Bien;
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
            }
            else
                tbNomImmeuble.Text = tbRefImmeuble.Text = tbNumLot.Text = "";
        }

        private void ShowInfoLocataire(LocataireEntite locataire)
        {
            if (locataire != null)
            {
                tbRefLocataire.Text = locataire.reference;
                tbNomLocataire.Text = locataire.NomPrenom;
            }
            else
                tbRefLocataire.Text = tbNomLocataire.Text = tbNomLocataire.Text = "";
        }

        private void EntreeLocataireFicheForm_Load(object sender, EventArgs e)
        {
//            InitializeCombos();
            btnPrint.Location = btnFirst.Location;
            btnPrint.Width = btnFirst.Width;
//            btnSave.Location = btnPrev.Location;
//          btnSave.Text = "&Fiche";
//          btnSave.ImageIndex = 7;
            btnSave.Visible = true;
            btnSave.Location = btnPrev.Location;
            
            btnNext.Text = "Fiche";
            btnNext.Visible = true;

            reportViewer1.Visible = false;
            setModified(false);
            dtFin.Value = new DateTime(dtDebut.Value.Year, dtDebut.Value.Month, 1).AddMonths(1).AddDays(-1);
        }
        protected override void InitializeCombos()
        {
            DateTime dt = DateTime.Parse("01/01/2000");

            for (int i = 0; i < 12; i++)
            {
                String[] lDate = dt.ToLongDateString().Split(' ');
                cbMoisAugm.Items.Add(lDate[2]);
                dt = dt.AddMonths(1);
            }
            ParametresDB.FillComboFromParams(cbPeriodiciteLoyer, "PERIODICITE", "nom");
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            BienEntite bien;
            if (entite != null)
                bien = (BienEntite)entite;
            else
                bien = new BienEntite();

            tbTaxe.Text = bien.taxe.ToString();
            tbLoyer.Text = bien.montant_loyer.ToString();
            tbCharges.Text = bien.montant_charges.ToString();
            tbCaution.Text = bien.montant_caution.ToString();
            tbIndice.Text = bien.dernier_indice.ToString();
            cbMoisAugm.SelectedIndex = bien.mois_augmentation - 1;
            cbPeriodiciteLoyer.SelectedValue = bien.periodicite_loyer;
            tbDureeBail.Text = bien.duree_bail.ToString();
            tbPeriodiciteAugmentation.Text = bien.periodicite_augmentation.ToString();
            
            tbHonoLoc.Text = bien.honoraires_locataire.ToString();
            
            if (bien.taxe == 0)
                tbTVA.Text = "0";
            else
                tbTVA.Text = bien.valeur_taxe.ToString();

            tbFraisBail.Text = bien.frais_bail.ToString();

            base.setFicheValues(bien);
            setModified(false);
        }
        protected override bool saveValue()
        {
            bool rc = false;
            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
//            BienEntite bien = BienController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (locataire != null)
            {
                Npgsql.NpgsqlTransaction trx = Database.BeginTransaction();
                try
                {
                    BienEntite bien = locataire.Bien;
                    if (bien != null)
                    {
                        // TODO Revoir FraisBail => Etat des lieux

                        bien.montant_loyer = Convertir.ToDecimal(tbLoyer.Text);
                        bien.montant_augmentation = Convertir.ToDecimal(tbAugment.Text);
                        bien.valeur_taxe = Convertir.ToDecimal(tbTVA.Text);
                        bien.montant_charges = Convertir.ToDecimal(tbCharges.Text);
                        bien.frais_bail = Convertir.ToDecimal(tbFraisBail.Text);
                        bien.honoraires_locataire = Convertir.ToDecimal(tbHonoLoc.Text);
                        
                        //bien.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text)/2;
                        bien.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text);

                        bien.montant_divers1 = Convertir.ToDecimal(tbMontant1.Text);
                        bien.montant_divers2 = Convertir.ToDecimal(tbMontant2.Text);
                        bien.montant_divers3 = Convertir.ToDecimal(tbMontant3.Text);
                        bien.montant_divers4 = Convertir.ToDecimal(tbMontant4.Text);
                        bien.montant_divers5 = Convertir.ToDecimal(tbMontant5.Text);
                        bien.divers1 = tbPresta1.Text;
                        bien.divers2 = tbPresta2.Text;
                        bien.divers3 = tbPresta3.Text;
                        bien.divers4 = tbPresta4.Text;
                        bien.divers5 = tbPresta5.Text;
                        bien.dernier_indice = Convertir.ToInt(tbIndice.Text);
                        // TODO  Gérer Dernier indice et Variation
                        if (!BienController.getController().InsertOrUpdate(bien))
                            throw new Exception("Mise à jour du bien");

                        QuittanceEntite quittance = QuittancesController.getController().getDerniereQuittance(locataire.id);
                        if ( quittance == null )
                            quittance = new QuittanceEntite();

                        quittance.bien_id = bien.id;
                        quittance.proprietaire_id = bien.proprietaire_id;
                        quittance.locataire_id = locataire.id;
                        quittance.date_quittance = dtDebut.Value;

                        quittance.montant_loyer = Convertir.ToDecimal(tbLoyer.Text);
                        quittance.montant_augmentation = Convertir.ToDecimal(tbAugment.Text);
                        quittance.valeur_taxe = Convertir.ToDecimal(tbTVA.Text);
                        quittance.montant_charge = Convertir.ToDecimal(tbCharges.Text);
                        quittance.frais_bail = Convertir.ToDecimal(tbFraisBail.Text);
                        quittance.honoraire_locataire = Convertir.ToDecimal(tbHonoLoc.Text);
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
                        quittance.statut = (int) GlobalConstantes.StatutQuittance.Modifie;
                        
                        //quittance.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text)/2;
                        quittance.etat_lieux = Convertir.ToDecimal(tbEtatLieux.Text);

                        quittance.montant_quittance = quittance.SumMontant();
                        
                        locataire.total_du = quittance.SumMontant();
                        
                        if (!LocataireController.getController().InsertOrUpdate(locataire))
                            throw new Exception("Update Solde Locataire");

                        if ( !QuittancesController.getController().InsertOrUpdate(quittance))
                            throw new Exception("Mise à jour quittance");
                        quittance_id = quittance.id;
                        rc = true;
                        trx.Commit();
                        setModified(false);
                    }

                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            return rc;
        }
        string quittance_id = "";
        private void btnPrint_Click(object sender, EventArgs e)
        {
            setModified(true);
            if (saveForm(false, false) != DialogResult.OK)
                return;
            LocataireEntite locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
//            BienEntite bien = BienController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (locataire != null)
            {
                BienEntite bien = locataire.Bien;
                if (bien != null)
                {
                    reportViewer1.Location = gbHdr.Location;
                    reportViewer1.Width = gbHdr.Width;
                    reportViewer1.Height = panel1.Location.Y - gbHdr.Location.Y - 10;
                    reportViewer1.Visible = true;
                    reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    string hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                    string hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
                    string hdr_description_small = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION_SMALL");

                    ReportParameter[] parameters = new ReportParameter[]{
                            new ReportParameter("typeReport", "1"),
                            new ReportParameter("dateEdition", DateTime.Now.ToShortDateString()),
                            new ReportParameter("dateDebut", dtDebut.Value.ToShortDateString()),
                            new ReportParameter("bien_id", bien.id),
                            new ReportParameter("dateFin", dtFin.Value.ToShortDateString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                    new ReportParameter("Header_Description_Small", hdr_description_small),
                        };

                    //                    reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.Locataires.LocataireQuittanceEntreeReport.rdlc";
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.AppelALoyer.QuittanceLoyerDetailReport.rdlc";
                    reportViewer1.LocalReport.SetParameters(parameters);
                    reportViewer1.LocalReport.DataSources.Clear();

                    // TODO  Imprimer la quittance et non le contenu du bien
                    //                    DataTable table = BienController.getController().getDetailAppelDeLoyerEntree(bien.id);
                    DataTable table = QuittancesController.getController().getDetailAppelDeLoyerEntree(quittance_id);

                    DataRow row = table.Rows[0];
                    row["imm_adress"] = row["imm_adress"].ToString().Replace("\n", " ");
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("QuittanceLoyerLocataire", table));
                    reportViewer1.RefreshReport();
                }
                else
                    MessageBox.Show("Bien non défini");
            }
            else
                MessageBox.Show("Locataire Invalide");
        }

        private void tbRefLocataire_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.Control == true)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    if (sender == tbRefImmeuble)
                        lblImmeuble_Click(sender, null);
                    if (sender == tbRefLocataire)
                        lblLocataire_Click(sender, null);
                }
        }

        private void btnGetCoeff_Click(object sender, EventArgs e)
        {
            Indices.IndicesForm form = new Indices.IndicesForm( tbCoeff, tbIndice);
            form.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //reportViewer1.Visible = false;
            btnPrint_Click(sender, e);
        }
        // TODO à Paramétrer
        decimal taux_tva = 20, taux_bail = (decimal)0;

        private void tbLoyer_Validating(object sender, CancelEventArgs e)
        {
            if ( bien == null )
                return;
            decimal loyer = Convertir.ToDecimal(tbLoyer.Text);
            decimal tva = Math.Round((loyer ) * ((bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
            tbTVA.Text = tva.ToString();
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;
        }
    }
}
