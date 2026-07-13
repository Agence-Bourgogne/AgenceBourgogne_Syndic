using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
using GeranceData.Entites;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Biens;
namespace Gerance.Formulaires.AppelALoyer
{
    public partial class AppelALoyerListeForm : Common.CommonGridviewForm
    {
        public AppelALoyerListeForm()
        {
            InitializeComponent();
        }
        protected override void InitializeCombos()
        {

            var dt = DateTime.Parse("01/01/2000");

            for (var i = 0; i < 12; i++)
            {
                var lDate = dt.ToLongDateString().Split(' ');
                cbMonth.Items.Add(lDate[2]);
                dt = dt.AddMonths(1);
            }
            cbMonth.SelectedIndex = DateTime.Now.AddMonths(1).Month - 1;

            dt = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
            dateDebut.Value = dt;
            dateFin.Value = dt.AddMonths(1).AddDays(-1);
            dateFinTrimestre.Value = dt.AddMonths(3).AddDays(-1);

            cbType.Items.Add("Mensuel et Trimestriel");
            cbType.Items.Add("Mensuel");
            cbType.Items.Add("Trimestriel");
            cbType.SelectedIndex = 0;
        }

        private void AppelALoyerListeForm_Load(object sender, EventArgs e)
        {
//            InitializeCombos();

            FillDataGrid();

            dataGridView.Height = gbFactures.Height - (dataGridView.Location.Y)*2;
            reportViewer1.Visible = false;
            reportViewer1.Location = dataGridView.Location;
            reportViewer1.Width = dataGridView.Width;
            reportViewer1.Height = dataGridView.Height;
            reportViewer1.Anchor = dataGridView.Anchor;
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            reportViewer1.PrintingBegin += reportViewer1_PrintingBegin;
        }
        bool bHaveToUpdate = false, bPrintedQuittance = false, bPrintedAppel = false;
        void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
//            UpdateDossiers();
            bHaveToUpdate = true;
            if (typeReport == "1")
                bPrintedQuittance = true;
            else
                bPrintedAppel = true;
        }

