using System;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;


namespace CommonProjectsPartners.Formulaires.Config
{
    public partial class DatabaseConfigForm : Form
    {
        protected string application;                
        public DatabaseConfigForm()
        {
            InitializeComponent();
        }
        public DatabaseConfigForm(string application)
        {
            InitializeComponent();
            this.application = application;
        }
        private void ShowParam(TextBox tb, string param)
        {
            String[] txt = param.Split('=');
            tb.Text = txt[1];
        }
        protected virtual string getConnexionString()
        {
            return Database.getConnexionString(application);
        }
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            string str = getConnexionString();
            if ( str != null && str!= "" )
            {
                String[] parametres = str.Split(';');

                ShowParam(tbServeur, parametres[0]);
                ShowParam(tbPort, parametres[1]);
                ShowParam(tbUser, parametres[2]);
                ShowParam(tbPassword, parametres[3]);
                ShowParam(tbSchema, parametres[4]);
            }
        }
        protected virtual void setConnexionString(string strCnx)
        {
            Database.setConnexionString(application, strCnx);
            Database.CloseConnection();
            if (Database.GetInstance() != null)
            {
                Close();
                MessageBox.Show("Connexion Ok");
            }
            else
                MessageBox.Show("Connexion KO");
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string strCnx = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", 
                tbServeur.Text,
                tbPort.Text,
                tbUser.Text,
                tbPassword.Text,
                tbSchema.Text
                );
            setConnexionString(strCnx);
        }
    }
}
