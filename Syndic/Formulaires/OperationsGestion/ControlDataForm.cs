using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using CommonProjectsPartners.Common;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Exercice;
using System.IO;
using System.Diagnostics;
namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class ControlDataForm : Form
    {
        HelpForm TotauxForm = new HelpForm("ControlTotauxCloture");
        string TitreForm;
        public ControlDataForm()
        {
            InitializeComponent();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        void fillDataGrid()
        {
            if (tbRefImmeuble.Text != "")
            {
                switch (cbType.SelectedIndex)
                {
                    case 0:
                        ControlFactures();
                        break;
                    case 1:
                        ControlReglements();
                        break;
                    case 2:
                        ControlAppelDeFond();
                        break;
                    case 3:
                        ControlOperationsFactures();
                        break;
                    case 4:
                        ControlOperationsReglements();
                        break;
                    case 5:
                        ControlOperationsAppelDeFond();
                        break;
                }
            }
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
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                FillComboExercice();
            }
            else
                this.Text = TitreForm;
        }

        private void FillComboExercice()
        {
            if (immeuble == null)
                return;
            DataTable exercices = ExerciceComptableController.getController().getListExerciceFromImmeuble(immeuble.id );
            cbExercice.DataSource = exercices;

            cbExercice.DisplayMember = "reference";
            cbExercice.ValueMember = "e.id";
            if (immeuble != null)
            {
                ExerciceComptableEntite exercice = ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
                cbExercice.SelectedValue = exercice.id;
            }
        }

        private string getExerciceSelected()
        {
            string exercice_id = "";

            if (cbExercice.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)cbExercice.SelectedItem;
                Console.Write(cbExercice.SelectedItem);
                exercice_id = row["id"].ToString();
            }

            return exercice_id;
        }
        ImmeubleEntite immeuble = null;
        void ControlOperationsAppelDeFond()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    immeuble_id = immeuble.id;
            }
            else
                return;

            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = OperationController.getController().getAllAppelDeFondOperations(immeuble_id, datDeb, datFin);
            headerOperation();
            dataGridView.Rows.Clear();

            foreach (DataRow row in table.Rows)
            {
                OperationEntite entite = new OperationEntite(row);
                DataTable appels = SaisieAppelFondController.getController().getSaisieAppel(entite);
                if (appels != null)
                {
                    if (appels.Rows.Count == 0 || appels.Rows.Count > 1)
                    {
                        string ref_copro = "";
                        if (entite.Coproprietaire != null)
                            ref_copro = entite.Coproprietaire.reference;
                        dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), ref_copro, entite.Nature.reference, entite.base_repart, entite.libelle, 
                            entite.debit.ToString(), entite.credit.ToString(), entite.global.ToString(), appels.Rows.Count.ToString() });
                    }
                }              
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }
        void ControlOperationsFactures()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    immeuble_id = immeuble.id;
            }
            else
                return;

            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = OperationController.getController().getAllFactureOperations(immeuble_id, datDeb, datFin);
            headerOperation();
            dataGridView.Rows.Clear();

            foreach (DataRow row in table.Rows)
            {
                OperationEntite entite = new OperationEntite(row);
                DataTable factures = SaisieFactureController.getController().getSaisieFacture(entite);
                string ref_copro = "";
                if (entite.Coproprietaire != null)
                    ref_copro = entite.Coproprietaire.reference;
                //Console.WriteLine("{0} {1} {2} {3} {4} {5}", row["date_operation"], ref_copro, row["libelle"], row["debit"], row["credit"], factures.Rows.Count);
                if (factures != null)
                {
                    if (factures.Rows.Count == 0 || factures.Rows.Count > 1)
                    {
                        dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), ref_copro, entite.Nature.reference, entite.base_repart, entite.libelle, 
                            entite.debit.ToString(), entite.credit.ToString(), entite.global.ToString(), factures.Rows.Count.ToString() });
                    }
                }
                //else
                //    dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), ref_copro, entite.Nature.reference, entite.base_repart, entite.libelle, 
                //            entite.debit.ToString(), entite.credit.ToString(), entite.global.ToString(), factures.Rows.Count.ToString() });
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }
        void headerOperation()
        {
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols.Clear();
            cols.Add("id", "id");
            cols.Add("date", "Date");
            cols.Add("copro", "Copro");
            cols.Add("nature", "Nature");
            cols.Add("base", "Base");
            cols.Add("libelle", "Libelle");
            cols.Add("debit", "Débit");
            cols.Add("credit", "Credit");
            cols.Add("global", "Global");
            cols.Add("nombre", "Nombre");
            cols["id"].Visible = false;
            cols["libelle"].MinimumWidth = 160;
        }
        void ControlOperationsReglements()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    immeuble_id = immeuble.id;
            }
            else
                return;

            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = OperationController.getController().getAllReglementsOperations(immeuble_id, datDeb, datFin);
            headerOperation();
            dataGridView.Rows.Clear();
            foreach (DataRow row in table.Rows)
            {
                OperationEntite entite = new OperationEntite(row);
                DataTable reglements = SaisieReglementController.getController().getSaisieReglement(entite);

                if (reglements != null)
                {
                    if (reglements.Rows.Count == 0 || reglements.Rows.Count > 1)
                    {
                        string ref_copro = "";
                        if (entite.Coproprietaire != null)
                            ref_copro = entite.Coproprietaire.reference;
                        dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), ref_copro, entite.Nature.reference, entite.base_repart, entite.libelle, 
                            entite.debit.ToString(), entite.credit.ToString(), entite.global.ToString(), reglements.Rows.Count.ToString() });
                    }
                }
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }
        private void ControlReglements()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    immeuble_id = immeuble.id;
            }
            else 
                return;
            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = SaisieReglementController.getController().GetAllElements(immeuble_id, datDeb, datFin);

            dataGridView.Rows.Clear();
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols.Clear();
            cols.Add("id", "id");
            cols.Add("date", "Date");
            cols.Add("nature", "Nature");
