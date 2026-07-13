using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerance.Formulaires;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using System.IO.Compression;
using System.IO;
using System.Data;
using CommonProjectsPartners.Formulaires.Logon;
using CommonProjectsPartners.Formulaires.Config;
using GeranceData.Common;

namespace Gerance
{
    static class GeranceApplication
    {
        public const String CURRENT_APPLICATION = "gerance";
        public const String SYNDIC_APPLICATION = "syndic";

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            BaseApplication.ComputerName = System.Windows.Forms.SystemInformation.ComputerName;
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
                    Application.Run(new GeranceMainForm());
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
