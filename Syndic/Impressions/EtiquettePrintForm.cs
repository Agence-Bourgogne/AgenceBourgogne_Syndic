using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Properties;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions;

public partial class EtiquettePrintForm : Form
{
    private readonly string _titreForm;
    private ImmeubleEntite _immeuble;

    public EtiquettePrintForm()
    {
        InitializeComponent();
        _titreForm = Text;
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
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

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (_immeuble != null)
        {
            Text = $"{_titreForm} pour l'immeuble : {_immeuble.nom} ({_immeuble.DateExercice})";
            btnRapport.Enabled = true;
        }
        else
        {
            btnRapport.Enabled = false;
            Text = _titreForm;
        }
    }

    private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
    {
        lblImmeuble_Click(sender, e);
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        const string nomModele = "ETIQUETTES";

        var modele = ParametresDB.getModeleOrCopyDefaultOne(nomModele, Resources.etiquettes);

        BaseApplication.PublipostageEtiquetteWord(
            CoproprietaireController.getController().CoproprietaireImmeubleDescriptionEtiquettes(_immeuble.id), modele);
    }


    private void EtiquettePrintForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }
}