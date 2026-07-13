using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Entites;
using SyndicData.Controller;
namespace EspaceSyndic.Impressions
{
    public partial class EtiquettePrintForm : Form
    {
        ImmeubleEntite immeuble = null;
        string TitreForm;
        public EtiquettePrintForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
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

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                btnRapport.Enabled = true;
            }
            else
            {
                btnRapport.Enabled = false;
                this.Text = TitreForm;
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
            String modele = ParametresDB.getParam1("MODELES", "ETIQUETTES");
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
}
