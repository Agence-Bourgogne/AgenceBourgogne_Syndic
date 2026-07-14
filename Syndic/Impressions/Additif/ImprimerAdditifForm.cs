using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Impressions.RelevesIndividuels;
using EspaceSyndic.UtilsApp;
using Microsoft.Reporting.WinForms;
using Npgsql;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.Additif;

public partial class ImprimerAdditifForm : Form
{
    private ImmeubleEntite immeuble;
    private readonly HelpForm infoForm = new("aide_additif");
    private const  string  TEXT_KEY = "ADDITIF";
    private readonly string TitreForm;

    public ImprimerAdditifForm()
    {
        InitializeComponent();
        TitreForm = Text;
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
    private static string GetHeureAssemblee()
    {
        return "1800";
    }

    private string GetLieuAssemblee()
    {
        var lieu = "";
        if (immeuble != null)
            lieu = immeuble.lieuconv;
        if ( lieu == "")
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
                //if (sender.Equals(tbNature))
                //    lblNature_Click(null, null);
                //if (sender.Equals(tbFournisseur))
                //    lblFournisseur_Click(null, null);
            }
    }

    private ImmeubleRepartitionEntite repart;
    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            var comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, TEXT_KEY);
            repart = ImmeubleRepartitionController.getController().getRepartitionImmeubleEntite(immeuble.id);
            if (comment != null)
            {
                tbText.Text = comment.libelle;
            }
            else
                tbText.Text = "";

            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";

            infoForm.DoFormText(this, immeuble.note);
            try
            {
                dtDateAssemblee.Value = immeuble.dateass;
            }
            catch (Exception)
            {

            }
            tbLieu.Text = GetLieuAssemblee();
            btnRapport.Enabled = btnWord.Enabled = true;
        }
        else
        {
            Text = TitreForm;
            btnRapport.Enabled = btnWord.Enabled = false;
            infoForm.Hide();
        }
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        CreateReport();
    }

    private void CreateReport(string num_lot = "")
    {
        var repart_valeur = $"{repart.valeur}";
        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");
        var parameters = new ReportParameter[]{
            new("DateEntete", dtDateEntete.Value.ToShortDateString()),
            new("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
            new("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
            new("OrdreDuJour", tbText.Text),
            new("Convocation", "Convocation "+ cbConvoc.SelectedItem),
            new("repart_immeuble", repart_valeur),
            new("Header_Description", hdr_descr),
            new("Header_Agence", hdr_agence),
            new("LieuAssemblee", tbLieu.Text)
        };
        reportViewer1.LocalReport.SetParameters(parameters);
        if(string.IsNullOrEmpty(num_lot))
            tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
        else
            tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionByLot(immeuble.id,num_lot);

        reportViewer1.RefreshReport();
    }
    private void btnWord_Click(object sender, EventArgs e)
    {

        var parameters = new NpgsqlParameter[]{
            new("DateEntete", dtDateEntete.Value.ToShortDateString()),
            new("DateAssemblee", dtDateAssemblee.Value.ToShortDateString()),
            new("HeureAssemblee", tbHeure.Text.Replace (":", " H ")),
            new("OrdreDuJour", tbText.Text),
            new("Convocation", "Convocation "+ cbConvoc.SelectedItem),
            new("LieuAssemblee", tbLieu.Text)
        };

        var table = CoproprietaireController.getController().CoproprietaireImmeubleDescriptionWord(immeuble.id, parameters);

        var modele = ParametresDB.getParam1("MODELES", "ADDITIF");
        BaseApplication.PublipostageLettreWord(table, modele);
    }

    private void label4_Click(object sender, EventArgs e)
    {
        var form = new FicheAideImmeubleForm(immeuble, TEXT_KEY);
        form.ShowDialog();
        var comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, TEXT_KEY);
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
        var lots = LotDescriptionController.getController().getListeLotDescription(immeuble.id);
        var dlg = new ExportCopro();
        try
        {
            dlg.Show(this);
            dlg.Activate();
            foreach (var lot in lots)
            {
                if (lot is { Coproprietaire: not null })
                {
                    var rapportName = "Additif convocation " + cbConvoc.SelectedItem + " " + dtDateEntete.Value.Year;
                    dlg.textBox1.Text = $"Export Additif convocation lot : {lot.numero_lot}";
                    dlg.textBox1.Refresh();
                    CreateReport(lot.numero_lot.ToString());
                    ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
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