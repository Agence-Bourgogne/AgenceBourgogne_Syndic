using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires;

public partial class AideForm : Form
{
    public AideForm()
    {
        InitializeComponent();
    }

    private void AideForm_Load(object sender, EventArgs e)
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "EspaceSyndic.Formulaires.roadmap.txt";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream);
        tbAide.Text = reader.ReadToEnd();
    }
}