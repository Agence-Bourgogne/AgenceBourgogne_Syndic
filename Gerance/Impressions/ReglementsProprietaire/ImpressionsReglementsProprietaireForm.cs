using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GeranceData.Controller;
using CommonProjectsPartners.Utils;

namespace Gerance.Impressions.ReglementsProprietaire
{
    public partial class ImpressionsReglementsProprietaireForm : Formulaires.Common.CommonRapportForm
    {
        public ImpressionsReglementsProprietaireForm()
        {
            InitializeComponent();
        }

        private void ImpressionsReglementsProprietaireForm_Load(object sender, EventArgs e)
        {
            //label1.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            //dtDebut.Visible = false;
            //dtFin.Visible = false;
            var dt = DateTime.Now;
            dtDebut.Value = new DateTime(dt.Year, dt.Month, 1);
            dtFin.Value = dtDebut.Value.AddMonths(1).AddDays(-1);
            var pos = label3.Location;
            pos.X -= 20;
            label3.Location = pos;
            label3.Text = "Date écriture";
            FillRapport();
            reportViewer1.PrintingBegin += reportViewer1_PrintingBegin;
        }
        bool bUpdateRequired = false;
        void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            bUpdateRequired = true;
        }

        private void FillRapport()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            var virements = ProprietaireController.getController().getImpressionListePaiementsLoyers(1 , dtDebut.Value, dtFin.Value);
            var cheques = ProprietaireController.getController().getImpressionListePaiementsLoyers(0, dtDebut.Value, dtFin.Value);
            
            decimal totalVirement = 0;
            foreach (DataRow row in virements.Rows)
            {
                totalVirement += Convertir.ToDecimal(row["montant"].ToString());
            }
            //decimal totalCheque = 0;
            foreach (DataRow row in virements.Rows)
            {
                totalVirement += Convertir.ToDecimal(row["montant"].ToString());
            }


            var parameters = new ReportParameter[]{
                    new ReportParameter("totalVirement", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("totalCheque", dtDebut.Value.ToShortDateString()),

                };

//            reportViewer1.LocalReport.SetParameters(parameters);


            if ( virements.Rows.Count <=0 && cheques.Rows.Count <= 0 )
            {
                MessageBox.Show("Aucune données avec ces Paramètres");
                return;
            }
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ListeVirementsLoyers", virements));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ListeChequesLoyers", cheques));
            reportViewer1.RefreshReport();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UpdateHonoraireProprio();
        }
        private void UpdateHonoraireProprio()
        {
            var form = new UpdateHonoraireProprioForm(dtDebut.Value, dtFin.Value, dtEdition.Value);
            form.ShowDialog();
        }

        private void ImpressionsReglementsProprietaireForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bUpdateRequired)
                UpdateHonoraireProprio();
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            FillRapport();
        }

    }
}
