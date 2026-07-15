using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Config;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.Convocations;

public partial class ImprimerConvocationForm : Form
{
    private static readonly string[] units = ["", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf"];
    private static readonly string[] teens = ["", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"
    ];
    private static readonly string[] tens = ["", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix"
    ];

    private bool ForExport;
    private string currentLot = "";
    public static string ConvertToWords(double number)
    {
        if (number == 0)
            return "zéro";

        if (number < 0)
            return "moins " + ConvertToWords(Math.Abs(number));

        var words = "";

        var integerPart = (long)Math.Floor(number);
        words = ConvertToWordsInternal(integerPart);

        return words;
    }
    private static string ConvertToWordsInternal(long number)
    {
        var words = "";

        if (number / 1000000000000 > 0)
        {
            words += ConvertToWordsInternal(number / 1000000000000) + " Billion ";
            number %= 1000000000000;
        }

        if (number / 1000000000 > 0)
        {
            words += ConvertToWordsInternal(number / 1000000000) + " milliard ";
            number %= 1000000000;
        }

        if (number / 1000000 > 0)
        {
            words += ConvertToWordsInternal(number / 1000000) + " million ";
            number %= 1000000;
        }

        if (number / 1000 > 0)
        {
            words += ConvertToWordsInternal(number / 1000) + " mille ";
            if (words == "un mille ")
            {
                words = "mille ";
            }
            number %= 1000;
        }

        if (number / 100 > 0)
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
                    words += "quatre-vingt-" + teens[number - 90];
                }
                else if (number > 70 && number < 80)
                {
                    words += "soixante-" + teens[number - 70];
                }
                else
                {
                    words += tens[number / 10];
                    if (number % 10 > 0)
                        words += "-" + units[number % 10];
                }
            }
        }

        return words.Trim();
    }

    private ImmeubleEntite immeuble;
    private readonly HelpForm infoForm = new("aide_convocation");
    private readonly string TitreForm;
    public ImprimerConvocationForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void ImprimerConvocationForm_Load(object sender, EventArgs e)
    {
        btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = false;
        tbLieu.Text = GetLieuAssemblee();
        cbConvoc.SelectedIndex = 0;
        btnEnter.Width = 0;
            
        reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
#if DEBUG
    
#else
           btnPV.Visible = false;
           btnExport.Visible = false;
#endif
    }

    private string GetLieuAssemblee()
    {
        var lieu = "";
        if (immeuble != null)
            lieu = immeuble.lieuconv;
        if (lieu == "")
            lieu = "AGENCE Bourgogne 45 rue des Carmes 45000 ORLEANS";
        return lieu;
    }
    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
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

        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(sender, null);
            }
    }

    private ImmeubleRepartitionEntite repart;

    private void SetTextHeader()
    {
        var aide = "CONVOCATION";
        if (immeuble != null)
        {
            var comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, aide);
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
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
            infoForm.DoFormText(this, immeuble.note);
            if ( immeuble.dateass.Year > 2000 )
                dtDateAssemblee.Value = immeuble.dateass;
            tbLieu.Text = GetLieuAssemblee();
            btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = true;
        }
        else
        {
            Text = TitreForm;
            btnRapport.Enabled = btnWord.Enabled = btnExport.Enabled = false;
            infoForm.Hide();
        }
    }

    private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        Console.WriteLine(e.ReportPath);
        e.DataSources.Clear();
        if (e.ReportPath == "ConvocationReport" ) 
        {
            var src = new BindingSource();
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
            var src = new BindingSource();
            if (ForExport)
                src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, currentLot, true);
            else
                src.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, true);
            src.Filter = "valeur <> 0";
            e.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", src));
