using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions;

public partial class EtiquettePrintForm : Form
{
    private ImmeubleEntite immeuble;
    private readonly string TitreForm;
    public EtiquettePrintForm()
    {
        InitializeComponent();
        TitreForm = Text;
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
        immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";
            btnRapport.Enabled = true;
        }
        else
        {
            btnRapport.Enabled = false;
            Text = TitreForm;
        }
    }

    private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
    {
        lblImmeuble_Click(sender, e);
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        //tableCoproImmeubleBindingSource.DataSource = 
        //    CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id);

        // reportViewer1.RefreshReport();
        var modele = ParametresDB.getParam1("MODELES", "ETIQUETTES");
        BaseApplication.PublipostageEtiquetteWord(CoproprietaireController.getController().CoproprietaireImmeubleDescriptionEtiquettes(immeuble.id), modele);
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