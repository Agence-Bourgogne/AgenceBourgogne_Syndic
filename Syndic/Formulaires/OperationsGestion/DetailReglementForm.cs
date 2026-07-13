using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
using Npgsql;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class DetailReglementForm : EspaceSyndic.Formulaires.OperationsGestion.DetailOperationForm
    {
        ImmeubleEntite immeuble;
        SaisieReglementEntite entite;
//        CoproprietaireEntite coproprietaire;
        bool bInitialized = false;
        public DetailReglementForm()
        {
            InitializeComponent();
        }
        public DetailReglementForm(string entite_id) : base(entite_id)
        {
            InitializeComponent();
        }
        protected override void ShowDetail()
        {
            entite = SaisieReglementController.getController().getEntiteById(entite_id);
            if (entite == null)
                return;

            lblBase.Visible = false;
            tbBase.Visible = false;


            bool bEnabled = entite.statut <= (int)GlobalConstantes.StatutOperation.Valide;//&& !facture.liasse_id.StartsWith("Reprise");
            if (CommonProjectsPartners.Common.BaseApplication.userConnected.reference == "GVI")
            {
                bEnabled = true;
                //lblBase.Visible = true;
                //tbBase.Visible = true;
            }
            tbCommentaireFournisseur.Enabled = false;
            ControlsWindows.setTooltip(tbComment, "Libellé Ecriture");
            ControlsWindows.setTooltip(tbCommentaireFournisseur, "Information Fournisseur");
            btnEnter.Width = 0;
            btnValid.Enabled = bEnabled;

            fillFormFromMaster();
  //          tbMontant.Enabled = true;
        }
        protected override void fillFormFromMaster()
        {
            immeuble = ImmeubleController.getController().getEntiteById(entite.immeuble_id);
            nature = NatureController.getController().getEntiteById(entite.nature_id);
            LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromCopro(entite.immeuble_id, entite.coproprietaire_id);
            if (lot != null)
            {
                tbLot.Text = lot.numero_lot.ToString();
                tbLot_Validating(null, null);
            }

            tbRefImmeuble.Text = immeuble.reference;
            tbMontant.Text = entite.montant.ToString();
            tbComment.Text = entite.libelle;
            tbNature.Text = nature.reference;
            tbLibNature.Text = nature.nom;
            if (fournisseur != null)
            {
                tbFournisseur.Text = fournisseur.reference;
                tbNomFournisseur.Text = fournisseur.nom;
                tbAdresseFournisseur.Text = fournisseur.adresse;
                tbCpFournisseur.Text = fournisseur.codepostal;
                tbVilleFournisseur.Text = fournisseur.ville;
            }
            tbDateCreation.Text = entite.date_reference.ToShortDateString();
            FillDataGridView();
        }
        protected override void FillDataGridView()
        {
            DataTable table;
            if (entite.liasse_id.StartsWith("Reprise"))
                table = OperationController.getController().getReglementOperations(entite);
            else
                table = OperationController.getController().getSaisieOperations(entite.id);

            dataGridView.DataSource = table;
            if (CommonProjectsPartners.Common.BaseApplication.userConnected.reference == "GVI")
            {
                dataGridView.ContextMenuStrip = contextMenuStrip1;
                dataGridView.MultiSelect = true;
            }
            else
            {
                dataGridView.ContextMenuStrip = null;
                dataGridView.MultiSelect = false;
            }

            DataGridViewColumnCollection cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["ref_nature"].Width = 40;
            cols["nature"].MinimumWidth = 140;
            cols["libelle"].MinimumWidth = 160;
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["saisie_id"].Visible = false;
            dataGridView.ClearSelection();
            setRowIndicators();
//            tbMontant.Enabled = dataGridView.Rows.Count == 1;
            bInitialized = true;
            if (dataGridView.Rows.Count > 0 )
                dataGridView.Rows[0].Selected = true;
        }
        protected override void DeleteEntite()
        {
            if (DialogResult.Yes == MessageBox.Show("L'annulation d'un règlement et de ses éléments est irréversible\nVoulez vous continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                //if (entite.liasse_id.StartsWith("Reprise"))
                //    ValidModification();
                if (SaisieReglementController.getController().AnnuleElement(entite))
                    FillDataGridView();
            }
        }

        protected override void ValidModification()
        {
            bool bRepartChanged = false;
            decimal montant = Convertir.ToDecimal(tbMontant.Text);
            string ref_nature = tbNature.Text;
            string ref_fournisseur = tbFournisseur.Text;
            DateTime date_reference = DateTime.Parse(tbDateCreation.Text);
            string comment = tbComment.Text;
            string comment_fournisseur = tbCommentaireFournisseur.Text;
            string base_repart = tbBase.Text;

            NatureEntite nature = NatureController.getController().getEntiteFromField("reference", ref_nature);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id), new NpgsqlParameter("@numero_lot", Convertir.ToInt(tbLot.Text)) };
            LotDescriptionEntite lot = LotDescriptionController.getController().getEntite(" where immeuble_id = @immeuble_id and numero_lot = @numero_lot", parameters);
            if ( lot == null )
            {
                MessageBox.Show("Numéro de lot Invalide");
                return;
            }
            CoproprietaireEntite coproprietaire = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
            if ( coproprietaire == null )
            {
                MessageBox.Show("Coproprietaire Invalide");
                return;
            }

            if (dataGridView.Rows.Count == 1)
                bRepartChanged = false;
            if (!bRepartChanged)
            {
                NpgsqlConnection cnx = Database.GetInstance();
                NpgsqlTransaction trx = cnx.BeginTransaction();

                try
                {
                    if (nature == null)
                        throw new Exception("Nature invalide");

                    DataTable table = null;
                    if (entite.liasse_id.StartsWith("Reprise"))
                    {
                        table = OperationController.getController().getReglementOperations(entite);
                        entite.liasse_id = "Correction";
                    }
                    else
                        table = OperationController.getController().getSaisieOperations(entite.id);

                    entite.montant = montant;
                    entite.immeuble_id = immeuble.id;
                    entite.nature_id = nature.id;
                    entite.date_reference = date_reference;
                    entite.libelle = comment;
                    entite.coproprietaire_id = coproprietaire.id;
                    entite.comptebanque = immeuble.comptebanque;


                    //entite.banque = coproprietaire.codecomp;
                    entite.emetteur = coproprietaire.nomcomp;
                    if (entite.emetteur == "")
                        entite.emetteur = coproprietaire.nom;

                    OperationEntite operation = null;
                    if (table != null && table.Rows.Count > 0)
                    {
                        operation = OperationController.getController().getEntiteById(table.Rows[0]["id"].ToString());
//                        operation = new OperationEntite(table.Rows[0]);
                        operation.setValue(entite);
                    }
                    else
                        operation = new OperationEntite(entite);
                    //operation.debit = montant < 0 ? montant * (decimal)(-1.0) : (decimal)0.0;
                    //operation.credit = montant > 0 ? montant : (decimal)0.0;
                    operation.lot_id = lot.id;
                    operation.coproprietaire_id = coproprietaire.id;

                    if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                        throw new Exception("Reglement");

                    if (!OperationController.getController().InsertOrUpdate(operation))
                        throw new Exception("Operation");
                    //if (dataGridView.Rows.Count == 0)
                    //{
                    //    OperationEntite operation = new OperationEntite(entite);
                    //    operation.debit = montant < 0 ? montant * (decimal)(-1.0) : (decimal)0.0;
                    //    operation.credit = montant > 0 ? montant : (decimal)0.0;
                    //    operation.lot_id = lot.id;
                    //    operation.coproprietaire_id = coproprietaire.id;
                    ////    if (!OperationController.getController().InsertOrUpdate(operation))
                    ////        throw new Exception("Operation");
                    //}
                    //else
                    //foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                    //{
                    //    DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                    //    OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                    //    operation.immeuble_id = immeuble.id;
                    //    operation.lot_id = lot.id;
                    //    operation.coproprietaire_id = coproprietaire.id;
                    //    operation.nature_id = nature.id;
                    //    operation.date_reference = date_reference;
                    //    operation.libelle = comment;
                    //    operation.saisie_id = entite.id;
                    //    if (montant > 0)
                    //        operation.credit = montant;
                    //    else
                    //        operation.debit = montant * -1;
                    //    //                        operation.coproprietaire_id = coproprietaire.id;
                    //    if (dataGridView.Rows.Count == 1)
                    //    {
                    //        operation.debit = montant < 0 ? montant * (decimal)(-1.0): (decimal)0.0;
                    //        operation.credit = montant > 0 ? montant : (decimal)0.0;
                    //        operation.global = montant;
                    //    }
                    //    if (!OperationController.getController().InsertOrUpdate(operation))
                    //        throw new Exception("Operation");
                    //}
                    trx.Commit();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La modification de ces élements entraine une nouvelle repartition\rVous devez annulez cet élément et le recréer");
            }
            entite = SaisieReglementController.getController().getEntiteById(entite.id);
            fillFormFromMaster();
            tbRefImmeuble_Validating(null, null);
        }

        private void tbCopro_Validating(object sender, CancelEventArgs e)
        {
            //coproprietaire = CoproprietaireController.getController().getEntiteFromField("reference", tbCopro.Text);
            //if ( coproprietaire != null )
            //{
            //    if (coproprietaire != null)
            //    {
            //        tbCopro.BackColor = Color.White;
            //        tbLibCopro.Text = String.Format("{0} {1}", coproprietaire.nom.Trim(), coproprietaire.prenom);
            //        //tbEmetteur.Text = coproprietaire.nomcomp.Trim();
            //        //if (tbEmetteur.Text == "")
            //        //    tbEmetteur.Text = coproprietaire.nom;
            //    }
            //    else
            //    {
            //        tbCopro.BackColor = Color.Red;
            //        //tbEmetteur.Text = "";
            //    }
            //}
        }
        protected override void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if ( bInitialized)
            {
                if ( dataGridView.SelectedRows.Count > 0)
                {
                    DataRowView row = (DataRowView) dataGridView.SelectedRows[0].DataBoundItem;
                    OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                    LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById(operation.lot_id);
                    CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                    tbLot.Text = lot.numero_lot.ToString();
                    tbCopro.Text = copro.reference;
                     tbLibCopro.Text = String.Format("{0} {1}", copro.nom.Trim(), copro.prenom);
                }
                //Console.WriteLine("dataGridView_SelectionChanged");
            }
        }

        private void tbLot_Validating(object sender, CancelEventArgs e)
        {
            List<NpgsqlParameter>  parameters = new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id), new NpgsqlParameter("@numero_lot", Convertir.ToInt(tbLot.Text)) };
            LotDescriptionEntite lot = LotDescriptionController.getController().getEntite(" where immeuble_id = @immeuble_id and numero_lot = @numero_lot", parameters);
            if ( lot != null )
            {
                    CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
//                    tbLot.Text = lot.numero_lot.ToString();
                    tbCopro.Text = copro.reference;
                    tbLibCopro.Text = String.Format("{0} {1}", copro.nom.Trim(), copro.prenom);
            }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
//                tbBase.Enabled = true;

            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                tbBase.Text = "";
//                tbBase.Enabled = false;
            }
            
        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            NatureEntite nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (nature != null)
            {
                tbLibNature.Text = nature.nom;
            }
            else
                tbLibNature.Text = "";
            
        }
        private void supprimerLélémentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                NpgsqlTransaction trx = Database.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                        OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        if (operation != null)
                        {
                            operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                            if (!OperationController.getController().InsertOrUpdate(operation))
                                throw new Exception("Operation");
                        }
                    }
                    trx.Commit();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
                FillDataGridView();
            }
        }

        private void mettreÀJourLidDeSaisieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                NpgsqlTransaction trx = Database.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                        OperationEntite operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        if (operation != null)
                        {
                            operation.saisie_id = entite.id;
                            if (!OperationController.getController().doInsertOrUpdate(operation))
                                throw new Exception("Operation");
                        }
                    }
                    entite.liasse_id = "Correction";
                    if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                        throw new Exception("Reglement");
                    trx.Commit();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
                FillDataGridView();
            }

        }
    }
}
