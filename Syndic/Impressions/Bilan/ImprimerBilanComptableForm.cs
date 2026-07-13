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
using EspaceSyndic.Formulaires.Immeubles;
using Npgsql;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Exercice;
using CommonProjectsPartners.Common;
namespace EspaceSyndic.Impressions.Bilan
{
    public partial class ImprimerBilanComptableForm : Form
    {
        ImmeubleEntite immeuble = null;
        List<NatureEntite> natTravaux;
        List<NatureEntite> natSolde;
        decimal chargesNormales, chargesTravaux, chargesPrivatives, depenses, soldeBilan, reglements;
        decimal avancePermanente, soldeExercice, totalDebit, totalCredit;
        List<string> baseIndividuelle = new List<string> { "80" };
        List<string> excludeNature = new List<string> { "090", "091", "092", "093" };
//        List<string> baseIndividuelle = new List<string> { "80", "81", "82", "83", "84", "85", "86", "87" };
        //List<string> baseIndividuelle = new List<string> { "81", "82", "83", "84", "85", "86", "87" };
        string TitreForm;
        public ImprimerBilanComptableForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
            if ( UtilsApp.ServiceReferenceUtils.ServiceClientIsConfigured() )
                btnExport.Visible = true;
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
//                tbRefImmeuble_Validating(null, null);
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
                }

        }

        private NatureEntite getNatureCloture()
        {
            string reference = ParametresDB.getParam1("CLOTURE", "NATURE");
            return NatureController.getController().getEntiteFromField("reference", reference);
        }

        private void ImprimerBilanComptableForm_Load(object sender, EventArgs e)
        {
            btnRapport.Enabled = false;
            btnExport.Enabled = false;
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-dt.DayOfYear +1);
            dtDebut.Value = dt;
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            btnEnter.Width = 0;
            List<NatureEntite> natures = NatureController.getController().GetListEntite();
            natTravaux = natures.FindAll(x=> (x.type_charge & 2) == 2);
