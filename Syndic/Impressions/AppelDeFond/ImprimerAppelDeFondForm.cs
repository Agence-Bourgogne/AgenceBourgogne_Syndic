using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Utils;
using SyndicData.Entites;
using SyndicData.Controller;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Config;
using EspaceSyndic.Impressions.RelevesIndividuels;
namespace EspaceSyndic.Impressions.AppelDeFond
{
    public partial class ImprimerAppelDeFondForm : Form
    {
        public ImmeubleEntite immeuble = null;
        AutoCompleteStringCollection lotsString = new AutoCompleteStringCollection();
        BindingSource immeubleSource = new BindingSource();
        String TitreForm;
        public String saisie_id = "";

        public ImprimerAppelDeFondForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void ValidAppelDeFondForm_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (immeuble != null) 
            {
                tbRefImmeuble.Text = immeuble.reference;
                tbRefImmeuble.Enabled = false;
            }
            tbRefImmeuble_Validating(null, null);
            tbText.Text = GetTextAppelFond();
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            btnEnter.Width = 0;
            tbRefImmeuble.Focus();
        }

        private string GetTextAppelFond()
        {
            string txt = "";
            if ( ckFerie.Checked)
                txt = ParametresDB.getParam1("APPEL DE FOND", "FETES");
            else
                txt = ParametresDB.getParam1("APPEL DE FOND", "ENTETE");
            return txt;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateReport( tbLot.Text);
            this.reportViewer1.RefreshReport();
            dataGridView.ClearSelection();
        }

        void CreateReport(string num_lot = "")
        {
            string saisie = saisie_id;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (!row["liasse_id"].ToString().StartsWith("Reprise"))
                    saisie = row["id"].ToString();
                else
                    saisie = "";
                Console.WriteLine(saisie_id);
            }
            dataGridView.Visible = false;

            string commentaire = tbText.Text.ToString();
            if (commentaire == "")
                commentaire = " ";
            if (num_lot != "")
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromReference(immeuble.id, num_lot);
                if (lot == null)
                {
                    MessageBox.Show("Lot Invalide");
                    return;
                }
            }
            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("TexteAppel", commentaire),
                new ReportParameter("DateAppel", dtEntete.Value.ToShortDateString()),
                new ReportParameter("seuil", ParametresDB.getParam1("APPEL DE FOND", "SEUIL")),
                new ReportParameter("appel_delai_payer", ParametresDB.getParam1("IMPRESSION", "APPEL_DELAI_PAYER")),
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
                new ReportParameter("TexteDate", immeuble.texte_date),
            };
            this.reportViewer1.LocalReport.SetParameters(parameters);
           // reportViewer1.LocalReport.DataSources.Clear();
            immeubleSource.DataSource = ImmeubleController.getController().GetDescriptionCoproprietairesImmeubleAF(immeuble.id, num_lot, false, saisie);
            immeubleSource.Filter = "";
            immeublecoproBindingSource.DataSource = immeubleSource;
            reportViewer1.RefreshReport();
        }


        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            string immeuble_id = e.Parameters[0].Values[0];
            string coproprietaire_id = e.Parameters[3].Values[0];
            DataTable source = OperationController.getController().getCoproprietaireOperation(immeuble_id, coproprietaire_id, dtDeb.Value, dtFin.Value);
            e.DataSources.Clear();
            e.DataSources.Add(new ReportDataSource("operation", source));
            immeubleSource.Filter = String.Format("copro_id = '{0}'", coproprietaire_id);
            e.DataSources.Add(new ReportDataSource("immeuble_copro", immeubleSource));
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
            if ( tbRefImmeuble.Enabled )
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                DataTable lots = LotDescriptionController.getController().getListeLot(immeuble.id);

                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);

                if (immeuble.ExerciceCourant == null)
                    MessageBox.Show("Attention pas d'exercice comptable défini");
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
                this.Text = TitreForm;                        
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
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
        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
        }
        private void pleinÉcranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.Fill;
        }
        private void réduireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportViewer1.Dock = DockStyle.None;
        }
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnPrint_Click(null, null);
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
            FindLotCoproprietaireImmeubleForm form = new FindLotCoproprietaireImmeubleForm();
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
            LotDescriptionEntite lot = LotDescriptionController.getController().getLotFromReference(immeuble.id, tbLot.Text);
            if (lot == null)
                tbLot.BackColor = Color.Red;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            ReferenceExerciceForm form = new ReferenceExerciceForm(immeuble);
            form.ShowDialog();
            tbRefImmeuble_Validating(null, null);
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            DateTime dtDeb = DateTime.Parse("01/01/1970");
            DateTime dtFin = DateTime.Parse("01/01/1970");

            dataGridView.DataSource = SaisieAppelFondController.getController().getListeOperations(tbRefImmeuble.Text, dtDeb, dtFin, "", "", true, "");
            DataGridViewColumnCollection cols = dataGridView.Columns;
            ControlsWindows.ToTitleCase(cols);
            cols["statut"].Visible = false;
            cols["id"].Visible = false;
            cols["liasse_id"].Visible = false;
            dataGridView.ClearSelection();
        }

        private void lbParametres_Click(object sender, EventArgs e)
        {
            ConfigParamForm form = new ConfigParamForm();
           
            form.groupe_selected = "APPEL DE FOND";
            form.param_selected = "ENTETE";
            form.ShowDialog();
            tbText.Text = GetTextAppelFond();
        }

        private void ckFerie_CheckedChanged(object sender, EventArgs e)
        {
            tbText.Text = GetTextAppelFond();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (immeuble == null) return;
            List<LotDescriptionEntite> lots = LotDescriptionController.getController().getListeLotDescription(immeuble.id);
            if (lots == null || lots.Count == 0) return;

            this.Enabled = false;
            ExportCopro dlg = new ExportCopro();
            try
            {
                //string serveur = SyndicData.Common.ParametresDB.getParam1("SERVEUR", "ADDRESSE");
                //ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient("BasicHttpBinding_IService", serveur);
                dlg.Show(this);
                dlg.Activate();
                if (!string.IsNullOrEmpty(tbLot.Text) && lots.Exists(x => x.numero_lot.ToString() == tbLot.Text))
                {
                    LotDescriptionEntite lot = lots.FirstOrDefault(x => x.numero_lot.ToString() == tbLot.Text);
                    if (lot.Coproprietaire != null)
                    {
                        CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                        string monthName = new DateTime(2010, 8, 1).ToString("MMM", System.Globalization.CultureInfo.CurrentCulture);
                        string rapportName = "Appel de Fonds " + copro.nom + "_" + monthName + "-" + dtFin.Value.Year.ToString();
                        dlg.textBox1.Text = string.Format("Export Appel de Fonds lot : {0}", lot.numero_lot);
                        dlg.textBox1.Refresh();
                        CreateReport(lot.numero_lot.ToString());
                        UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                    }
                }
                else
                {
                    //  CreateReport("");
                    foreach (LotDescriptionEntite lot in lots)
                    {
                        if (lot != null && lot.Coproprietaire != null)
                        {
                            CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                            string monthName = new DateTime(2010, 8, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);
                            string rapportName = "Appel de Fonds " + copro.nom + "_" + monthName + "-" + dtFin.Value.Year.ToString();
                            dlg.textBox1.Text = string.Format("Export Appel de Fonds lot : {0}", lot.numero_lot);
                            dlg.textBox1.Refresh();
                            CreateReport(lot.numero_lot.ToString());
                            UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                        }
                    }
                    CreateReport("");
                }

                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                MessageBox.Show(ex.Message);
            }
            this.Enabled = true;
            this.Activate();
        }
    }
}