        protected override void FillDataGrid()
        {
            var iMonth = -1;
            if (ckLoyer.Checked)
                iMonth = cbMonth.SelectedIndex + 1;

            dataGridView.DataSource = BienController.getController().getListeAppelsLoyer(iMonth, tbRefLocataire.Text, tbNomLocataire.Text, tbRefImmeuble.Text, tbNomImmeuble.Text, cbType.SelectedIndex, ckGul.Checked ? 1:0 , ckNullLoyer.Checked);
            
            if (dataGridView.DataSource != null)
            {
                var cols = dataGridView.Columns;
                cols["locataire"].MinimumWidth = 120;
                cols["proprietaire"].MinimumWidth = 120;
                cols["ref_immeuble"].Width = 50;
                cols["ref_locataire"].Width = 50;
                cols["id"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
            }
        }
        private void ckLoyer_CheckedChanged(object sender, EventArgs e)
        {
            cbMonth.Enabled = ckLoyer.Checked;
            FillDataGrid();
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }


        protected override void ShowFicheForm(string entite_id)
        {
            var form = new AppelALoyerFicheForm(entite_id, dataGridView);
            form.ShowDialog();
            FillDataGrid();
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void tbNomLocataire_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            reportViewer1.Visible = false;
            FillDataGrid();
        }
        string typeReport = "1";
        List<string> quittancePrinted = new List<string>();
        List<string> appelPrinted = new List<string>();
        private void btnGrid_Click(object sender, EventArgs e)
        {
            var form = new AppelALoyerImpressionForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                dataGridView.Visible = false;
                reportViewer1.Visible = true;

                if (form.rdLoyer.Checked || form.rdAugment.Checked)
                {
                    typeReport = "0";
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.AppelALoyer.AppelALoyerMasterReport.rdlc";
                }
                if (form.rdQuittance.Checked)
                {
                    typeReport = "1";
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Gerance.Formulaires.AppelALoyer.QuittanceLoyerMasterReport.rdlc";
                }

                var hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                var hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
                var hdr_description_small = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION_SMALL");

                var dtFin = dateFin.Value;
                if (cbType.SelectedIndex == 2)
                    dtFin = dateFinTrimestre.Value;
                
                var parameters = new ReportParameter[]{
                    new ReportParameter("typeReport", typeReport),
                    new ReportParameter("dateEdition", DateTime.Now.ToShortDateString()),
                    new ReportParameter("dateDebut", dateDebut.Value.ToShortDateString()),
                    new ReportParameter("dateFin", dtFin.ToShortDateString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                    new ReportParameter("Header_Description_Small", hdr_description_small),
                };

                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                var bind = new BindingSource();
                bind.DataSource = dataGridView.DataSource;
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("list_biens", bind));
                try
                {
                    reportViewer1.RefreshReport();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
            }
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            if (e.Parameters.Count > 0)
            {
                var bien_id = e.Parameters["bien_id"].Values[0];
                var typeReport = e.Parameters["typeReport"].Values[0];

                var detailQuittance = new BindingSource();
                DataTable table;
                if ( typeReport == "1")
                {
                    var dtDeb = DateTime.Parse(e.Parameters["dateDebut"].Values[0]);
                    //e.Parameters["dateFin"].Values[0] = dtDeb.AddMonths(3).ToShortDateString();
                    
                    table = BienController.getController().getDetailQuittanceFromQuittance(bien_id, dtDeb);
                    if ( table == null || table.Rows.Count < 1)
                        table = BienController.getController().getDetailQuittance(bien_id);
                    if (!quittancePrinted.Contains(bien_id))
                        quittancePrinted.Add(bien_id);
                }
                else
                {
                    var dtDeb = DateTime.Parse(e.Parameters["dateDebut"].Values[0]);
                    table = BienController.getController().getDetailAppelDeLoyer(bien_id, dtDeb);
                    if (!appelPrinted.Contains(bien_id))
                        appelPrinted.Add(bien_id);
                }


                var row = table.Rows[0];
                row["imm_adress"] = row["imm_adress"].ToString().Replace("\n", " ");
                detailQuittance.DataSource = table; //BienController.getController().getDetailAppelDeLoyer(bien_id);

                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("QuittanceLoyerLocataire", detailQuittance));
            }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void tbNomImmeuble_Validating(object sender, CancelEventArgs e)
        {
             FillDataGrid();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDossiers();
        }
        private void UpdateDossiers()
        {
            var form = new UpdateDossierForm();
            form.ShowDialog();
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowFindForm(new BienFindForm(), tbRefImmeuble))
                tbRefLocataire_Validating(null, null);
        }

        private void lblLocataire_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ShowFindForm(new LocataireFindForm(), tbRefLocataire))
                tbRefLocataire_Validating(null, null);
        }

        private void standard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    if (sender == tbRefImmeuble)
                        lblImmeuble_Click(null, null);
                    if (sender == tbRefLocataire)
                        lblLocataire_Click(null, null);
                    e.Handled = true;
                }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var colsToHide = new List<string> { "id" };
            var obj = BaseApplication.DataGridToExcel(dataGridView, colsToHide);

            BaseApplication.ColumnFormula(obj, 9, "=F{0}+G{0}+H{0}", "Total", 1);
            BaseApplication.ColumnFormula(obj, 10,"=I{0}*3/100", "GUL", 1);
        }

        private void ckGul_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        const int REFERENCE_TACHE = 4;

        private void AppelALoyerListeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bHaveToUpdate)
                UpdateDossiers();
            if ( bPrintedQuittance)
                if (quittancePrinted.Count > 0)
                {
                    var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE + 1, dateDebut.Value);
                    foreach (var bien_id in quittancePrinted)
                    {
                        WorkflowDetailController.getController().WriteRecord(workflow, bien_id, "Impression");
                    }
                    WorkflowController.FireWorkflowChanged();
                }
            if ( bPrintedAppel)
                if (appelPrinted.Count > 0)
                {
                    var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE , dateDebut.Value);
                    foreach (var bien_id in appelPrinted)
                    {
                        WorkflowDetailController.getController().WriteRecord(workflow, bien_id, "Impression");
                    }
                    WorkflowController.FireWorkflowChanged();
                }
        }

        private void ckNullLoyer_CheckedChanged_1(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void dateDebut_Validating(object sender, CancelEventArgs e)
        {
            var dt = dateDebut.Value;
            dateFin.Value = dt.AddMonths(1).AddDays(-1);
            dateFinTrimestre.Value = dt.AddMonths(3).AddDays(-1);
        }
    }
}
