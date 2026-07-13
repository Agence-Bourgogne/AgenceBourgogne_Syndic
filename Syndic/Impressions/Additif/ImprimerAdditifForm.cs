using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Entites;
using SyndicData.Controller;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Common;
using CommonProjectsPartners.Common;
namespace EspaceSyndic.Impressions.Additif
{
    public partial class ImprimerAdditifForm : Form
    {
        ImmeubleEntite immeuble = null;
        HelpForm infoForm = new HelpForm("aide_additif");
        const  string  TEXT_KEY = "ADDITIF";
        String TitreForm;

        public ImprimerAdditifForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void ImprimerConvocationForm_Load(object sender, EventArgs e)
        {
            btnRapport.Enabled = btnWord.Enabled = false;
            //DateTime dt = DateTime.Now;
            //tbDateEntete.Text = dt.ToShortDateString();
            //tbDateAssemblee.Text = GetDateAssemblee();
            tbLieu.Text = GetLieuAssemblee();
            tbHeure.Text = GetHeureAssemblee();
            cbConvoc.SelectedIndex = 0;
            btnEnter.Width = 0;

        }
        private string GetHeureAssemblee()
        {
            return "1800";
        }
        private string GetDateAssemblee()
        {
            return DateTime.Now.ToShortDateString();
        }
        private string GetLieuAssemblee()
        {
            string lieu = "";
            if (immeuble != null)
                lieu = immeuble.lieuconv;
            if ( lieu == "")
                lieu = "AGENCE Bourgogne 45 rue des Carmes 45000 ORLEANS";
            return lieu;
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

        private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
        {
            lblImmeuble_Click(sender, e);
        }
        private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    if (sender.Equals(tbRefImmeuble))
                        lblImmeuble_Click(sender, null);
                    //if (sender.Equals(tbNature))
                    //    lblNature_Click(null, null);
                    //if (sender.Equals(tbFournisseur))
                    //    lblFournisseur_Click(null, null);
                }
        }
        ImmeubleRepartitionEntite repart;
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, TEXT_KEY);
                repart = ImmeubleRepartitionController.getController().getRepartitionImmeubleEntite(immeuble.id);
                if (comment != null)
                {
                    tbText.Text = comment.libelle;
                }
                else
                    tbText.Text = "";

                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);

                infoForm.DoFormText(this, immeuble.note);
                try
                {
                    dtDateAssemblee.Value = immeuble.dateass;
                }
                catch (Exception ex)
                {

                }
                tbLieu.Text = GetLieuAssemblee();
                btnRapport.Enabled = btnWord.Enabled = true;
            }
            else
            {
                this.Text = TitreForm;
                btnRapport.Enabled = btnWord.Enabled = false;
                infoForm.Hide();
            }
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }

        void CreateReport(string num_lot = "")
        {
            String repart_valeur = String.Format("{0}", repart.valeur);
            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("DateEntete", dtDateEntete.Value.ToShortDateString()),
                new ReportParameter("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
                new ReportParameter("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
                new ReportParameter("OrdreDuJour", tbText.Text),
                new ReportParameter("Convocation", "Convocation "+ cbConvoc.SelectedItem),
                new ReportParameter("repart_immeuble", repart_valeur),
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
                new ReportParameter("LieuAssemblee", tbLieu.Text)
            };
            reportViewer1.LocalReport.SetParameters(parameters);
            if(string.IsNullOrEmpty(num_lot))
                this.tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
            else
                this.tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id,num_lot);

            reportViewer1.RefreshReport();
        }
        private void btnWord_Click(object sender, EventArgs e)
        {

            NpgsqlParameter[] parameters = new NpgsqlParameter[]{
                new NpgsqlParameter("DateEntete", dtDateEntete.Value.ToShortDateString()),
                new NpgsqlParameter("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
                new NpgsqlParameter("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
                new NpgsqlParameter("OrdreDuJour", tbText.Text),
                new NpgsqlParameter("Convocation", "Convocation "+ cbConvoc.SelectedItem),
                new NpgsqlParameter("LieuAssemblee", tbLieu.Text)
            };

            DataTable table = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionWord(immeuble.id, parameters);

            String modele = ParametresDB.getParam1("MODELES", "ADDITIF");
            BaseApplication.PublipostageLettreWord(table, modele);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FicheAideImmeubleForm form = new FicheAideImmeubleForm(immeuble, TEXT_KEY);
            form.ShowDialog();
            AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, TEXT_KEY);
            if (comment != null)
            {
                tbText.Text = comment.libelle;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void ImprimerAdditifForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (immeuble == null) return;
            List<LotDescriptionEntite> lots = LotDescriptionController.getController().getListeLotDescription(immeuble.id);
            EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro dlg = new EspaceSyndic.Impressions.RelevesIndividuels.ExportCopro();
            try
            {
                dlg.Show(this);
                dlg.Activate();
                foreach (LotDescriptionEntite lot in lots)
                {
                    if (lot != null && lot.Coproprietaire != null)
                    {
                        CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                        string monthName = new DateTime(2010, 8, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);
                        string rapportName = "Additif convocation " + cbConvoc.SelectedItem + " " + dtDateEntete.Value.Year.ToString();
                        dlg.textBox1.Text = string.Format("Export Additif convocation lot : {0}", lot.numero_lot);
                        dlg.textBox1.Refresh();
                        CreateReport(lot.numero_lot.ToString());
                        UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                    }
                }
                CreateReport();
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
