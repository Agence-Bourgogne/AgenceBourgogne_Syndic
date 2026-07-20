using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion;

public partial class DetailReglementForm : DetailOperationForm
{
    private bool bInitialized;

    private SaisieReglementEntite entite;
    private ImmeubleEntite immeuble;

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


        var bEnabled = entite.statut <= (int)GlobalConstantes.StatutOperation.Valide
                       || BaseApplication.userConnected.reference == "GVI";

        tbCommentaireFournisseur.Enabled = false;
        ControlsWindows.setTooltip(tbComment, "Libellé Ecriture");
        ControlsWindows.setTooltip(tbCommentaireFournisseur, "Information Fournisseur");
        btnEnter.Width = 0;
        btnValid.Enabled = bEnabled;

        fillFormFromMaster();
    }

    private void fillFormFromMaster()
    {
        immeuble = ImmeubleController.getController().getEntiteById(entite.immeuble_id);
        nature = NatureController.getController().getEntiteById(entite.nature_id);
        var lot = LotDescriptionController.getController()
            .getLotFromCopro(entite.immeuble_id, entite.coproprietaire_id);
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

    private void FillDataGridView()
    {
        var table = entite.liasse_id.StartsWith("Reprise")
            ? OperationController.getController().getReglementOperations(entite)
            : OperationController.getController().getSaisieOperations(entite.id);

        dataGridView.DataSource = table;
        if (BaseApplication.userConnected.reference == "GVI")
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
        dataGridView.ClearSelection();
        setRowIndicators();
        bInitialized = true;
        if (dataGridView.Rows.Count > 0)
            dataGridView.Rows[0].Selected = true;
    }

    protected override void DeleteEntite()
    {
        if (DialogResult.Yes ==
            MessageBox.Show("L'annulation d'un règlement et de ses éléments est irréversible\nVoulez vous continuer ?",
                "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            if (SaisieReglementController.getController().AnnuleElement(entite))
                FillDataGridView();
    }

    protected override void ValidModification()
    {
        var bRepartChanged = false;
        var montant = Convertir.ToDecimal(tbMontant.Text);
        var ref_nature = tbNature.Text;
        var date_reference = DateTime.Parse(tbDateCreation.Text);
        var comment = tbComment.Text;
        var nature = NatureController.getController().getEntiteFromField("reference", ref_nature);
        var parameters = new List<NpgsqlParameter>
            { new("@immeuble_id", immeuble.id), new("@numero_lot", Convertir.ToInt(tbLot.Text)) };
        var lot = LotDescriptionController.getController()
            .getEntite(" where immeuble_id = @immeuble_id and numero_lot = @numero_lot", parameters);
        if (lot == null)
        {
            MessageBox.Show(@"Numéro de lot Invalide");
            return;
        }

        var coproprietaire = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
        if (coproprietaire == null)
        {
            MessageBox.Show(@"Coproprietaire Invalide");
            return;
        }

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

                DataTable table = null;
                if (entite.liasse_id.StartsWith("Reprise"))
                {
                    table = OperationController.getController().getReglementOperations(entite);
                    entite.liasse_id = "Correction";
                }
                else
                {
                    table = OperationController.getController().getSaisieOperations(entite.id);
                }

                entite.montant = montant;
                entite.immeuble_id = immeuble.id;
                entite.nature_id = nature.id;
                entite.date_reference = date_reference;
                entite.libelle = comment;
                entite.coproprietaire_id = coproprietaire.id;
                entite.comptebanque = immeuble.comptebanque;


                entite.emetteur = coproprietaire.nomcomp;
                if (entite.emetteur == "")
                    entite.emetteur = coproprietaire.nom;

                OperationEntite operation = null;
                if (table != null && table.Rows.Count > 0)
                {
                    operation = OperationController.getController().getEntiteById(table.Rows[0]["id"].ToString());
                    operation.setValue(entite);
                }
                else
                {
                    operation = new OperationEntite(entite);
                }

                operation.lot_id = lot.id;
                operation.coproprietaire_id = coproprietaire.id;

                if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                    throw new Exception("Reglement");

                if (!OperationController.getController().InsertOrUpdate(operation))
                    throw new Exception("Operation");

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        entite = SaisieReglementController.getController().getEntiteById(entite.id);
        fillFormFromMaster();
        tbRefImmeuble_Validating(null, null);
    }

    private void tbCopro_Validating(object sender, CancelEventArgs e)
    {
    }

    protected override void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (bInitialized)
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                var operation = OperationController.getController().getEntiteById(row["id"].ToString());
                var lot = LotDescriptionController.getController().getEntiteById(operation.lot_id);
                var copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                tbLot.Text = lot.numero_lot.ToString();
                tbCopro.Text = copro.reference;
                tbLibCopro.Text = $"{copro.nom.Trim()} {copro.prenom}";
            }
    }

    private void tbLot_Validating(object sender, CancelEventArgs e)
    {
        var parameters = new List<NpgsqlParameter>
            { new("@immeuble_id", immeuble.id), new("@numero_lot", Convertir.ToInt(tbLot.Text)) };
        var lot = LotDescriptionController.getController()
            .getEntite(" where immeuble_id = @immeuble_id and numero_lot = @numero_lot", parameters);
        if (lot != null)
        {
            var copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
            tbCopro.Text = copro.reference;
            tbLibCopro.Text = $"{copro.nom.Trim()} {copro.prenom}";
        }
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
        }
        else
        {
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            tbBase.Text = "";
        }
    }

    private void tbNature_Validating(object sender, CancelEventArgs e)
    {
        var nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
        tbLibNature.Text = nature != null ? nature.nom : "";
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