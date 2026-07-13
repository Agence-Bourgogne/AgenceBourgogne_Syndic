using System;
using System.Net.Mail;
using SyndicData.Common;

namespace EspaceSyndic.UtilsApp
{
    public class MailUtils
    {
        private static string urlWeb;
        //---------------------------------- 
        public static void SendEMail(string mailTo, string pass)
        {
            
            try
            {
                urlWeb = ParametresDB.getParam1("SERVEUR", "ADDRESSE CONNECTION");
                String hostSrv = ParametresDB.getParam1("SERVEUR", "HOTE SMTP"); //"smtp.gmail.com";
                int uPort = Int32.Parse(ParametresDB.getParam1("SERVEUR", "PORT SMTP")); // 587;
                String strUser = ParametresDB.getParam1("SERVEUR", "USER SMTP"); //"racattac13@gmail.com";
                String strPswd = ParametresDB.getParam1("SERVEUR", "PASS GMAIL");
                int testMode = Int32.Parse(ParametresDB.getParam1("SERVEUR", "TEST MODE")); // 587;
                String strTo = (testMode == 1) ? ParametresDB.getParam1("SERVEUR", "TEST MAIL") : mailTo;
                if (CommonProjectsPartners.Utils.RegexUtils.IsValidEmail(strTo) && CommonProjectsPartners.Utils.RegexUtils.IsValidEmail(strUser))
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Host = hostSrv;
                    SmtpServer.Port = uPort;
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(strUser);
                    mail.To.Add(strTo);
                    mail.Subject = "Création de compte extranet Agence Bourgogne";
                    string subject = ParametresDB.getParam1("SERVEUR", "OBJET MAIL");
                    if (!string.IsNullOrEmpty(subject))
                        mail.Subject = subject;
                    mail.Body = GetBody(pass);

                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(strUser, strPswd);

                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("erreur Envoi email " +ex.Message);
            }
        }
        //------------------------------------
        private static string ReplaceVariable(string line, string pass)
        {
            return line.Replace("{link}", urlWeb).Replace("{pass}", pass);
        }
        //------------------------------------
        private static string GetBody(string pass)
        {
            string srvPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = srvPath + @"Utils\mailbody.txt";
            string[] lines = System.IO.File.ReadAllLines(FileName);
            string body = "";
            foreach (string line in lines)
            {
                body += ReplaceVariable(line, pass) + "\r\n";
            }
            return body;
        }
    }
}
