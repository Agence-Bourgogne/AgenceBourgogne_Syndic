using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Locataires;
using GeranceData.Controller;
using GeranceData.Entites;
using GeranceData.Common;
using Gerance.Formulaires.Syndic;
using Gerance.Formulaires.Common;
namespace Gerance.Formulaires.Reglements
{
    public partial class ReglementLocataireForm : BaseFicheForm
    {
        public ReglementLocataireForm()
        {
            InitializeComponent();
        }
        private void ReglementLocataireForm_Load(object sender, EventArgs e)
        {
            tbRefLocataire.TextChanged -= tbTextChanged;
            FillDataGrid();
            ShowFromModeReglement();
            btnDelete.Location = btnFirst.Location;
            btnDelete.Enabled = dataGridView.SelectedRows.Count > 0;
            tbLblProprio.Location = new Point(lblProprio.Location.X, tbRefProprio.Location.Y);
            tbLblProprio.Size = new Size(lblProprio.Size.Width, tbLblProprio.Size.Height);
            tbLblProprio.TabStop = false;
            tbLblProprio.Enabled = false;
            tbLblProprio.Visible = false;

            btnPrev.Visible = true;
            btnPrev.ImageIndex = 7;
            btnPrev.Text = "&Detail";
            btnPrev.ImageAlign = ContentAlignment.MiddleRight;
            
            btnNext.Visible = true;
            btnNext.ImageIndex = 8;
            btnNext.Text = "&Impression";
            btnPrev.ImageAlign = ContentAlignment.MiddleRight;
           
        }

        private void ShowFromModeReglement()
        {
            var bVisible = false;
            if (cbReglement.SelectedValue is int)
            {
                bVisible = (int)cbReglement.SelectedValue == 1;
                if (bVisible)
                    tbTire.Text = tbNomLocataire.Text;
            }
            lblBanque.Visible = tbBanque.Visible = lblTire.Visible = tbTire.Visible = bVisible;
        }
        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if ( !tbRefLocataire.ReadOnly)
                if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
                {
                    tbRefLocataire_Validating(null, null);
                }
        }

