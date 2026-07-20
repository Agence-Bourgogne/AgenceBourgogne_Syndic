using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.Convocations;

public partial class PvAssembleeForm : Form
{
    private readonly string TitreForm;
    private ImmeubleEntite immeuble;

    public PvAssembleeForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void immeubleUserControl1_ValidatingControle(object sender, CancelEventArgs e)
    {
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", immeubleUserControl.Reference);
        if (immeuble != null)
        {
            immeubleUserControl.Invalid = false;
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
        }
        else
        {
            if (immeubleUserControl.tbRefImmeuble.Text != "")
                immeubleUserControl.Invalid = true;
            Text = TitreForm;
        }
    }

    private void PvAssembleeForm_Load(object sender, EventArgs e)
    {
        cbConvoc.SelectedIndex = 0;
        btnEnter.Width = 0;
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }
}