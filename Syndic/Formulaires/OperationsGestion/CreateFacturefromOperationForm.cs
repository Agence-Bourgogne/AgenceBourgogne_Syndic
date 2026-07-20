using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Fournisseur;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion;

public partial class CreateFacturefromOperationForm : Form
{
    private readonly OperationEntite operation;
    private FournisseurEntite fournisseur;
    private NatureEntite nature;

    public CreateFacturefromOperationForm()
    {
        InitializeComponent();
    }

    public CreateFacturefromOperationForm(OperationEntite entite)
    {
        InitializeComponent();
        operation = entite;
    }

    private void CreateFacturefromOperationForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        if (operation != null)
        {
            tbRefImmeuble.Text = operation.Immeuble.reference;
            tbNature.Text = operation.Nature.reference;
            tbMontant.Text = operation.global.ToString();
            tbBase.Text = operation.base_repart;
            tbComment.Text = operation.libelle;
            tbDateCreation.Text = operation.date_reference.ToShortDateString();
            FillDataGrid();
        }
    }

    private void FillDataGrid()
    {
        var table = OperationController.getController().getOperations(operation);
        dataGridView.DataSource = table;
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        cols["id"].Visible = false;
        cols["statut"].Visible = false;
        decimal total = 0;
        foreach (DataRow row in table.Rows)
        {
            var credit = Convertir.ToDecimal(row["credit"]);
            var debit = Convertir.ToDecimal(row["debit"]);
            total += credit - debit;
        }

        tbTotal.Text = Math.Abs(total).ToString();
        tbNature_Validating(null, null);
        tbFournisseur_Validating(null, null);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var montant = Convertir.ToDecimal(tbMontant.Text);
        var ref_nature = tbNature.Text;
        var ref_fournisseur = tbFournisseur.Text;
        var date_reference = DateTime.Parse(tbDateCreation.Text);
        var comment = tbComment.Text;
        var comment_fournisseur = tbCommentaireFournisseur.Text;
        var base_repart = tbBase.Text;

        var nature = NatureController.getController().getEntiteFromField("reference", ref_nature);
        var fournisseur = FournisseurController.getController().getEntiteFromField("reference", ref_fournisseur);
        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();

        try
        {
            if (nature == null)
                throw new Exception("Nature invalide");
            if (fournisseur == null)
                throw new Exception("Fournisseur invalide");


            var entite = new SaisieFactureEntite
            {
                base_repart = base_repart,
                immeuble_id = operation.immeuble_id,
                numero_operation = SaisieFactureController.getController()
                    .getNextNumeroOperation(Convert.ToDateTime(tbDateCreation.Text)),
                montant = montant
            };
            entite.date_operation = entite.date_reference = date_reference;
            entite.nature_id = nature.id;
            entite.fournisseur_id = fournisseur.id;
//                entite.date_reference = date_reference;
            entite.comment_fournisseur = comment_fournisseur;
            entite.liasse_id = "Correction";
            entite.libelle = comment;
            entite.comment_fournisseur = comment_fournisseur;
            entite.statut = (int)GlobalConstantes.StatutOperation.Valide;

            if (!SaisieFactureController.getController().InsertOrUpdate(entite))
                throw new Exception("Facture");
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                var row = (DataRowView)rowGrid.DataBoundItem;
                var opes = OperationController.getController().getEntiteById(row["id"].ToString());
                opes.nature_id = nature.id;
                opes.date_reference = date_reference;
                opes.libelle = comment;
                opes.saisie_id = entite.id;
                if (dataGridView.Rows.Count == 1)
                {
                    opes.debit = montant > 0 ? montant : (decimal)0.0;
                    opes.credit = montant < 0 ? montant * (decimal)-1.0 : (decimal)0.0;
                    opes.global = montant;
                }

                if (!OperationController.getController().InsertOrUpdate(opes))
                    throw new Exception("Operation");
            }

            trx.Commit();
            MessageBox.Show(@"Modification enregistrées");
            Close();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }
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
            tbNature.BackColor = tbNature.Text != "" ? Color.Red : Color.White;
            tbLibNature.Text = "";
        }
    }

    private void tbFournisseur_Validating(object sender, CancelEventArgs e)
    {
        fournisseur = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);
        if (fournisseur != null)
        {
            tbFournisseur.BackColor = Color.White;
            tbNomFournisseur.Text = fournisseur.nom;
            tbAdresseFournisseur.Text = fournisseur.adresse;
            tbVilleFournisseur.Text = fournisseur.ville;
            tbCpFournisseur.Text = fournisseur.codepostal;
        }
        else
        {
            tbFournisseur.BackColor = tbFournisseur.Text != "" ? Color.Red : Color.White;
            tbNomFournisseur.Text = "";
            tbAdresseFournisseur.Text = "";
            tbVilleFournisseur.Text = "";
            tbCpFournisseur.Text = "";
        }
    }

    private void lblFournisseur_Click(object sender, EventArgs e)
    {
        var form = new FindFournisseurForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbFournisseur.Text = form.reference;
            tbFournisseur_Validating(null, null);
        }
    }
}