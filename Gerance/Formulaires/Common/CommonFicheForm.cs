using System;
using System.Windows.Forms;

//using EspaceSyndic.UtilsApp;
namespace Gerance.Formulaires.Common
{
    public partial class CommonFicheForm : BaseFicheForm
    {

        public CommonFicheForm()
        {
            InitializeComponent();
        }

        public CommonFicheForm(string entite_id) : base (entite_id)
        {
            InitializeComponent();
        }

        protected virtual void ShowFindFromReference()
        {

        }
        private void lblReference_Click(object sender, EventArgs e)
        {
            ShowFindFromReference();
        }

        private void tbReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    lblReference_Click(null, null);
                }
            
        }
    }
}
