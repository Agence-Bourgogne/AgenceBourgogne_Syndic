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
using EspaceSyndic.Formulaires.Nature;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Common;


namespace EspaceSyndic.Formulaires.Budget
{
    public partial class SaisieBudgetForm : Form
    {
        ImmeubleEntite immeuble;
        NatureEntite nature;

        public SaisieBudgetForm()
        {
            InitializeComponent();
        }
        private void SaisieBudgetForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            btnExerciceAdd.Enabled = false;
            btnPrint.Enabled = false;
            btnPrint.Enabled = false;
            FillDataGridViewExercice();
            btnExerciceAdd.Visible = false;
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
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            if (!tbRefImmeuble.Enabled)
                return;
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
               tbRefImmeuble.BackColor = Color.White;
               FillDataGridViewExercice();
               btnExerciceAdd.Enabled = true;
               tbBase.Enabled = true;
            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                btnExerciceAdd.Enabled = false;
                tbBase.Text = "";
                tbBase.Enabled = false;
            }
        }
        bool bLoaded;
        private void FillDataGridViewExercice(string exercice_id = "")
        {
            bLoaded = false;

            // TODO Meme Présentation que l'impression

            DataTable exercices = ExerciceComptableController.getController().getListExerciceFromImmeuble(immeuble != null ? immeuble.id:"");
            dataGridViewExercice.DataSource = exercices;
            bLoaded = true;

            if (exercices != null)
            {
                DataGridViewColumnCollection cols = dataGridViewExercice.Columns;
                cols["budget_id"].Visible= false;
                if (cols["id"] != null)
                    cols["id"].Visible = false;

                ControlsWindows.ToTitleCase(cols);
                FillDataGridViewBudget();
            }
        }

        private string getBudgetExerciceSelected()
        {
            string budget_id = "";

            if ( dataGridViewExercice.SelectedRows.Count > 0 )
            {
                DataRowView row = (DataRowView)dataGridViewExercice.SelectedRows[0].DataBoundItem;
                budget_id = row["budget_id"].ToString();
            }
            return budget_id;
        }
        private string getExerciceSelected()
        {
            string exercice_id = "";

            if (dataGridViewExercice.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridViewExercice.SelectedRows[0].DataBoundItem;
                exercice_id = row["id"].ToString();
                if (bLoaded)
                {
                    //decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble.id, (DateTime)row["date_deb"], (DateTime)row["date_fin"]);
                }
            }
            return exercice_id;
        }
        private void btnExerciceAdd_Click(object sender, EventArgs e)
        {
            NouvelExerciceForm form = new NouvelExerciceForm(immeuble.id);
            form.exercice_id = getExerciceSelected(); ;
            form.ShowDialog();
            if ( form.exercice_id != "")
            {
                FillDataGridViewExercice(form.exercice_id);
                dataGridViewExercice_SelectionChanged(null, null);
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void FillDataGridViewBudget()
        {
            if (!bLoaded)
                return;
            dataGridViewBudget.DataSource = "";
            if (immeuble == null)
                return;
            dataGridViewBudget.DataSource = BudgetController.getController().getViewBudgets(immeuble.id, getExerciceSelected());

            DataGridViewColumnCollection cols = dataGridViewBudget.Columns;
            cols["nature"].MinimumWidth = 160;
            if (cols["id"] != null)
                cols["id"].Visible = false;
            cols["prevu_suivant"].HeaderText = "Prevu N+1";
            cols["prevu_suivant_1"].HeaderText = "Prevu N+2";
            ControlsWindows.ToTitleCase(cols);
            dataGridViewBudget.ClearSelection();
        }
        private void dataGridViewBudget_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBudget.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView) dataGridViewBudget.SelectedRows[0].DataBoundItem;
//                Console.WriteLine(row);
                tbBase.Text = row["base"].ToString();
                tbNature.Text = row["compte"].ToString();
                tbMontant.Text = row["prevu"].ToString();
                btnAdd.Text = "&Modifier";
                btnDel.Enabled = true;
            }
            else
            {
                tbBase.Text = "";
                tbMontant.Text = "";
                tbNature.Text = "";
                btnAdd.Text = "&Ajouter";
                btnDel.Enabled = false;
            }
            tbNature_Validating(null, null);
        }


        private string CreateBudget()
        {
            String id = "";

            string exercice_id = getExerciceSelected();
            BudgetEntite budget = BudgetController.getController().getEntiteFromField("exercice_id", exercice_id);
            if (budget == null)
            {
                ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
                if ( exercice != null )
                {
                    budget = new BudgetEntite();
                    budget.exercice_id = exercice_id;
                    budget.statut = (int) GlobalConstantes.StatutBudget.Brouillard;
                    budget.reference = exercice.reference;
                    if (BudgetController.getController().InsertOrUpdate(budget))
                        id = budget.id;
                }
            }
            else
                id = budget.id;
            return id;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbBase.Text == "") return;
            if (tbNature.Text == "") return;
            if (tbMontant.Text == "") return;

            BudgetLigneEntite budgetLine = new BudgetLigneEntite();

            if (dataGridViewBudget.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView) dataGridViewBudget.SelectedRows[0].DataBoundItem;
                if (row["id"].ToString() != "")
                    budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());
            }
            else
            {
                budgetLine.budget_id = getBudgetExerciceSelected();
                budgetLine.statut = (int) GlobalConstantes.StatutBudget.Brouillard;
            }
            if (budgetLine.budget_id == "" || budgetLine.budget_id == null)
            {
                budgetLine.budget_id = CreateBudget();
            }

            budgetLine.base_repart = tbBase.Text;
            budgetLine.nature_id = nature.id;
            budgetLine.montant = Convertir.ToDecimal(tbMontant.Text);
            try
            {
                BudgetLigneController.getController().InsertOrUpdate(budgetLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FillDataGridViewBudget();
        }

        private void tbBase_Validating(object sender, CancelEventArgs e)
        {
            //if (baseAuto.Contains(tbBase.Text))
            //{
            //    tbBase.BackColor = Color.White;
            //}
            //else
            //{
            //    tbBase.BackColor = tbBase.Text != "" ? Color.Red : Color.White;
            //}
        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("reference", tbNature.Text)
            }; 

            nature = NatureController.getController().getEntite("where reference = @reference and budgetisable=true", parameters);
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

        private void lblNature_Click(object sender, EventArgs e)
        {
            FindNatureForm form = new FindNatureForm();
            form.filter = "budgetisable = true";
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbNature.Text = form.reference;
                tbNature_Validating(null, null);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewBudget.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridViewBudget.SelectedRows[0].DataBoundItem;
                BudgetLigneEntite budgetLine = BudgetLigneController.getController().getEntiteById(row["id"].ToString());

                if (budgetLine != null)
                {
                    budgetLine.statut = (int) GlobalConstantes.StatutBudget.Supprime;
                    BudgetLigneController.getController().InsertOrUpdate(budgetLine);
                    FillDataGridViewBudget();
                    tbRefImmeuble.Enabled = false;
                    tbRefImmeuble.Enabled = true;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Impressions.Budget.ImprimerBudgetForm form = new Impressions.Budget.ImprimerBudgetForm(immeuble, getExerciceSelected());
            form.ShowDialog();
        }

        private void dataGridViewExercice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

            try
            {
                if (col.Name == "statut_budget")
                    if ( dgv[e.ColumnIndex, e.RowIndex].Value.ToString() != "" )
                    {
                        GlobalConstantes.StatutBudget statut = (GlobalConstantes.StatutBudget)dgv[e.ColumnIndex, e.RowIndex].Value;
                        e.Value = statut.ToString().Replace("_", " ");
                        e.FormattingApplied = true;
                    }
                if (col.Name == "statut")
                    if (dgv[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                    {
                        GlobalConstantes.StatutExercice statut = (GlobalConstantes.StatutExercice)dgv[e.ColumnIndex, e.RowIndex].Value;
                        e.Value = statut.ToString().Replace("_", " ");
                        e.FormattingApplied = true;
                    }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridViewExercice_SelectionChanged(object sender, EventArgs e)
        {
            if ( bLoaded )
                FillDataGridViewBudget();
            btnPrint.Enabled = getExerciceSelected() != "";
            btnAdd.Enabled = getExerciceSelected() != "";
        }

        private LiasseEntite createLiasseReprise(decimal valueSoldeImm)
        {
            LiasseEntite liasse = new LiasseEntite();
            //liasse.id = liasse.get_uuid();
            liasse.isNew = true;
            liasse.montant = valueSoldeImm;
            liasse.type_ecriture = GlobalConstantes.TypeOperation.Facture.ToString();
            liasse.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            liasse.reference = String.Format("{0} du {1}", BaseApplication.ComputerName, DateTime.Now);
            if (!LiasseController.getController().InsertOrUpdate(liasse))
                throw new Exception("Creation Liasse");
            return liasse;
        }
        private SaisieFactureEntite createFactureReprise(LiasseEntite liasse, DateTime dateDeb, decimal valueSoldeImm)
        {
            SaisieFactureEntite facture = new SaisieFactureEntite();

            facture.base_repart = "0";
            facture.date_operation = facture.date_reference = dateDeb;
            facture.numero_operation = 1;
            facture.nature_id = nature.id;
            facture.liasse_id = liasse.id;
            facture.montant = valueSoldeImm;
            facture.libelle = ParametresDB.getParam1("CLOTURE", "LIBELLE FACTURE");
            //facture.libelle = "SOLDE DE COPROPRIETE";
            facture.statut = (int)GlobalConstantes.StatutOperation.Valide;

            return facture;
        }
        private FournisseurEntite getFournisseurCloture()
        {
            string reference = ParametresDB.getParam1("CLOTURE", "FOURNISSEUR");
            return FournisseurController.getController().getEntiteFromField("reference", reference);
        }
        private NatureEntite getNatureCloture()
        {
            string reference = ParametresDB.getParam1("CLOTURE", "NATURE");
            return NatureController.getController().getEntiteFromField("reference", reference);
        }
        private void cloturerExerciceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exercice_id = getExerciceSelected();
            if ( exercice_id != "" )
            {
                nature = getNatureCloture();
                FournisseurEntite fournisseur = getFournisseurCloture();
                String libelle = ParametresDB.getParam1("CLOTURE","LIBELLE OPERATION");

//                LiasseEntite liasse = 
                ExerciceComptableEntite currExercice = ExerciceComptableController.getController().getEntiteById(exercice_id);
                DataTable exercice_suivant = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
                if ( exercice_suivant.Rows.Count <= 0 )
                {
                    dataGridViewExercice.ClearSelection();

                    btnExerciceAdd_Click(null, null);
                    exercice_suivant = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
                }
                NpgsqlConnection cnx = Database.GetInstance();
                NpgsqlTransaction trx = cnx.BeginTransaction();
                try
                {
                    // TODO Voir pour TimestampServer
                    // TODO Revoir la gestion exception
                    if (exercice_suivant != null && exercice_suivant.Rows.Count > 0 )
                    {
                        ExerciceComptableEntite exerciceSuivantEntite = new ExerciceComptableEntite( exercice_suivant.Rows[0]);
                        DataTable soldeImm = SaisieFactureController.getController().getCurrentSoldeImmeuble(exerciceSuivantEntite.immeuble_id, exerciceSuivantEntite.date_deb, exerciceSuivantEntite.date_fin  );

                        if ( soldeImm.Rows.Count <= 0 )
                        {
                            decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(currExercice.immeuble_id, currExercice.date_deb, currExercice.date_fin);
                            LiasseEntite liasse = createLiasseReprise(valueSoldeImm);

                            SaisieFactureEntite facture = createFactureReprise(liasse, exerciceSuivantEntite.date_deb, valueSoldeImm);
                            facture.fournisseur_id = fournisseur.id;
                            facture.immeuble_id = currExercice.immeuble_id;
                            if (!SaisieFactureController.getController().InsertOrUpdate(facture))
                                throw new Exception("Creation Facture");

                            DataTable repart = LotDescriptionController.getController().getListeLot(immeuble.id);
                            int numero_ligne = 0;
                            foreach (DataRow row in repart.Rows)
                            {
                                LotDescriptionEntite repimm = new LotDescriptionEntite(row);
                                decimal soldeCopro = OperationController.getController().getSoldeImmeuble(immeuble.id, currExercice.date_deb, currExercice.date_fin, repimm.coproprietaire_id);
                                OperationEntite operation = new OperationEntite(facture);
                                operation.numero_ligne = numero_ligne++;
                                operation.coproprietaire_id = repimm.coproprietaire_id;
                                operation.lot_id = repimm.id;
                                operation.libelle = libelle;//"SOLDE BILAN";
                                operation.type_mouvement = GlobalConstantes.TypeMouvement.Recette.ToString();
                                operation.type_operation = GlobalConstantes.TypeOperation.SoldeBilan.ToString();
                                if (soldeCopro <= 0)
                                    operation.debit = soldeCopro;
                                else
                                    operation.credit = soldeCopro;
                                operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
                                if ( !OperationController.getController().InsertOrUpdate(operation))
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
                    }
                    trx.Commit();
                    tbRefImmeuble_Validating(null, null);
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void budget_a_VoterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string budget_id = getBudgetExerciceSelected();
            BudgetController.getController().UpdateStatus(budget_id, GlobalConstantes.StatutBudget.A_Voter);
            FillDataGridViewExercice();
        }

        private void budgetApprouveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string budget_id = getBudgetExerciceSelected();
            BudgetController.getController().UpdateStatus(budget_id, GlobalConstantes.StatutBudget.Approuve);
            FillDataGridViewExercice();
        }

        private void nouvelExerciceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NouvelExerciceForm form = new NouvelExerciceForm(immeuble.id);
            form.exercice_id = "";
            form.ShowDialog();
            if (form.exercice_id != "")
            {
                FillDataGridViewExercice(form.exercice_id);
                dataGridViewExercice_SelectionChanged(null, null);
            }
        }

        private void modifierExerciceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NouvelExerciceForm form = new NouvelExerciceForm(immeuble.id);
            form.exercice_id = getExerciceSelected(); 
            form.ShowDialog();
            if (form.exercice_id != "")
            {
                FillDataGridViewExercice(form.exercice_id);
                dataGridViewExercice_SelectionChanged(null, null);
            }
        }

        private void dataGridViewBudget_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Console.WriteLine(e.ColumnIndex);
            if ( e.ColumnIndex > 2 )
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewColumn col = dgv.Columns[e.ColumnIndex];
                if (e.Value.ToString() == "0")
                    e.Value = "";
            }
        }
    }
}
