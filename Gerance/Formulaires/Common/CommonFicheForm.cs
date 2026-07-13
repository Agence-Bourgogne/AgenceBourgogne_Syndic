using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using GeranceData.Entites;
using GeranceData.Controller;
using CommonProjectsPartners.Utils;

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
