using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions;

public partial class FeuillePresencePrintForm : Form
{
    private ImmeubleEntite immeuble;
    public FeuillePresencePrintForm()
    {
        InitializeComponent();
        btnRapport.Enabled = false;
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

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var parameters = new ReportParameter[]{
            new("TypeAssemblee", cbAssemblee.SelectedItem.ToString()),
            new("DateAssemblee", dtAssemblee.Value.ToShortDateString())
        };

        reportViewer1.LocalReport.DataSources.Clear();
        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id)));
        reportViewer1.LocalReport.SetParameters(parameters);
        reportViewer1.RefreshReport();
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if ((immeuble != null) &(cbAssemblee.SelectedIndex >= 0))
        {
            btnRapport.Enabled = true;
        }
        else
            btnRapport.Enabled = false;
    }

    private void FeuillePresencePrintForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
    }

    private void cbAssemblée_SelectedIndexChanged(object sender, EventArgs e)
    {
        tbRefImmeuble_Validating(null, null);
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }
}