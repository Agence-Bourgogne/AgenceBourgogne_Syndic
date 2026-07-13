using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using SyndicData.Controller;
using SyndicData.Entites;
using EspaceSyndic.Formulaires.Immeubles;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Common;
using EspaceSyndic.Formulaires.OperationsGestion;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Budget;

namespace EspaceSyndic.Formulaires.Exercice
{
    public partial class ClotureExerciceForm : Form
    {
        ImmeubleEntite immeuble;
        ExerciceComptableEntite exercice;
        string TitreForm;
        HelpForm TotauxForm = new HelpForm("TotauxCloture");

        public ClotureExerciceForm()
        {
            InitializeComponent();
            TitreForm = Text;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void ClotureExerciceForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
            cbTypeOpe.SelectedIndex = 0;
            btnEnter.Width = 0;
            dtFin.Enabled = false;
            btnCloture.Enabled = btnExercice.Enabled = exercice != null;
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            tbRefImmeuble.BackColor = Color.White;
            tbNom.Text = tbAdresse.Text = "";
            if (immeuble != null)
            {
                tbNom.Text = immeuble.nom;
                tbAdresse.Text = immeuble.Adresse;
                exercice = immeuble.ExerciceCourant;
                if ( exercice != null )
                {
                    dtDeb.Value = exercice.date_fin.AddDays(1);
                    dtFin.Value = dtDeb.Value.AddYears(1).AddDays(-1);
                }
                var datDeb = dtDeb.Value.AddYears(-1);
                var datFin = dtDeb.Value.AddDays(-1);
                Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";

                var valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                tbSolde.Text = valueSoldeImm.ToString();
            }
            else
            {
                if (tbRefImmeuble.Text != "")
                    tbRefImmeuble.BackColor = Color.Red;
                Text = TitreForm;
                dataGridView.DataSource = null;
            }

            btnCloture.Enabled = btnExercice.Enabled = immeuble != null;
            FillDataGrid();
            btnDetail.Enabled = dataGridView.SelectedRows.Count > 0;
        }
        private void FillDataGrid()
        {
            if (tbRefImmeuble.Text == "")
                return;
            if (/*immeuble != null & */cbTypeOpe.SelectedIndex >= 0)
            {
                switch (cbTypeOpe.SelectedIndex)
                {
                    case 0:
                        //regKey = "listes\\factures";
                        FillFromFacture();
                        break;
                    case 1:
                        //regKey = "listes\\appels";
                        FillFromAppelsDeFond();
                        break;
                    case 2:
                        //regKey = "listes\\reglements";
                        FillFromReglements();
                        break;
                    case 3:
                        if (immeuble != null)
                        {
                            FillFromOperations("");
                        }
                        else
                            dataGridView.DataSource = null;
                        break;
                    case 4:
                        if (immeuble != null)
                        {
                            FillFromOperations(nameof(GlobalConstantes.TypeMouvement.Depense));
                        }
                        else
                            dataGridView.DataSource = null;
                        break;
                    case 5:
                        if (immeuble != null)
                        {
                            FillFromOperations(nameof(GlobalConstantes.TypeMouvement.Recette));
                        }
                        else
                            dataGridView.DataSource = null;
                        break;
                }
            }
            var datDeb = dtDeb.Value.AddYears(-1);
            var datFin = dtDeb.Value.AddDays(-1);

            if ( immeuble != null )
            {
                var total_facture = SaisieFactureController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
//                decimal total_appels = SaisieAppelFondController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                var total_reglements = SaisieReglementController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                var soldeReprise = SaisieFactureController.getController().getSoldeAnterieurImmeuble(immeuble.id, datDeb, datFin);
                var valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                var depenseOperation = OperationController.getController().getOperationDepense(immeuble.id, datDeb, datFin, "");
                var strTotaux = $"Factures: \t\t {total_facture}\r\n";
                strTotaux += $"Règlements: \t\t {total_reglements}\r\n";

                strTotaux += "\r\n";
                strTotaux += $"Operations Depenses: \t {depenseOperation}\r\n";
//                strTotaux += String.Format("Operations Reglements: \t {0}\r\n", reglementOperation);

                strTotaux += "\r\n";
                strTotaux += $"Solde Antérieur: \t {soldeReprise}\r\n";
                strTotaux += $"Solde Exercice: \t\t {valueSoldeImm}\r\n";
                //strTotaux += String.Format("Opération Débit: \t {0}\r\n", total_operations[0]);
                //strTotaux += String.Format("Opération Crédit: \t {0}\r\n", total_operations[1]);
                //strTotaux += String.Format("Débit - Crédit: \t\t {0}", total_operations[0] - total_operations[1]);

                TotauxForm.DoFormText(this, strTotaux);
                TotauxForm.Text = "Totaux";
                TotauxForm.ShowForm(this);
                Activate();

//                decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                tbSolde.Text = valueSoldeImm.ToString();
            }

        }

