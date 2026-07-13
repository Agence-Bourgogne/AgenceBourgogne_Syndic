using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Fournisseur;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Impressions.Facture;
using EspaceSyndic.UtilsApp;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Ecritures;

public partial class FicheFactureForm : Form
{
    private ImmeubleEntite immeuble;
    private NatureEntite nature;
    private FournisseurEntite fournisseur;
    private AutoCompleteStringCollection baseAuto = new();
    private bool bLoadEcriture;
    private readonly InfoKeyHelpForm infoKey = new("aide_clavier_facture");
    private readonly HelpForm infoForm = new("aide_facture");
    private readonly string TitreForm;
    private AutoCompleteStringCollection lotAuto = new();
    private const string regKey = "listes\\saisie_factures";

    private readonly int stdWidth;

    private readonly int stdHeight;

    public FicheFactureForm()
    {
        InitializeComponent();
        TitreForm = Text;

        stdWidth = Width;
        stdHeight = Height;
            
        var width = (int)CommonRegistry.getRegistryValue(regKey, "width", -1);
        if (width != -1)
            Width = width;
        var height = (int)CommonRegistry.getRegistryValue(regKey, "height", -1);
        if (height != -1)
            Height = height;
    }

    protected virtual void OrderColumns()
    {
        foreach (DataGridViewColumn col in dataGridViewEcriture.Columns)
        {
            var index = (int)CommonRegistry.getRegistryValue(regKey, col.Name, -1);
            if (index != -1)
                col.DisplayIndex = index;
            var width = (int)CommonRegistry.getRegistryValue(regKey+"\\width", col.Name, -1);
            if (width != -1)
                col.Width = width;
        }
    }
        
