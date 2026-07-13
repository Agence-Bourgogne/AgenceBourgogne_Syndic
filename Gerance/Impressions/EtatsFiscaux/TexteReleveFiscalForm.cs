using System;
using GeranceData.Common;

namespace Gerance.Impressions.EtatsFiscaux
{
    public partial class TexteReleveFiscalForm : Formulaires.Common.CommonTextForm
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
