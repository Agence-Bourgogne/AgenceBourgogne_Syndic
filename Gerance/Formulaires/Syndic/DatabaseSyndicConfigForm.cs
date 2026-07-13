using CommonProjectsPartners.Formulaires.Config;
using CommonProjectsPartners.Utils;
using System.Windows.Forms;

namespace Gerance.Formulaires.Syndic
{
    class DatabaseSyndicConfigForm : DatabaseConfigForm
    {
        public DatabaseSyndicConfigForm(string application) : base(application)
        {
            this.ckAlternateCnx.Visible = true;
            var iCnxSyndic = CommonRegistry.getRegistryValue(Gerance.GeranceApplication.SYNDIC_APPLICATION, "Database", "ConnexionSyndic", 0);
            ckAlternateCnx.Checked = ((int)iCnxSyndic) == 1;
        }
        protected override void setConnexionString(string strCnx)
        {
            Database.setConnexionString(this.application, strCnx);
            CommonRegistry.setRegistryValue(application, "Database", "ConnexionSyndic", ckAlternateCnx.Checked ? 1:0);

            SyndicDatabase.SyndicProprio.Clear();
            if (ckAlternateCnx.Checked)
            {
                if (SyndicDatabase.ConnexionValide())
                {
                    this.Close();
                    SyndicDatabase.StartLoadSyndicCopro();
                    MessageBox.Show("Connexion Ok");
                }
                else
                    MessageBox.Show("Connexion KO");
            }
            else
                this.Close();
        }
    }
}
