using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Common;

namespace EspaceSyndic.Impressions.Facture
{
    public partial class ImprimerListeFacturationForm : Form
    {
        public List<string> liasses = new List<string>();

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
        bool bLoading = false;

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
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
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
            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");


            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
            };

            this.reportViewer1.LocalReport.SetParameters(parameters);
            DataTable source = SaisieFactureController.getController().getMasterListeFacturation(liasses);
            this.facturation_hdr_descrBindingSource.DataSource = source;
            this.reportViewer1.RefreshReport();
        }

        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            string codereg = e.Parameters[0].Values[0];
            string nom_four = e.Parameters["nom_four"].Values[0];
            string reference = e.Parameters["reference"].Values[0];
            Console.WriteLine(nom_four);
            DataTable source = SaisieFactureController.getController().getListeFacturation(liasses, codereg, reference, nom_four);
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
}
