using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class DetailAppelDeFondForm : DetailOperationForm
    {
        SaisieAppelFondEntite entite;
        public DetailAppelDeFondForm()
        {
            InitializeComponent();
        }
        public DetailAppelDeFondForm( string entite_id):base(entite_id)
        {
            InitializeComponent();
        }
        protected override void ShowDetail()
        {
            entite = SaisieAppelFondController.getController().getEntiteById(entite_id);
            if (entite == null)
                return;
            var filtre = $"where immeuble_id = '{entite.immeuble_id}' and reference = '{entite.base_repart}'";

            tbRefImmeuble.Enabled = false;
            tbBase.Enabled = false;

            var bEnabled = entite.statut <= (int)GlobalConstantes.StatutOperation.Valide;//&& !facture.liasse_id.StartsWith("Reprise");

            tbNature.Enabled = false;
            tbFournisseur.Enabled = bEnabled;
            tbDateCreation.Enabled = bEnabled;
            tbComment.Enabled = bEnabled;
            tbCommentaireFournisseur.Enabled = false;
            tbMontant.Enabled = false;//bEnabled;


            ControlsWindows.setTooltip(tbComment, "Libellé Ecriture");
            ControlsWindows.setTooltip(tbCommentaireFournisseur, "Information Fournisseur");
            btnEnter.Width = 0;
            btnValid.Enabled = bEnabled;

            fillFormFromMaster();

            //            btn
        }
        protected virtual void fillFormFromMaster()
        {
            var immeuble = ImmeubleController.getController().getEntiteById(entite.immeuble_id);
            nature = NatureController.getController().getEntiteById(entite.nature_id);

            tbRefImmeuble.Text = immeuble.reference;

            tbBase.Text = entite.base_repart;
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
            dataGridView.ClearSelection();
        }

        protected virtual void FillDataGridView()
        {
            DataTable table;
            if (entite.liasse_id.StartsWith("Reprise"))
                table = OperationController.getController().getAppelDeFondOperations(entite);
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

            var cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["ref_nature"].Width = 40;
            cols["nature"].MinimumWidth = 140;
            cols["libelle"].MinimumWidth = 160;
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["saisie_id"].Visible = false;
            cols["ref_nature"].Visible = false;
            cols["ref_copro"].Visible = false;
            dataGridView.ClearSelection();
            setRowIndicators();
            tbMontant.Enabled = dataGridView.Rows.Count == 1;
            decimal total = 0;
            foreach (DataRow row in table.Rows)
            {
                var credit = Convertir.ToDecimal(row["credit"]);
                var debit = Convertir.ToDecimal(row["debit"]);
                total += credit - debit;
            }
            tbTotal.Text = Math.Abs(total).ToString();

            if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
            {
                tbTotal.BackColor = Color.Red;
                tbTotal.ForeColor = Color.Black;
            }
            else
                tbTotal.BackColor = Color.Gray;
        }
        protected override void DeleteEntite()
        {
            if (DialogResult.Yes == MessageBox.Show("L'annulation d'un appel de fond et de ses éléments est irréversible\nVoulez vous continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (entite.liasse_id.StartsWith("Reprise"))
                    ValidModification();
                if (SaisieAppelFondController.getController().DeleteEntite(entite))
                    FillDataGridView();
            }
        }
        protected override void ValidModification()
        {
            var bRepartChanged = false;
            var montant = Convertir.ToDecimal(tbMontant.Text);
            var ref_nature = tbNature.Text;
            var ref_fournisseur = tbFournisseur.Text;
            var date_reference = DateTime.Parse(tbDateCreation.Text);
            var comment = tbComment.Text;
            var comment_fournisseur = tbCommentaireFournisseur.Text;
            var base_repart = tbBase.Text;

            var nature = NatureController.getController().getEntiteFromField("reference", ref_nature);

            if (dataGridView.Rows.Count == 1)
                bRepartChanged = false;
            if (!bRepartChanged)
            {
                var cnx = Database.GetInstance();
                var trx = cnx.BeginTransaction();

                try
                {
                    if (nature == null)
                        throw new Exception("Nature invalide");

                    if (dataGridView.Rows.Count == 1)
                        entite.montant = montant;
                    entite.nature_id = nature.id;
                    entite.date_reference = date_reference;
                    entite.libelle = comment;
                    if (!SaisieAppelFondController.getController().InsertOrUpdate(entite))
                        throw new Exception("Appel de Fond");
                    foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        operation.nature_id = nature.id;
                        operation.date_reference = date_reference;
                        operation.base_repart = entite.base_repart;
                        operation.libelle = comment;
                        operation.saisie_id = entite.id;
                        if (dataGridView.Rows.Count == 1)
                        {
                            operation.debit = montant > 0 ? montant : (decimal)0.0;
                            operation.credit = montant < 0 ? montant * (decimal)(-1.0) : (decimal)0.0;
                            operation.global = montant;
                        }
                        if (!OperationController.getController().InsertOrUpdate(operation))
                            throw new Exception("Operation");
                    }
                    trx.Commit();
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }

            entite = SaisieAppelFondController.getController().getEntiteById(entite.id);
            fillFormFromMaster();
        }


        private void btnRecalc_Click(object sender, EventArgs e)
        {
            if (entite != null)
            {
                SaisieAppelFondController.getController().RecalcRepartition(entite, true);
            }
            fillFormFromMaster();
        }

        private void supprimerLélémentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var trx = Database.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        if (operation != null)
                        {
                            operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                            if (!OperationController.getController().doInsertOrUpdate(operation))
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
                var trx = Database.BeginTransaction();

                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        if (operation != null)
                        {
                            operation.saisie_id = entite.id;
                            if (!OperationController.getController().doInsertOrUpdate(operation))
                                throw new Exception("Operation");
                        }
                    }
                    entite.liasse_id = "Correction";
                    if (!SaisieAppelFondController.getController().InsertOrUpdate(entite))
                        throw new Exception("Appel de Fond");
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
        protected override void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView) dataGridView.SelectedRows[0].DataBoundItem;
                var form = new DetailElementOperationForm(row["id"].ToString());
                form.ShowDialog();
                FillDataGridView();
            }
        }
    }
}
