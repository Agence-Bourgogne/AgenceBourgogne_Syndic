using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Common;

namespace Gerance.Impressions.EtatsFiscaux
{
    public partial class TexteReleveFiscalForm : Gerance.Formulaires.Common.CommonTextForm
    {
        public TexteReleveFiscalForm()
        {
            InitializeComponent();
        }
        private void TexteReleveForm_Load(object sender, EventArgs e)
        {
            tbText.Text = ParametresDB.getParam1("IMPRESSION", "HDR_RELEVE_FISCAL");
            tbText.Select(tbText.Text.Length, 0);
        }

        private void valid_Click(object sender, EventArgs e)
        {
            ParametresDB.setParam1("IMPRESSION", "HDR_RELEVE_FISCAL", tbText.Text);
        }

    }
}
