using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Entites;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using CommonProjectsPartners.Common;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using EspaceSyndic.Formulaires.Config;

namespace EspaceSyndic.Impressions.Convocations
{
    public partial class ImprimerConvocationForm : Form
    {
        //===================================================================  modif version 1.0.0.95 chiffre en lettre
        private static string[] units = { "", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf" };
        private static string[] teens = { "", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
        private static string[] tens = { "", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix" };

        bool ForExport = false;
        string currentLot = "";
        public static string ConvertToWords(double number)
        {
            if (number == 0)
                return "zéro";

            if (number < 0)
                return "moins " + ConvertToWords(Math.Abs(number));

            string words = "";

            long integerPart = (long)Math.Floor(number);
            words = ConvertToWordsInternal(integerPart);
            //long fractionalPart = (long)(Math.Round((number - integerPart), 2) * 100); // الأجزاء العشرية

            //words = ConvertToWordsInternal(integerPart) + " Dinar ";

            //if (fractionalPart > 0)
            //{
            //    words += " et " + ConvertToWordsInternal(fractionalPart) + " Centime ";
            //}

            return words;
        }
        private static string ConvertToWordsInternal(long number)
        {
            string words = "";

            if ((number / 1000000000000) > 0)
            {
                words += ConvertToWordsInternal(number / 1000000000000) + " Billion ";
                number %= 1000000000000;
            }

            if ((number / 1000000000) > 0)
            {
                words += ConvertToWordsInternal(number / 1000000000) + " milliard ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertToWordsInternal(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertToWordsInternal(number / 1000) + " mille ";
                if (words == "un mille ")
                {
                    words = "mille ";
                }
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                if (number < 200)
                    words += "cent ";
                else
                    words += units[number / 100] + " cent ";
                number %= 100;
            }

            if (number > 0)
            {
                if (number < 10)
                    words += units[number];
                else if (number < 20 && number != 10)
                    words += teens[number - 10];
                else
                {
                    if (number > 90 && number < 100)
                    {
                        words += "quatre-vingt-" + teens[(number - 90)];
                    }
                    else if (number > 70 && number < 80)
                    {
                        words += "soixante-" + teens[(number - 70)];
                    }
                    else
                    {
                        words += tens[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + units[number % 10];
                    }
                }
            }

            return words.Trim();
        }
        //===================================================================  
        ImmeubleEntite immeuble = null;
        HelpForm infoForm = new HelpForm("aide_convocation");
        string TitreForm;
        public ImprimerConvocationForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void ImprimerConvocationForm_Load(object sender, EventArgs e)
        {
            btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = false;
            //DateTime dt = DateTime.Now;
            //tbDateEntete.Text = dt.ToShortDateString();
            //tbDateAssemblee.Text = GetDateAssemblee();
            tbLieu.Text = GetLieuAssemblee();
//            tbHeure.Text = GetHeureAssemblee();
            cbConvoc.SelectedIndex = 0;
            btnEnter.Width = 0;
            
            reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
#if DEBUG
    
#else
           btnPV.Visible = false;
           btnExport.Visible = false;
#endif
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
            if (lieu == "")
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
                }
        }
        ImmeubleRepartitionEntite repart;

        void SetTextHeader()
        {
            String aide = "CONVOCATION";
            if (immeuble != null)
            {
                AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, aide);
                if (comment != null)
                {
                    tbText.Text = comment.libelle;
                }
            }
        }
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            SetTextHeader();
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                repart = ImmeubleRepartitionController.getController().getRepartitionImmeubleEntite(immeuble.id);
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                infoForm.DoFormText(this, immeuble.note);
                if ( immeuble.dateass.Year > 2000 )
                    dtDateAssemblee.Value = immeuble.dateass;
                tbLieu.Text = GetLieuAssemblee();
                btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = true;
            }
            else
            {
                this.Text = TitreForm;
                btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = false;
                infoForm.Hide();
            }
        }
        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            Console.WriteLine(e.ReportPath);
            e.DataSources.Clear();
            if (e.ReportPath == "ConvocationReport" ) 
            {
                BindingSource src = new BindingSource();
                if(ForExport)
                    src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, currentLot);
                else
                    src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
                src.Filter = "valeur <> 0";
                e.DataSources.Add(new ReportDataSource("convocation", src));
            }
            if (e.ReportPath == "ConvocationViergeReport")
            {
                if (ForExport)
                    e.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, currentLot, false, " Limit 1")));
                else
                    e.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, false, " Limit 1" )));
            }
            if (e.ReportPath.EndsWith("FeuillePresence.rdlc"))
            {
                BindingSource src = new BindingSource();
                if (ForExport)
                    src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, currentLot, true);
                else
                    src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, true);
                src.Filter = "valeur <> 0";
                e.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", src));