//            cols.Add("base", "Base");
            cols.Add("libelle", "Libelle");
            cols.Add("montant", "Montant Reglement");
            cols.Add("montant_ope", "Montant Opération");
            cols["id"].Visible = false;
            cols["libelle"].MinimumWidth = 160;

            foreach (DataRow row in table.Rows)
            {
                SaisieReglementEntite entite = new SaisieReglementEntite(row);
                DataTable opes = OperationController.getController().getReglementOperations(entite);

                decimal total = 0;
                foreach (DataRow opeRow in opes.Rows)
                {
                    decimal credit = Convertir.ToDecimal(opeRow["credit"]);
                    decimal debit = Convertir.ToDecimal(opeRow["debit"]);
                    total += credit - debit;
                }
                if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
                {
                    dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference, entite.libelle, entite.montant.ToString(), total.ToString() });
                }
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }
        private void ControlFactures()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if( immeuble != null )
                    immeuble_id = immeuble.id;
            }
            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = SaisieFactureController.getController().GetAllElements(immeuble_id, datDeb, datFin);
            dataGridView.Rows.Clear();
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols.Clear();
            cols.Add("id", "id");
            cols.Add("date", "Date");
            cols.Add("nature", "Nature"); 
            cols.Add("base", "Base");
            cols.Add("libelle", "Libelle");
            cols.Add("montant", "Montant Facture");
            cols.Add("montant_ope", "Montant Opération");
            cols["id"].Visible = false;
            cols["libelle"].MinimumWidth = 160;
            foreach (DataRow row in table.Rows)
            {
                SaisieFactureEntite entite = new SaisieFactureEntite(row);
                DataTable opes = OperationController.getController().getFactureOperations(entite);
                decimal total = 0;
                foreach (DataRow opeRow in opes.Rows)
                {
                    decimal credit = Convertir.ToDecimal(opeRow["credit"]);
                    decimal debit = Convertir.ToDecimal(opeRow["debit"]);
                    total += credit - debit;
                }
                if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
                {
                    total = Math.Abs(total);
                    if ( entite.Nature.reference != "140")
                        dataGridView.Rows.Add(new string[]{entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference, entite.base_repart, entite.libelle, entite.montant.ToString(), total.ToString()});
                }
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }

        private void ControlAppelDeFond()
        {
            Cursor.Current = Cursors.WaitCursor;
            string immeuble_id = "";
            if (tbRefImmeuble.Text != "")
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
                if (immeuble != null)
                    immeuble_id = immeuble.id;
            }
            ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById(getExerciceSelected());
            DateTime datDeb = exercice.date_deb;
            DateTime datFin = exercice.date_fin;

            DataTable table = SaisieAppelFondController.getController().GetAllElements(immeuble_id, datDeb, datFin);
            dataGridView.Rows.Clear();
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols.Clear();
            cols.Add("id", "id");
            cols.Add("date", "Date");
            cols.Add("nature", "Nature");
            cols.Add("base", "Base");
            cols.Add("libelle", "Libelle");
            cols.Add("montant", "Montant Appel");
            cols.Add("montant_ope", "Montant Opération");
            cols["id"].Visible = false;
            cols["libelle"].MinimumWidth = 160;
            foreach (DataRow row in table.Rows)
            {
                SaisieAppelFondEntite entite = new SaisieAppelFondEntite(row);
                DataTable opes = OperationController.getController().getAppelDeFondOperations(entite);
                decimal total = 0;
                foreach (DataRow opeRow in opes.Rows)
                {
                    decimal credit = Convertir.ToDecimal(opeRow["credit"]);
                    decimal debit = Convertir.ToDecimal(opeRow["debit"]);
                    total += credit - debit;
                }
                if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
                {
                    total = Math.Abs(total);
                    dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference, entite.base_repart, entite.libelle, entite.montant.ToString(), total.ToString() });
                }
            }
            ShowPostit();
            Cursor.Current = Cursors.Default;
        }

        void AllImmeuble(String fileName)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataTable immeubles = ImmeubleController.getController().GetTableList();
            StreamWriter file = new StreamWriter(fileName, false);
            file.Write("ref_immeuble;date_deb;date_fin;");
            file.Write("factures;factures_ope;;");
            file.Write("reglements;reglements_ope;;");
            file.Write("appels;appels_ope;;");
            file.WriteLine("solde_anterieur;sol_imm");

            foreach (DataRow row in immeubles.Rows)
            {
                ImmeubleEntite immeuble = new ImmeubleEntite(row);
                ExerciceComptableEntite exercice = ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
                if (exercice != null)
                {
                    DateTime datDeb = exercice.date_deb;
                    DateTime datFin = exercice.date_fin;

                    decimal total_facture = SaisieFactureController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                    decimal total_reglements = SaisieReglementController.getController().getSumReglements(immeuble.id, datDeb, datFin);
                    decimal total_appels = SaisieAppelFondController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);

                    decimal soldeReprise = SaisieFactureController.getController().getSoldeAnterieurImmeuble(immeuble.id, datDeb, datFin);
                    decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                    decimal depenseOperation = OperationController.getController().getOperationDepense(immeuble.id, datDeb, datFin, "");
                    decimal reglementOperation = SaisieReglementController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                    decimal appelOperation = OperationController.getController().getOperationAppel(immeuble.id, datDeb, datFin, "");

                    file.Write(string.Format("*** {0};{1};{2};", immeuble.reference, datDeb.ToShortDateString(), datFin.ToShortDateString()));
                    string results = string.Format("{0};{1};;{2};{3};;{4};{5};;{6};{7}", total_facture, depenseOperation, total_reglements, reglementOperation, 
                                total_appels, Math.Abs(appelOperation), Math.Abs(soldeReprise), valueSoldeImm);
//                    file.WriteLine(results.Replace(",","."));
                    file.WriteLine(results);

                }
            }
            file.Close();
            Cursor.Current = Cursors.Default;
        }

        void ShowPostit()
        {
            if (immeuble != null)
            {
                //ExerciceComptableEntite exercice = immeuble.ExerciceCourant;
                ExerciceComptableEntite exercice = ExerciceComptableController.getController().getEntiteById (getExerciceSelected());
                DateTime datDeb = exercice.date_deb;
                DateTime datFin = exercice.date_fin;

                decimal total_facture = SaisieFactureController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin );
                decimal total_reglements = SaisieReglementController.getController().getSumReglements(immeuble.id, datDeb, datFin );
                decimal total_appels = SaisieAppelFondController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);

                decimal soldeReprise = SaisieFactureController.getController().getSoldeAnterieurImmeuble(immeuble.id, datDeb, datFin);
                decimal valueSoldeImm = OperationController.getController().getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                decimal depenseOperation = OperationController.getController().getOperationDepense(immeuble.id, datDeb, datFin, "");
                decimal reglementOperation = SaisieReglementController.getController().getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                decimal appelOperation = OperationController.getController().getOperationAppel(immeuble.id, datDeb, datFin, "");



                string strTotaux = String.Format("Factures: \t\t {0}\r\n", total_facture);
                strTotaux += String.Format("Règlements: \t\t {0}\r\n", total_reglements);
                strTotaux += String.Format("Appel de fonds: \t\t {0}\r\n", total_appels);

                strTotaux += "\r\n";
                strTotaux += String.Format("Operations Depenses: \t {0}\r\n", depenseOperation);
                strTotaux += String.Format("Operations Reglements: \t {0}\r\n", reglementOperation);
                strTotaux += String.Format("Operations Appels: \t {0}\r\n", Math.Abs(appelOperation));

                strTotaux += "\r\n";
                strTotaux += String.Format("Solde Antérieur: \t {0}\r\n", soldeReprise);
                strTotaux += String.Format("Solde Exercice: \t\t {0}\r\n", valueSoldeImm);

                TotauxForm.DoFormText(this, strTotaux);
                TotauxForm.Text = "Totaux";
                TotauxForm.ShowForm(this);
                this.Activate();
            }

        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            EditionOperation();
        }
        void EditionOperation()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                //DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                DataGridViewRow row = dataGridView.SelectedRows[0];
                Form form = null;
                switch (cbType.SelectedIndex)
                {
                    case 5:
                    case 4:
                    case 3:
                        //AnnuleOperation(row["id"].ToString());
                        form = new DetailElementOperationForm(row.Cells["id"].Value.ToString());
                        break;
                    case 1:
                        form = new DetailReglementForm(row.Cells["id"].Value.ToString());
                        break;
                    case 2:
                        form = new DetailAppelDeFondForm(row.Cells["id"].Value.ToString());
                        break;
                    case 0:
                        //Console.WriteLine(row.Cells["id"].Value.ToString());
                        form = new DetailFactureForm(row.Cells["id"].Value.ToString());
                        break;
                }
                if (form != null)
                {
                    form.ShowDialog();
                    //FillD
                    //commonValidating();
                }
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            EditionOperation();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void ControlDataForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            TitreForm = this.Text;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            ReferenceExerciceForm form = new ReferenceExerciceForm(immeuble);
            form.ShowDialog();
            tbRefImmeuble_Validating(null, null);
        }

        private void AnnuleOperations()
        {
            Npgsql.NpgsqlTransaction trx = Database.BeginTransaction();
            try
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    OperationController.getController().DeleteEntite(row.Cells["id"].Value.ToString());
                }
                trx.Commit();
                fillDataGrid();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }

        }
        private void supprimerLesÉlémentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count <= 0)
                return;
            switch (cbType.SelectedIndex)
            {
                case 5:
                case 4:
                case 3:
                    AnnuleOperations();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string filename = Path.GetTempFileName().Replace(".tmp", ".csv");

                Console.WriteLine(filename);
                AllImmeuble(filename);
                Process proc = new Process();

                proc.StartInfo.FileName = filename;
                proc.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
