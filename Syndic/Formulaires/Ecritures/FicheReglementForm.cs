using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using Npgsql;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Impressions.Reglement;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Ecritures
{
    public partial class FicheReglementForm : Form
    {
        CoproprietaireEntite coproprietaire = null;
        NatureEntite nature = null;
        protected bool bLoadEcriture;
        InfoKeyHelpForm infoKey = new InfoKeyHelpForm("aide_clavier_reglement");
        String TitreForm;
        public FicheReglementForm()
        {
            InitializeComponent();
            TitreForm = Text;
        }

        private void FicheReglementForm_Load(object sender, EventArgs e)
        {
            ControlsWindows.setAutoControle(tbNature, NatureController.getController().getAutoComplete("reference"));
            DateTime dt = DateTime.Now;
            tbDate.Text = dt.ToShortDateString();
            fillCBLiasse();
            EnableSaveAction();
            setAutoCompleteCoproprietaire();
            ControlsWindows.ToTitleCase(dataGridViewLots.Columns);
            tbNature.Text = "146";
            tbNature_Validating(null, null);
            //tbCopro.Focus();
            //this.MinimumSize = this.MaximumSize = this.Size;
            lblDiff.Visible = tbDiff.Visible = lblTotal.Visible = tbTotal.Visible = lblLiasse.Visible = tbMontantLiasse.Visible = false;

            btnEnter.Width = 0;
        }
        void fillCBLiasse()
        {
            cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());
            cbLiasse.DisplayMember = "reference";
            cbLiasse.ValueMember = "id";
            cbLiasse.Enabled = true;
            cbLiasse_SelectedIndexChanged(null, null);
        }
        private void ClearFicheSaisie()
        {
            tbNature.Text = "146";
            tbCopro.Text = "";
            tbMontant.Text = "";
            tbBanque.Text = "";
            tbEmetteur.Text = "";
            tbLibelle.Text = "";
            tbLibNature.Text = "";
            tbLibCopro.Text = "";
            tbCopro_Validating(null, null);
            tbNature_Validating(null, null);
        }

        protected void ShowSoldeCopro()
        {
            if (coproprietaire == null )
            {
                dataGridViewLots.DataSource = OperationController.getController().getSoldeRepriseCoproprietaire("");
            }
            else
            {
                DataTable table = OperationController.getController().getSoldeRepriseCoproprietaire(coproprietaire.id);
                if (table.Rows.Count <= 0)
                    table = OperationController.getController().getSoldeRepriseCoproprietaireVide(coproprietaire.id);
                dataGridViewLots.DataSource = table;
            }
            if (dataGridViewLots.DataSource != null)
            {
                ControlsWindows.ToTitleCase(dataGridViewLots.Columns);
                dataGridViewLots.Columns["immeuble_id"].Visible = false;
                dataGridViewLots.Columns["lot_id"].Visible = false;
            }
        }
        protected void EnableSaveAction()
        {
            bool enable = true;

            enable &= (coproprietaire != null);
            enable &= (tbNature.AutoCompleteCustomSource.Contains(tbNature.Text));
            enable &= (!tbMontant.Text.Equals(""));

            btnAdd.Enabled = enable;

            btnSave.Enabled = dataGridViewEcriture.Rows.Count > 0;
            btnDelete.Enabled = dataGridViewEcriture.SelectedRows.Count > 0;
        }
        protected void cbLiasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbLiasse.Enabled) return;
            DataRowView row = (DataRowView)cbLiasse.SelectedItem;
            tbTotal.Text = row["montant"].ToString();
            tbTotal_TextChanged(null, null);

            FillDatagridEcritures();
            EnableSaveAction();
            //tbCopro.Focus();
        }
        protected void tbTotal_TextChanged(object sender, EventArgs e)
        {
            float total = Convertir.ToFloat(tbTotal.Text);
        }

        private void setAutoCompleteCoproprietaire()
        {

            AutoCompleteStringCollection autoComplete = CoproprietaireController.getController().getAutoComplete("reference");
            ControlsWindows.setAutoControle(tbCopro, autoComplete);
        }

        private void lblCopro_Click(object sender, EventArgs e)
        {
            FindCoproprietaireForm form = new FindCoproprietaireForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbCopro.Text = form.reference;
                tbCopro_Validating(tbCopro, null);
            }
        }
        public virtual GlobalConstantes.TypeOperation getTypeEcriture()
        {
            return GlobalConstantes.TypeOperation.Tresorerie;
        }
        private void tbCopro_Validating(object sender, CancelEventArgs e)
        {
            infoKey.DoFormText(this);
            Text = TitreForm;

            if (tbCopro.Text != "")
            {
                coproprietaire = CoproprietaireController.getController().getEntiteFromField("reference", tbCopro.Text);
                if (coproprietaire != null)
                {
                    tbCopro.BackColor = /*tbLibCopro.BackColor = */Color.White;
                    tbLibCopro.Text = String.Format("{0} {1}", coproprietaire.nom.Trim(), coproprietaire.prenom);
                    tbEmetteur.Text = coproprietaire.nomcomp.Trim();
                    if ( tbEmetteur.Text == "" )
                        tbEmetteur.Text = coproprietaire.nom;
                    ImmeubleEntite immeuble = coproprietaire.Immeuble;
                    if ( immeuble != null )
                        Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);


                    if (coproprietaire.huissier)
                    {
                        tbCopro.BackColor = Color.Red;
                        tbLibCopro.Text  = "Attention Dossier Transmis à un huissier";
                        tbLibCopro.BackColor = Color.Red;
                        tbLibCopro.Enabled = true;
                    }
                    else
                    {
                        tbLibCopro.Enabled = false;
                        tbLibCopro.BackColor = DefaultBackColor;
                    }
                }
                else
                {
                    tbCopro.BackColor = Color.Red;
                    tbEmetteur.Text = "";
                }
                ShowSoldeCopro();
            }
            EnableSaveAction();
        }
        private void lblNature_Click(object sender, EventArgs e)
        {
            if (!tbNature.Enabled)
                return;
            FindNatureForm form = new FindNatureForm();

            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbNature.Text = form.reference;
            }
        }

        private void tbNature_DoubleClick(object sender, EventArgs e)
        {
            lblNature_Click(sender, e);
        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {

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
        
        private void tbMontant_Validating(object sender, CancelEventArgs e)
        {
            EnableSaveAction();
        }

        private void tbMontant_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewLots.RowCount == 1)
                dataGridViewLots.Rows[0].Cells["reglement"].Value = tbMontant.Text;
            
            EnableSaveAction();
        }

        private SaisieReglementEntite FillSaisieFromForm(SaisieReglementEntite saisie)
        {
            saisie.coproprietaire_id = coproprietaire.id;
            saisie.nature_id = nature.id;
            saisie.montant = Convertir.ToDecimal(tbMontant.Text);
            saisie.date_reference = Convert.ToDateTime(tbDate.Text);
            //saisie.base_global = Convertir.ToDecimal(tbTotal.Text);
            saisie.libelle = tbLibelle.Text;
            saisie.emetteur = tbEmetteur.Text;
            saisie.banque = tbBanque.Text;
            return saisie;
        }
        LotDescriptionEntite lot;
        ImmeubleEntite immeuble;

        private bool ValidateForm()
        {
            string msg = "";

            if (tbMontant.Text.Equals("")) msg += "Montant Invalide\r\n";
            if (tbNature.Text.Equals("")) 
                msg += "Nature Requise\r\n";
            else
            {
                nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
                if (nature == null) msg += "Nature Invalide\r\n";
            }


            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }
            if (coproprietaire != null)
            {
                lot = coproprietaire.LotDescription;
                if (lot == null)
                {
                    MessageBox.Show("Attention Coproprietaire non Affecté à un lot");
                    return false;
                }

                immeuble = coproprietaire.Immeuble;
                if ( immeuble == null )
                {
                    MessageBox.Show("Lot coproprietaire sans immeuble");
                }
            }
            else
            {
                MessageBox.Show("Coproprietaire Invalide");
                return false;
            }

            DateTime dtFac = Convert.ToDateTime(tbDate.Text);
            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getExerciceFromDate(immeuble.id, dtFac);

            if (exercice != null)
            {
                if (exercice.statut != (int)GlobalConstantes.StatutExercice.Ouvert)
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

            DataRowView rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;

            if (rowGrid != null)
            {
                DataRow row = rowGrid.Row;
                NpgsqlTransaction trx = Database.GetInstance().BeginTransaction();
                try
                {
                    SaisieReglementEntite saisie = SaisieReglementController.getController().getEntiteById(row["id"].ToString());
                    if (saisie != null)
                    {
                        saisie = FillSaisieFromForm(saisie);
                        if (SaisieReglementController.getController().InsertOrUpdate(saisie))
                        {
                            if (UpdateSaisieInOperation(saisie))
                                trx.Commit();
                            else
                                trx.Rollback();

                        }
                        else
                            trx.Rollback();
                        ClearFicheSaisie();

                        coproprietaire = null;
                        ShowSoldeCopro();
                        FillDatagridEcritures();
                        tbCopro.Focus();
                    }
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
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

        private void SaveEcriture()
        {
            if (!ValidateForm())
                return;
            if (tbMontant.Text.Equals("")) return;
            if (tbNature.Text.Equals("")) return;
            NatureEntite nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (nature == null) return;

            NpgsqlTransaction trx = Database.GetInstance().BeginTransaction();
            bool bNewLiasse = false;
            int numero_operation = 1;
            string liasse_id = cbLiasse.SelectedValue.ToString();
            try
            {
                if (LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
                {
                    LiasseEntite liasse = new LiasseEntite();
                    liasse.isNew = true;
                    liasse.montant = Convertir.ToDecimal(tbTotal.Text);
                    liasse.type_ecriture = getTypeEcriture().ToString();
                    liasse.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
                    liasse.reference = String.Format("{0} du {1}", BaseApplication.ComputerName, DateTime.Now);
                    LiasseController.getController().InsertOrUpdate(liasse);
                    liasse_id = liasse.id;
                    bNewLiasse = true;
                }
                numero_operation = SaisieReglementController.getController().getNextNumeroOperation(Convert.ToDateTime(tbDate.Text));

//TODO Revoir cette saisie pour gérer les payements sur plusieurs Lots
            
                string immeuble_id = "";
                string compte_banque = "";
                string lot_id = "";

                if (dataGridViewLots.Rows.Count > 0)
                {
                    DataRowView row = (DataRowView)dataGridViewLots.Rows[0].DataBoundItem;
                    immeuble_id = row["immeuble_id"].ToString();
                    compte_banque = row["comptebanque"].ToString();
                    lot_id = row["lot_id"].ToString();
                }
                else
                {
                    //LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteFromField("coproprietaire_id", coproprietaire.id);
                    //if (lot == null)
                    //{
                    //    throw new Exception("Attention Coproprietaire non Affecté à un lot");
                    //}
                    immeuble_id = lot.immeuble_id;
                    lot_id = lot.id;
                    //ImmeubleEntite immeuble = ImmeubleController.getController().getEntiteById(immeuble_id);
                    //if (immeuble == null)
                    //{
                    //    throw new Exception("Lot coproprietaire sans immeuble");
                    //}
                    compte_banque = immeuble.comptebanque;
                }
            
                SaisieReglementEntite saisie = new SaisieReglementEntite();
                saisie.liasse_id = liasse_id;

                saisie.date_operation = saisie.date_reference = Convert.ToDateTime(tbDate.Text);
                saisie.numero_operation = numero_operation;
                saisie.immeuble_id = immeuble_id;
                saisie.comptebanque = compte_banque;
                saisie = FillSaisieFromForm(saisie);

                saisie.statut = (int)GlobalConstantes.StatutOperation.Brouillon;

                if (SaisieReglementController.getController().InsertOrUpdate(saisie))
                {
                    WriteSaisieInOperation(saisie, immeuble_id, lot_id);
                    trx.Commit();
                }
                else
                    trx.Rollback();
                    
                ClearFicheSaisie();
                if (bNewLiasse)
                    selectComboLiasse(liasse_id);
                coproprietaire = null;
                ShowSoldeCopro();
                FillDatagridEcritures();
                tbCopro.Focus();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private bool WriteSaisieInOperation(SaisieReglementEntite entite, String immeuble_id, string lot_id)
        {
            int numero_ligne = 1;
            bool allValide = true;

            OperationController controller = OperationController.getController();
            foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
            {
                DataRowView row = (DataRowView)rowGrid.DataBoundItem;

                OperationEntite operation = new OperationEntite();
                operation.type_mouvement = GlobalConstantes.TypeMouvement.Recette.ToString();
                operation.date_operation = operation.date_reference = entite.date_reference;
                operation.type_operation = GlobalConstantes.TypeOperation.Tresorerie.ToString();
                operation.numero_operation = entite.numero_operation;
                operation.numero_ligne = numero_ligne++;
                operation.saisie_id = entite.id;
                operation.coproprietaire_id = entite.coproprietaire_id;
                operation.immeuble_id = row["immeuble_id"].ToString();
                operation.liasse_id = entite.liasse_id;
                operation.lot_id = row["lot_id"].ToString();
                operation.nature_id = entite.nature_id;
                operation.base_repart = "10";
//                operation.date_reference = entite.date_reference;
                operation.libelle = entite.libelle;
                operation.credit = Convertir.ToDecimal(rowGrid.Cells["reglement"].Value);
                operation.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
                operation.global = entite.montant;
                if (!controller.InsertOrUpdate(operation))
                {
                    allValide = false;
                    break;
                }
            }
            return allValide;
        }
        private bool UpdateSaisieInOperation(SaisieReglementEntite saisie)
        {
            bool allValide = true;
            string cmd = String.Format("select * from {0} ", OperationController.getController().getSchemaTable());
            cmd += " where saisie_id = @saisie_id and immeuble_id = @immeuble_id and lot_id = @lot_id";
            OperationController controller = OperationController.getController();
            foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
            {
                DataRowView row = (DataRowView)rowGrid.DataBoundItem;

                //Console.WriteLine(saisie.id);
                //Console.WriteLine(row["immeuble_id"].ToString());
                //Console.WriteLine(row["lot_id"].ToString());
                List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
                {
                    new NpgsqlParameter("@saisie_id", saisie.id),
                    new NpgsqlParameter("@immeuble_id", row["immeuble_id"].ToString()),
                    new NpgsqlParameter("@lot_id", row["lot_id"].ToString())
                };
                DataTable table = OperationController.getController().getResultSQL(cmd, parameters);
                if ( table != null )
                    if (table.Rows.Count > 0)
                    {
                        OperationEntite operation = new OperationEntite(table.Rows[0]);
                        operation.coproprietaire_id = saisie.coproprietaire_id;
                        operation.nature_id = saisie.nature_id;
                        operation.date_reference = operation.date_operation = saisie.date_reference;
//                        operation.date_operation = saisie.date_reference;
                        operation.libelle = saisie.libelle;
                        operation.credit = Convertir.ToDecimal(rowGrid.Cells["reglement"].Value);
                        if (!controller.InsertOrUpdate(operation))
                        {
                            allValide = false;
                            break;
                        }
                    }
            }
            return allValide;
        }

        private void selectComboLiasse(string liasse_id)
        {
            DataTable source = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.Tresorerie);
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

        protected void FillDatagridEcritures()
        {

            bLoadEcriture = true;
            string liasse_id = cbLiasse.SelectedValue.ToString();
            DataTable source = SaisieReglementController.getController().getGridRowSaisieReglement(liasse_id);
            dataGridViewEcriture.DataSource = source;
            dataGridViewEcriture.ClearSelection();
            if ( dataGridViewLots.DataSource  != null )
                dataGridViewLots.DataSource = null;
            if (source != null)
            {
                DataGridViewColumnCollection cols = dataGridViewEcriture.Columns;
                cols["id"].Visible = false;
                cols["immeuble_id"].Visible = false;
                cols["coproprietaire_id"].Visible = false;
                cols["nature_id"].Visible = false;
                cols["liasse_id"].Visible = false;
                cols["coproprietaire_ref"].Visible = false;
                cols["immeuble_ref"].Visible = false;
                cols["nature_ref"].Visible = false;
                if (source.Rows.Count < 1)
                    dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                else
                    dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                ControlsWindows.ToTitleCase(cols);
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
            bLoadEcriture = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string liasse_id = cbLiasse.SelectedValue.ToString();
            OperationController.getController().ValidateReglement(liasse_id);
            cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());

            ImprimerListeReglementForm form = new ImprimerListeReglementForm();
            form.liasse_id = liasse_id;
            form.ShowDialog();
        }
        private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    if (sender.Equals(tbCopro))
                        lblCopro_Click(sender, null);
                    if (sender.Equals(tbNature))
                        lblNature_Click(null, null);
                    //if (sender.Equals(tbFournisseur))
                    //    lblFournisseur_Click(null, null);
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
                        tbCopro.Text = row["coproprietaire_ref"].ToString();
                        tbNature.Text = row["nature_ref"].ToString();
                        tbMontant.Text = row["montant"].ToString();
                        tbLibelle.Text = row["Libellé Ecriture"].ToString();
                        tbDate.Text = row["Date Ecriture"].ToString();
                        tbCopro_Validating(null, null);
                        tbNature_Validating(null, null);
                        tbMontant_TextChanged(null, null);
                        tbEmetteur.Text = row["emetteur"].ToString();
                        tbBanque.Text = row["banque"].ToString();
                    }
                }
                else
                    ClearFicheSaisie();

        }

        private void tbLibelle_KeyUp(object sender, KeyEventArgs e)
        {
            StandardFunctionnalities.Standard_KeyPress(sender, e, false);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbDate_Enter(object sender, EventArgs e)
        {
            tbDate.SelectAll();
        }

        private void FicheReglementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
//            infoForm.ShowForm(this);
            infoKey.ShowForm(this);
        }
        // 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                DataRowView rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                if (rowGrid != null)
                {
                    DataRow row = rowGrid.Row;
                    if (row != null)
                    {
                        if ( DialogResult.Yes == MessageBox.Show("Etes vous sur de vouloir annuler cet element", "Attention", MessageBoxButtons.YesNo))
                            SaisieReglementController.getController().AnnuleElement(row["id"].ToString());
                        FillDatagridEcritures();
                    }
                }
            }
        }
    }
}
