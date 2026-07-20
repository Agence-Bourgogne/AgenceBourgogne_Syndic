using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.RemiseDeCles;

public partial class ImprimerRemiseDeClesForm : Form
{
    private readonly string TitreForm;
    private ImmeubleEntite immeuble;

    public ImprimerRemiseDeClesForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void lblImmeuble_Click()
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }
    }

    private void ImprimerRemiseDeClesForm_Load(object sender, EventArgs e)
    {
        btnRapport.Enabled = false;
        btnEnter.Width = 0;
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            btnRapport.Enabled = true;
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
        }
        else
        {
            btnRapport.Enabled = false;
            Text = TitreForm;
        }
    }

    private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
    {
        lblImmeuble_Click();
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        var parameters = new ReportParameter[]
        {
            new("DateRemise", dtRemise.Value.ToShortDateString())
        };

//            this.tableCoproImmeubleBindingSource.Filter = String.Format("immeuble_id = '{0}'", immeuble.id);
        reportViewer1.LocalReport.SetParameters(parameters);
        tableCoproImmeubleBindingSource.DataSource =
            CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);
//            this.coproImmeubleTableAdapter.Fill(this.coproprietaireImmeuble.TableCoproImmeuble);
        reportViewer1.RefreshReport();
    }

    private void tbHelpBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click();
                //if (sender.Equals(tbNature))
                //    lblNature_Click(null, null);
                //if (sender.Equals(tbFournisseur))
                //    lblFournisseur_Click(null, null);
            }
    }

    private void lblImmeuble_Click_1(object sender, EventArgs e)
    {
        lblImmeuble_Click();
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        //Console.WriteLine(sender);
        ControlsWindows.FocusNextTabbedControl(this);
    }
}