        bool bLoading = false;
        private void FillFromFacture()
        {
            bLoading = true;
            var datDeb = dtDeb.Value.AddYears(-1);
            var datFin = dtDeb.Value.AddDays(-1);
            
            var sortedCol = dataGridView.SortedColumn;
            var sortOrder = dataGridView.SortOrder;


            dataGridView.DataSource = SaisieFactureController.getController().getListeOperations(tbRefImmeuble.Text, "", datDeb, datFin, "", "", "", true, "");
            var cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);

            cols["base_repart"].Width = 40;
            cols["ref_nature"].Width = 40;
            cols["ref_fourn"].Width = 40;
            cols["nature"].Visible = false;
            cols["fournisseur"].MinimumWidth = 120;
            cols["libelle"].MinimumWidth = 160;
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["ref_immeuble"].Visible = false;
            if (sortOrder == SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

            if (sortedCol == null)
                dataGridView.Sort(cols["date_reference"], ListSortDirection.Ascending);
            ShowMontant();
            //setRowIndicators();
            //OrderColumns();
            bLoading = false;
        }
        private void ShowMontant()
        {
            var nature = ParametresDB.getParam1("NATURE", "SOLDE BILAN");
            
            lblMontant.Text = "Total";
            tbCredit.Visible = lblCredit.Visible = false;
            Decimal total = 0;

            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                var row = (DataRowView)rowGrid.DataBoundItem;
                if ( nature != row["ref_nature"].ToString() )
                    total += Convertir.ToDecimal(row["montant"]);
            }
            tbMontant.Text = total.ToString();
        }
        private void ShowDebitCredit()
        {
            var nature = ParametresDB.getParam1("NATURE", "SOLDE BILAN");
            lblMontant.Text = "Débit";
            tbCredit.Visible = lblCredit.Visible = true;
            Decimal debit = 0, credit = 0 ;
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                var row = (DataRowView)rowGrid.DataBoundItem;
                if (nature != row["ref_nature"].ToString())
                {
                    debit += Convertir.ToDecimal(row["debit"]);
                    credit += Convertir.ToDecimal(row["credit"]);
                }
            }
            tbMontant.Text = debit.ToString();
            tbCredit.Text = credit.ToString();
        }
        private void FillFromAppelsDeFond()
        {
            bLoading = true;
            var datDeb = dtDeb.Value.AddYears(-1);
            var datFin = dtDeb.Value.AddDays(-1);

            var sortedCol = dataGridView.SortedColumn;
            var sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = SaisieAppelFondController.getController().getListeOperations(tbRefImmeuble.Text, datDeb, datFin, "", "", true, "");
            var cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["liasse_id"].Visible = false;

            if (sortOrder == SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);
            if (sortedCol == null)
                dataGridView.Sort(cols["date_reference"], ListSortDirection.Ascending);

            ShowMontant();
            //setRowIndicators();
            //OrderColumns();
            bLoading = false;
        }
        private void FillFromReglements()
        {
            bLoading = true;
            var datDeb = dtDeb.Value.AddYears(-1);
            var datFin = dtDeb.Value.AddDays(-1);

            var sortedCol = dataGridView.SortedColumn;
            var sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = SaisieReglementController.getController().getListeOperations(tbRefImmeuble.Text, "", datDeb, datFin, "", "", "", true);
            var cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;

            if (sortOrder == SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);

            if (sortedCol == null)
                dataGridView.Sort(cols["date_reference"], ListSortDirection.Ascending);

            ShowMontant();
            //setRowIndicators();
            //OrderColumns();
            bLoading = false;
        }
        private void FillFromOperations(string type)
        {
            bLoading = true;
            var datDeb = dtDeb.Value.AddYears(-1);
            var datFin = dtDeb.Value.AddDays(-1);

            var sortedCol = dataGridView.SortedColumn;
            var sortOrder = dataGridView.SortOrder;

            dataGridView.DataSource = OperationController.getController().getListeOperations(immeuble.id, "", type, (int)GlobalConstantes.StatutOperation.Valide, datDeb, datFin, "", "");
            var cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["base_repart"].Width = 20;
            cols["ref_nature"].Width = 40;
            cols["date_relance"].Width = 50;
            cols["ref_copro"].Width = 50;
            cols["debit"].Width = 50;
            cols["credit"].Width = 50;
            cols["nature"].Visible = false;
            cols["global"].Width = 50;
            cols["date_relance"].Visible = false;

            if (sortOrder == SortOrder.Ascending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Ascending);
            if (sortOrder == SortOrder.Descending)
                dataGridView.Sort(cols[sortedCol.Name], ListSortDirection.Descending);
            if (sortedCol == null)
                dataGridView.Sort(cols["date_reference"], ListSortDirection.Ascending);

            ShowDebitCredit();
            //setRowIndicators();
            //OrderColumns();
            bLoading = false;
        }

        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void cbTypeOpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnCloture_Click(object sender, EventArgs e)
        {

            var exercice_id = exercice.id;

            if (DialogResult.Yes != MessageBox.Show("Cette opération est irreversible\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
            {
                return;
            }

            if (exercice_id != "")
            {
                nature = getNatureCloture();
                var fournisseur = getFournisseurCloture();
                var libelle = ParametresDB.getParam1("CLOTURE", "LIBELLE OPERATION");

                var currExercice = exercice;
                var cnx = Database.GetInstance();
                var trx = cnx.BeginTransaction();
                try
                {
                    // TODO Voir pour TimestampServer
                    var exercice_suivant = ExerciceComptableController.getController().createExerciceSuivant(exercice);
                    if ( exercice_suivant != null )
                    {
                        var soldeImm = SaisieFactureController.getController().getCurrentSoldeImmeuble(exercice_suivant.immeuble_id, exercice_suivant.date_deb, exercice_suivant.date_fin);

                        if (soldeImm.Rows.Count <= 0)
                        {
                            var valueSoldeImm = OperationController.getController().getSoldeImmeuble(currExercice.immeuble_id, currExercice.date_deb, currExercice.date_fin);
                            //Console.WriteLine(" Solde immeuble : {0}", valueSoldeImm);
                            var liasse = createLiasseReprise(valueSoldeImm);

                            var facture = createFactureReprise(liasse, exercice_suivant.date_deb, valueSoldeImm);
                            facture.fournisseur_id = fournisseur.id;
                            facture.immeuble_id = currExercice.immeuble_id;
                            if (!SaisieFactureController.getController().InsertOrUpdate(facture))
                                throw new Exception("Creation Facture");

                            var repart = LotDescriptionController.getController().getListeLot(immeuble.id);
                            var numero_ligne = 0;
                            foreach (DataRow row in repart.Rows)
                            {
                                var repimm = new LotDescriptionEntite(row);
                                if (repimm.statut == (int)GlobalConstantes.StatutData.Supprime || repimm.coproprietaire_id == "")
                                    //if (repimm.statut != (int)GlobalConstantes.StatutData.Actif || repimm.coproprietaire_id == "")
                                {
                                    Console.WriteLine("{0}", repimm.numero_lot);
                                    continue;
                                }

                                var soldeCopro = OperationController.getController().getSoldeImmeuble(immeuble.id, currExercice.date_deb, currExercice.date_fin, repimm.coproprietaire_id);
                                var operation = new OperationEntite(facture);
                                operation.numero_ligne = numero_ligne++;
                                operation.coproprietaire_id = repimm.coproprietaire_id;
                                operation.lot_id = repimm.id;
                                operation.libelle = libelle;
                                operation.type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette);
                                operation.type_operation = nameof(GlobalConstantes.TypeOperation.SoldeBilan);
                                if (soldeCopro <= 0)
                                    operation.debit = Math.Abs(soldeCopro);
                                else
                                    operation.credit = Math.Abs(soldeCopro);
                                operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
                                if (!OperationController.getController().InsertOrUpdate(operation))
                                    throw new Exception("Creation Operation");
                            }
                        }

                        if (!SaisieFactureController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime))
                            throw new Exception("Cloture Facture");
                        if (!SaisieAppelFondController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime))
                            throw new Exception("Cloture Facture");
                        if (!SaisieReglementController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime))
                            throw new Exception("Cloture Facture");
                        if (!OperationController.getController().ChangeEtat(immeuble.id, currExercice.date_deb, currExercice.date_fin, (int)GlobalConstantes.StatutOperation.Cloture, (int)GlobalConstantes.StatutOperation.Supprime))
                            throw new Exception("Cloture Facture");

                        currExercice.statut = (int)GlobalConstantes.StatutExercice.Clos;
                        if (!ExerciceComptableController.getController().InsertOrUpdate(currExercice))
                            throw new Exception("Statut exercice");
                        trx.Commit();
                        tbRefImmeuble_Validating(null, null);
                    }
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private LiasseEntite createLiasseReprise(decimal valueSoldeImm)
        {
            var liasse = new LiasseEntite();
            //liasse.id = liasse.get_uuid();
            liasse.isNew = true;
            liasse.montant = valueSoldeImm;
            liasse.type_ecriture = nameof(GlobalConstantes.TypeOperation.Facture);
            liasse.statut = (int)GlobalConstantes.StatutOperation.Valide;
            liasse.reference = $"{BaseApplication.ComputerName} du {DateTime.Now}";
            if (!LiasseController.getController().InsertOrUpdate(liasse))
                throw new Exception("Creation Liasse");
            return liasse;
        }
        NatureEntite nature;
        private SaisieFactureEntite createFactureReprise(LiasseEntite liasse, DateTime dateDeb, decimal valueSoldeImm)
        {
            var facture = new SaisieFactureEntite();

            facture.base_repart = "0";
            facture.date_operation = facture.date_reference = dateDeb;
            facture.numero_operation = 1;
            facture.nature_id = nature.id;
            facture.liasse_id = liasse.id;
            facture.montant = valueSoldeImm;
            facture.libelle = ParametresDB.getParam1("CLOTURE", "LIBELLE FACTURE");
            facture.statut = (int)GlobalConstantes.StatutOperation.Valide;
            return facture;
        }
        private FournisseurEntite getFournisseurCloture()
        {
            var reference = ParametresDB.getParam1("CLOTURE", "FOURNISSEUR");
            return FournisseurController.getController().getEntiteFromField("reference", reference);
        }
        private NatureEntite getNatureCloture()
        {
            var reference = ParametresDB.getParam1("CLOTURE", "NATURE");
            return NatureController.getController().getEntiteFromField("reference", reference);
        }

        private void dtDeb_ValueChanged(object sender, EventArgs e)
        {
            dtFin.Value = dtDeb.Value.AddYears(1).AddDays(-1);
            //Console.WriteLine(dtFin.Value);
        }
        private void EditionOperation()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                Form form = null;
                switch (cbTypeOpe.SelectedIndex)
                {
                    case 2:
                        form = new DetailReglementForm(row["id"].ToString());
                        break;
                    case 1:
                        form = new DetailAppelDeFondForm(row["id"].ToString());
                        break;
                    case 0:
                        form = new DetailFactureForm(row["id"].ToString());
                        break;
                }
                if (form != null)
                {
                    form.ShowDialog();
                    FillDataGrid();
                }
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
                EditionOperation();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var colsToHide = new List<string>{"id", "statut"};
            BaseApplication.DataGridToExcel( dataGridView, colsToHide);
        }

        private void btnExercice_Click(object sender, EventArgs e)
        {
            var form = new ReferenceExerciceForm(immeuble);
            form.ShowDialog();
            tbRefImmeuble_Validating(null, null);
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            var form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Validating(tbRefImmeuble, null);
            }
        }
        private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!bLoading)
                if (ModifierKeys == Keys.Control)
                    if (e.KeyChar == ' ')
                    {
                        e.Handled = true;
                        if (sender.Equals(tbRefImmeuble))
                            lblImmeuble_Click(sender, null);
                    }
        }

        private void btnNouvelExerciceAdd_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            if ((int)CommonRegistry.getRegistryValue("", "", 0) == 0)
            {
                var form = new NouvelExerciceOnlyForm(immeuble.id);
                form.ShowDialog();
            }
            else
            {
                var form = new NouvelExerciceForm(immeuble.id);
                form.ShowDialog();
            }
//            FillComboExercice();
        }

    }
}
