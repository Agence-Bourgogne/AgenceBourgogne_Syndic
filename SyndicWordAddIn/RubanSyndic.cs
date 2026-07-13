using System;
using Microsoft.Office.Tools.Ribbon;

namespace SyndicWordAddIn
{
    public partial class RubanSyndic
    {
        private void RubanSyndic_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnEtiquette_Click(object sender, RibbonControlEventArgs e)
        {
            Console.WriteLine(edRef.Text);
            if (edRef.Text != "")
            {
                Globals.ThisAddIn.GenerationEtiquetteImmeuble(edRef.Text);
            }
        }
    }
}
