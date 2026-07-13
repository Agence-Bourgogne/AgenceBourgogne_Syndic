using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Entites;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Coproprietaire;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Impressions.ReleveFiscal
{
    public partial class ReleveFiscalForm : Form
    {
        public ImmeubleEntite immeuble = null;
        BindingSource immeubleSource = new BindingSource();
        AutoCompleteStringCollection lotsString = new AutoCompleteStringCollection();
        string TitreForm;
        public ReleveFiscalForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void ReleveFiscalForm_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            dtDebut.Value = dtFin.Value.AddYears(-1);
            btnEnter.Width = 0;
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            string dateDeb = e.Parameters[0].Values[0];
            string dateFin = e.Parameters[1].Values[0];

            DateTime dtDeb = DateTime.Parse(dateDeb);
            DateTime dtFin= DateTime.Parse(dateFin);
            string coproprietaire_id = e.Parameters[2].Values[0];
            DataTable source = OperationController.getController().GetReleveFiscalCoproprietaire( coproprietaire_id, dtDeb, dtFin);
            immeubleSource.Filter = String.Format("copro_id = '{0}'", coproprietaire_id);

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
            FindImmeubleForm form = new FindImmeubleForm();
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
                DataTable lots = LotDescriptionController.getController().getListeLotFiscaux(immeuble.id);
                ExerciceComptableEntite exercice = immeuble.ExerciceCourant;
                if (exercice != null)
                {
                    dtDebut.Value = exercice.date_deb;
                    dtFin.Value = exercice.date_fin;
                }
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
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
                this.Text = TitreForm;
                btnRapport.Enabled = false;
            }
        }

        private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
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
                if (lotsString.Contains(tbLot.Text))
                    tbLot.BackColor = Color.White;
                else
                    tbLot.BackColor = Color.Red;
            else
                tbLot.BackColor = Color.White;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            FindLotCoproprietaireImmeubleForm form = new FindLotCoproprietaireImmeubleForm();
            form.immeuble = immeuble;
            form.ShowDialog();
            if (form.reference != "")
            {
                tbLot.Text = form.reference;
            }

        }
        void CreateReport(string lot)
        {
            if (immeuble != null)
            {
//                immeubleSource.DataSource = ImmeubleController.getController().GetDescriptionCoproprietairesImmeuble(immeuble.id, tbLot.Text, true);
                immeubleSource.DataSource = ImmeubleController.getController().GetDescriptionCoproprietairesImmeuble(immeuble.id, lot, true);
                immeubleSource.Filter = "";
                immeublecoproBindingSource.DataSource = immeubleSource;

                string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("DateEdition", dtEdition.Value.ToShortDateString()),
                    new ReportParameter("DateDebut", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("DateFin", dtFin.Value.ToShortDateString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };
                this.reportViewer1.LocalReport.SetParameters(parameters);
//                reportViewer1.RefreshReport();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
//            CreateReport();
            List<LotDescriptionEntite> lots = LotDescriptionController.getController().getListeLotDescriptionFiscaux(immeuble.id);
            EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro dlg = new EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro();
            try
            {
//                MessageBox.Show(UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, "Releve Fiscal " + dtDebut.Value.Year, Guid.NewGuid().ToString(), immeuble.id, ""));
                dlg.Show(this);
                dlg.Activate();
                foreach (LotDescriptionEntite lot in lots)
                {
                    if (String.IsNullOrEmpty(tbLot.Text) || lot.numero_lot.ToString() == tbLot.Text)
                    {
                        dlg.textBox1.Text = String.Format("Export releve Fiscal lot : {0}", lot.numero_lot);
                        dlg.textBox1.Refresh();
                        CreateReport(lot.numero_lot.ToString());
                        UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, "Releve Fiscal " + dtDebut.Value.Year.ToString(), Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                    }
                }
                CreateReport("");
                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
