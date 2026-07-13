using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Impressions.Convocations
{
    public partial class PvAssembleeForm : Form
    {
        ImmeubleEntite immeuble;
        string TitreForm;
        public PvAssembleeForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }

        private void immeubleUserControl1_ValidatingControle(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", immeubleUserControl.Reference);
            if (immeuble != null)
            {
                immeubleUserControl.Invalid = false;
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
            }
            else
            {
                if ( immeubleUserControl.tbRefImmeuble.Text != "")
                    immeubleUserControl.Invalid = true;
                this.Text = TitreForm;
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
}
