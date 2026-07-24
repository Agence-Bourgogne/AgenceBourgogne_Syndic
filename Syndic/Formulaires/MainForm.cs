using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Formulaires.Config;
using CommonProjectsPartners.Formulaires.Logon;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Budget;
using EspaceSyndic.Formulaires.Config;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Ecritures;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Fournisseur;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Formulaires.OperationsGestion;
using EspaceSyndic.Formulaires.Utilisateurs;
using EspaceSyndic.Impressions;
using EspaceSyndic.Impressions.Additif;
using EspaceSyndic.Impressions.AppelDeFond;
using EspaceSyndic.Impressions.Balances;
using EspaceSyndic.Impressions.Bilan;
using EspaceSyndic.Impressions.Convocations;
using EspaceSyndic.Impressions.Facture;
using EspaceSyndic.Impressions.Reglement;
using EspaceSyndic.Impressions.ReleveFiscal;
using EspaceSyndic.Impressions.RelevesComptes;
using EspaceSyndic.Impressions.RelevesIndividuels;
using EspaceSyndic.Impressions.RemiseDeCles;
using EspaceSyndic.Impressions.RetardsPaiements;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires;

public partial class MainForm : Form
{
    private static readonly Dictionary<string, Form> dicoForms = new();
    public static readonly CommonChangedEvent syndicEvent = new();

    private static MainForm instance;

    public MainForm()
    {
        InitializeComponent();
        instance = this;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Text = Text + " " + Assembly.GetEntryAssembly().GetName().Version;

        var lbl1 = ParametresDB.getParam1("PRESENTATION", "LABEL1", "AGENCE");
        var lbl2 = ParametresDB.getParam1("PRESENTATION", "LABEL2", "BOURGOGNE");

        label2.Text = lbl1;
        label3.Text = lbl2;

        Connection();
    }

