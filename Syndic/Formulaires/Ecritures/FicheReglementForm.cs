using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Impressions.Reglement;
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Ecritures;

public partial class FicheReglementForm : Form
{
    private readonly InfoKeyHelpForm infoKey = new("aide_clavier_reglement");
    private readonly string TitreForm;
    protected bool bLoadEcriture;
    private CoproprietaireEntite coproprietaire;
    private ImmeubleEntite immeuble;

    private LotDescriptionEntite lot;
    private NatureEntite nature;

    public FicheReglementForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void FicheReglementForm_Load(object sender, EventArgs e)
    {
        ControlsWindows.setAutoControle(tbNature, NatureController.getController().getAutoComplete("reference"));
        var dt = DateTime.Now;
        tbDate.Text = dt.ToShortDateString();
        fillCBLiasse();
        EnableSaveAction();
        setAutoCompleteCoproprietaire();
        ControlsWindows.ToTitleCase(dataGridViewLots.Columns);
        tbNature.Text = "146";
        tbNature_Validating(null, null);
        //tbCopro.Focus();
        //this.MinimumSize = this.MaximumSize = this.Size;
        lblDiff.Visible = tbDiff.Visible =
            lblTotal.Visible = tbTotal.Visible = lblLiasse.Visible = tbMontantLiasse.Visible = false;

        btnEnter.Width = 0;
    }

    private void fillCBLiasse()
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

    private void ShowSoldeCopro()
    {
        if (coproprietaire == null)
        {
            dataGridViewLots.DataSource = OperationController.getController().getSoldeRepriseCoproprietaire("");
        }
        else
        {
            var table = OperationController.getController().getSoldeRepriseCoproprietaire(coproprietaire.id);
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

    private void EnableSaveAction()
    {
        var enable = true;

        enable &= coproprietaire != null;
        enable &= tbNature.AutoCompleteCustomSource.Contains(tbNature.Text);
        enable &= !tbMontant.Text.Equals("");

        btnAdd.Enabled = enable;

        btnSave.Enabled = dataGridViewEcriture.Rows.Count > 0;
        btnDelete.Enabled = dataGridViewEcriture.SelectedRows.Count > 0;
    }

    private void cbLiasse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!cbLiasse.Enabled) return;
        var row = (DataRowView)cbLiasse.SelectedItem;
        tbTotal.Text = row["montant"].ToString();
        tbTotal_TextChanged(null, null);

        FillDatagridEcritures();
        EnableSaveAction();
    }

    private void tbTotal_TextChanged(object sender, EventArgs e)
    {
        _ = Convertir.ToFloat(tbTotal.Text);
    }

    private void setAutoCompleteCoproprietaire()
    {
        var autoComplete = CoproprietaireController.getController().getAutoComplete("reference");
        ControlsWindows.setAutoControle(tbCopro, autoComplete);
    }

