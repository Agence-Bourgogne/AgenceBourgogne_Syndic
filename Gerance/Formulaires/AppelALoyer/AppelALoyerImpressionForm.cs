using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