    private void verifOperationFacture()
    {
        var file = new StreamWriter("c:\\ctl_reprise\\operation_facture_orphelines.csv", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\operation_facture.csv", false);
        var table = OperationController.getController().getOperationRepriseFacture();
        var trx = Database.BeginTransaction();

        try
        {
            var old_imm = "";
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("{0}", old_imm);
                    file.WriteLine("{0}", old_imm);
                }

                var operation = new OperationEntite(row);
                var regs = SaisieFactureController.getController().getSaisieFacture(operation);
                if (regs.Rows.Count > 1)
                    file_1.WriteLine(
                        $"{operation.date_reference.ToShortDateString()} ; {operation.credit} ; {operation.debit} ; {operation.global} ; {operation.base_repart}; {operation.libelle} ; {regs.Rows[0]["ref_imm"]} = {regs.Rows.Count}");
                else if (regs.Rows.Count < 1)
                    file.WriteLine(
                        $"{operation.date_reference.ToShortDateString()} ; {operation.credit} ; {operation.debit} ; {operation.global} ; {operation.base_repart}; {operation.libelle}; {operation.Nature.reference}; {operation.Coproprietaire.reference}");
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            trx.Rollback();
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void verifOperationReglement(bool bRepare)
    {
        var file = new StreamWriter("c:\\ctl_reprise\\operation_reglement.txt", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\operation_reglement_1.txt", false);
        var table = OperationController.getController().getOperationRepriseReglement();
        var trx = Database.BeginTransaction();

        try
        {
            var old_imm = "";
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("{0}", old_imm);
                    file.WriteLine("{0}", old_imm);
                }

                var operation = new OperationEntite(row);
                var regs = SaisieReglementController.getController().getSaisieReglement(operation);
                if (regs != null)
                {
                    var ref_copro = "null";

                    if (regs.Rows.Count > 1)
                    {
                        if (regs.Rows[0]["ref_copro"] != null)
                            ref_copro = regs.Rows[0]["ref_copro"].ToString();
                        file_1.WriteLine(
                            $"{operation.date_reference} ; {operation.credit} ; {operation.debit} ; {operation.base_repart} ; {operation.libelle}; {ref_copro} = {regs.Rows.Count}");
                    }
                    else if (regs.Rows.Count < 1)
                    {
                        if (operation.Coproprietaire != null)
                            ref_copro = operation.Coproprietaire.reference;
                        file.WriteLine(
                            $"{operation.date_reference} ; {operation.credit} ; {operation.debit} ; {operation.base_repart} ; {operation.libelle}; {ref_copro}");
                        if (bRepare)
                        {
                            var entite = new SaisieReglementEntite(operation)
                            {
                                liasse_id = "Correction"
                            };
                            if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                                throw new Exception("REglement");
                        }
                    }
                }
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            trx.Rollback();
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void verifOperationAppel(bool bRepare)
    {
        var file = new StreamWriter("c:\\ctl_reprise\\operation_appel_orphelin.csv", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\operation_appel_doublon.csv", false);
        var table = OperationController.getController().getOperationRepriseAppels();
        var trx = Database.BeginTransaction();

        try
        {
            var old_imm = "";
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("{0}", old_imm);
                    file.WriteLine("{0}", old_imm);
                }

                var operation = new OperationEntite(row);
                var regs = SaisieAppelFondController.getController().getSaisieAppel(operation);
                if (regs != null)
                {
                    var ref_copro = "null";
                    if (operation.Coproprietaire != null)
                        ref_copro = operation.Coproprietaire.reference;

                    if (regs.Rows.Count > 1)
                    {
                        //if (regs.Rows[0]["ref_copro"] != null)
                        //    ref_copro = regs.Rows[0]["ref_copro"].ToString();
                        file_1.WriteLine(
                            $"{operation.date_reference} ; {operation.credit} ; {operation.debit} ; {operation.base_repart} ; {operation.libelle}; {ref_copro} = {regs.Rows.Count}");
                    }
                    else if (regs.Rows.Count < 1)
                    {
                        file.WriteLine(
                            $"{operation.date_reference} ; {operation.credit} ; {operation.debit} ; {operation.base_repart} ; {operation.libelle}; {ref_copro}");
                        if (bRepare)
                        {
                            var entite = new SaisieReglementEntite(operation)
                            {
                                liasse_id = "Correction"
                            };
                            if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                                throw new Exception("REglement");
                        }
                    }
                }
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            trx.Rollback();
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void doFacture(DataRow row, StreamWriter file, StreamWriter file_1, bool bRepare)
    {
        var entite = new SaisieFactureEntite(row);
        var opes = OperationController.getController().getFactureOperations(entite);
        decimal total = 0;
        //Console.WriteLine("{0} {1}", i++, opes.Rows.Count);
        foreach (DataRow opeRow in opes.Rows)
        {
            var credit = Convertir.ToDecimal(opeRow["credit"]);
            var debit = Convertir.ToDecimal(opeRow["debit"]);
            total += credit - debit;
        }

        if (Math.Abs(Math.Abs(Math.Abs(total) - Math.Abs(entite.montant))) > 1)
        {
            if (entite.base_repart.StartsWith("8") && bRepare)
            {
                var operation = OperationController.getController().getEntiteById(opes.Rows[0]["id"].ToString());
                entite.liasse_id = "Correction";
                entite.lot_id = operation.lot_id;
                operation.saisie_id = entite.id;
                if (OperationController.getController().InsertOrUpdate(operation))
                {
                    if (!SaisieFactureController.getController().InsertOrUpdate(entite))
                        throw new Exception("Facture");
                }
                else
                {
                    throw new Exception("Operation");
                }
            }

            if (opes.Rows.Count > 0)
                file_1.WriteLine(
                    $"{opes.Rows[0]["ref_copro"]};{entite.date_reference.ToShortDateString()};{entite.montant};{total};{entite.libelle};{entite.base_repart};{entite.statut}");
            else if (entite.nature_id != "10230EAADFA54BCBBBE9434214D0AE50")
                file.WriteLine(
                    $"{row["ref_imm"]};{entite.date_reference.ToShortDateString()};{entite.montant};{total};{entite.libelle};{entite.base_repart};{entite.statut}");
        }
    }

    private void verifFactures(bool bRepare)
    {
        var table = SaisieFactureController.getController().GetAllElements("", Database.NullDate, Database.NullDate);
        var file = new StreamWriter("c:\\ctl_reprise\\facture_orphelines.csv", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\facture_montant_diff.csv", false);
        var trx = Database.BeginTransaction();
        try
        {
            var old_imm = "";
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("*** {0}", old_imm);
                    file.WriteLine("*** {0}", old_imm);
                }

                doFacture(row, file, file_1, bRepare);
            }

            trx.Commit();
        }
        catch (Exception e)
        {
            trx.Rollback();
            MessageBox.Show(e.Message);
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void verifAppelDeFond()
    {
        var table = SaisieAppelFondController.getController().GetAllElements();
        var file = new StreamWriter("c:\\ctl_reprise\\appel_orphelins.csv", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\appel_montant_diff.csv", false);
        var old_imm = "";
        foreach (DataRow row in table.Rows)
        {
            if (row["ref_imm"].ToString() != old_imm)
            {
                old_imm = row["ref_imm"].ToString();
                file_1.WriteLine("*** {0}", old_imm);
                file.WriteLine("*** {0}", old_imm);
            }

            var entite = new SaisieAppelFondEntite(row);
//                if (entite.liasse_id.StartsWith("Reprise"))
            {
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
                    if (opes.Rows.Count > 0)
                        file_1.WriteLine(
                            $"{opes.Rows[0]["ref_copro"]};{entite.date_reference.ToShortDateString()};{entite.montant};{total};{entite.libelle}");
                    else
                        file.WriteLine(
                            $"{row["ref_imm"]};{entite.date_reference.ToShortDateString()};{entite.montant};{total};{entite.libelle}");
                }
            }
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void verifLotOperation()
    {
        var table = OperationController.getController().getBadOperations();
        var file = new StreamWriter("c:\\ctl_reprise\\lot_operation_0.txt", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\lot_operation_1.txt", false);
        var trx = Database.BeginTransaction();
        var old_imm = "";
        try
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("*** {0}", old_imm);
                    file.WriteLine("*** {0}", old_imm);
                }

                var operation = new OperationEntite(row);
                var lot = LotDescriptionController.getController()
                    .getLotFromCopro(operation.immeuble_id, operation.coproprietaire_id);
                if (lot != null)
                {
                    operation.lot_id = lot.id;
                    operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                    if (!OperationController.getController().InsertOrUpdate(operation))
                        throw new Exception("Operation Lot");
                }
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void verifReglement(bool bUpdate)
    {
        var table = SaisieReglementController.getController().GetAllElements("", Database.NullDate, Database.NullDate);

        var file = new StreamWriter("c:\\ctl_reprise\\reglement_0.txt", false);
        var file_1 = new StreamWriter("c:\\ctl_reprise\\reglement_1.txt", false);
        var trx = Database.BeginTransaction();
        var old_imm = "";
        try
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["ref_imm"].ToString() != old_imm)
                {
                    old_imm = row["ref_imm"].ToString();
                    file_1.WriteLine("*** {0}", old_imm);
                    file.WriteLine("*** {0}", old_imm);
                }

                var entite = new SaisieReglementEntite(row);

                var opes = OperationController.getController().getReglementOperations(entite);
                if (opes.Rows.Count != 1)
                {
                    if (opes.Rows.Count > 0)
                    {
                        file_1.WriteLine(
                            $"{opes.Rows[0]["ref_copro"]};{opes.Rows.Count};{entite.date_reference};{entite.montant};{entite.libelle};{entite.emetteur};{entite.banque}");
                    }
                    else
                    {
                        var immeuble_id = row["immeuble_id"].ToString();
                        file.WriteLine(
                            $"{row["ref_copro"]};{row["immeuble_id"]};{entite.date_reference};{entite.montant};{entite.libelle};{entite.emetteur};{row["nature_id"]}");
                        if (bUpdate && !immeuble_id.StartsWith("*"))
                        {
                            entite.liasse_id = "Correction";
                            var operation = new OperationEntite(entite);
                            var lot = LotDescriptionController.getController()
                                .getLotFromCopro(entite.immeuble_id, entite.coproprietaire_id);
                            operation.coproprietaire_id = entite.coproprietaire_id;
                            operation.lot_id = lot.id;
                            if (!OperationController.getController().InsertOrUpdate(operation))
                                throw new Exception("Operation");
                            if (!SaisieReglementController.getController().InsertOrUpdate(entite))
                                throw new Exception("Reglement");
                        }
                    }
                }
            }

            var badOpe = OperationController.getController().getBadOperations();
            old_imm = "";
            foreach (DataRow rowOpe in badOpe.Rows)
            {
                var operation = new OperationEntite(rowOpe);
                var lot = LotDescriptionController.getController()
                    .getLotFromCopro(operation.immeuble_id, operation.coproprietaire_id);
                operation.lot_id = lot.id;
                if (!OperationController.getController().InsertOrUpdate(operation))
                    throw new Exception("Operation Lot");
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }

        file.Close();
        file_1.Close();
        Console.WriteLine("Ended");
    }

    private void GenericForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        var form = (Form)sender;
        var className = sender.GetType().ToString();

        Console.WriteLine(className);
        if (dicoForms.Remove(className))
            if (form is ICommonChangedListener listener)
                syndicEvent.Changed -= listener.ChangedReference;

        Activate();
    }

    private static void GenericBtnCancel_Click(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (btn.Parent != null)
        {
            var parent = btn.Parent;
            while (parent != null)
            {
                parent = parent.Parent;
                if (parent is Form form)
                    form.Close();
            }
        }
    }

    public TForm ShowForm<TForm>() where TForm : Form
    {
        var formType = typeof(TForm);
        var className = formType.FullName;

        try
        {
            TForm form;
            if (!dicoForms.TryGetValue(className, out var dicoForm))
            {
                var obj = Activator.CreateInstance(formType);
                form = (TForm)obj;
                dicoForms.Add(className, form);
                form.FormClosed += GenericForm_FormClosed;
                if (form is ICommonChangedListener listener) syndicEvent.Changed += listener.ChangedReference;
            }
            else
            {
                form = (TForm)dicoForm;
            }

            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ControlBox = true;
            form.ShowInTaskbar = true;
            form.Icon = Icon;
            form.ShowIcon = true;
            if (form.CancelButton != null)
            {
                var btn = (Button)form.CancelButton;
                btn.Click += GenericBtnCancel_Click;
            }

            form.Show();
            form.Activate();

            return form;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        return null;
    }

    private void commentairesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new FicheAideImmeubleForm();
        try
        {
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void immeublesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ListeImmeubleForm>();
    }

    private void copropriétairesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ListeCoproprietaireForm>();
    }

    private void fournisseursToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ListeFournisseurForm>();
    }

    private void naturesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ListeNatureForm>();
    }

    private void saisieToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<FicheFactureForm>();
    }

    private void appelDeFondsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<FicheAppelDeFondForm>();
    }

    private void feuillesDePrésenceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<FeuillePresencePrintForm>();
    }

    private void immeublesToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        ShowForm<ImmeublePrintForm>();
    }

    private void saisieReglementCoproproToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<FicheReglementForm>();
    }

    private void appelDeFondDunimmeubleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerAppelDeFondForm>();
    }

    private void bordereauRemiseDeChèquesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerListeReglementForm>();
    }

    private void validationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ValidationFactureForm>();
    }

    private void tableauRemiseDeClefsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerRemiseDeClesForm>();
    }

    private void convocationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerConvocationForm>();
    }

    private void editionEtiquettesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<EtiquettePrintForm>();
    }

    private void bilanGénéralEtCompteExploitationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerBilanComptableForm>();
    }

    private void retardDePaiementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<RetardsPaiementsForm>();
    }

    private void editionComptesFiscauxParImmeublesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ReleveFiscalForm>();
    }

    private void balanceReglementsAppelsDeFondImmeubleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = ShowForm<BalanceImmeublePrintForm>();
        form.RefreshTypeReport(1);
    }

    private void balanceReglementsFacturesPourUnImmeubleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<BalanceImmeublePrintForm>();
    }

    private void visualisationOperationDeGestionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<OperationsGestionForm>();
    }

    private void consultationComptesPropriétairesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ReleveCompteCoproPrintForm>();
    }

    private void relevesIndividuelsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ReleveIndividuelsPrintForm>();
    }

    private void budgetPrévisionnelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<BudgetSruForm>();
    }

    private void additifsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerAdditifForm>();
    }

    private void clotureExerciceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ClotureExerciceForm>();
    }

    private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<UtilisateursListeForm>();
    }

    private void impressionRéglementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ImprimerListeReglementForm>();
    }

    private void controleDesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowForm<ControlDataForm>();
    }

    private void parametresToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new DatabaseConfigForm(SyndicApplication.CURRENT_APPLICATION);
        try
        {
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void parametresGenerauxToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new ConfigParamForm();
        try
        {
            form.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public static MainForm getInstance()
    {
        return instance;
    }

    private void Connection()
    {
        try
        {
            foreach (var item in dicoForms) item.Value.Hide();
            Hide();
            var logonForm = new LogonForm();
            logonForm.ShowDialog();
            if (BaseApplication.userConnected != null)
            {
                if (BaseApplication.userConnected.reference == "GVI")
                    controlesDBToolStripMenuItem.Visible = true;
                Show();
            }
            else
            {
                Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void deconnexionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Connection();
    }

    private void MainForm_Activated(object sender, EventArgs e)
    {
        foreach (var item in dicoForms) item.Value.Show();
    }

    private void facturesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifFactures(false);
    }

    private void reglementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifReglement(false);
    }

    private void appelDeFondToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifAppelDeFond();
    }

    private void repareFacturesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifFactures(true);
    }

    private void répareRéglementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
//            verifReglement(true);
        verifLotOperation();
    }

    private void operationsReglementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifOperationReglement(false);
    }

    private void répareOpérationReglementsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifOperationReglement(true);
    }

    private void operationsFacturesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifOperationFacture();
    }

    private void operationsAppelDeFondToolStripMenuItem_Click(object sender, EventArgs e)
    {
        verifOperationAppel(false);
    }


    private void transfertAppelDeFondsSurGéranceToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void modèlesDeDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Form form = new ModelesDocumentsForm();
        form.ShowDialog();
    }

    private void impressionListeFacturesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = new ImprimerListeFacturationForm();
        form.ShowDialog();
    }

    private void GrandLivreToolStripMenuItemOnClick(object sender, EventArgs e)
    {
        ShowForm<GrandLivreForm>();
    }
}