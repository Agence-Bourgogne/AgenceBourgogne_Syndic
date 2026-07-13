using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Biens;
using GeranceData.Controller;
using GeranceData.Entites;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Natures;
using Gerance.Formulaires.Fournisseurs;
using GeranceData.Common;


namespace Gerance.Formulaires.Factures
{
    public partial class FactureForm : Common.BaseFicheForm
    {
        public FactureForm()
        {
            InitializeComponent();
        }

        protected override void InitializeCombos()
        {
            ParametresDB.FillComboFromParams(cbReglement, "REGLEMENTS", "nom");
            cbReglement.SelectedIndex = 1;
        }

        private void ClearFicheSaisie()
        {
            tbRefImmeuble.Text = tbNomImmeuble.Text = tbNumLot.Text = "";
            tbRefLocataire.Text = tbNomLocataire.Text = tbPrenomLocataire.Text = "";
            tbRefProprio.Text = tbNomProprio.Text = tbPrenomProprio.Text = "";
            tbRefImmeuble.BackColor = Color.White;
            ShowInfoNature(null);
            ShowInfoFournisseur(null);
            tbLibelle.Text = tbMontant.Text = "";
            dtEcriture.Value = DateTime.Now;
            setModified(false);
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
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            tbRefImmeuble.BackColor = Color.White;
            if (tbRefImmeuble.Text == "")
                return;
            
            var bien = BienController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (bien != null)
            {
                ControlsWindows.setAutoControle(tbNumLot, ImmeubleController.getImmeubleController().getLots(bien.reference));
                ControlsWindows.setAutoControle(tbRefLocataire, ImmeubleController.getImmeubleController().getReferencesLocataires(bien.reference));
            }
            else
                tbRefImmeuble.BackColor = Color.Red;
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
                var bien = BienController.getController().getBien(tbRefImmeuble.Text, Convertir.ToInt(tbNumLot.Text));
                ShowInfoImmeuble(bien);
                ShowInfoProprio(bien.Proprietaire);
                ShowInfoLocataire(bien.Locataire);
            }
        }
        private void lblRefImmeuble_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new BienFindForm(), tbRefImmeuble) == DialogResult.OK)
            {
                tbRefImmeuble_Validating(null, null);
            }
        }
        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if ( tbRefLocataire.Text != "" )
            {
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                {
                    var bien = locataire.Bien;
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
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (tbRefImmeuble.Text != "")
            {
                if (ShowFindForm(new LocatairesImmeubleFindForm(tbRefImmeuble.Text), tbRefLocataire) == DialogResult.OK)
                {
                    tbRefLocataire_Validating(null, null);
                    tbMontant.Focus();
                }
            }
            else
                if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
                {
                    tbRefLocataire_Validating(null, null);
                }
        }

        private void lblNature_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new NatureFindForm(), tbNature) == DialogResult.OK)
            {
                tbNature_Validating(null, null);
            }
        }

        private void btnNatureAdd_Click(object sender, EventArgs e)
        {

        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            tbNature.BackColor = Color.White;
            tbLibNature.Text = "";

            if (tbNature.Text == "")
                return;

            var entite = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (entite != null)
            {
                tbLibNature.Text = entite.nom;
            }
            else
                tbNature.BackColor = Color.Red;
        }

        private void lblFournisseur_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new FournisseurFindForm(), tbFournisseur) == DialogResult.OK)
            {
                tbFournisseur_Validating(null, null);
            }

        }

        private void btnFournisseurAdd_Click(object sender, EventArgs e)
        {

        }
        private void tbFournisseur_Validating(object sender, CancelEventArgs e)
        {
            tbFournisseur.BackColor = Color.White;
            tbNomFournisseur.Text = "";

            if (tbFournisseur.Text == "")
                return;

            var entite = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);

            if (entite != null)
            {
                tbNomFournisseur.Text = entite.nom;
                tbDesiFournisseur.Visible = (entite.reference == "999");
            }
            else
                tbNature.BackColor = Color.Red;
        }

        private void FactureForm_Load(object sender, EventArgs e)
        {
            btnDelete.Location = btnFirst.Location;
            btnDelete.Enabled = dataGridView.SelectedRows.Count > 0;
            FillDataGrid();
        }

        //protected override void tbTextChanged(object sender, EventArgs e)
        //{
        //    if (dataGridView.SelectedRows.Count > 0)
        //        base.tbTextChanged(sender, e);
        //}

        private bool bLoading;
        private void FillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = FacturesController.getController().getFactures30DerniersJours();
            if (dataGridView.DataSource != null)
            {
                var cols = dataGridView.Columns;
                cols["locataire"].MinimumWidth = 120;
                cols["libelle"].MinimumWidth = 120;
                cols["immeuble"].MinimumWidth = 120;
                cols["ref_immeuble"].Width = 40;
                cols["ref_locataire"].Width = 60;
                cols["date_facture"].Width = 70;
                cols["id"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
                dataGridView.ClearSelection();
            }
            bLoading = false;
        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (bLoading)
                return;
            btnDelete.Enabled = false;
            if (dataGridView.SelectedRows.Count > 0)
            {
                Console.WriteLine("dataGridView_SelectionChanged");
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;

                ShowFicheValues(row["id"].ToString());
                btnDelete.Enabled = true;
            }
            else
                ShowFicheValues(null);
        }
        private void ShowFicheValues(string entite_id)
        {
            FactureEntite entite = null;
            if (entite_id != null)
                entite = FacturesController.getController().getEntiteById(entite_id);
            if (entite != null)
            {
                var montant = entite.debit == 0 ? entite.credit : entite.debit;
//                decimal montant = entite.debit == 0 ? entite.credit * -1 : entite.debit;
                tbMontant.Text = montant.ToString();

                dtEcriture.Value = entite.date_facture;
                tbLibelle.Text = entite.libelle;
                cbReglement.SelectedValue = entite.code_reglement;
                ShowInfoImmeuble(entite.Bien);
                ShowInfoLocataire(entite.Locataire);
                ShowInfoProprio(entite.Proprietaire);
                ShowInfoNature(entite.Nature);
                ShowInfoFournisseur(entite.Fournisseur);
                tbRefImmeuble_Validating(null, null);
                tbNature_Validating(null, null);
                tbDesiFournisseur.Text = entite.libelle_fournisseur;
            }
            else
            {
                dtEcriture.Value = DateTime.Now;
                tbLibelle.Text = tbMontant.Text =  "";
                cbReglement.SelectedValue = -1;
                ShowInfoImmeuble(null);
                ShowInfoLocataire(null);
                ShowInfoProprio(null);
                ShowInfoNature(null);
                ShowInfoFournisseur(null);
            }
            setModified(false);
        }

        LocataireEntite locataire;
        NatureEntite nature;
        FournisseurEntite fournisseur;

        protected bool ValideDatas()
        {
            locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire == null)
            {
                MessageBox.Show("reference locataire invalide");
                return false;
            }
            if (locataire.Bien == null)
            {
                MessageBox.Show("Ce locataire n'est défini sur aucun bien");
                return false;
            }
            nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if ( nature == null )
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

        protected override bool saveValue()
        {
            if (tbRefLocataire.Text == "")
                return true;
            if (!ValideDatas())
                return false;

            var facture = new FactureEntite();

            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                facture = FacturesController.getController().getEntiteById(row["id"].ToString());
            }

            var montant = Convertir.ToDecimal(tbMontant.Text);

            facture.credit = facture.debit = 0;
            if (montant < 0)
                facture.credit = montant;
            else
                facture.debit = montant;
            facture.Bien = locataire.Bien;
            facture.Proprietaire = locataire.Bien.Proprietaire;
            facture.Locataire = locataire;
            facture.date_facture = dtEcriture.Value;
            facture.code_reglement = (int) cbReglement.SelectedValue;
            facture.libelle = tbLibelle.Text;
            facture.Nature = nature;
            facture.Fournisseur = fournisseur;
            if ( fournisseur.reference == "999")
                facture.libelle_fournisseur = tbDesiFournisseur.Text;
            else
                facture.libelle_fournisseur = "";

            if (!FacturesController.getController().InsertOrUpdate(facture))
                return false;
            FillDataGrid();
            ClearFicheSaisie();
            return true;
        }

        private void tbRefImmeuble_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblRefImmeuble_Click(null, null);
        }

        private void tbRefLocataire_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblRefLocataire_Click(null, null);

        }

        private void tbNature_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblNature_Click(null, null);

        }

        private void tbFournisseur_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblFournisseur_Click(null, null);
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            if (tbRefImmeuble.Text != "")
            {
                var form = new LocataireLotFindForm();
                form.ref_immeuble = tbRefImmeuble.Text;
                if (ShowFindForm(form, tbNumLot) == DialogResult.OK)
                    tbNumLot_Validating(sender, null);
            }
        }

        private void tbNumLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (ControlsWindows.IsCtrlSpace(e))
                lblLot_Click(null, null);
        }
        protected override DialogResult saveForm(bool bShowMessage = false, bool bShowResult = true)
        {
            return base.saveForm(false, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                var facture = FacturesController.getController().getEntiteById(row["id"].ToString());
                if (facture != null)
                {
                    facture.statut = (int) GlobalConstantes.StatutOperation.Supprime;
                    FacturesController.getController().InsertOrUpdate(facture);
                }
            }
            FillDataGrid();
        }

    }
}
