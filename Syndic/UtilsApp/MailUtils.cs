using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using CommonProjectsPartners.Utils;
using SyndicData.Common;

namespace EspaceSyndic.UtilsApp;

public static class MailUtils
{
    private static string urlWeb;

    public static void SendEMail(string mailTo, string pass)
    {
            
        try
        {
            urlWeb = ParametresDB.getParam1("SERVEUR", "ADDRESSE CONNECTION");
            var hostSrv = ParametresDB.getParam1("SERVEUR", "HOTE SMTP"); //"smtp.gmail.com";
            var uPort = int.Parse(ParametresDB.getParam1("SERVEUR", "PORT SMTP")); // 587;
            var strUser = ParametresDB.getParam1("SERVEUR", "USER SMTP"); //"racattac13@gmail.com";
            var strPswd = ParametresDB.getParam1("SERVEUR", "PASS GMAIL");
            var testMode = int.Parse(ParametresDB.getParam1("SERVEUR", "TEST MODE")); // 587;
            var strTo = testMode == 1 ? ParametresDB.getParam1("SERVEUR", "TEST MAIL") : mailTo;
            if (RegexUtils.IsValidEmail(strTo) && RegexUtils.IsValidEmail(strUser))
            {
                var SmtpServer = new SmtpClient();
                SmtpServer.Host = hostSrv;
                SmtpServer.Port = uPort;
                var mail = new MailMessage();

                mail.From = new MailAddress(strUser);
                mail.To.Add(strTo);
                mail.Subject = "Création de compte extranet Agence Bourgogne";
                var subject = ParametresDB.getParam1("SERVEUR", "OBJET MAIL");
                if (!string.IsNullOrEmpty(subject))
                    mail.Subject = subject;
                mail.Body = GetBody(pass);

                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(strUser, strPswd);

                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("erreur Envoi email " +ex.Message);
        }
    }

    private static string ReplaceVariable(string line, string pass)
    {
        return line.Replace("{link}", urlWeb).Replace("{pass}", pass);
    }

    private static string GetBody(string pass)
    {
        var srvPath = AppDomain.CurrentDomain.BaseDirectory;
        var FileName = srvPath + @"Utils\mailbody.txt";
        var lines = File.ReadAllLines(FileName);
        var body = "";
        foreach (var line in lines)
        {
            body += ReplaceVariable(line, pass) + "\r\n";
        }
        return body;
    }
}