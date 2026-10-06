using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.OperationsGestion;

public partial class ControlDataForm : Form
{
    private readonly HelpForm _totauxForm = new("ControlTotauxCloture");

    private ImmeubleEntite _immeuble;
    private string _titreForm;

    public ControlDataForm()
    {
        InitializeComponent();
    }

    private void cbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void FillDataGrid()
    {
        if (tbRefImmeuble.Text != "")
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

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                Text = $"{_titreForm} pour l'immeuble : {_immeuble.nom} ({_immeuble.DateExercice})";
            FillComboExercice();
        }
        else
        {
            Text = _titreForm;
        }
    }

    private void FillComboExercice()
    {
        if (_immeuble == null)
            return;
        var exercices = ExerciceComptableController.GetController().GetListExerciceFromImmeuble(_immeuble.id);
        cbExercice.DataSource = exercices;

        cbExercice.DisplayMember = "reference";
        cbExercice.ValueMember = "e.id";
        if (_immeuble != null)
        {
            var exercice = ExerciceComptableController.GetController().GetExerciceCourant(_immeuble.id);
            cbExercice.SelectedValue = exercice.id;
        }
    }

    private string GetExerciceSelected()
    {
        var exerciceId = "";

        if (cbExercice.SelectedIndex >= 0)
        {
            var row = (DataRowView)cbExercice.SelectedItem;
            Console.Write(cbExercice.SelectedItem);
            exerciceId = row["id"].ToString();
        }

        return exerciceId;
    }

    private void ControlOperationsAppelDeFond()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }
        else
        {
            return;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = OperationController.getController().getAllAppelDeFondOperations(immeubleId, datDeb, datFin);
        HeaderOperation();
        dataGridView.Rows.Clear();

        foreach (DataRow row in table.Rows)
        {
            var entite = new OperationEntite(row);
            var appels = SaisieAppelFondController.getController().getSaisieAppel(entite);
            if (appels != null)
                if (appels.Rows.Count == 0 || appels.Rows.Count > 1)
                {
                    var refCopro = "";
                    if (entite.Coproprietaire != null)
                        refCopro = entite.Coproprietaire.reference;
                    dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), refCopro,
                        entite.Nature.reference, entite.base_repart, entite.libelle, entite.debit.ToString(),
                        entite.credit.ToString(), entite.global.ToString(), appels.Rows.Count.ToString());
                }
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private void ControlOperationsFactures()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }
        else
        {
            return;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = OperationController.getController().getAllFactureOperations(immeubleId, datDeb, datFin);
        HeaderOperation();
        dataGridView.Rows.Clear();

        foreach (DataRow row in table.Rows)
        {
            var entite = new OperationEntite(row);
            var factures = SaisieFactureController.getController().getSaisieFacture(entite);
            var refCopro = "";
            if (entite.Coproprietaire != null)
                refCopro = entite.Coproprietaire.reference;
            //Console.WriteLine("{0} {1} {2} {3} {4} {5}", row["date_operation"], ref_copro, row["libelle"], row["debit"], row["credit"], factures.Rows.Count);
            if (factures != null)
                if (factures.Rows.Count == 0 || factures.Rows.Count > 1)
                    dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), refCopro,
                        entite.Nature.reference, entite.base_repart, entite.libelle, entite.debit.ToString(),
                        entite.credit.ToString(), entite.global.ToString(), factures.Rows.Count.ToString());
            //else
            //    dataGridView.Rows.Add(new string[] { entite.id, entite.date_reference.ToShortDateString(), ref_copro, entite.Nature.reference, entite.base_repart, entite.libelle, 
            //            entite.debit.ToString(), entite.credit.ToString(), entite.global.ToString(), factures.Rows.Count.ToString() });
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private void HeaderOperation()
    {
        var cols = dataGridView.Columns;
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

    private void ControlOperationsReglements()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }
        else
        {
            return;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = OperationController.getController().getAllReglementsOperations(immeubleId, datDeb, datFin);
        HeaderOperation();
        dataGridView.Rows.Clear();
        foreach (DataRow row in table.Rows)
        {
            var entite = new OperationEntite(row);
            var reglements = SaisieReglementController.getController().getSaisieReglement(entite);

            if (reglements != null)
                if (reglements.Rows.Count == 0 || reglements.Rows.Count > 1)
                {
                    var refCopro = "";
                    if (entite.Coproprietaire != null)
                        refCopro = entite.Coproprietaire.reference;
                    dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), refCopro,
                        entite.Nature.reference, entite.base_repart, entite.libelle, entite.debit.ToString(),
                        entite.credit.ToString(), entite.global.ToString(), reglements.Rows.Count.ToString());
                }
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private void ControlReglements()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }
        else
        {
            return;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = SaisieReglementController.getController().GetAllElements(immeubleId, datDeb, datFin);

        dataGridView.Rows.Clear();
        var cols = dataGridView.Columns;
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
            var entite = new SaisieReglementEntite(row);
            var opes = OperationController.getController().getReglementOperations(entite);

            decimal total = 0;
            foreach (DataRow opeRow in opes.Rows)
            {
                var credit = Convertir.ToDecimal(opeRow["credit"]);
                var debit = Convertir.ToDecimal(opeRow["debit"]);
                total += credit - debit;
            }

            if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
                dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference,
                    entite.libelle, entite.montant.ToString(), total.ToString());
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private void ControlFactures()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = SaisieFactureController.getController().GetAllElements(immeubleId, datDeb, datFin);
        dataGridView.Rows.Clear();
        var cols = dataGridView.Columns;
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
            var entite = new SaisieFactureEntite(row);
            var opes = OperationController.getController().getFactureOperations(entite);
            decimal total = 0;
            foreach (DataRow opeRow in opes.Rows)
            {
                var credit = Convertir.ToDecimal(opeRow["credit"]);
                var debit = Convertir.ToDecimal(opeRow["debit"]);
                total += credit - debit;
            }

            if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
            {
                total = Math.Abs(total);
                if (entite.Nature.reference != "140")
                    dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference,
                        entite.base_repart, entite.libelle, entite.montant.ToString(), total.ToString());
            }
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private void ControlAppelDeFond()
    {
        Cursor.Current = Cursors.WaitCursor;
        var immeubleId = "";
        if (tbRefImmeuble.Text != "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
                immeubleId = _immeuble.id;
        }

        var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
        var datDeb = exercice.date_deb;
        var datFin = exercice.date_fin;

        var table = SaisieAppelFondController.getController().GetAllElements(immeubleId, datDeb, datFin);
        dataGridView.Rows.Clear();
        var cols = dataGridView.Columns;
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
            var entite = new SaisieAppelFondEntite(row);
            var opes = OperationController.getController().getAppelDeFondOperations(entite);
            decimal total = 0;
            foreach (DataRow opeRow in opes.Rows)
            {
                var credit = Convertir.ToDecimal(opeRow["credit"]);
                var debit = Convertir.ToDecimal(opeRow["debit"]);
                total += credit - debit;
            }

            if (Math.Abs(Math.Abs(total) - Math.Abs(entite.montant)) > 1)
            {
                total = Math.Abs(total);
                dataGridView.Rows.Add(entite.id, entite.date_reference.ToShortDateString(), entite.Nature.reference,
                    entite.base_repart, entite.libelle, entite.montant.ToString(), total.ToString());
            }
        }

        ShowPostit();
        Cursor.Current = Cursors.Default;
    }

    private static void AllImmeuble(string fileName)
    {
        Cursor.Current = Cursors.WaitCursor;

        var immeubles = ImmeubleController.getController().GetTableList();
        var file = new StreamWriter(fileName, false);
        file.Write("ref_immeuble;date_deb;date_fin;");
        file.Write("factures;factures_ope;;");
        file.Write("reglements;reglements_ope;;");
        file.Write("appels;appels_ope;;");
        file.WriteLine("solde_anterieur;sol_imm");

        foreach (DataRow row in immeubles.Rows)
        {
            var immeuble = new ImmeubleEntite(row);
            var exercice = ExerciceComptableController.GetController().GetExerciceCourant(immeuble.id);
            if (exercice != null)
            {
                var datDeb = exercice.date_deb;
                var datFin = exercice.date_fin;

                var totalFacture = SaisieFactureController.getController()
                    .getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                var totalReglements = SaisieReglementController.getController()
                    .getSumReglements(immeuble.id, datDeb, datFin);
                var totalAppels = SaisieAppelFondController.getController()
                    .getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);

                var soldeReprise = SaisieFactureController.getController()
                    .getSoldeAnterieurImmeuble(immeuble.id, datDeb, datFin);
                var valueSoldeImm = OperationController.getController()
                    .getSoldeImmeuble(immeuble == null ? "" : immeuble.id, datDeb, datFin);
                var depenseOperation =
                    OperationController.getController().getOperationDepense(immeuble.id, datDeb, datFin);
                var reglementOperation = SaisieReglementController.getController()
                    .getTotalOperationWithoutSolde(immeuble.id, datDeb, datFin);
                var appelOperation = OperationController.getController().getOperationAppel(immeuble.id, datDeb, datFin);

                file.Write($"*** {immeuble.reference};{datDeb.ToShortDateString()};{datFin.ToShortDateString()};");
                var results =
                    $"{totalFacture};{depenseOperation};;{totalReglements};{reglementOperation};;{totalAppels};{Math.Abs(appelOperation)};;{Math.Abs(soldeReprise)};{valueSoldeImm}";
                file.WriteLine(results);
            }
        }

        file.Close();
        Cursor.Current = Cursors.Default;
    }

    private void ShowPostit()
    {
        if (_immeuble != null)
        {
            //ExerciceComptableEntite exercice = immeuble.ExerciceCourant;
            var exercice = ExerciceComptableController.GetController().getEntiteById(GetExerciceSelected());
            var datDeb = exercice.date_deb;
            var datFin = exercice.date_fin;

            var totalFacture = SaisieFactureController.getController()
                .getTotalOperationWithoutSolde(_immeuble.id, datDeb, datFin);
            var totalReglements =
                SaisieReglementController.getController().getSumReglements(_immeuble.id, datDeb, datFin);
            var totalAppels = SaisieAppelFondController.getController()
                .getTotalOperationWithoutSolde(_immeuble.id, datDeb, datFin);

            var soldeReprise = SaisieFactureController.getController()
                .getSoldeAnterieurImmeuble(_immeuble.id, datDeb, datFin);
            var valueSoldeImm = OperationController.getController()
                .getSoldeImmeuble(_immeuble == null ? "" : _immeuble.id, datDeb, datFin);
            var depenseOperation = OperationController.getController().getOperationDepense(_immeuble.id, datDeb, datFin);
            var reglementOperation = SaisieReglementController.getController()
                .getTotalOperationWithoutSolde(_immeuble.id, datDeb, datFin);
            var appelOperation = OperationController.getController().getOperationAppel(_immeuble.id, datDeb, datFin);


            var strTotaux = $"Factures: \t\t {totalFacture}\r\n";
            strTotaux += $"Règlements: \t\t {totalReglements}\r\n";
            strTotaux += $"Appel de fonds: \t\t {totalAppels}\r\n";

            strTotaux += "\r\n";
            strTotaux += $"Operations Depenses: \t {depenseOperation}\r\n";
            strTotaux += $"Operations Reglements: \t {reglementOperation}\r\n";
            strTotaux += $"Operations Appels: \t {Math.Abs(appelOperation)}\r\n";

            strTotaux += "\r\n";
            strTotaux += $"Solde Antérieur: \t {soldeReprise}\r\n";
            strTotaux += $"Solde Exercice: \t\t {valueSoldeImm}\r\n";

            _totauxForm.DoFormText(this, strTotaux);
            _totauxForm.Text = "Totaux";
            _totauxForm.ShowForm(this);
            Activate();
        }
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        EditionOperation();
    }

    private void EditionOperation()
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            //DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            var row = dataGridView.SelectedRows[0];
            Form form = cbType.SelectedIndex switch
            {
                5 or 4 or 3 =>
                    //AnnuleOperation(row["id"].ToString());
                    new DetailElementOperationForm(row.Cells["id"].Value.ToString()),
                1 => new DetailReglementForm(row.Cells["id"].Value.ToString()),
                2 => new DetailAppelDeFondForm(row.Cells["id"].Value.ToString()),
                0 =>
                    //Console.WriteLine(row.Cells["id"].Value.ToString());
                    new DetailFactureForm(row.Cells["id"].Value.ToString()),
                _ => null
            };

            form?.ShowDialog();
            //FillD
            //commonValidating();
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
        _titreForm = Text;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string> { "id" };
        BaseApplication.DataGridToExcel(dataGridView, colsToHide);
    }

    private void btnGrid_Click(object sender, EventArgs e)
    {
        FillDataGrid();
    }

    private void label2_Click(object sender, EventArgs e)
    {
        if (_immeuble == null)
            return;
        var form = new ReferenceExerciceForm(_immeuble);
        form.ShowDialog();
        tbRefImmeuble_Validating(null, null);
    }

    private void AnnuleOperations()
    {
        var trx = Database.BeginTransaction();
        try
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                OperationController.getController().DeleteEntite(row.Cells["id"].Value.ToString());
            trx.Commit();
            FillDataGrid();
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
            var filename = Path.ChangeExtension(Path.GetTempFileName(), ".csv");

            AllImmeuble(filename);

            Process.Start(new ProcessStartInfo
            {
                FileName = filename,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        Cursor.Current = Cursors.Default;
    }
}