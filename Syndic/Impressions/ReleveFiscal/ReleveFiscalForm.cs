using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.ReleveFiscal;

public partial class ReleveFiscalForm : Form
{
    private ImmeubleEntite immeuble;
    private readonly BindingSource immeubleSource = new();
    private readonly AutoCompleteStringCollection lotsString = new();
    private readonly string TitreForm;
    public ReleveFiscalForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void ReleveFiscalForm_Load(object sender, EventArgs e)
    {
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        dtDebut.Value = dtFin.Value.AddYears(-1);
        btnEnter.Width = 0;
    }

    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var dateDeb = e.Parameters[0].Values[0];
        var dateFin = e.Parameters[1].Values[0];

        var dtDeb = DateTime.Parse(dateDeb);
        var dtFin= DateTime.Parse(dateFin);
        var coproprietaire_id = e.Parameters[2].Values[0];
        var source = OperationController.getController().GetReleveFiscalCoproprietaire( coproprietaire_id, dtDeb, dtFin);
        immeubleSource.Filter = $"copro_id = '{coproprietaire_id}'";

        e.DataSources.Add(new ReportDataSource("fiscal_copro", source));
        e.DataSources.Add(new ReportDataSource("immeuble_copro", immeubleSource));
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        CreateReport(tbLot.Text);
        reportViewer1.RefreshReport();
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
        if (tbRefImmeuble.Enabled)
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
            var lots = LotDescriptionController.getController().getListeLotFiscaux(immeuble.id);
            var exercice = immeuble.ExerciceCourant;
            if (exercice != null)
            {
                dtDebut.Value = exercice.date_deb;
                dtFin.Value = exercice.date_fin;
            }
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
            lotsString.Clear();
            foreach ( DataRow row in lots.Rows)
            {
                lotsString.Add(row["numero_lot"].ToString());
            }
            ControlsWindows.setAutoControle(tbLot, lotsString);
            btnRapport.Enabled = true;
        }
        else
        {
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            Text = TitreForm;
            btnRapport.Enabled = false;
        }
    }

    private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(null, null);
                if (sender.Equals(tbLot))
                    lblLot_Click(null, null);
            }
    }

    private void tbLot_Validating(object sender, CancelEventArgs e)
    {
        if (tbLot.Text != "")
            tbLot.BackColor = lotsString.Contains(tbLot.Text) ? Color.White : Color.Red;
        else
            tbLot.BackColor = Color.White;
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
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

    private void CreateReport(string lot)
    {
        if (immeuble != null)
        {
            immeubleSource.DataSource = ImmeubleController.getController().GetDescriptionCoproprietairesImmeuble(immeuble.id, lot, true);
            immeubleSource.Filter = "";
            immeublecoproBindingSource.DataSource = immeubleSource;

            var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            var parameters = new ReportParameter[]
            {
                new("DateEdition", dtEdition.Value.ToShortDateString()),
                new("DateDebut", dtDebut.Value.ToShortDateString()),
                new("DateFin", dtFin.Value.ToShortDateString()),
                new("Header_Description", hdr_descr),
                new("Header_Agence", hdr_agence)
            };
            reportViewer1.LocalReport.SetParameters(parameters);
        }
    }
}