    private void lblCopro_Click(object sender, EventArgs e)
    {
        var form = new FindCoproprietaireForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbCopro.Text = form.reference;
            tbCopro_Validating(tbCopro, null);
        }
    }

    private GlobalConstantes.TypeOperation getTypeEcriture()
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
                tbLibCopro.Text = $"{coproprietaire.nom.Trim()} {coproprietaire.prenom}";
                tbEmetteur.Text = coproprietaire.nomcomp.Trim();
                if (tbEmetteur.Text == "")
                    tbEmetteur.Text = coproprietaire.nom;
                var immeuble = coproprietaire.Immeuble;
                if (immeuble != null)
                    Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";


                if (coproprietaire.huissier)
                {
                    tbCopro.BackColor = Color.Red;
                    tbLibCopro.Text = "Attention Dossier Transmis à un huissier";
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
        var form = new FindNatureForm();

        form.ShowDialog();
        if (!"".Equals(form.reference)) tbNature.Text = form.reference;
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
        saisie.libelle = tbLibelle.Text;
        saisie.emetteur = tbEmetteur.Text;
        saisie.banque = tbBanque.Text;
        return saisie;
    }

    private bool ValidateForm()
    {
        var msg = "";

        if (tbMontant.Text.Equals("")) msg += "Montant Invalide\r\n";
        if (tbNature.Text.Equals(""))
        {
            msg += "Nature Requise\r\n";
        }
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
                MessageBox.Show(@"Attention Coproprietaire non Affecté à un lot");
                return false;
            }

            immeuble = coproprietaire.Immeuble;
            if (immeuble == null) MessageBox.Show(@"Lot coproprietaire sans immeuble");
        }
        else
        {
            MessageBox.Show(@"Coproprietaire Invalide");
            return false;
        }

        var dtFac = Convert.ToDateTime(tbDate.Text);
        var exercice = ExerciceComptableController.getController().getExerciceFromDate(immeuble.id, dtFac);

        if (exercice != null)
            if (exercice.statut != (int)GlobalConstantes.StatutExercice.Ouvert)
            {
                var dr = MessageBox.Show(
                    "La date de l'opération correspond à un exercice Cloturé\r\nVoulez vous continuer", "Attention",
                    MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                    return false;
            }

        return true;
    }

    private void UpdateEcriture()
    {
        if (!ValidateForm())
            return;

        var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;

        if (rowGrid != null)
        {
            var row = rowGrid.Row;
            var trx = Database.GetInstance().BeginTransaction();
            try
            {
                var saisie = SaisieReglementController.getController().getEntiteById(row["id"].ToString());
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
                    {
                        trx.Rollback();
                    }

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
        var nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
        if (nature == null) return;

        var trx = Database.GetInstance().BeginTransaction();
        var bNewLiasse = false;
        var numero_operation = 1;
        var liasse_id = cbLiasse.SelectedValue.ToString();
        try
        {
            if (LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
            {
                var liasse = new LiasseEntite
                {
                    isNew = true,
                    montant = Convertir.ToDecimal(tbTotal.Text),
                    type_ecriture = getTypeEcriture().ToString(),
                    statut = (int)GlobalConstantes.StatutOperation.Brouillon,
                    reference = $"{BaseApplication.ComputerName} du {DateTime.Now}"
                };
                LiasseController.getController().InsertOrUpdate(liasse);
                liasse_id = liasse.id;
                bNewLiasse = true;
            }

            numero_operation = SaisieReglementController.getController()
                .getNextNumeroOperation(Convert.ToDateTime(tbDate.Text));

            var immeuble_id = "";
            var compte_banque = "";

            if (dataGridViewLots.Rows.Count > 0)
            {
                var row = (DataRowView)dataGridViewLots.Rows[0].DataBoundItem;
                immeuble_id = row["immeuble_id"].ToString();
                compte_banque = row["comptebanque"].ToString();
            }
            else
            {
                immeuble_id = lot.immeuble_id;
                compte_banque = immeuble.comptebanque;
            }

            var saisie = new SaisieReglementEntite
            {
                liasse_id = liasse_id
            };

            saisie.date_operation = saisie.date_reference = Convert.ToDateTime(tbDate.Text);
            saisie.numero_operation = numero_operation;
            saisie.immeuble_id = immeuble_id;
            saisie.comptebanque = compte_banque;
            saisie = FillSaisieFromForm(saisie);

            saisie.statut = (int)GlobalConstantes.StatutOperation.Brouillon;

            if (SaisieReglementController.getController().InsertOrUpdate(saisie))
            {
                WriteSaisieInOperation(saisie);
                trx.Commit();
            }
            else
            {
                trx.Rollback();
            }

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

    private void WriteSaisieInOperation(SaisieReglementEntite entite)
    {
        var numero_ligne = 1;

        var controller = OperationController.getController();
        foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
        {
            var row = (DataRowView)rowGrid.DataBoundItem;

            var operation = new OperationEntite
            {
                type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette)
            };
            operation.date_operation = operation.date_reference = entite.date_reference;
            operation.type_operation = nameof(GlobalConstantes.TypeOperation.Tresorerie);
            operation.numero_operation = entite.numero_operation;
            operation.numero_ligne = numero_ligne++;
            operation.saisie_id = entite.id;
            operation.coproprietaire_id = entite.coproprietaire_id;
            operation.immeuble_id = row["immeuble_id"].ToString();
            operation.liasse_id = entite.liasse_id;
            operation.lot_id = row["lot_id"].ToString();
            operation.nature_id = entite.nature_id;
            operation.base_repart = "10";
            operation.libelle = entite.libelle;
            operation.credit = Convertir.ToDecimal(rowGrid.Cells["reglement"].Value);
            operation.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            operation.global = entite.montant;
            if (!controller.InsertOrUpdate(operation)) break;
        }
    }

    private bool UpdateSaisieInOperation(SaisieReglementEntite saisie)
    {
        var allValide = true;
        var cmd = $"select * from {OperationController.getController().getSchemaTable()} ";
        cmd += " where saisie_id = @saisie_id and immeuble_id = @immeuble_id and lot_id = @lot_id";
        var controller = OperationController.getController();
        foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
        {
            var row = (DataRowView)rowGrid.DataBoundItem;

            var parameters = new List<NpgsqlParameter>
            {
                new("@saisie_id", saisie.id),
                new("@immeuble_id", row["immeuble_id"].ToString()),
                new("@lot_id", row["lot_id"].ToString())
            };
            var table = OperationController.getController().getResultSQL(cmd, parameters);
            if (table != null)
                if (table.Rows.Count > 0)
                {
                    var operation = new OperationEntite(table.Rows[0])
                    {
                        coproprietaire_id = saisie.coproprietaire_id,
                        nature_id = saisie.nature_id
                    };
                    operation.date_reference = operation.date_operation = saisie.date_reference;
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
        var source = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.Tresorerie);
        cbLiasse.DataSource = source;
        foreach (DataRow row in source.Rows)
            if (liasse_id.Equals(row["id"].ToString()))
            {
                cbLiasse.SelectedValue = liasse_id;
                break;
            }
    }

    private void FillDatagridEcritures()
    {
        bLoadEcriture = true;
        var liasse_id = cbLiasse.SelectedValue.ToString();
        var source = SaisieReglementController.getController().getGridRowSaisieReglement(liasse_id);
        dataGridViewEcriture.DataSource = source;
        dataGridViewEcriture.ClearSelection();
        if (dataGridViewLots.DataSource != null)
            dataGridViewLots.DataSource = null;
        if (source != null)
        {
            var cols = dataGridViewEcriture.Columns;
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
        foreach (DataRow row in source.Rows) current += Convertir.ToFloat(row["montant"]);

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
        var liasse_id = cbLiasse.SelectedValue.ToString();
        OperationController.getController().ValidateReglement(liasse_id);
        cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());

        var form = new ImprimerListeReglementForm();
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
            }
    }

    private void dataGridViewEcriture_SelectionChanged(object sender, EventArgs e)
    {
        if (!bLoadEcriture)
            if (dataGridViewEcriture.SelectedRows.Count > 0)
            {
                var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                if (rowGrid != null)
                {
                    var row = rowGrid.Row;
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
            {
                ClearFicheSaisie();
            }
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
        infoKey.ShowForm(this);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dataGridViewEcriture.SelectedRows.Count > 0)
        {
            var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
            var row = rowGrid?.Row;
            if (row != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Etes vous sur de vouloir annuler cet element", "Attention",
                        MessageBoxButtons.YesNo))
                    SaisieReglementController.getController().AnnuleElement(row["id"].ToString());
                FillDatagridEcritures();
            }
        }
    }
}