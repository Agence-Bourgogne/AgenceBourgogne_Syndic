using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Formulaires.Config;
using CommonProjectsPartners.Formulaires.Logon;
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

    public static MainForm GetInstance()
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