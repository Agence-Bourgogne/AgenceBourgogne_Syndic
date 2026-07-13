using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Impressions.Reglement;

public partial class ImprimerListeReglementForm : Form
{
    public string liasse_id = "";

    public ImprimerListeReglementForm()
    {
        InitializeComponent();
    }

    private void ImprimerRemiseChequeForm_Load(object sender, EventArgs e)
    {
        cbLiasse.DataSource = LiasseController.getController().GetLiassesValidees(GlobalConstantes.TypeOperation.Tresorerie);
        cbLiasse.DisplayMember = "reference";
        cbLiasse.ValueMember = "id";
        if (liasse_id != "")
            cbLiasse.SelectedValue = liasse_id;
        ParametresDB.FillComboFromParams(cbReg, "MODE_REGLEMENT", "param_1", "code");
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        var liasse_id = (string) cbLiasse.SelectedValue;

        if (string.IsNullOrEmpty(liasse_id))
            MessageBox.Show(@"vous n'avez pas selectionner de liasse");
        saisieremisechequeBindingSource.DataSource = SaisieReglementController.getController().GetListeReglementValideFromNature(liasse_id, cbReg.SelectedValue.ToString());
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        reportViewer1.RefreshReport();
    }

    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var liasse_id = e.Parameters[0].Values[0];
        var nature_id = e.Parameters[1].Values[0];
        var comptebanque = e.Parameters[2].Values[0];

        var source = SaisieReglementController.getController().GetListeReglementValideFromCompteBanque(liasse_id, nature_id, comptebanque);
        e.DataSources.Add(new ReportDataSource("detail_operation", source));
    }

}