        protected override void InitializeCombos()
        {
            ParametresDB.FillComboFromParams(cbReglement, "REGLEMENTS", "nom");
            cbReglement.SelectedIndex = 1;
        }


        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbNomLocataire.Text = tbPrenomLocataire.Text = "";
            tbRefProprio.Text = tbNomProprio.Text = tbPrenomProprio.Text = "";
            tbRefImmeuble.Text = tbNomImmeuble.Text = tbNumLot.Text = "";
            if (tbRefLocataire.Text == "")
                return;
            var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            ShowDetailFromLocataire(locataire);
        }
        private void ClearSyndicCopro()
        {
            tbLblProprio.BackColor = tbNomProprio.BackColor = tbRefProprio.BackColor = tbPrenomProprio.BackColor = SystemColors.Control;
            tbLblProprio.Visible = false;
            lblProprio.Visible = true;
        }
        private void ShowDetailFromLocataire(LocataireEntite locataire)
        {
            tbNomLocataire.Text = tbPrenomLocataire.Text = "";
            tbRefImmeuble.Text = tbNomImmeuble.Text = tbNumLot.Text = "";
            tbRefProprio.Text = tbNomProprio.Text = tbPrenomProprio.Text = "";
            tbBaseHono.Text = tbMontantDu.Text = "";

            tbRefLocataire.BackColor = Color.White;
            ClearSyndicCopro();
            if (locataire != null)
            {

                tbNomLocataire.Text = locataire.nom;
                tbPrenomLocataire.Text = locataire.prenom;
                tbMontantDu.Text = locataire.total_du.ToString();

                if (locataire.Bien != null)
                {
                    tbRefImmeuble.Text = locataire.Bien.reference;
                    tbNomImmeuble.Text = locataire.Bien.nom;
                    tbNumLot.Text = locataire.Bien.numero_lot.ToString();
                    var basehono = locataire.Bien.montant_loyer + locataire.Bien.montant_augmentation;
                    tbBaseHono.Text = basehono.ToString();
                    if (locataire.Bien.Proprietaire != null)
                    {
                        tbRefProprio.Text = locataire.Bien.Proprietaire.reference;
                        tbNomProprio.Text = locataire.Bien.Proprietaire.nom;
                        tbPrenomProprio.Text = locataire.Bien.Proprietaire.prenom;
                        var lot = SyndicDatabase.getSyndicCoproLot(locataire.id);
                        if (lot != null)
                        {
                            tbLblProprio.BackColor = tbNomProprio.BackColor = tbRefProprio.BackColor = tbPrenomProprio.BackColor = Color.GreenYellow;
                            tbLblProprio.Visible = true;
                            lblProprio.Visible = false;
                        }
                    }
                }
            }
            else
            {
                if ( tbRefLocataire.Text != "" )
                    tbRefLocataire.BackColor = Color.Red;
            }
            setModified(false);
        }

        private void cbReglement_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowFromModeReglement();
        }
        private bool bLoading;
        private void FillDataGrid()
        {
            bLoading = true;
            dataGridView.DataSource = ReglementsController.getController().getReglements30DerniersJours();
            if (dataGridView.DataSource != null)
            {
                var cols = dataGridView.Columns;
                cols["locataire"].MinimumWidth = 120;
                cols["libelle"].MinimumWidth = 120;
                cols["ref_immeuble"].Width = 40;
                cols["ref_locataire"].Width = 50;
                cols["date_reglement"].Width = 70;
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
            if (dataGridView.SelectedRows.Count > 0)
            {
                Console.WriteLine("dataGridView_SelectionChanged");
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if ( row != null )
                    ShowFicheValues(row["id"].ToString());
                else
                    ShowFicheValues(null);
            }
            else 
                ShowFicheValues(null);
            btnDelete.Enabled = dataGridView.SelectedRows.Count > 0;
        }
        private void ShowFicheValues(string entite_id)
        {
            ReglementEntite entite = null;
            if (entite_id != null)
                entite = ReglementsController.getController().getEntiteById(entite_id);
            if ( entite != null )
            {
                var locataire = entite.Locataire;
                tbRefLocataire.Text = locataire.reference;
                tbMontantDu.Text = locataire.total_du.ToString();

                dtReg.Value = entite.date_reglement;
                tbLibelle.Text = entite.libelle;
                tbMontant.Text = entite.credit.ToString(); ;
                cbReglement.SelectedValue = entite.code_reglement;
                tbTire.Text = entite.tire;
                tbBanque.Text = entite.banque_tire;
                tbRefLocataire.ReadOnly = true;
                tbRefLocataire.Enabled = false;
                ShowDetailFromLocataire(entite.Locataire);
            }
            else
            {
                tbRefLocataire.Text = "";
                dtReg.Value = DateTime.Now;
                tbLibelle.Text = tbMontant.Text = tbTire.Text = tbBanque.Text = tbMontant.Text = "";
                cbReglement.SelectedValue = -1;
                ShowDetailFromLocataire(null);
                tbRefLocataire.ReadOnly = false;
                tbRefLocataire.Enabled = true;
            }
            setModified(false);
        }
        const int REFERENCE_TACHE = 3;
        bool bForceDetail = false;
        protected override bool saveValue()
        {
            var CurrentId = "";
            var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            if (locataire == null)
            {
                MessageBox.Show("reference locataire invalide");
                return false;
            }
            if (locataire.Bien == null)
            {
                var form = new Biens.BienFindForm();
                form.Text = "Veuillez définir le bien";
                if ( DialogResult.OK != form.ShowDialog() )
                    return false;
                if (form.reference != "") 
                {
                    locataire.Bien = BienController.getController().getEntiteFromField("reference", form.reference);
                }
                if (locataire.Bien == null)
                {
                    MessageBox.Show("Le bien n'est pas défini");
                    return false;
                }
                bForceDetail = true;
            }

            var reglement = new ReglementEntite();
            Decimal oldTotal_du = 0;
            var montant_du = Convertir.ToDecimal(tbMontantDu.Text);
            var montant_reglement = Convertir.ToDecimal(tbMontant.Text);
            var montant_loyer = locataire.Bien.MontantDu;
            var openPartiel = false;
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                reglement = ReglementsController.getController().getEntiteById(row["id"].ToString());
                CurrentId = reglement.id;
                oldTotal_du = reglement.credit;
            }
            else
                if (montant_reglement != montant_loyer)
                {
                    //reglement.base_honoraire = montant_reglement;
                    openPartiel = true;
                }
                else
                {
                    reglement.base_honoraire = Convertir.ToDecimal(tbBaseHono.Text);
                    reglement.charges = locataire.Bien.montant_charges;
                    reglement.valeur_taxe = locataire.Bien.valeur_taxe;
                    reglement.frais_bail = locataire.Bien.frais_bail;
                    reglement.etat_lieux = locataire.Bien.etat_lieux;
                    reglement.divers1 = locataire.Bien.divers1;
                    reglement.montant_divers1 = locataire.Bien.montant_divers1;
                    reglement.divers2 = locataire.Bien.divers2;
                    reglement.montant_divers2 = locataire.Bien.montant_divers2;
                    reglement.divers3 = locataire.Bien.divers3;
                    reglement.montant_divers3 = locataire.Bien.montant_divers3;
                    reglement.divers4 = locataire.Bien.divers4;
                    reglement.montant_divers4 = locataire.Bien.montant_divers4;
                    reglement.divers5 = locataire.Bien.divers5;
                    reglement.montant_divers5 = locataire.Bien.montant_divers5;
                }

            var total_du = locataire.total_du + oldTotal_du - montant_reglement;

            reglement.bien_id = locataire.Bien.id;
            reglement.proprietaire_id = locataire.Bien.proprietaire_id;
            reglement.locataire_id = locataire.id;
            reglement.date_reglement = dtReg.Value;
            reglement.Locataire = locataire;
            reglement.credit = Convertir.ToDecimal(tbMontant.Text);
            reglement.libelle = tbLibelle.Text;
            reglement.tire = tbTire.Text;
            reglement.banque_tire = tbBanque.Text;

            // TODO Verif Montant, Libelle
            Console.WriteLine(total_du);

            if ( total_du != 0 || bForceDetail || openPartiel )
            {
                var form = new ReglementPartielForm(reglement);
                Enabled = false;
                var result = form.ShowDialog();
                Enabled = true;
                if (result != DialogResult.OK)
                    return false;
            }
            
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();

            try
            {
                reglement.code_reglement = (int)cbReglement.SelectedValue;

                if (!ReglementsController.getController().InsertOrUpdate(reglement))
                    throw new Exception("Erreur Reglement");

                locataire.total_du = locataire.total_du + oldTotal_du - reglement.credit;
                if (!LocataireController.getController().InsertOrUpdate(locataire))
                    throw new Exception("Erreur Locataire");
                var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtReg.Value);
                WorkflowDetailController.getController().WriteRecord(workflow, reglement.id, "Reglement");
                WorkflowController.FireWorkflowChanged();

                trx.Commit();

                FillDataGrid();

                // Mantis 254
                if (!String.IsNullOrWhiteSpace(CurrentId))
                {
                    foreach (DataGridViewRow r in dataGridView.Rows)
                    {
                        var dbRow = (DataRowView)r.DataBoundItem;
                        if (dbRow != null)
                        {
                            if (dbRow["id"].ToString() == CurrentId)
                            {
                                r.Selected = true;
                                dataGridView.FirstDisplayedScrollingRowIndex = r.Index;
                                break;
                            }
                        }
                    }
                }

                ShowFicheValues(null);
                tbRefLocataire.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
                return false;
            }
            return true;
        }
        private void standard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    if (sender == tbRefLocataire)
                        lblRefLocataire_Click(null, null);
                    e.Handled = true;
                }
        }

        private void tbRefLocataire_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (tbRefLocataire.ReadOnly)
                tbRefLocataire.BackColor = Color.LightGray;
            else
                tbRefLocataire.BackColor = Color.White;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                ReglementsController.DeleteReglement(row["id"].ToString());
            }
            FillDataGrid();
            ShowFicheValues(null);
        }
        private void btnPrev_Click_1(object sender, EventArgs e)
        {
            bForceDetail = true;
            saveValue();
            bForceDetail = true;
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                btnPrev_Click_1(null, null);
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            var form = new ReglementPrintForm();
            form.ShowDialog();
        }

        private void tbLibelle_KeyPress(object sender, KeyEventArgs e)
        {
// Mantis 257
//            StandardFunctionnalities.Standard_KeyPress(sender, e, false);
            StandardFunctionnalities.Standard_KeyPress(sender, e, false);
        }

    }
}
