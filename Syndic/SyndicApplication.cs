using System;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Formulaires.Config;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires;
using SyndicData.Common;



namespace EspaceSyndic;

internal static class SyndicApplication 
{
    public const string CURRENT_APPLICATION = "syndic";

    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        CommonRegistry.setCurrentApp(CURRENT_APPLICATION);
        try
        {
            var str = Database.getConnexionString(CURRENT_APPLICATION);

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
            if (string.IsNullOrEmpty(str))
            {
                var cfgForm = new DatabaseConfigForm(CURRENT_APPLICATION);
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