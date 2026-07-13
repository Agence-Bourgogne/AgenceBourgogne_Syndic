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
            var report = reportViewer.LocalReport.Render("PDF");
            var lenReport = report.Length;
            var pos = 0;
            while (pos < lenReport)
            {
                var buffer = new byte[32768];
                Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, (int)(lenReport - pos)));
                pos += 32768;
                sc.UploadPartFile(Guid, buffer);
            }
            return sc.CloseFile(Header, Guid, immeuble_id, copro_id);
        }
        public static string SendReportPDF(string pdfFile, String Header, string Guid, String immeuble_id, string copro_id)
        {
            GetInstance();
            //------
            var fs = new FileStream(pdfFile,
                                           FileMode.Open,
                                           FileAccess.Read);
            var numBytes = new FileInfo(pdfFile).Length;
            var br = new BinaryReader(fs);
            var report = new byte[numBytes];
            fs.Read(report, 0, report.Length);
            fs.Close();

            //------


           // byte[] report = File.ReadAllBytes(pdfFile);
            var lenReport = report.Length;
            var pos = 0;
            while (pos < lenReport)
            {
                var buffer = new byte[32768];
                Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, (int)(lenReport - pos)));
                pos += 32768;
                sc.UploadPartFile(Guid, buffer);
            }
            return sc.CloseFile(Header, Guid, immeuble_id, copro_id);
        }
        public static String CreateUser(String UserCode, String Password)
        {
            var msg = "";
            GetInstance();
            msg = sc.CreateUser(UserCode, Password);
            return msg;
        }
        public static String UpdateUser(String Guid, String UserCode, String Password)
        {
            var msg = "";
            GetInstance();
            msg = sc.UpdateUser(Guid, UserCode, Password);
            return msg;
        }
        public static String DeleteUser(String userGuid)
        {
            var msg = "";
            GetInstance();
            msg = sc.DeleteUser(userGuid);
            return msg;
        }
        public static String DeleteCopro(String userGuid)
        {
            var msg = "";
            GetInstance();
            msg = sc.DeleteCopro(userGuid);
            return msg;
        }
        public static String DeleteDocument(String docGuid)
        {
            var msg = "";
            GetInstance();
            msg = sc.DeleteDocument(docGuid);
            return msg;
        }
        public static bool ServiceClientIsConfigured()
        {
            var Configured = false;
            if ( !String.IsNullOrEmpty(serveur))
            {
                Configured = true;
            }
            return Configured;
        }
       // public static List<docu>
    }
}
