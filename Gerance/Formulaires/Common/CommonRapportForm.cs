using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Common
{
    public partial class CommonRapportForm : Form
    {
        public CommonRapportForm()
        {
            InitializeComponent();
        }

        protected void CommonRapportListeForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
    }
}
