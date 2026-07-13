using System;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Common
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
