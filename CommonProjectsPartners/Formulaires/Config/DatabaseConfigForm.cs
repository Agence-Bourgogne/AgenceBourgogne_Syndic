using System;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace CommonProjectsPartners.Formulaires.Config;

public partial class DatabaseConfigForm : Form
{
    private readonly string application;                
    public DatabaseConfigForm()
    {
        InitializeComponent();
    }
    public DatabaseConfigForm(string application)
    {
        InitializeComponent();
        this.application = application;
    }
    private static void ShowParam(TextBox tb, string param)
    {
        var txt = param.Split('=');
        tb.Text = txt[1];
    }

    private string getConnexionString()
    {
        return Database.getConnexionString(application);
    }

    private void ConfigForm_Load(object sender, EventArgs e)
    {
        var str = getConnexionString();
        if ( !string.IsNullOrEmpty(str) )
        {
            var parametres = str.Split(';');

            ShowParam(tbServeur, parametres[0]);
            ShowParam(tbPort, parametres[1]);
            ShowParam(tbUser, parametres[2]);
            ShowParam(tbPassword, parametres[3]);
            ShowParam(tbSchema, parametres[4]);
        }
    }

    private void setConnexionString(string strCnx)
    {
        Database.setConnexionString(application, strCnx);
        Database.CloseConnection();
        if (Database.GetInstance() != null)
        {
            Close();
            MessageBox.Show(@"Connexion Ok");
        }
        else
            MessageBox.Show(@"Connexion KO");
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
        var strCnx =
            $"Server={tbServeur.Text};Port={tbPort.Text};User Id={tbUser.Text};Password={tbPassword.Text};Database={tbSchema.Text}";
        setConnexionString(strCnx);
    }
}