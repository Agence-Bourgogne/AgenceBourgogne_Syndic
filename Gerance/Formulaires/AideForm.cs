using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Gerance.Formulaires
{
    public partial class AideForm : Form
    {
        public AideForm()
        {
            InitializeComponent();
        }

        private void AideForm_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Gerance.Formulaires.roadmap.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                tbAide.Text = reader.ReadToEnd();
            }            
        }
    }
}
