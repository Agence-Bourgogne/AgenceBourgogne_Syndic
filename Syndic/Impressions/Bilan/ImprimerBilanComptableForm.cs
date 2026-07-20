using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.Bilan;

public partial class ImprimerBilanComptableForm : Form
{
    private readonly List<string> baseIndividuelle = ["80"];

    private readonly List<string> excludeNature = ["090", "091", "092", "093"];

    private readonly string TitreForm;
    private decimal avancePermanente, soldeExercice, totalDebit, totalCredit;
    private DataTable BilanOperationsCoproprietairesAppelDeFond;
    private DataTable BilanOperationsCoproprietairesPaiements;
    private DataTable BilanOperationsCoproprietairesSoldes;
    private decimal chargesNormales, chargesTravaux, chargesPrivatives, depenses, soldeBilan, reglements;

    private DataTable CompteGestionGeneral;
    private ImmeubleEntite immeuble;
    private List<NatureEntite> natSolde;
    private List<NatureEntite> natTravaux;

    public ImprimerBilanComptableForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference)) tbRefImmeuble.Text = form.reference;
    }

    private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(null, null);
            }
    }

    private NatureEntite getNatureCloture()
    {
        var reference = ParametresDB.getParam1("CLOTURE", "NATURE");
        return NatureController.getController().getEntiteFromField("reference", reference);
    }

    private void ImprimerBilanComptableForm_Load(object sender, EventArgs e)
    {
        btnRapport.Enabled = false;
        var dt = DateTime.Now;
        dt = dt.AddDays(-dt.DayOfYear + 1);
        dtDebut.Value = dt;
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        btnEnter.Width = 0;
        var natures = NatureController.getController().GetListEntite();
        natTravaux = natures.FindAll(x => (x.type_charge & 2) == 2);
        natSolde = [getNatureCloture()];
        var excl = ParametresDB.getParam1("NATURE", "PAS PRIVATIVES");
        if (!string.IsNullOrEmpty(excl))
        {
            excl = excl.Replace(", ", ",").Replace(" ,", ",");
            var lExcl = excl.Split(',');
            excludeNature.Clear();
            excludeNature.AddRange(lExcl);
        }
    }

    private bool isRepartIndividuelle(string base_repart, string refNature)
    {
        var isIndividuelle = false;
        if (!excludeNature.Contains(refNature))
            isIndividuelle = baseIndividuelle.Contains(base_repart);
        return isIndividuelle;
    }

    private bool isNatureTravaux(string nature)
    {
        var isTravaux = false;
        isTravaux = natTravaux.Find(x => x.reference == nature) != null;
        return isTravaux;
    }

    private void Cumuls()
    {
        chargesNormales = chargesTravaux = chargesPrivatives = depenses = soldeBilan = reglements = 0;
        avancePermanente = LotDescriptionController.getController().getAvanceImmeuble(immeuble.id);
        soldeExercice = totalDebit = totalCredit = 0;
        foreach (DataRow row in CompteGestionGeneral.Rows)
        {
            var isIndividuelle = isRepartIndividuelle(row["base_repart"].ToString(), row["reference"].ToString());
            var isTravaux = isNatureTravaux(row["reference"].ToString());
            var charges = (decimal)row["debit"] - (decimal)row["credit"];
            depenses += charges;
            if (!isTravaux && !isIndividuelle)
                chargesNormales += charges;
            else if (isIndividuelle)
                chargesPrivatives += charges;
            else
                chargesTravaux += charges;
            totalDebit += (decimal)row["debit"];
            totalCredit += (decimal)row["credit"];
        }

        foreach (DataRow row in BilanOperationsCoproprietairesSoldes.Rows)
        {
            var charges = (decimal)row["credit"] - (decimal)row["debit"];
            soldeBilan += charges;
        }

        foreach (DataRow row in BilanOperationsCoproprietairesPaiements.Rows)
        {
            var charges = (decimal)row["credit"] - (decimal)row["debit"];
            Console.WriteLine("{1} {0} {2} {3} {4} ", row["libelle"], row["reference"], (decimal)row["credit"],
                (decimal)row["debit"], charges);
            reglements += charges;
        }

// Mantis 134 mais Pa OK mantis 136 => 134 c'est relevé individuel
//            reglements += totalCredit;
        soldeExercice = soldeBilan + reglements - depenses + avancePermanente;

        Console.WriteLine("Solde en Bilan : {0} {1} {2} {3}", soldeBilan, reglements, depenses, avancePermanente);
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        CreateReport();
        reportViewer1.RefreshReport();
    }

    private void CreateReport()
    {
        var parameters = new List<NpgsqlParameter> { new("@reference", tbRefImmeuble.Text) };
        immeubleBindingSource.DataSource = ImmeubleController.getController()
            .getDataTable(" where reference = @reference", parameters);
        if (immeubleBindingSource.DataSource != null)
        {
            CompteGestionGeneral = SaisieFactureController.getController()
                .getCompteGestionGeneral(immeuble.id, dtDebut.Value, dtFin.Value);

            // TODO Paramétrer les natures
            BilanOperationsCoproprietairesSoldes = OperationController.getController()
                .getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value, " n.reference = '140'");
            BilanOperationsCoproprietairesPaiements = OperationController.getController()
                .getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value,
                    " n.reference != '140' and n.reference != '145' ", true);
            BilanOperationsCoproprietairesAppelDeFond = OperationController.getController()
                .getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value, " n.reference = '145' ");

            //BaseApplication.GenerateDataSource(CompteGestionGeneral, "c:\\export_syndic\\compte_gestion.csv", Encoding.UTF8);
            //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesSoldes, "c:\\export_syndic\\soldes.csv", Encoding.UTF8);
            //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesPaiements, "c:\\export_syndic\\paiements.csv", Encoding.UTF8);
            //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesAppelDeFond, "c:\\export_syndic\\appels.csv", Encoding.UTF8);


            Cumuls();
            var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            var reportParams = new ReportParameter[]
            {
                new("DateEdition", dtEdition.Value.ToShortDateString()),
                new("DateDebut", dtDebut.Value.ToShortDateString()),
                new("DateFin", dtFin.Value.ToShortDateString()),
                new("chargesNormales", chargesNormales.ToString()),
                new("chargesTravaux", chargesTravaux.ToString()),
                new("chargesPrivatives", chargesPrivatives.ToString()),
                new("soldeBilan", soldeBilan.ToString()),
                new("reglements", reglements.ToString()),
                new("depenses", depenses.ToString()),
                new("avancePermanente", avancePermanente.ToString()),
                new("soldeExercice", soldeExercice.ToString()),
                new("totalDebit", totalDebit.ToString()),
                new("totalCredit", totalCredit.ToString()),
                new("Header_Description", hdr_descr),
                new("Header_Agence", hdr_agence)
            };

            reportViewer1.LocalReport.SetParameters(reportParams);
        }
    }

    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var rapport = e.Parameters[0].Values[0];

        e.DataSources.Clear();
        if (rapport == "1") e.DataSources.Add(new ReportDataSource("CompteGestionGeneral", CompteGestionGeneral));
        if (rapport == "2") e.DataSources.Add(new ReportDataSource("CompteGestionGeneral", CompteGestionGeneral));
        if (rapport == "3")
        {
            e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesSolde",
                BilanOperationsCoproprietairesSoldes));
            e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesPaiements",
                BilanOperationsCoproprietairesPaiements));
            e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesAppel",
                BilanOperationsCoproprietairesAppelDeFond));
        }
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            var exercice = ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
            if (exercice != null)
            {
                dtDebut.Value = exercice.date_deb;
                dtFin.Value = exercice.date_fin;
            }

            tbRefImmeuble.BackColor = Color.White;
            btnRapport.Enabled = true;
        }
        else
        {
            Text = TitreForm;

            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            btnRapport.Enabled = false;
        }
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void label1_Click(object sender, EventArgs e)
    {
        if (immeuble == null)
            return;
        var form = new ReferenceExerciceForm(immeuble);
        form.ShowDialog();
        tbRefImmeuble_Validating(null, null);
    }
}