//                e.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, true)));
        }
    }

    private string getOrdre(string[] lines)
    {
        var text = "";
        //int tabWidth = 4;
        //int minTab = 120;
            
        foreach (var l in lines)
        {
            text += l.Replace("\t", "    ")+"\n";
        }
        Console.WriteLine(text);
        return text;
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        CreateReport();
    }

    private void CreateReport(string num_lot = "")
    {
        ForExport = !string.IsNullOrEmpty(num_lot);
        currentLot = num_lot;
        var yearAss = $" {dtDateAssemblee.Value.Year}";
        var dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");
        var anneeAssemblee = ConvertToWords(dtDateAssemblee.Value.Year).ToUpper();

        var ordre = tbText.Text;
        if (string.IsNullOrWhiteSpace(tbHeure.Text.Replace(":", "")))
        {
            MessageBox.Show(@"L'heure de convocation n'est pas renseignée");
            return;
        }

        ordre = getOrdre(tbText.Lines);
        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
        var parameters = new ReportParameter[]{
            new("DateEntete", dtDateEntete.Value.ToShortDateString()),
            new("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
            new("DateLimite", ""),//dtLimite.Value.ToShortDateString()),
            new("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
            new("OrdreDuJour", ordre),
            new("Convocation", "Convocation "+ cbConvoc.SelectedItem),
            new("repart_immeuble", $"{repart.valeur}"),
            new("paragraphe_decret", ParametresDB.getParam1("IMPRESSION", "PARAGRAPHE_DECRET")),
            new("paragraphe_decret_contenu", ParametresDB.getParam1("IMPRESSION", "PARAMETRE_DECRET_CONTENU")),
            new("LieuAssemblee", tbLieu.Text),
            new("AdresseImmeuble", immeuble.Adresse),
            new("AnneeAssemblee", anneeAssemblee),
            new("Header_Description", hdr_descr),
            new("Header_Agence", hdr_agence),
            new("DateAssembleeText", dateAssemblee)
        };

        MajdateAssemblee();

        if ((int)CommonRegistry.getRegistryValue("convocation", "type_convocation", 0) == 1)
        {
            if (string.IsNullOrEmpty(num_lot))
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id)));
            else
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("convocation", CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id, num_lot)));
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationReport.rdlc";
        }
        else
            reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationMasterReport.rdlc";

        reportViewer1.LocalReport.SetParameters(parameters);
        reportViewer1.RefreshReport();
    }

    private static List<string[]> GetTablePresence(DataTable table)
    {
        var datas =new List<string[]>();

        foreach (DataRow row in table.Rows)
        {
            var data = new string[4];
            data[0] =
                $"{row["Civilite"]} {row["coproprietaire"]}\r\n{row["adressecoproprietaire"]}\r\n{row["codepostalcoproprietaire"]} {row["villecoproprietaire"]}";
            data[1] = row["referencecoproprietaire"].ToString();
            data[2] = "";
            data[3] = row["valeur"].ToString();
            datas.Add(data);
        }

        return datas;
    }

    private static string GetDocOrdreDuJour()
    {
        var dlg = new OpenFileDialog();
        dlg.Filter = "Document Word (*.docx)|*.docx|Tous les fichiers|*.*";
        dlg.Title = "Choisir le document Ordre du jour";
        if (dlg.ShowDialog() != DialogResult.OK)
            return "";
        if (!File.Exists(dlg.FileName))
            return "";
        return dlg.FileName;
    }

    private NpgsqlParameter[] ParamTextDateAssemblee()
    {
        var yearAss = $" {dtDateAssemblee.Value.Year}";
        var dateAssemblee = dtDateAssemblee.Value.ToLongDateString().Replace(yearAss, "");
        var anneeAssemblee = ConvertToWords(dtDateAssemblee.Value.Year).ToUpper();
            
        var parameters = new NpgsqlParameter[]{
            new("AnneeAssemblee", anneeAssemblee),
            new("DateAssembleeText", dateAssemblee)
        };
        return parameters;
    }

    private void btnWord_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbHeure.Text.Replace(":", "")))
        {
            MessageBox.Show(@"L'heure de convocation n'est pas renseignée");
            return;
        }
        var OrdreJour = GetDocOrdreDuJour();
        if (string.IsNullOrWhiteSpace(OrdreJour))
            return;
        var FeuillePresence = BaseApplication.GetTempFileName("docx");
        var ConvocWord = BaseApplication.GetTempFileName("docx");

        var ConvocHdr = BaseApplication.GetTempFileName("docx");
        var ConvocCopro = BaseApplication.GetTempFileName("docx");
        var PathConvoc = @"C:\Syndic_Modeles\Convocations\";
        var LiasseConvoc = Path.Combine(PathConvoc,
            $"convocations_{immeuble.reference}_{dtDateAssemblee.Value:yyyyMMdd}");
        var modeleConvocation = ParametresDB.getParam1("MODELES", "CONVOCATIONS");
        var modelePresence = @"c:\syndic_modeles\feuillePresence.dotx";
        var modeleConvocTexte = @"c:\syndic_modeles\convocation_texte.dotx";

        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
        var parameters = new List<NpgsqlParameter>{
            new("DateEntete", dtDateEntete.Value.ToShortDateString()),
            new("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
            new("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
            new("Convocation", cbConvoc.SelectedItem),
            new("LieuAssemblee", tbLieu.Text),
            new("Header_description", hdr_descr),
            new("Header_agence", hdr_agence)
        };
        parameters.AddRange(ParamTextDateAssemblee());

        MajdateAssemblee();

        var tableCopro = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionWord(immeuble.id, parameters.ToArray());
        var tableHdr = CoproprietaireController.getController().HeaderConvocationWord(immeuble.id, parameters.ToArray());

        BaseApplication.GenerateDataSource(tableHdr, @"c:\syndic_modeles\csv\convoc_hdr.csv", Encoding.UTF8);

        BaseApplication.PublipostageLettreWordAndFillTable(tableHdr, modelePresence, GetTablePresence(tableCopro), 2, FeuillePresence);
        BaseApplication.PublipostageLettreWordAndInsertFile(tableHdr, modeleConvocTexte, OrdreJour, "OrdreDuJour", ConvocWord);
        BaseApplication.PublipostageLettreWordAndInsertFile(tableHdr, modeleConvocation, OrdreJour, "OrdreDuJour", ConvocHdr);
        BaseApplication.PublipostageLettreWordAndInsertFile(tableCopro, modeleConvocation, OrdreJour, "OrdreDuJour", ConvocCopro);

        BaseApplication.MergeFiles(LiasseConvoc, [ConvocHdr, FeuillePresence, ConvocWord, ConvocCopro]);
        BaseApplication.ActivateWord();
    }

    private void label4_Click(object sender, EventArgs e)
    {
        if (immeuble == null ) return;
        var form = new FicheAideImmeubleForm(immeuble, "CONVOCATION");
        form.ShowDialog();
        var comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, "CONVOCATION");
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
        immeuble.dateass = dtDateAssemblee.Value;
        ImmeubleController.getController().InsertOrUpdate(immeuble);
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
        infoForm.Text = "Notes Assemblée";
        Activate();
    }

    private void btnPV_Click(object sender, EventArgs e)
    {
        var form = new PvAssembleeForm();
        form.ShowDialog();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        var parameters = new ReportParameter[]{
            new("DateEntete", dtDateEntete.Value.ToShortDateString()),
            new("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
            new("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
            new("OrdreDuJour", tbText.Text),
            new("Convocation", "Convocation "+ cbConvoc.SelectedItem),
            new("repart_immeuble", $"{repart.valeur}"),
            new("paragraphe_decret", ParametresDB.getParam1("IMPRESSION", "PARAGRAPHE_DECRET")),
            new("paragraphe_decret_contenu", ParametresDB.getParam1("IMPRESSION", "PARAMETRE_DECRET_CONTENU")),
            new("LieuAssemblee", tbLieu.Text)
        };

        Cursor.Current = Cursors.WaitCursor;

        var table = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
        var copros = new BindingSource();
        copros.DataSource = table;
            
        var pathFile = $"C:\\export_syndic\\{immeuble.reference}";
        var pathZip = $"C:\\export_syndic\\zip_{immeuble.reference}";
        var zipFile = $"{pathZip}\\convoc.zip";
        if (!Directory.Exists(pathFile))
            Directory.CreateDirectory(pathFile);

        if (!Directory.Exists(pathZip))
            Directory.CreateDirectory(pathZip);
        File.Delete(zipFile);
        try
        {
            foreach ( DataRow row in table.Rows)
            {
                var lr = new ReportViewer();
                var reference = row["reference"].ToString();
                copros.Filter = $"reference = '{reference}'";
                lr.LocalReport.DataSources.Add(new ReportDataSource("convocation", copros ));
                lr.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.Convocations.ConvocationReport.rdlc";
                lr.LocalReport.SetParameters(parameters);
                var renderedBytes = lr.LocalReport.Render
                (
                    "PDF",
                    @"<DeviceInfo><OutputFormat>PDF</OutputFormat><HumanReadablePDF>False</HumanReadablePDF></DeviceInfo>",
                    out _,
                    out _,
                    out _,
                    out _,
                    out _
                );
                var saveAs = $"{pathFile}\\convoc_{reference}.pdf";

                using (var stream = new FileStream(saveAs, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(renderedBytes, 0, renderedBytes.Length);
                    stream.Close();
                }
                lr.Dispose();
            }

            ZipFile.CreateFromDirectory(pathFile, zipFile);
            foreach ( var fname  in Directory.GetFiles(pathFile, "*.*"))
            {
                File.Delete(fname);
            }

            MessageBox.Show(@"Export terminé");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        Cursor.Current = Cursors.Default;
    }

    private void decret_Click(object sender, EventArgs e)
    {
        var form = new ConfigParamForm();

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
}