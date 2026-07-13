using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Entites;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
//using EspaceSyndic.Formulaires.Fournisseur;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Impressions.AppelDeFond;
using EspaceSyndic.UtilsApp;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Ecritures
{
    public partial class FicheAppelDeFondForm : Form
    {
        protected ImmeubleEntite immeuble = null;
        protected NatureEntite nature = null;
        protected AutoCompleteStringCollection baseAuto = new AutoCompleteStringCollection();
        protected bool bLoadEcriture;
        HelpForm infoForm = new HelpForm("aide_appelfond");
        InfoKeyHelpForm infoKey = new InfoKeyHelpForm("aide_clavier_appelfond");
        String TitreForm;
        AutoCompleteStringCollection lotAuto = new AutoCompleteStringCollection();
        String saisie_id = "";
        public FicheAppelDeFondForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            RepartitionControlsWindows.initGridRepartition(dataGridView);
            //            EnableSaisieEcriture(false);
            DateTime dt = DateTime.Now;
            tbDateCreation.Text = dt.ToShortDateString();

            ControlsWindows.setAutoControle(tbRefImmeuble, ImmeubleController.getController().getAutoComplete("reference"));
            ControlsWindows.setAutoControle(tbNature, NatureController.getController().getAutoComplete("reference"));
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EnableSaveAction();
            ControlsWindows.setTooltip(tbComment, "Libellé Appel de Fond");
            FillComboLiasse();
            tbRefImmeuble.Focus();
//            this.MinimumSize = this.MaximumSize = this.Size;
            btnEnter.Width = 0;
            // TODO Paramétrer
            lblDiff.Visible = tbDiff.Visible = lblTotal.Visible = tbTotal.Visible = lblLiasse.Visible = tbMontantLiasse.Visible = false;
            tbNature.Text = "145";
            tbNature_Validating(null, null);
        }
        void FillComboLiasse()
        {
            cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());
            cbLiasse.DisplayMember = "reference";
            cbLiasse.ValueMember = "id";
            cbLiasse.Enabled = true;
            cbLiasse_SelectedIndexChanged(null, null);
        }
        protected void EnableSaveAction()
        {
            bool enable = true;

            enable &= (immeuble != null);
            enable &= (nature != null);
            enable &= (baseAuto.Contains(tbBase.Text));
            enable &= (!tbMontant.Text.Equals(""));
            
            btnAdd.Enabled = enable;
            btnSave.Enabled = dataGridViewEcriture.Rows.Count > 0;
        }
        protected void cbLiasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbLiasse.Enabled) return;
            DataRowView row = (DataRowView)cbLiasse.SelectedItem;
            tbTotal.Text = row["montant"].ToString();
            tbTotal_TextChanged(null, null);

            FillDatagridEcritures();

            DataTable source = (DataTable) dataGridViewEcriture.DataSource;
            ImmeubleEntite immeuble = null;

            if (source.Rows.Count > 0)
            {
                DataRow rowEcriture = source.Rows[0];
                immeuble =ImmeubleController.getController().getEntiteById(rowEcriture["immeuble_id"].ToString());
            }
            if (immeuble != null)
            {
                tbRefImmeuble.Text = immeuble.reference;
                tbRefImmeuble.Enabled = false;
                tbRefImmeuble_Validating(null, null);
                tbDateCreation.Focus();
            }
            else
            {
                tbRefImmeuble.Enabled = true;
                tbRefImmeuble.Text = "";
                tbRefImmeuble.Focus();
            }
        }

        protected void tbTotal_TextChanged(object sender, EventArgs e)
        {
            float total = Convertir.ToFloat(tbTotal.Text);
            EnableSaisieEcriture(total != 0);
        }
        protected virtual void EnableSaisieEcriture(bool saisie)
        {
            tbRefImmeuble.Enabled = saisie;
            tbDateCreation.Enabled = saisie;
            tbNature.Enabled = saisie;
            tbMontant.Enabled = saisie;
            tbBase.Enabled = immeuble != null;
        }
        public virtual GlobalConstantes.TypeOperation getTypeEcriture()
        {
            return GlobalConstantes.TypeOperation.AppelDeFond;
        }
        protected void FillDatagridEcritures()
        {
            bLoadEcriture = true;
            string liasse_id = cbLiasse.SelectedValue.ToString();
            DataTable source = SaisieAppelFondController.getController().getGridRowSaisieAppelFond(liasse_id);
            dataGridViewEcriture.DataSource = source;
            dataGridViewEcriture.ClearSelection();
            if (source != null)
            {
                DataGridViewColumnCollection cols = dataGridViewEcriture.Columns;
                dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ControlsWindows.ToTitleCase(cols);
                cols["id"].Visible = false;
                cols["immeuble_id"].Visible = false;
                cols["nature_id"].Visible = false;
                cols["liasse_id"].Visible = false;
                cols["immeuble_ref"].Visible = false;
                cols["nature_ref"].Visible = false;
                cols["nature"].Visible = false;
                
                cols["Immeuble"].MinimumWidth = cols["Immeuble"].Width = 220;
                //cols["Nature"].MinimumWidth = cols["Nature"].Width = 180;
                cols["Libellé Ecriture"].MinimumWidth = cols["Libellé Ecriture"].Width = 240;
                cols["base"].Width = 40;
                cols["lot"].Width = 40;
                cols["montant"].Width = 60;
                cols["Date Ecriture"].Width = 80;
                //if (source.Rows.Count < 1)
                //else
                //    dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            float current = 0;
            foreach (DataRow row in source.Rows)
            {
                current += Convertir.ToFloat(row["montant"]);
            }
            
            tbMontantLiasse.Text = current.ToString();

            if (!"".Equals(tbTotal.Text))
            {
                double total = Convertir.ToFloat(tbTotal.Text);
                tbDiff.Text = (total - current).ToString();
            }
            Boolean bVisibilite = false;
            if (!LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
            {
                if (dataGridViewEcriture.Rows.Count <= 0)
                    bVisibilite = true;
            }
            btnDelLiasse.Visible = bVisibilite;

            if (dataGridViewEcriture.Rows.Count > 0)
                dataGridViewEcriture.FirstDisplayedScrollingRowIndex = dataGridViewEcriture.Rows.Count - 1;

            bLoadEcriture = false;
        }
        private void ClearFicheSaisie()
        {
            string liasse_id = cbLiasse.SelectedValue.ToString();

            tbMontant.Text = "";
            tbBase.Text = "";
            tbComment.Text = "";
            tbRefImmeuble_Validating(null, null);
            btnAdd.Text = "&Ajouter";
            tbLot.Text = "";
            lblLot.Visible = false;
            tbLot.Visible = false;
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Validating(null, null);
            }
        }

        private void ShowFromRepartitionImmeuble(ImmeubleEntite immeuble)
        {
            DataTable repartitionImmeuble = immeuble.getRepartitionImmeuble();

            baseAuto = RepartitionControlsWindows.ShowRepartitionImmeuble(dataGridView, repartitionImmeuble);
            ControlsWindows.setAutoControle(tbBase, baseAuto);
            lotAuto = LotsControlsWindows.getLotsAutocomplete(immeuble);
            ControlsWindows.setAutoControle(tbLot, lotAuto);
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            infoKey.DoFormText(this);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                ShowFromRepartitionImmeuble(immeuble);
                tbBase.Enabled = true;
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                infoForm.DoFormText(this, immeuble.note_repart);
            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                tbBase.Text = "";
                this.Text = TitreForm;
                tbBase.Enabled = false;
                infoForm.Hide();
            }
            EnableSaveAction();

        }

        private void lblNature_Click(object sender, EventArgs e)
        {
            FindNatureForm form = new FindNatureForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbNature.Text = form.reference;
                tbNature_Validating(null, null);
            }
        }

        private void btnNatureAdd_Click(object sender, EventArgs e)
        {
            FicheNatureForm form = new FicheNatureForm(false);
            form.entite = new NatureEntite();
            form.ShowDialog();
            if (!form.entite.id.Equals(""))
            {
                tbNature.Text = form.entite.reference;
                tbNature_Validating(null, null);
            }
            ControlsWindows.setAutoControle(tbNature, NatureController.getController().getAutoComplete("reference"));
        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            if (tbNature.Text == "")
                return;
            nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (nature != null)
            {
                tbNature.BackColor = Color.White;
                tbLibNature.Text = nature.nom;
            }
            else
            {
                tbNature.BackColor = Color.Red;
                tbLibNature.Text = "";
            }
            EnableSaveAction();

        }
        private void tbBase_TextChanged(object sender, EventArgs e)
        {
            if (baseAuto.Contains(tbBase.Text) || tbBase.Text == "")
            {
                tbBase.BackColor = Color.White;
            }
            else
            {
                tbBase.BackColor = Color.Red;
            }
            tbLot.Visible = (tbBase.Text == "80");
            lblLot.Visible = (tbBase.Text == "80");
            ShowOldLot();
            EnableSaveAction();
        }

        private void tbMontantFac_TextChanged(object sender, EventArgs e)
        {
            float montant = 0;
            if (tbMontant.Text != "")
            {
                montant = Convertir.ToFloat(tbMontant.Text.Replace(".", ","));
                if (montant == 0)
                {
                    tbMontant.BackColor = Color.Red;
                }
                else
                {
                    tbMontant.BackColor = Color.White;
                }
            }
            EnableSaveAction();
        }

        private void selectComboLiasse(string liasse_id)
        {
            DataTable source = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.AppelDeFond);
            cbLiasse.DataSource = source;
            foreach (DataRow row in source.Rows)
            {
                if (liasse_id.Equals(row["id"].ToString()))
                {
                    cbLiasse.SelectedValue = liasse_id;
                    break;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
                UpdateEcriture();
            else
                SaveEcriture();
        }

        private SaisieAppelFondEntite FillSaisieFromForm(SaisieAppelFondEntite saisie)
        {
            saisie.immeuble_id = immeuble.id;
            saisie.nature_id = nature.id;
            saisie.montant = Convertir.ToDecimal(tbMontant.Text);
            saisie.date_reference = Convert.ToDateTime(tbDateCreation.Text);
            saisie.libelle = tbComment.Text;
            saisie.base_repart = tbBase.Text;
            return saisie;
        }

        private bool ValidateForm()
        {
            string msg = "";

            if (immeuble == null) msg += "Immeuble invalide\r\n";
            if (nature == null) msg += "Nature invalide\r\n";
            if (!baseAuto.Contains(tbBase.Text)) msg += "Base invalide\r\n";
            if (tbMontant.Text.Equals("")) msg += "Montant invalide\r\n";
            if (tbComment.Text.Equals("")) msg += "Libelle invalide\r\n";
            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }

            DateTime dtFac = Convert.ToDateTime(tbDateCreation.Text);
            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getExerciceFromDate(immeuble.id, dtFac);

            if ( exercice != null )
            {
                if ( exercice.statut != (int) GlobalConstantes.StatutExercice.Ouvert)
                {
                    DialogResult dr = MessageBox.Show("La date de l'opération correspond à un exercice Cloturé\r\nVoulez vous continuer", "Attention", MessageBoxButtons.YesNo);
                    if (dr != DialogResult.Yes)
                        return false;
                }
            }

            return true;
        }

        private void UpdateEcriture()
        {
            if (!ValidateForm())
                return;

            DataRowView rowGrid = (DataRowView) dataGridViewEcriture.SelectedRows[0].DataBoundItem;
            if (rowGrid != null)
            {
                DataRow row = rowGrid.Row;
                try
                {
                    SaisieAppelFondEntite saisie = SaisieAppelFondController.getController().getEntiteById(row["id"].ToString());
                    if (saisie != null)
                    {
                        saisie_id = saisie.id;
                        ImmeubleRepartitionEntite immeuble_repart = ImmeubleRepartitionController.getController().getRepartFromImmeubleBase(immeuble.id, tbBase.Text);
                        if (immeuble_repart == null) return;
                        
                        string oldBase = saisie.base_repart;

                        if (tbBase.Text != oldBase)
                        {
                            ImmeubleRepartitionEntite old_repart = ImmeubleRepartitionController.getController().getRepartFromImmeubleBase(immeuble.id, saisie.base_repart);
                            if ( old_repart.type_ventilation != immeuble_repart.type_ventilation)
                            {
                                MessageBox.Show("Vous ne pouvez pas changer de base si le type de répartition change \r\nVous devez supprimer l'écriture");
                                return;
                            }
                        }
                        saisie = FillSaisieFromForm(saisie);

                        if (immeuble_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
                        {
                            if ( tbBase.Text == "80" )
                            {
                                SaisieAppelFondController.getController().UpdateSaisieAndLot(saisie, immeuble.id, tbLot.Text, Convertir.ToDecimal(tbMontant.Text));
                            }
                            else
                            {
                                FicheAppelDeFondRepartitionIndividuelle form = new FicheAppelDeFondRepartitionIndividuelle();
                                form.saisie = saisie;
                                form.immeuble = immeuble;
                                DialogResult rc = form.ShowDialog();
                            }
                        }
                        else
                            SaisieAppelFondController.getController().InsertOrUpdate(saisie);

                        ClearFicheSaisie();

                        FillDatagridEcritures();
                        tbRefImmeuble.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnValid_Click(object sender, EventArgs e)
        {
            String msg  = "Voulez-vous valider cet appel de fond\n";
            msg+= "Cette opération est irréversible\n";
            msg+= "Si vous répondez Oui\n";
            msg+= "Seule l'impression (Réimpression) sera accessible";

            DialogResult res = MessageBox.Show( msg, "Attention", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
                return;
            
            if (res == DialogResult.No)
                this.Close();

            if ( res == DialogResult.Yes)
            {
                string liasse_id = cbLiasse.SelectedValue.ToString();
                OperationController.getController().ValidateAppelDeFond(liasse_id);
                cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());
                ImprimerAppelDeFondForm form = new ImprimerAppelDeFondForm();
                form.immeuble = immeuble;
                form.saisie_id = saisie_id;
                form.ShowDialog();
            }
        }
        private void SaveEcriture()
        {
            if (!ValidateForm())
                return;

            bool bNewLiasse = false;
            int numero_operation = 1;
            string liasse_id = cbLiasse.SelectedValue.ToString();
            LiasseEntite liasse = null;
            if (LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
            {
                //LiasseEntite liasse = new LiasseEntite();
                liasse = new LiasseEntite();
                liasse.isNew = true;
                liasse.montant = Convertir.ToDecimal(tbTotal.Text);
                liasse.type_ecriture = getTypeEcriture().ToString();
                liasse.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
                liasse.reference = String.Format("{0} pour {1} du {2}", BaseApplication.ComputerName, immeuble.reference, DateTime.Now);
                //LiasseController.getController().InsertOrUpdate(liasse);
                liasse_id = liasse.id = liasse.get_uuid();
                bNewLiasse = true;
            }

            numero_operation = SaisieAppelFondController.getController().getNextNumeroOperation(Convert.ToDateTime(tbDateCreation.Text));

            SaisieAppelFondEntite saisie = new SaisieAppelFondEntite();
            saisie.liasse_id = liasse_id;
            saisie.date_operation = saisie.date_reference = Convert.ToDateTime(tbDateCreation.Text);
            saisie.numero_operation = numero_operation;
            saisie = FillSaisieFromForm(saisie);
            saisie.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            try
            {
                ImmeubleRepartitionEntite immeuble_repart = ImmeubleRepartitionController.getController().getEntiteFromField("reference", tbBase.Text);
                if (immeuble_repart == null) return;
                if (immeuble_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
                {
                    if (tbBase.Text == "80")
                    {
                         SaisieAppelFondController.getController().UpdateSaisieAndLot(saisie, immeuble.id, tbLot.Text, Convertir.ToDecimal(tbMontant.Text));
                    }
                    else
                    {
                        FicheAppelDeFondRepartitionIndividuelle form = new FicheAppelDeFondRepartitionIndividuelle();
                        form.saisie = saisie;
                        form.immeuble = immeuble;
                        if (DialogResult.Cancel == form.ShowDialog())
                            bNewLiasse = false;
                    }
                }
                else
                    SaisieAppelFondController.getController().InsertOrUpdate(saisie);

                if (bNewLiasse)
                    LiasseController.getController().InsertOrUpdate(liasse);

                ClearFicheSaisie();
                if ( bNewLiasse )
                    selectComboLiasse(liasse_id);

                saisie_id = saisie.id;

                FillDatagridEcritures();
                tbRefImmeuble.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FicheAppelDeFondForm_FormClosing(object sender, FormClosingEventArgs e)
        {
//            infoForm.Hide();
            e.Cancel = false;
        }

        private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    if ( sender.Equals(tbRefImmeuble))
                        lblImmeuble_Click(null, null);
                    if (sender.Equals(tbNature))
                        lblNature_Click(null, null);
                    if (sender.Equals(tbLot))
                        lblLot_Click(null, null);
                }
        }

        private void tbComment_KeyPress(object sender, KeyEventArgs e)
        {
            Common.StandardFunctionnalities.Standard_KeyPress(sender, e);
        }
        private void ShowOldLot()
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                DataRowView rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                if (rowGrid != null)
                {
                    DataRow row = rowGrid.Row;
                    if (tbBase.Text == "80")
                    {
                        tbLot.Text = OperationController.getController().getNumeroLotFromSaisie(row["id"].ToString());
                    }
                }
            }
        }
        private void dataGridViewEcriture_SelectionChanged(object sender, EventArgs e)
        {
            if (!bLoadEcriture)
                if (dataGridViewEcriture.SelectedRows.Count > 0)
                {
                    DataRowView rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                    if (rowGrid != null)
                    {
                        DataRow row = rowGrid.Row;
                        tbRefImmeuble.Text = row["immeuble_ref"].ToString();
                        tbBase.Text = row["base"].ToString();
                        tbNature.Text = row["nature_ref"].ToString();
                        tbMontant.Text = row["montant"].ToString();
                        tbComment.Text = row["Libellé Ecriture"].ToString();
                        tbDateCreation.Text = row["Date Ecriture"].ToString();
                        tbRefImmeuble_Validating(null, null);
                        tbNature_Validating(null, null);
                        tbRefImmeuble.Enabled = true;
                        ShowOldLot();
                        btnAdd.Text = "&Modifier";
                    }
                }
                else
                {
                    ClearFicheSaisie();
                }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbDateCreation_Enter(object sender, EventArgs e)
        {
            tbDateCreation.SelectAll();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!infoKey.Visible)
                infoKey.ShowForm(this);
            else
                infoKey.Close();
            this.Activate();
        }

        private void btnRepart_Click(object sender, EventArgs e)
        {
            if (!infoForm.Visible)
                infoForm.ShowForm(this);
            else
                infoForm.Close();
            this.Activate();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                DataRowView rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                if (rowGrid != null)
                {
                    DataRow row = rowGrid.Row;
                    SaisieAppelFondEntite saisie = SaisieAppelFondController.getController().getEntiteById(row["id"].ToString());
                    if (saisie != null)
                    {
                        SaisieAppelFondController.getController().DeleteEntite(saisie);
                        ClearFicheSaisie();
                        FillDatagridEcritures();
                        tbRefImmeuble.Focus();
                    }
                }
            }
        }

        private void RowMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDel_Click(null, null);
        }

        private void dataGridViewEcriture_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                int numbase = Convertir.ToInt(tbBase.Text);
                if (numbase >= 81 && numbase <= 88)
                {
                    DataRowView row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                    FicheAppelDeFondRepartitionIndividuelle form = new FicheAppelDeFondRepartitionIndividuelle();
                    form.saisie = SaisieAppelFondController.getController().getEntiteById(row["id"].ToString());
                    form.immeuble = ImmeubleController.getController().getEntiteById(row["immeuble_id"].ToString());
                    form.ShowDialog();
                }
            }

        }

        private void tbLot_Validating(object sender, CancelEventArgs e)
        {
            if (tbLot.Visible)
            {

            }
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            FindLotCoproprietaireImmeubleForm form = new FindLotCoproprietaireImmeubleForm();
            form.immeuble = immeuble;
            form.ShowDialog();
            if (form.reference != "")
            {
                tbLot.Text = form.reference;
            }
        }

        private void btnDelLiasse_Click(object sender, EventArgs e)
        {
            string liasse_id = cbLiasse.SelectedValue.ToString();
            LiasseEntite liasse = LiasseController.getController().getEntiteById(liasse_id);
            if (liasse != null)
            {
                liasse.statut = (int)GlobalConstantes.StatutData.Supprime;
                LiasseController.getController().InsertOrUpdate(liasse);
                FillComboLiasse();
            }
        }
    }
}
