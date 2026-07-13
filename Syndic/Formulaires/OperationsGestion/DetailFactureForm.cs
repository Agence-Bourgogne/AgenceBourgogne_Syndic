using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion;

public partial class DetailFactureForm : DetailOperationForm
{
    private SaisieFactureEntite entite;

    public DetailFactureForm()
    {
        InitializeComponent();
    }
    public DetailFactureForm(string entite_id) : base ( entite_id)
    {
        InitializeComponent();
    }
    protected override void ShowDetail()
    {
        entite = SaisieFactureController.getController().getEntiteById(entite_id);
        if (entite == null)
            return;

        tbRefImmeuble.Enabled = false;
        tbBase.Enabled = false;
        lblLot.Visible = entite.base_repart == "80";
        tbLot.Visible = entite.base_repart == "80";

        if (entite.lot_id != null)
        {
            var lot = LotDescriptionController.getController().getEntiteById(entite.lot_id);
            if (lot != null)
                tbLot.Text = lot.numero_lot.ToString();
        }

        var bEnabled = entite.statut <= (int)GlobalConstantes.StatutOperation.Valide;//&& !facture.liasse_id.StartsWith("Reprise");
        if (BaseApplication.userConnected.IsAdmin)
        {
            dataGridView.ContextMenuStrip = contextMenuStrip1;
            dataGridView.MultiSelect = true;
            bEnabled = true;
        }
        else
        {
            dataGridView.ContextMenuStrip = null;
            dataGridView.MultiSelect = false;
        }

        tbNature.Enabled = bEnabled;
        tbFournisseur.Enabled = bEnabled;
        tbDateCreation.Enabled = bEnabled;
        tbComment.Enabled = bEnabled;
        tbCommentaireFournisseur.Enabled = bEnabled;
        tbMontant.Enabled = false;//bEnabled;


        ControlsWindows.setTooltip(tbComment, "Libellé Ecriture");
        ControlsWindows.setTooltip(tbCommentaireFournisseur, "Information Fournisseur");
        btnEnter.Width = 0;
        btnValid.Enabled = tbDateCreation.Enabled;

        fillFormFromMaster();

        //            btn
    }
    protected virtual void FillDataGridView()
    {
        DataTable table;
        if (entite.liasse_id.StartsWith("Reprise"))
            table = OperationController.getController().getFactureOperations(entite);
        else
            table = OperationController.getController().getSaisieOperations(entite.id);

        dataGridView.DataSource = table;

        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        //cols["base_repart"].Width = 40;
        cols["ref_nature"].Width = 40;
        cols["nature"].MinimumWidth = 140;
        cols["libelle"].MinimumWidth = 160;
        cols["statut"].Visible = false;
        cols["id"].Visible = false;
        cols["saisie_id"].Visible = false;
        cols["ref_nature"].Visible = false;
        dataGridView.ClearSelection();
        setRowIndicators();
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

    protected virtual void fillFormFromMaster()
    {
        var immeuble = ImmeubleController.getController().getEntiteById(entite.immeuble_id);
        nature = NatureController.getController().getEntiteById(entite.nature_id);
        fournisseur = FournisseurController.getController().getEntiteById(entite.fournisseur_id);

        tbRefImmeuble.Text = immeuble.reference;

        tbBase.Text = entite.base_repart;
        tbMontant.Text = entite.montant.ToString();
        tbComment.Text = entite.libelle;
        tbCommentaireFournisseur.Text = entite.comment_fournisseur;

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
        tbMontant.Enabled = dataGridView.Rows.Count == 1 || nature.reference == "140";
    }

    private bool bCheckLot = true;
    protected override void DeleteEntite()
    {
        if (DialogResult.Yes == MessageBox.Show("L'annulation d'une facture et de ses éléments est irréversible\nVoulez vous continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
        {
            bCheckLot = false;
            if (entite.liasse_id.StartsWith("Reprise") && dataGridView.Rows.Count > 0 )
                ValidModification();
            bCheckLot = true;
            if (SaisieFactureController.getController().DeleteEntite(entite))
                //FillDataGridView();
                Close();
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
        var base_repart = tbBase.Text.Trim();

        var old_nature = NatureController.getController().getEntiteById(entite.nature_id);

        var nature = NatureController.getController().getEntiteFromField("reference", ref_nature);
        var fournisseur = FournisseurController.getController().getEntiteFromField("reference", ref_fournisseur);
        LotDescriptionEntite lot = null;
        if ( base_repart == "80" && bCheckLot)
        {
            lot = LotDescriptionController.getController().getLotFromReference(entite.immeuble_id, tbLot.Text);
            if (lot == null)
            {
                MessageBox.Show(@"Lot Invalide");
                return;
            }
                
        }

        if (old_nature != null && old_nature.reference == "140")
            bRepartChanged = false;
        else
            bRepartChanged |= montant != entite.montant;

        bRepartChanged |= base_repart != entite.base_repart;

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
                if (fournisseur == null)
                    throw new Exception("Fournisseur invalide");

                if (dataGridView.Rows.Count == 1 || (old_nature != null && old_nature.reference == "140"))
                    entite.montant = montant;
                    
                if (lot != null)
                    entite.lot_id = lot.id;
                var statut = entite.statut;
                if (BaseApplication.userConnected.IsAdmin)
                    if (entite.statut >= (int) GlobalConstantes.StatutOperation.Valide)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Voulez-vous repasser le statut de l'opération comme Validé", "Attention", MessageBoxButtons.YesNo))
                            statut = (int)GlobalConstantes.StatutOperation.Valide;
                    }

                entite.nature_id = nature.id;
                entite.fournisseur_id = fournisseur.id;
                entite.date_reference = entite.date_operation = date_reference;
                entite.comment_fournisseur = comment_fournisseur;
                entite.libelle = comment;
                entite.statut = statut;
                if (!SaisieFactureController.getController().InsertOrUpdate(entite))
                    throw new Exception("Facture");
                    
                if (dataGridView.Rows.Count == 0 && base_repart == "80")
                {
                    var operation = new OperationEntite
                    {
                        statut = statut
                    };
                    operation.setValue(entite);
                    operation.debit = montant > 0 ? montant : (decimal)0.0;
                    operation.credit = montant < 0 ? montant * (decimal)-1.0 : (decimal)0.0;
                    operation.date_reference = operation.date_operation = date_reference;
                    operation.global = montant;
                    if ( lot != null)
                        operation.lot_id = entite.lot_id;
                    operation.coproprietaire_id = lot.coproprietaire_id;
                    if (!OperationController.getController().InsertOrUpdate(operation))
                        throw new Exception("Operation");
                }
                else
                    foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                        operation.statut = statut;
                        operation.nature_id = nature.id;
                        operation.date_reference = operation.date_operation = date_reference;
                        operation.libelle = comment;
                        operation.saisie_id = entite.id;
                            
                        if (dataGridView.Rows.Count == 1)
                        {
                            if ( entite.lot_id != null)
                                operation.lot_id = entite.lot_id;
                            if (lot != null)
                                operation.coproprietaire_id = lot.coproprietaire_id;
                            operation.debit = montant > 0 ? montant : (decimal)0.0;
                            operation.credit = montant < 0 ? montant * (decimal)-1.0 : (decimal)0.0;
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
        else
        if (DialogResult.No == MessageBox.Show("La modification de ces élements entraine une nouvelle repartition\rVous devez annulez cette facture et la recréer", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
        {
            return;
        }
        entite = SaisieFactureController.getController().getEntiteById(entite.id);
        fillFormFromMaster();
    }

    private void btnRecalc_Click(object sender, EventArgs e)
    {
        if (entite != null)
        {
            if (entite.base_repart == "0")
                SaisieFactureController.getController().RecalcRepartitionBilan(entite, true);
            else
                SaisieFactureController.getController().RecalcRepartition(entite, true);
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
                if (!SaisieFactureController.getController().InsertOrUpdate(entite))
                    throw new Exception("Facture");
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
    private void tbTotal_Enter(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }
    protected override void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var form = new DetailElementOperationForm(row["id"].ToString());
            form.ShowDialog();
            FillDataGridView();
        }
    }
}