//                e.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, true)));
            }
        }

        string getOrdre(string[] lines)
        {
            string text = "";
            //int tabWidth = 4;
            //int minTab = 120;
            
            foreach (string l in lines)
            {
                text += l.Replace("\t", "    ")+"\n";
            }
            Console.WriteLine(text);
            return text;
        }

       // string[] yearText = { "QUATORZE", "QUINZE", "SEIZE", "DIX-SEPT", "DIX-HUIT", "DIX-NEUF", "VINGT", "VINGT ET UN", "VINGT DEUX", "VINGT TROIS" };
        private void btnRapport_Click(object sender, EventArgs e)
        {
            CreateReport();
        }

        void CreateReport(string num_lot = "")
        {
            ForExport = !string.IsNullOrEmpty(num_lot);
            currentLot = num_lot;
            string yearAss = String.Format(" {0}", dtDateAssemblee.Value.Year);
            string dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");
            string anneeAssemblee = ConvertToWords(dtDateAssemblee.Value.Year).ToUpper(); // ConvertAmount(dtDateAssemblee.Value.Year);
            //---------------------------------------------------
            string ordre = tbText.Text;//.Replace("\t", "........");
            if (String.IsNullOrWhiteSpace(tbHeure.Text.Replace(":", "")))
            {
                MessageBox.Show("L'heure de convocation n'est pas renseignée");
                return;
            }

            ordre = getOrdre(tbText.Lines);
            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("DateEntete", dtDateEntete.Value.ToShortDateString()),
                new ReportParameter("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
                new ReportParameter("DateLimite", ""),//dtLimite.Value.ToShortDateString()),
                new ReportParameter("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
                new ReportParameter("OrdreDuJour", ordre),
                new ReportParameter("Convocation", "Convocation "+ cbConvoc.SelectedItem),
                new ReportParameter("repart_immeuble", String.Format("{0}", repart.valeur)),
                new ReportParameter("paragraphe_decret", ParametresDB.getParam1("IMPRESSION", "PARAGRAPHE_DECRET")),
                new ReportParameter("paragraphe_decret_contenu", ParametresDB.getParam1("IMPRESSION", "PARAMETRE_DECRET_CONTENU")),
                new ReportParameter("LieuAssemblee", tbLieu.Text),
                new ReportParameter("AdresseImmeuble", immeuble.Adresse),
                new ReportParameter("AnneeAssemblee", anneeAssemblee),
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
                new ReportParameter("DateAssembleeText", dateAssemblee)
            };
            //            Console.WriteLine(ordre);
            MajdateAssemblee();

            if ((int)CommonRegistry.getRegistryValue("convocation", "type_convocation", 0) == 1)
            {
                if (string.IsNullOrEmpty(num_lot))
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id)));
                else
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, num_lot)));
               // reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id)));
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationReport.rdlc";
            }
            else
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationMasterReport.rdlc";

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }

        List<String[]> GetTablePresence(DataTable table)
        {
            List<String[]> datas =new List<string[]>();

            foreach (DataRow row in table.Rows)
            {
                String[] data = new String[4];
                data[0] = String.Format("{0} {1}\r\n{2}\r\n{3} {4}", row["Civilite"], row["coproprietaire"], row["adressecoproprietaire"], row["codepostalcoproprietaire"], row["villecoproprietaire"]);
                data[1] = row["referencecoproprietaire"].ToString();
                data[2] = "";
                data[3] = row["valeur"].ToString();// +"/ " + repart.valeur;
                datas.Add(data);
            }

            return datas;
        }

        String GetDocOrdreDuJour()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Document Word (*.docx)|*.docx|Tous les fichiers|*.*";
            dlg.Title = "Choisir le document Ordre du jour";
            if (dlg.ShowDialog() != DialogResult.OK)
                return "";
            if (!File.Exists(dlg.FileName))
                return "";
            return dlg.FileName;
        }

        NpgsqlParameter[] ParamTextDateAssemblee()
        {
            //-------------------------------------------------
            //int posYear = dtDateAssemblee.Value.Year - 2014;
            //string anneeAssemblee = "DEUX MILLE ";
            //if (posYear >= 0 && posYear < yearText.Length)
            //    anneeAssemblee += yearText[posYear];
            //string yearAss = String.Format(" {0}", dtDateAssemblee.Value.Year);
            //string dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");
            string yearAss = String.Format(" {0}", dtDateAssemblee.Value.Year);
            string dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");
            string anneeAssemblee = ConvertToWords(dtDateAssemblee.Value.Year).ToUpper(); // ConvertAmount(dtDateAssemblee.Value.Year);
            //-----------------------------------------------------------------------------------------
            NpgsqlParameter[] parameters = new NpgsqlParameter[]{
                new NpgsqlParameter("AnneeAssemblee", anneeAssemblee),
                new NpgsqlParameter("DateAssembleeText", dateAssemblee),
            };
            return parameters;
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbHeure.Text.Replace(":", "")))
            {
                MessageBox.Show("L'heure de convocation n'est pas renseignée");
                return;
            }
            string OrdreJour = GetDocOrdreDuJour();
            if (String.IsNullOrWhiteSpace(OrdreJour))
                return;
            String FeuillePresence = BaseApplication.GetTempFileName("docx");
            String ConvocWord = BaseApplication.GetTempFileName("docx");

            String ConvocHdr = BaseApplication.GetTempFileName("docx");
            String ConvocCopro = BaseApplication.GetTempFileName("docx");
            String PathConvoc = @"C:\Syndic_Modeles\Convocations\";
            String LiasseConvoc = Path.Combine(PathConvoc, String.Format("convocations_{0}_{1}", immeuble.reference, dtDateAssemblee.Value.ToString("yyyyMMdd")));
            string modeleConvocation = ParametresDB.getParam1("MODELES", "CONVOCATIONS");
            string modelePresence = @"c:\syndic_modeles\feuillePresence.dotx";
            string modeleConvocTexte = @"c:\syndic_modeles\convocation_texte.dotx";

            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("DateEntete", dtDateEntete.Value.ToShortDateString()),
                new NpgsqlParameter("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
//                new NpgsqlParameter("DateLimite", dtLimite.Value.ToShortDateString()),
                new NpgsqlParameter("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
                new NpgsqlParameter("Convocation", cbConvoc.SelectedItem),
                new NpgsqlParameter("LieuAssemblee", tbLieu.Text),
                new NpgsqlParameter("Header_description", hdr_descr),
                new NpgsqlParameter("Header_agence", hdr_agence),
            };
            parameters.AddRange(ParamTextDateAssemblee());

            MajdateAssemblee();

            DataTable tableCopro = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionWord(immeuble.id, parameters.ToArray());
            DataTable tableHdr = CoproprietaireController.getController().HeaderConvocationWord(immeuble.id, parameters.ToArray());

            BaseApplication.GenerateDataSource(tableHdr, @"c:\syndic_modeles\csv\convoc_hdr.csv", Encoding.UTF8);

            BaseApplication.PublipostageLettreWordAndFillTable(tableHdr, modelePresence, GetTablePresence(tableCopro), 2, FeuillePresence);
            BaseApplication.PublipostageLettreWordAndInsertFile(tableHdr, modeleConvocTexte, OrdreJour, "OrdreDuJour", ConvocWord);
            BaseApplication.PublipostageLettreWordAndInsertFile(tableHdr, modeleConvocation, OrdreJour, "OrdreDuJour", ConvocHdr);
            BaseApplication.PublipostageLettreWordAndInsertFile(tableCopro, modeleConvocation, OrdreJour, "OrdreDuJour", ConvocCopro);

            BaseApplication.MergeFiles(LiasseConvoc, new List<String> { ConvocHdr, FeuillePresence, ConvocWord, ConvocCopro });
            BaseApplication.ActivateWord();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (immeuble == null ) return;
            FicheAideImmeubleForm form = new FicheAideImmeubleForm(immeuble, "CONVOCATION");
            form.ShowDialog();
            AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, "CONVOCATION");
            if (comment != null)
            {
                tbText.Text = comment.libelle;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void MajdateAssemblee()
        {
//            if (DialogResult.Yes == MessageBox.Show("Mettre à jour la date d'assemblée ??", "", MessageBoxButtons.YesNo))
            {
                immeuble.dateass = dtDateAssemblee.Value;
                ImmeubleController.getController().InsertOrUpdate(immeuble);
            }
        }

        private void ImprimerConvocationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnRepart_Click(object sender, EventArgs e)
        {
            if (!infoForm.Visible)
                infoForm.ShowForm(this);
            else
                infoForm.Close();
            this.infoForm.Text = "Notes Assemblée";
            this.Activate();
        }

        private void btnPV_Click(object sender, EventArgs e)
        {
            EspaceSyndic.Impressions.Convocations.PvAssembleeForm form = new Impressions.Convocations.PvAssembleeForm();
            form.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int posYear = dtDateAssemblee.Value.Year - 2014;
            string anneeAssemblee = "DEUX MILLE ";
            
            //if (posYear >= 0 && posYear < yearText.Length)
            //    anneeAssemblee += yearText[posYear];

            string yearAss = String.Format(" {0}", dtDateAssemblee.Value.Year);
            string dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");

            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("DateEntete", dtDateEntete.Value.ToShortDateString()),
                new ReportParameter("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
//                new ReportParameter("DateLimite", dtLimite.Value.ToShortDateString()),
                new ReportParameter("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
                new ReportParameter("OrdreDuJour", tbText.Text),
                new ReportParameter("Convocation", "Convocation "+ cbConvoc.SelectedItem),
                new ReportParameter("repart_immeuble", String.Format("{0}", repart.valeur)),
                new ReportParameter("paragraphe_decret", ParametresDB.getParam1("IMPRESSION", "PARAGRAPHE_DECRET")),
                new ReportParameter("paragraphe_decret_contenu", ParametresDB.getParam1("IMPRESSION", "PARAMETRE_DECRET_CONTENU")),
                new ReportParameter("LieuAssemblee", tbLieu.Text),
//                new ReportParameter("AdresseImmeuble", immeuble.Adresse),
//                new ReportParameter("AnneeAssemblee", anneeAssemblee),
//                new ReportParameter("DateAssembleeText", dateAssemblee)
            };

            string mimeType, encoding, extension;
            Cursor.Current = Cursors.WaitCursor;

            DataTable table = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
            BindingSource copros = new BindingSource();
            copros.DataSource = table;
            
            string pathFile = String.Format("C:\\export_syndic\\{0}", immeuble.reference);
            string pathZip = String.Format("C:\\export_syndic\\zip_{0}", immeuble.reference);
            string zipFile = string.Format("{0}\\convoc.zip", pathZip);
            if (!Directory.Exists(pathFile))
                Directory.CreateDirectory(pathFile);

            if (!Directory.Exists(pathZip))
                Directory.CreateDirectory(pathZip);
            File.Delete(zipFile);
            try
            {
                foreach ( DataRow row in table.Rows)
                {
                    ReportViewer lr = new ReportViewer();
                    string reference = row["reference"].ToString();
                    copros.Filter = String.Format("reference = '{0}'", reference);
                    lr.LocalReport.DataSources.Add(new ReportDataSource("convocation", copros ));
                    lr.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationReport.rdlc";
                    lr.LocalReport.SetParameters(parameters);
                    Warning[] warnings;
                    string[] streams;
                    var renderedBytes = lr.LocalReport.Render
                        (
                            "PDF",
                            @"<DeviceInfo><OutputFormat>PDF</OutputFormat><HumanReadablePDF>False</HumanReadablePDF></DeviceInfo>",
                            out mimeType,
                            out encoding,
                            out extension,
                            out streams,
                            out warnings
                        );
                    string saveAs = String.Format("{0}\\convoc_{1}.pdf", pathFile, reference) ;

                    using (var stream = new FileStream(saveAs, FileMode.Create, FileAccess.Write))
                    {
                        stream.Write(renderedBytes, 0, renderedBytes.Length);
                        stream.Close();
                    }
                    lr.Dispose();
                }

                ZipFile.CreateFromDirectory(pathFile, zipFile);
                foreach ( string fname  in Directory.GetFiles(pathFile, "*.*"))
                {
                    File.Delete(fname);
                }

                MessageBox.Show("Export terminé");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private System.IO.Stream Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                var response = client.PostAsync(actionUrl, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.Content.ReadAsStreamAsync().Result;
            }
        }

        private void decret_Click(object sender, EventArgs e)
        {
            ConfigParamForm form = new ConfigParamForm();

            form.groupe_selected = "IMPRESSION";
            form.param_selected = "PARAMETRE_DECRET_CONTENU";
            form.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (immeuble != null)
            {
                immeuble.lieuconv = tbLieu.Text;
                ImmeubleController.getController().doInsertOrUpdate(immeuble);
            }

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
                        string rapportName = "Convocation " + cbConvoc.SelectedItem + " " + dtDateEntete.Value.Year.ToString();
                        dlg.textBox1.Text = string.Format("Export Convocation lot : {0}", lot.numero_lot);
                        dlg.textBox1.Refresh();
                        CreateReport(lot.numero_lot.ToString());
                        UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                    }
                }


                CreateReport();
                //UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, "Convocation " + cbConvoc.SelectedItem + " " + dtDateEntete.Value.Year.ToString(), Guid.NewGuid().ToString(), immeuble.id,"");
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
