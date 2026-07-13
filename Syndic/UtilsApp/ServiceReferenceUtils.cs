using System;
using System.IO;
namespace EspaceSyndic.UtilsApp
{
    public class ServiceReferenceUtils
    {
        static string serveur = SyndicData.Common.ParametresDB.getParam1("SERVEUR", "ADDRESSE");
        static ServiceReference.ServiceClient sc = null;
        public static ServiceReference.ServiceClient GetInstance()
        {
            if (sc == null)
            {
                sc = new ServiceReference.ServiceClient("BasicHttpBinding_IService", serveur);
            }
            return sc;
        }

        public static string  SendReportPDF(Microsoft.Reporting.WinForms.ReportViewer reportViewer, String Header, string Guid, String immeuble_id, string copro_id)
        {
            GetInstance();
            byte[] report = reportViewer.LocalReport.Render("PDF");
            int lenReport = report.Length;
            int pos = 0;
            while (pos < lenReport)
            {
                byte[] buffer = new byte[32768];
                Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, (int)(lenReport - pos)));
                pos += 32768;
                sc.UploadPartFile(Guid, buffer);
            }
            return sc.CloseFile(Header, Guid, immeuble_id, copro_id);
        }
        public static string SendReportPDF(string pdfFile, String Header, string Guid, String immeuble_id, string copro_id)
        {
            GetInstance();
            //-------------
            FileStream fs = new FileStream(pdfFile,
                                           FileMode.Open,
                                           FileAccess.Read);
            long numBytes = new FileInfo(pdfFile).Length;
            BinaryReader br = new BinaryReader(fs);
            byte[] report = new byte[numBytes];
            fs.Read(report, 0, report.Length);
            fs.Close();

            //-------------


           // byte[] report = File.ReadAllBytes(pdfFile);
            int lenReport = report.Length;
            int pos = 0;
            while (pos < lenReport)
            {
                byte[] buffer = new byte[32768];
                Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, (int)(lenReport - pos)));
                pos += 32768;
                sc.UploadPartFile(Guid, buffer);
            }
            return sc.CloseFile(Header, Guid, immeuble_id, copro_id);
        }
        public static String CreateUser(String UserCode, String Password)
        {
            String msg = "";
            GetInstance();
            msg = sc.CreateUser(UserCode, Password);
            return msg;
        }
        public static String UpdateUser(String Guid, String UserCode, String Password)
        {
            string msg = "";
            GetInstance();
            msg = sc.UpdateUser(Guid, UserCode, Password);
            return msg;
        }
        public static String DeleteUser(String userGuid)
        {
            string msg = "";
            GetInstance();
            msg = sc.DeleteUser(userGuid);
            return msg;
        }
        public static String DeleteCopro(String userGuid)
        {
            string msg = "";
            GetInstance();
            msg = sc.DeleteCopro(userGuid);
            return msg;
        }
        public static String DeleteDocument(String docGuid)
        {
            string msg = "";
            GetInstance();
            msg = sc.DeleteDocument(docGuid);
            return msg;
        }
        public static bool ServiceClientIsConfigured()
        {
            bool Configured = false;
            if ( !String.IsNullOrEmpty(serveur))
            {
                Configured = true;
            }
            return Configured;
        }
       // public static List<docu>
    }
}
