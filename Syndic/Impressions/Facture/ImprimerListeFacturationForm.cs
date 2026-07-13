using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Impressions.Facture;

public partial class ImprimerListeFacturationForm : Form
{
    public readonly List<string> liasses = [];

    public ImprimerListeFacturationForm()
    {
        InitializeComponent();
    }

    public ImprimerListeFacturationForm(string liasse_id)
    {
        InitializeComponent();
        liasses.Add(liasse_id);
    }

    public ImprimerListeFacturationForm(List<string> liasses)
    {
        InitializeComponent();
        this.liasses.AddRange(liasses);
    }

    private bool bLoading;

    private void ImprimerListeFacturationForm_Load(object sender, EventArgs e)
    {
        if ( liasses.Count <= 0 )
        {
            bLoading = true;
            cbLiasse.DataSource = LiasseController.getController().GetLiassesValidees(GlobalConstantes.TypeOperation.Facture, " limit 10 ");
            cbLiasse.DisplayMember = "reference";
            cbLiasse.ValueMember = "Id";
            bLoading = false;
            //                reportViewer1.
        }
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        DoRapport();
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        DoRapport();
    }

    private void DoRapport()
    {
        if ( liasses.Count <= 0 )
        {
            liasses.Add(cbLiasse.SelectedValue.ToString());
        }
        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");


        var parameters = new ReportParameter[]{
            new("Header_Description", hdr_descr),
            new("Header_Agence", hdr_agence)
        };

        reportViewer1.LocalReport.SetParameters(parameters);
        var source = SaisieFactureController.getController().getMasterListeFacturation(liasses);
        facturation_hdr_descrBindingSource.DataSource = source;
        reportViewer1.RefreshReport();
    }

    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var codereg = e.Parameters[0].Values[0];
        var nom_four = e.Parameters["nom_four"].Values[0];
        var reference = e.Parameters["reference"].Values[0];
        Console.WriteLine(nom_four);
        var source = SaisieFactureController.getController().getListeFacturation(liasses, codereg, reference, nom_four);
        e.DataSources.Add(new ReportDataSource("facturation_descr", source));
    }

    private void cbLiasse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!bLoading)
        {
            liasses.Clear();
            DoRapport();
        }
    }

}