using System;
using GeranceData.Common;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class TexteReleveForm : Gerance.Formulaires.Common.CommonTextForm
    {
        public TexteReleveForm()
        {
            InitializeComponent();
        }

        private void TexteReleveForm_Load(object sender, EventArgs e)
        {
            tbText.Text = ParametresDB.getParam1("IMPRESSION", "PARAGRAPHE_RELEVE");
            tbText.Select(tbText.Text.Length, 0);
        }

        private void valid_Click(object sender, EventArgs e)
        {
            ParametresDB.setParam1("IMPRESSION", "PARAGRAPHE_RELEVE", tbText.Text);
        }
    }
}
