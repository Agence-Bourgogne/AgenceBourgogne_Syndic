using System;
//using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Formulaires.Config;
using EspaceSyndic.Formulaires;
namespace EspaceSyndic
{
    static class SyndicApplication 
    {
        public const String CURRENT_APPLICATION = "syndic";
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //BaseApplication.ComputerName = System.Windows.Forms.SystemInformation.ComputerName;
            CommonRegistry.setCurrentApp(CURRENT_APPLICATION);
            try
            {
                string str = Database.getConnexionString(CURRENT_APPLICATION);

                try
                {
                    if (Database.GetInstance() == null)
                    {
                        str = "";
                    }

                }
                catch (Exception)
                {
                    str = null;
                }
                if (str == null || str == "")
                {
                    DatabaseConfigForm cfgForm = new DatabaseConfigForm(CURRENT_APPLICATION);
                    cfgForm.ShowDialog();
                }
                else
                {
                    BaseApplication.schema = ParametresDB.getParam1("AGENCE", "schema");
                    Application.Run(new MainForm());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BaseApplication.CloseOfficeInstance();
        }
    }
}
