using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace EspaceSyndic.Formulaires
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
            var resourceName = "EspaceSyndic.Formulaires.roadmap.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                tbAide.Text = reader.ReadToEnd();
            }            
        }
    }
}