    private void FicheFactureForm_Load(object sender, EventArgs e)
    {
        RepartitionControlsWindows.initGridRepartition(dataGridView);
        var dt = DateTime.Now;
        tbDateCreation.Text = dt.ToShortDateString();
        ParametresDB.FillComboFromParams(cbReglement, "FACTURE_REGLEMENT");
        ControlsWindows.setAutoControle(tbRefImmeuble, ImmeubleController.getController().getAutoComplete("reference"));
        ControlsWindows.setAutoControle(tbNature, NatureController.getController().getAutoComplete("reference"));
        ControlsWindows.setAutoControle(tbFournisseur, FournisseurController.getController().getAutoComplete("reference"));
        dataGridView.ScrollBars = ScrollBars.None;
        dataGridView.BackgroundColor = Color.LightGray;
        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        FillComboLiasse();
        lblDiff.Visible = tbDiff.Visible = lblTotal.Visible = tbTotal.Visible = lblLiasse.Visible = tbMontantLiasse.Visible = false;
        EnableSaveAction();
        ControlsWindows.setTooltip(tbComment, "Libellé Ecriture");
        ControlsWindows.setTooltip(tbCommentaireFournisseur, "Information Fournisseur");
        btnEnter.Width = 0;
    }
    private void FillComboLiasse()
    {
        cbLiasse.DataSource = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.Facture);
        cbLiasse.DisplayMember = "reference";
        cbLiasse.ValueMember = "id";
        cbLiasse.Enabled = true;
        cbLiasse_SelectedIndexChanged(null, null);
    }
    private void EnableSaveAction()
    {
        var enable = true;

        enable &= immeuble != null;
        enable &= nature != null;
        enable &= fournisseur != null;
        enable &= baseAuto.Contains(tbBase.Text);
        enable &= !tbMontant.Text.Equals("");
            
        btnAdd.Enabled = enable;
    }

    private void ClearFicheSaisie()
    {
        tbRefImmeuble.Text = "";
        tbNature.Text = "";
        tbLibNature.Text = "";
        tbBase.Text = "";
        tbFournisseur.Text = "";
        tbMontant.Text = "";
        tbComment.Text = "";
        tbNomFournisseur.Text = "";
        tbCommentaireFournisseur.Text = "";
        tbAdresseFournisseur.Text = "";
        tbVilleFournisseur.Text = "";
        tbCpFournisseur.Text = "";
        tbRefImmeuble_Validating(null, null);
        btnAdd.Text = "&Ajouter";
        tbLot.Text = "";
        lblLot.Visible = false;
        tbLot.Visible = false;
        tbLot.Enabled = false;
    }
    private void EnableSaisieEcriture(bool saisie)
    {
        tbRefImmeuble.Enabled = saisie;
        tbDateCreation.Enabled = saisie;
        tbFournisseur.Enabled = saisie;
        tbNature.Enabled = saisie;
        tbMontant.Enabled = saisie;
        tbBase.Enabled = immeuble != null;
        cbReglement.Enabled = saisie;
    }

    private void tbTotal_TextChanged(object sender, EventArgs e)
    {
        var total = Convertir.ToFloat(tbTotal.Text);
        EnableSaisieEcriture(total != 0);
    }
    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }
    }
    private void ShowFromRepartitionImmeuble(ImmeubleEntite immeuble)
    {
        var repartitionImmeuble = immeuble.getRepartitionImmeuble();
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
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
            infoForm.DoFormText(this, immeuble.note_repart);
        }
        else
        {
            if ( !"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            Text = TitreForm;
            tbBase.Text = "";
            tbBase.Enabled = false;
            infoForm.Hide();
        }
        EnableSaveAction();
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

    private void btnFournisseurAdd_Click(object sender, EventArgs e)
    {
        var form = new FicheFournisseurForm(false);
        form.entite = new FournisseurEntite();
        form.ShowDialog();
        if (!form.entite.id.Equals(""))
        {
            tbFournisseur.Text = form.entite.reference;
            tbFournisseur_Validating(null, null);
        }
        ControlsWindows.setAutoControle(tbFournisseur, FournisseurController.getController().getAutoComplete("reference"));
    }

    private void tbFournisseur_Validating(object sender, CancelEventArgs e)
    {
//            tbCommentaireFournisseur.Visible = tbFournisseur.Text == fournisseur_divers;

        fournisseur = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);
        if (fournisseur != null)
        {
            tbFournisseur.BackColor = Color.White;
            tbNomFournisseur.Text = fournisseur.nom;
            tbAdresseFournisseur.Text = fournisseur.adresse;
            tbVilleFournisseur.Text = fournisseur.ville;
            tbCpFournisseur.Text = fournisseur.codepostal;
            cbReglement.SelectedValue = fournisseur.reglement;
        }
        else
        {
            tbFournisseur.BackColor = tbFournisseur.Text != "" ? Color.Red : Color.White;
            tbNomFournisseur.Text = "";
            tbAdresseFournisseur.Text = "";
            tbVilleFournisseur.Text = "";
            tbCpFournisseur.Text = "";
        }
        EnableSaveAction();

    }

    private void lblNature_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbNature.Text = form.reference;
            tbNature_Validating(null, null);
        }
    }

    private void btnNatureAdd_Click(object sender, EventArgs e)
    {
        var form = new FicheNatureForm(false);
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
        EnableSaveAction();

    }

    private void cbLiasse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!cbLiasse.Enabled) return;
        var row = (DataRowView) cbLiasse.SelectedItem;
        ClearFicheSaisie();
        tbTotal.Text = row["montant"].ToString();
        tbTotal_TextChanged(null, null);
        bLoadEcriture = true;
        FillDatagridEcritures();
        dataGridViewEcriture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        bLoadEcriture = false;
    }

    private void tbBase_TextChanged(object sender, EventArgs e)
    {
        if (baseAuto.Contains(tbBase.Text))
        {
            tbBase.BackColor = Color.White;
        }
        else
        {
            tbBase.BackColor = tbBase.Text != "" ? Color.Red: Color.White;
        }
        tbLot.Visible = tbBase.Text == "80";
        lblLot.Visible = tbBase.Text == "80";
        tbLot.Enabled = tbBase.Text == "80";
        ShowOldLot();
        EnableSaveAction();
    }

    private void tbMontantFac_TextChanged(object sender, EventArgs e)
    {
        float montant = 0;
        if (!tbMontant.Text.Equals(""))
            montant = Convertir.ToFloat(tbMontant.Text);
        if ( montant == 0)
        {
            tbMontant.BackColor = tbMontant.Text != "" ? Color.Red : Color.White;
        }
        else
        {
            tbMontant.BackColor = Color.White;
        }
        EnableSaveAction();
    }
    private void selectComboLiasse(string liasse_id)
    {
        var source = LiasseController.getController().getLiasseActives(GlobalConstantes.TypeOperation.Facture);
        cbLiasse.DataSource = source;
        foreach ( DataRow row in source.Rows){
            if ( row["id"].Equals(liasse_id)){
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
            saveEcriture();
    }
    public virtual GlobalConstantes.TypeOperation getTypeEcriture()
    {
        return GlobalConstantes.TypeOperation.Facture;
    }
    private bool validateForm()
    {
        var msg = "";

        if (immeuble == null) msg += "Immeuble invalide\r\n";
        if (nature == null) msg += "Nature invalide\r\n";
        if (fournisseur == null) msg += "Fournisseur Invalide\r\n";
        if (!baseAuto.Contains(tbBase.Text)) msg += "Base invalide\r\n";
        if (tbMontant.Text.Equals("")) msg += "Montant invalide\r\n";
        if (tbComment.Text.Equals("")) msg += "Libelle Requis\r\n";
        if (tbFournisseur.Text == "999")
            if (tbCommentaireFournisseur.Text.Trim() == "")
                msg += "Information Fournisseur Requise";
        if (msg != "")
        {
            MessageBox.Show(msg);
            return false;
        }
        var dtFac = Convert.ToDateTime(tbDateCreation.Text);
        var exercice = ExerciceComptableController.getController().getExerciceFromDate(immeuble.id, dtFac);

        if (exercice != null)
        {
            if (exercice.statut != (int)GlobalConstantes.StatutExercice.Ouvert)
            {
                var dr = MessageBox.Show("La date de l'opération correspond à un exercice Cloturé\r\nVoulez vous continuer", "Attention", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                    return false;
            }
        }
        return true;
    }


    private SaisieFactureEntite FillSaisieFromForm(SaisieFactureEntite saisie)
    {
        saisie.immeuble_id = immeuble.id;
        saisie.nature_id = nature.id;
        saisie.fournisseur_id = fournisseur.id;
        saisie.montant = Convertir.ToDecimal(tbMontant.Text);
        saisie.date_reference = Convert.ToDateTime(tbDateCreation.Text);
        saisie.libelle = tbComment.Text;
        saisie.comment_fournisseur = tbCommentaireFournisseur.Text;
        saisie.base_repart = tbBase.Text;
        saisie.reglement = (int) cbReglement.SelectedValue;
        return saisie;
    }

    private void UpdateEcriture()
    {
        if (!validateForm())
            return;

        var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
        if (rowGrid != null)
        {
            var row = rowGrid.Row;
            try
            {
                var saisie = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                if (saisie != null)
                {
                    var immeuble_repart = ImmeubleRepartitionController.getController().getEntiteFromField("reference", tbBase.Text);
                    if (immeuble_repart == null) return;

                    var oldBase = saisie.base_repart;

                    if (tbBase.Text != oldBase)
                    {
                        var old_repart = ImmeubleRepartitionController.getController().getRepartFromImmeubleBase(immeuble.id, saisie.base_repart);
                        if (old_repart.type_ventilation != immeuble_repart.type_ventilation)
                        {
                            MessageBox.Show("""
                                            Vous ne pouvez pas changer de base si le type de répartition change 
                                            Vous devez supprimer l'écriture
                                            """);
                            return;
                        }
                    }
                    saisie = FillSaisieFromForm(saisie);

                    if (immeuble_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
                    {
                        if (tbBase.Text == "80")
                        {
                            SaisieFactureController.getController().UpdateSaisieAndLot(saisie, immeuble.id, tbLot.Text, Convertir.ToDecimal(tbMontant.Text));
                        }
                        else
                        {
                            var multiCpt = LotRepartitionController.getController().GetLotRepartitionHaveMultiCompteur(immeuble.id, saisie.base_repart);

                            if (ParametresDB.IsBaseCompteur(tbBase.Text) && multiCpt != null && multiCpt.Rows.Count > 0)
                            {
                                var form = new FicheFactureRepartitionIndividuelleMultiCpt();
                                form.saisie = saisie;
                                form.immeuble = immeuble;
                                form.ShowDialog();
                            }
                            else
                            {
                                var form = new FicheFactureRepartitionIndividuelle();
                                form.saisie = saisie;
                                form.immeuble = immeuble;
                                form.ShowDialog();
                            }
                        }
                    }
                    else
                        SaisieFactureController.getController().InsertOrUpdate(saisie);

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

    private void saveEcriture()
    {
        if (!validateForm())
            return;

        var liasse_id = cbLiasse.SelectedValue.ToString();
        var numero_operation = 1;
        var bNewLiasse = false;
        LiasseEntite liasse = null;
        if (LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
        {
            liasse = new LiasseEntite
            {
                isNew = true,
                montant = Convertir.ToDecimal(tbTotal.Text),
                type_ecriture = getTypeEcriture().ToString(),
                statut = (int)GlobalConstantes.StatutOperation.Brouillon,
                reference = $"{BaseApplication.ComputerName} du {DateTime.Now}"
            };
            //                LiasseController.getController().InsertOrUpdate(liasse);
            liasse_id = liasse.id = liasse.get_uuid();
            liasse.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            bNewLiasse = true;
//                selectComboLiasse(liasse.id);
        }

        numero_operation = SaisieFactureController.getController().getNextNumeroOperation(Convert.ToDateTime(tbDateCreation.Text));

        var saisie = new SaisieFactureEntite
        {
            liasse_id = liasse_id,
            numero_operation = numero_operation
        };
        saisie.date_operation = saisie.date_reference = Convert.ToDateTime(tbDateCreation.Text);
        saisie = FillSaisieFromForm(saisie);
        saisie.statut = (int)GlobalConstantes.StatutOperation.Brouillon;

        try
        {
            var immeuble_repart = ImmeubleRepartitionController.getController().getEntiteFromField("reference", tbBase.Text);
            if (immeuble_repart == null) return;
            if (immeuble_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
            {
                if (tbBase.Text == "80")
                {
                    SaisieFactureController.getController().UpdateSaisieAndLot(saisie, immeuble.id, tbLot.Text, Convertir.ToDecimal(tbMontant.Text));
                }
                else
                {
                    var multiCpt = LotRepartitionController.getController().GetLotRepartitionHaveMultiCompteur(immeuble.id, saisie.base_repart);

                    if (ParametresDB.IsBaseCompteur(tbBase.Text) && multiCpt != null && multiCpt.Rows.Count > 0)
//                        if (false)
                    {
                        var form = new FicheFactureRepartitionIndividuelleMultiCpt();
                        form.saisie = saisie;
                        form.immeuble = immeuble;

                        if (DialogResult.Cancel == form.ShowDialog())
                            bNewLiasse = false;
                    }
                    else
                    {
                        var form = new FicheFactureRepartitionIndividuelle();
                        form.saisie = saisie;
                        form.immeuble = immeuble;
                        if (DialogResult.Cancel == form.ShowDialog())
                            bNewLiasse = false;
                    }

                }
            }
            else
                SaisieFactureController.getController().InsertOrUpdate(saisie);

            if ( bNewLiasse)
                LiasseController.getController().InsertOrUpdate(liasse);

            ClearFicheSaisie();
            if (bNewLiasse)
                selectComboLiasse(liasse_id);
            FillDatagridEcritures();
            tbRefImmeuble.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        } 
    }

    private void FillDatagridEcritures()
    {
        bLoadEcriture = true;

        var liasse_id = cbLiasse.SelectedValue.ToString();
        var source = SaisieFactureController.getController().getListeFactures(liasse_id);
        dataGridViewEcriture.DataSource = source;
        dataGridViewEcriture.ClearSelection();
        if (source != null)
        {
            var cols = dataGridViewEcriture.Columns;
            cols["id"].Visible = false;
            cols["immeuble_id"].Visible = false;
            cols["fournisseur_id"].Visible = false;
            cols["comment_fournisseur"].Visible = false;
            cols["nature_id"].Visible = false;
            cols["liasse_id"].Visible = false;
            cols["reglement"].Visible = false;
            cols["date_operation"].Visible = false;

            ControlsWindows.ToTitleCase(cols);

            OrderColumns();

        }
        float current = 0;
        foreach (DataRow row in source.Rows)
        {
            current += Convertir.ToFloat(row["montant"]);
        }

        tbMontantLiasse.Text = current.ToString();
            
        if ( !"".Equals(tbTotal.Text))
        {
            double total = Convertir.ToFloat(tbTotal.Text);
            tbDiff.Text = (total - current).ToString();
        }
        btnValid.Enabled = dataGridViewEcriture.Rows.Count > 0;

        var bVisibilite = false;
        if (!LiasseEntite.NOUVELLE_ID.Equals(liasse_id))
        {
            if (dataGridViewEcriture.Rows.Count <= 0)
                bVisibilite = true;
        }
        btnDelLiasse.Visible = bVisibilite;

        bLoadEcriture = false;
    }

    private void FicheEcritureForm_Shown(object sender, EventArgs e)
    {
        tbRefImmeuble.Focus();
    }


    private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if ( dataGridViewEcriture.SelectedRows.Count < 1 ) 
            return;
        var row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
        if ( row != null )
            if ( row.Row.RowState != DataRowState.Detached )
            {
                if ( DialogResult.Yes == MessageBox.Show ( "Voulez vous réellement supprimer cette ecriture\nCette opération est irréversible", "Attention", MessageBoxButtons.YesNo))
                {
                    var facture = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                    SaisieFactureController.getController().DeleteEntite(facture);
                    //SaisieFactureController.getController().deleteEntite(row["id"].ToString());
                }

                FillDatagridEcritures();
            }
    }

    private void repartIndividuelleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridViewEcriture.SelectedRows.Count <= 0)
            return;
        var row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
        if (row != null)
            if (row.Row.RowState != DataRowState.Detached)
            {
//                    DataRowView row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                var saisie = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                var multiCpt = LotRepartitionController.getController().GetLotRepartitionHaveMultiCompteur(immeuble.id, saisie.base_repart);

                if (ParametresDB.IsBaseCompteur(tbBase.Text) && multiCpt != null && multiCpt.Rows.Count > 0)
                {
                    var form = new FicheFactureRepartitionIndividuelleMultiCpt();
                    form.saisie = saisie;
                    form.immeuble = ImmeubleController.getController().getEntiteById(row["immeuble_id"].ToString());
                    form.ShowDialog();
                }
                else
                {
                    var form = new FicheFactureRepartitionIndividuelle();
                    form.saisie = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                    form.immeuble = ImmeubleController.getController().getEntiteById(row["immeuble_id"].ToString());
                    form.ShowDialog();
                }
            }
    }

    private void btnValid_Click(object sender, EventArgs e)
    {
        var msg = "Voulez-vous valider ces factures\n";
        msg += "Cette opération est irréversible\n";

        var res = MessageBox.Show(msg, "Attention", MessageBoxButtons.YesNoCancel);
        if (res == DialogResult.Cancel)
            return;

        if (res == DialogResult.No)
            Close();

        if (res == DialogResult.Yes)
        {
            var liasse_id = cbLiasse.SelectedValue.ToString();
            OperationController.getController().ValidateFacture(liasse_id);
            cbLiasse.DataSource = LiasseController.getController().getLiasseActives(getTypeEcriture());
            var form = new ImprimerListeFacturationForm(liasse_id);
            form.ShowDialog();
        }
    }
    private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
    {

        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(null, null);
                if (sender.Equals(tbNature))
                    lblNature_Click(null, null);
                if (sender.Equals(tbFournisseur))
                    lblFournisseur_Click(null, null);
                if (sender.Equals(tbLot))
                    lblLot_Click(null, null);
            }
//            Console.WriteLine(e.KeyChar);                
    }

    private void ShowOldLot()
    {
        if (dataGridViewEcriture.SelectedRows.Count > 0)
        {
            var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
            if (rowGrid != null)
            {
                var row = rowGrid.Row;
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
                var rowGrid = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                if (rowGrid != null)
                {
                    var row = rowGrid.Row;
                    tbRefImmeuble.Text = row["ref_immeuble"].ToString();
                    tbBase.Text = row["base"].ToString();
                    tbDateCreation.Text = row["date_reference"].ToString();
                    tbNature.Text = row["ref_nature"].ToString();
                    tbFournisseur.Text = row["ref_fournisseur"].ToString();
                    tbMontant.Text = row["montant"].ToString();
                    tbComment.Text = row["libelle"].ToString();
//                        tbCommentaireFournisseur.Text = row["fournisseur"].ToString();
                    tbCommentaireFournisseur.Text = row["comment_fournisseur"].ToString();
                    tbRefImmeuble_Validating(null, null);
                    tbNature_Validating(null, null);
                    tbFournisseur_Validating(null, null);
                    cbReglement.SelectedValue = Convertir.ToInt(row["reglement"]);


                    //if (tbBase.Text == "80")
                    //{
                    //    tbLot.Text = OperationController.getController().getNumeroLotFromSaisie(row["id"].ToString());
                    //}
                    ShowOldLot();
                    btnAdd.Text = "&Modifier";
                    tbBase_TextChanged(null, null);
                }
            }
            else
                ClearFicheSaisie();

    }

    private void tbComment_KeyUp(object sender, KeyEventArgs e)
    {
        StandardFunctionnalities.Standard_KeyPress(sender, e);
    }

    private void tbDateCreation_Enter(object sender, EventArgs e)
    {
        tbDateCreation.SelectAll();
    }

    private void cbReglement_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void FicheFactureForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = false;
    }

    private void dataGridViewEcriture_DoubleClick(object sender, EventArgs e)
    {
        if (dataGridViewEcriture.SelectedRows.Count > 0)
        {
            var numbase = Convertir.ToInt(tbBase.Text);
            if ( numbase >= 81 && numbase <= 88)
            {
                var row = (DataRowView)dataGridViewEcriture.SelectedRows[0].DataBoundItem;
                var saisie = SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                var multiCpt = LotRepartitionController.getController().GetLotRepartitionHaveMultiCompteur(immeuble.id, saisie.base_repart);

                if (ParametresDB.IsBaseCompteur(tbBase.Text) && multiCpt != null && multiCpt.Rows.Count > 0)
                {
                    var form = new FicheFactureRepartitionIndividuelleMultiCpt();
                    form.saisie = saisie;
                    form.immeuble = ImmeubleController.getController().getEntiteById(row["immeuble_id"].ToString());
                    form.ShowDialog();

                }
                else
                {
                    var form = new FicheFactureRepartitionIndividuelle();
                    form.saisie = saisie; //SaisieFactureController.getController().getEntiteById(row["id"].ToString());
                    form.immeuble = ImmeubleController.getController().getEntiteById(row["immeuble_id"].ToString());
                    form.ShowDialog();

                }
            }
        }
    }

    private void btnHelp_Click(object sender, EventArgs e)
    {
        if (!infoKey.Visible)
            infoKey.ShowForm(this);
        else
            infoKey.Close();
        Activate();
    }

    private void btnRepart_Click(object sender, EventArgs e)
    {
        if (!infoForm.Visible)
            infoForm.ShowForm(this);
        else
            infoForm.Close();
        Activate();
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        supprimerToolStripMenuItem_Click(null, null);
    }

    private void lblLot_Click(object sender, EventArgs e)
    {
        var form = new FindLotCoproprietaireImmeubleForm();
        form.immeuble = immeuble;
        form.ShowDialog();
        if (form.reference != "")
        {
            tbLot.Text = form.reference;
        }
    }

    private void enregistrerLaPrésentationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (regKey != "")
        {
            CommonRegistry.setRegistryValue(regKey, "width", Width);
            CommonRegistry.setRegistryValue(regKey, "height", Height);

            foreach (DataGridViewColumn col in dataGridViewEcriture.Columns)
            {
                CommonRegistry.setRegistryValue(regKey, col.Name, col.DisplayIndex);
                CommonRegistry.setRegistryValue(regKey + "\\width", col.Name, col.Width);
            }
        }
    }

    private void présentationParDéfautToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (regKey != "")
        {
            CommonRegistry.deleteRegistry(regKey);
            Height = stdHeight;
            Width = stdWidth;
            CenterToParent();
            FillDatagridEcritures();
        }
    }

    private void RowMenu_Opening(object sender, CancelEventArgs e)
    {
        if (dataGridViewEcriture.SelectedRows.Count > 0)
        {
            var numbase = Convertir.ToInt(tbBase.Text);
            if ( numbase >= 81 && numbase <= 88)
                repartIndividuelleToolStripMenuItem.Enabled = true;
            else
                repartIndividuelleToolStripMenuItem.Enabled = false;
        }
        else
        {
            supprimerToolStripMenuItem.Enabled = false;
            repartIndividuelleToolStripMenuItem.Enabled = false;
        }
    }

    private void btnDelLiasse_Click(object sender, EventArgs e)
    {
        var liasse_id = cbLiasse.SelectedValue.ToString();
        var liasse = LiasseController.getController().getEntiteById(liasse_id);
        if ( liasse != null )
        {
            liasse.statut = (int) GlobalConstantes.StatutData.Supprime;
            LiasseController.getController().InsertOrUpdate(liasse);
            FillComboLiasse();
        }
    }

}