//            natSolde = natures.FindAll(x=> (x.type_charge & 5) == 5);
            natSolde = new List<NatureEntite> { getNatureCloture() };
            String excl = ParametresDB.getParam1("NATURE", "PAS PRIVATIVES");
            if ( !String.IsNullOrEmpty(excl))
            {
                excl = excl.Replace(", ", ",").Replace(" ,",",");
                string[] lExcl = excl.Split(',');
                excludeNature.Clear();
                excludeNature.AddRange(lExcl);
            }
        }
        private bool isRepartIndividuelle(string base_repart, string refNature)
        {
            bool isIndividuelle = false;
            if (!excludeNature.Contains(refNature))
                isIndividuelle = baseIndividuelle.Contains(base_repart);
            return isIndividuelle;
        }
        private bool isNatureTravaux(string nature)
        {
            bool isTravaux = false;
            isTravaux = natTravaux.Find(x=>x.reference == nature)  != null;
            return isTravaux;
        }
        private bool isNatureSolde(string nature)
        {
            bool isNatureSolde = false;
            isNatureSolde = natSolde.Find(x => x.reference == nature) != null;
            return isNatureSolde;
        }
        private void Cumuls()
        {
            chargesNormales= chargesTravaux= chargesPrivatives = depenses= soldeBilan = reglements = 0;
            avancePermanente = LotDescriptionController.getController().getAvanceImmeuble( immeuble.id);
            soldeExercice = totalDebit = totalCredit = 0;
            foreach (DataRow row in CompteGestionGeneral.Rows)
            {
                bool isIndividuelle = isRepartIndividuelle(row["base_repart"].ToString(), row["reference"].ToString());
                bool isTravaux = isNatureTravaux(row["reference"].ToString());
                decimal charges = (decimal)row["debit"] - (decimal)row["credit"];
                depenses += charges;
                if (!isTravaux && !isIndividuelle)
                {
                    chargesNormales += charges;
                }
                else
                    if (isIndividuelle)
                        chargesPrivatives += charges;
                    else
                        chargesTravaux += charges;
                totalDebit += (decimal)row["debit"];
                totalCredit += (decimal)row["credit"];
            }

            foreach (DataRow row in BilanOperationsCoproprietairesSoldes.Rows)
            {
                decimal charges = (decimal)row["credit"] - (decimal)row["debit"];
                soldeBilan += charges;
            }
            foreach (DataRow row in BilanOperationsCoproprietairesPaiements.Rows)
            {
                decimal charges = (decimal)row["credit"] - (decimal)row["debit"];
                Console.WriteLine("{1} {0} {2} {3} {4} ", row["libelle"], row["reference"], (decimal)row["credit"] , (decimal)row["debit"], charges);
                reglements += charges;
            }
// Mantis 134 mais Pa OK mantis 136 => 134 c'est relevé individuel
//            reglements += totalCredit;
            soldeExercice = soldeBilan + reglements - depenses + avancePermanente;
            
            Console.WriteLine("Solde en Bilan : {0} {1} {2} {3}", soldeBilan, reglements, depenses, avancePermanente);
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            CreateReport();
            this.reportViewer1.RefreshReport();
        }
        void CreateReport()
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> { new NpgsqlParameter("@reference", tbRefImmeuble.Text) };
            immeubleBindingSource.DataSource = ImmeubleController.getController().getDataTable(" where reference = @reference", parameters);
            if (immeubleBindingSource.DataSource != null)
            {
                CompteGestionGeneral = SaisieFactureController.getController().getCompteGestionGeneral(immeuble.id, dtDebut.Value, dtFin.Value);
                
                // TODO Paramétrer les natures
                BilanOperationsCoproprietairesSoldes = OperationController.getController().getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value, " n.reference = '140'");
                BilanOperationsCoproprietairesPaiements = OperationController.getController().getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value, " n.reference != '140' and n.reference != '145' ", true);
                BilanOperationsCoproprietairesAppelDeFond = OperationController.getController().getBilanOperationsCoproprietaires(immeuble.id, dtDebut.Value, dtFin.Value, " n.reference = '145' ");

                //BaseApplication.GenerateDataSource(CompteGestionGeneral, "c:\\export_syndic\\compte_gestion.csv", Encoding.UTF8);
                //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesSoldes, "c:\\export_syndic\\soldes.csv", Encoding.UTF8);
                //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesPaiements, "c:\\export_syndic\\paiements.csv", Encoding.UTF8);
                //BaseApplication.GenerateDataSource(BilanOperationsCoproprietairesAppelDeFond, "c:\\export_syndic\\appels.csv", Encoding.UTF8);



                Cumuls();
                string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
                string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

                ReportParameter[] reportParams = new ReportParameter[]{
                    new ReportParameter("DateEdition", dtEdition.Value.ToShortDateString()),
                    new ReportParameter("DateDebut", dtDebut.Value.ToShortDateString()),
                    new ReportParameter("DateFin", dtFin.Value.ToShortDateString()),
                    new ReportParameter("chargesNormales", chargesNormales.ToString()),
                    new ReportParameter("chargesTravaux", chargesTravaux.ToString()),
                    new ReportParameter("chargesPrivatives", chargesPrivatives.ToString()),
                    new ReportParameter("soldeBilan", soldeBilan.ToString()),
                    new ReportParameter("reglements", reglements.ToString()),
                    new ReportParameter("depenses", depenses.ToString()),
                    new ReportParameter("avancePermanente", avancePermanente.ToString()),
                    new ReportParameter("soldeExercice", soldeExercice.ToString()),
                    new ReportParameter("totalDebit", totalDebit.ToString()),
                    new ReportParameter("totalCredit", totalCredit.ToString()),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };

                this.reportViewer1.LocalReport.SetParameters(reportParams);
            }

        }
        DataTable CompteGestionGeneral;
        DataTable BilanOperationsCoproprietairesSoldes;
        DataTable BilanOperationsCoproprietairesPaiements;
        DataTable BilanOperationsCoproprietairesAppelDeFond;
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            //Console.WriteLine(sender.ToString());
            LocalReport rpt = (LocalReport)sender;
//            Console.WriteLine(rpt.DisplayName);

            string immeuble_id = immeuble.id;
            string rapport = e.Parameters[0].Values[0];

            e.DataSources.Clear();
            if (rapport == "1")
            {
                e.DataSources.Add(new ReportDataSource("CompteGestionGeneral", CompteGestionGeneral));
            }
            if (rapport == "2")
            {
                e.DataSources.Add(new ReportDataSource("CompteGestionGeneral", CompteGestionGeneral));
            }
            if (rapport == "3")
            {
                e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesSolde", BilanOperationsCoproprietairesSoldes));
                e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesPaiements", BilanOperationsCoproprietairesPaiements));
                e.DataSources.Add(new ReportDataSource("BilanOperationsCoproprietairesAppel", BilanOperationsCoproprietairesAppelDeFond));
            }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                ExerciceComptableEntite exercice = ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                if (exercice != null)
                {
                    dtDebut.Value = exercice.date_deb;
                    dtFin.Value = exercice.date_fin;
                }
                tbRefImmeuble.BackColor = Color.White;
                btnRapport.Enabled = true;
                btnExport.Enabled = true;
            }
            else
            {
                this.Text = TitreForm;

                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                btnRapport.Enabled = false;
                btnExport.Enabled = false;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            ReferenceExerciceForm form = new ReferenceExerciceForm(immeuble);
            form.ShowDialog();
            tbRefImmeuble_Validating(null, null);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CreateReport();
            try
            {
                MessageBox.Show(UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, "Bilan Comptable " + dtDebut.Value.Year, Guid.NewGuid().ToString(), immeuble.id, ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
