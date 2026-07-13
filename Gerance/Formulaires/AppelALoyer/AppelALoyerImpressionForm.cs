using System;
using System.Windows.Forms;

namespace Gerance.Formulaires.AppelALoyer
{
    public partial class AppelALoyerImpressionForm : Form
    {
        public AppelALoyerImpressionForm()
        {
            InitializeComponent();
        }

        private void AppelALoyerImpressionForm_Load(object sender, EventArgs e)
        {
            rdLoyer.Visible = false;
        }
    }
}
