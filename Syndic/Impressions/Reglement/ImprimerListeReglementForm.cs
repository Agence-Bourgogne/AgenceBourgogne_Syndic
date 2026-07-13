using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Common;

namespace EspaceSyndic.Impressions.Reglement
{
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
            //string nature_id = "899BE15C5ABA4476BF9F29B9C3D0C595";
            // TODO Peux etre donner la possibilite d'imprimer des liasses Non Validees
            if (liasse_id == null || liasse_id == "")
                MessageBox.Show("vous n'avez pas selectionner de liasse");
            saisieremisechequeBindingSource.DataSource = SaisieReglementController.getController().GetListeReglementValideFromNature(liasse_id, cbReg.SelectedValue.ToString());
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            reportViewer1.RefreshReport();
        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            var liasse_id = e.Parameters[0].Values[0];
            var nature_id = e.Parameters[1].Values[0];
            var comptebanque = e.Parameters[2].Values[0];

            var source = SaisieReglementController.getController().GetListeReglementValideFromCompteBanque(liasse_id, nature_id, comptebanque);
            e.DataSources.Add(new ReportDataSource("detail_operation", source));
        }

    }
}
