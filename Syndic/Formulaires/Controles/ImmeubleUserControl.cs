using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Immeubles;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Formulaires.Controles
{
    public delegate void ValidatingEventHandler(object sender, CancelEventArgs e);

    public partial class ImmeubleUserControl : UserControl
    {
        public event ValidatingEventHandler ValidatingControl;
        public ImmeubleUserControl()
        {
            InitializeComponent();
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

        private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    lblImmeuble_Click(null, null);
                }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatingControl != null)
                ValidatingControl(sender, e);
        }
        public String Reference
        {
            get
            {
                return tbRefImmeuble.Text;
            }
            set
            {
                tbRefImmeuble.Text = value;
            }
        }
        public bool Invalid
        {
            set
            {
                if (value)
                    tbRefImmeuble.BackColor = Color.Red;
                else
                    tbRefImmeuble.BackColor = Color.White;
            }
        } 
    }
}
