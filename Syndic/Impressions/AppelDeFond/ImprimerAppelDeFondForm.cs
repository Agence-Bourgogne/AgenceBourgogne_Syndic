using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Config;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Impressions.RelevesIndividuels;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.AppelDeFond;

public partial class ImprimerAppelDeFondForm : Form
{
    public ImmeubleEntite immeuble;
    private readonly AutoCompleteStringCollection lotsString = new();
    private readonly BindingSource immeubleSource = new();
    private readonly string TitreForm;
    public string saisie_id = "";

    public ImprimerAppelDeFondForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void ValidAppelDeFondForm_Load(object sender, EventArgs e)
    {
        if (immeuble != null) 
        {
            tbRefImmeuble.Text = immeuble.reference;
            tbRefImmeuble.Enabled = false;
        }
        tbRefImmeuble_Validating(null, null);
        tbText.Text = GetTextAppelFond();
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        btnEnter.Width = 0;
        tbRefImmeuble.Focus();
    }

    private string GetTextAppelFond()
    {
        var txt = "";
        if ( ckFerie.Checked)
            txt = ParametresDB.getParam1("APPEL DE FOND", "FETES");
        else
            txt = ParametresDB.getParam1("APPEL DE FOND", "ENTETE");
        return txt;
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        CreateReport( tbLot.Text);
        reportViewer1.RefreshReport();
        dataGridView.ClearSelection();
    }

    private void CreateReport(string num_lot = "")
    {
        var saisie = saisie_id;
        if (dataGridView.SelectedRows.Count > 0)
        {
            var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            if (!row["liasse_id"].ToString().StartsWith("Reprise"))
                saisie = row["id"].ToString();
            else
                saisie = "";
            Console.WriteLine(saisie_id);
        }
        dataGridView.Visible = false;

        var commentaire = tbText.Text;
        if (commentaire == "")
            commentaire = " ";
        if (num_lot != "")
        {
            var lot = LotDescriptionController.getController().getLotFromReference(immeuble.id, num_lot);
            if (lot == null)
            {
                MessageBox.Show(@"Lot Invalide");
                return;
            }
        }
        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

        var parameters = new ReportParameter[]{
            new("TexteAppel", commentaire),
            new("DateAppel", dtEntete.Value.ToShortDateString()),
            new("seuil", ParametresDB.getParam1("APPEL DE FOND", "SEUIL")),
            new("appel_delai_payer", ParametresDB.getParam1("IMPRESSION", "APPEL_DELAI_PAYER")),
            new("Header_Description", hdr_descr),
            new("Header_Agence", hdr_agence),
            new("TexteDate", immeuble.texte_date)
        };
        reportViewer1.LocalReport.SetParameters(parameters);
        immeubleSource.DataSource = ImmeubleController.getController().GetDescriptionCoproprietairesImmeubleAF(immeuble.id, num_lot, false, saisie);
        immeubleSource.Filter = "";
        immeublecoproBindingSource.DataSource = immeubleSource;
        reportViewer1.RefreshReport();
    }


    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var immeuble_id = e.Parameters[0].Values[0];
        var coproprietaire_id = e.Parameters[3].Values[0];
        var source = OperationController.getController().getCoproprietaireOperation(immeuble_id, coproprietaire_id, dtDeb.Value, dtFin.Value);
        e.DataSources.Clear();
        e.DataSources.Add(new ReportDataSource("operation", source));
        immeubleSource.Filter = $"copro_id = '{coproprietaire_id}'";
        e.DataSources.Add(new ReportDataSource("immeuble_copro", immeubleSource));
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
        if ( tbRefImmeuble.Enabled )
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
            var lots = LotDescriptionController.getController().getListeLot(immeuble.id);

            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";

            if (immeuble.ExerciceCourant == null)
                MessageBox.Show(@"Attention pas d'exercice comptable défini");
            else
            {
                dtDeb.Value = immeuble.ExerciceCourant.date_deb;
                dtFin.Value = immeuble.ExerciceCourant.date_fin;
            }

            lotsString.Clear();
            foreach (DataRow row in lots.Rows)
            {
                lotsString.Add(row["numero_lot"].ToString());
            }
            ControlsWindows.setAutoControle(tbLot, lotsString);
            btnRapport.Enabled = true;
            tbLot.BackColor = Color.White;
            tbLot.Text = "";
        }
        else
        {
            Text = TitreForm;                        
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
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
    private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
    {
    }

    private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
    {
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

    private void tbLot_Validating(object sender, CancelEventArgs e)
    {
        if (immeuble == null)
            return;
        tbLot.BackColor = Color.White;
        if (tbLot.Text == "")
            return;
        var lot = LotDescriptionController.getController().getLotFromReference(immeuble.id, tbLot.Text);
        if (lot == null)
            tbLot.BackColor = Color.Red;

    }

    private void label1_Click(object sender, EventArgs e)
    {
        if (immeuble == null)
            return;
        var form = new ReferenceExerciceForm(immeuble);
        form.ShowDialog();
        tbRefImmeuble_Validating(null, null);
    }

    private void btnListe_Click(object sender, EventArgs e)
    {
        dataGridView.Visible = true;
        var dtDeb = DateTime.Parse("01/01/1970");
        var dtFin = DateTime.Parse("01/01/1970");

        dataGridView.DataSource = SaisieAppelFondController.getController().getListeOperations(tbRefImmeuble.Text, dtDeb, dtFin);
        var cols = dataGridView.Columns;
        ControlsWindows.ToTitleCase(cols);
        cols["statut"].Visible = false;
        cols["id"].Visible = false;
        cols["liasse_id"].Visible = false;
        dataGridView.ClearSelection();
    }

    private void lbParametres_Click(object sender, EventArgs e)
    {
        var form = new ConfigParamForm();
           
        form.groupe_selected = "APPEL DE FOND";
        form.param_selected = "ENTETE";
        form.ShowDialog();
        tbText.Text = GetTextAppelFond();
    }

    private void ckFerie_CheckedChanged(object sender, EventArgs e)
    {
        tbText.Text = GetTextAppelFond();
    }
}