using System;
using System.IO;
using System.ServiceModel;
using EspaceSyndic.ServiceReference;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;

namespace EspaceSyndic.UtilsApp;

public static class ServiceReferenceUtils
{
    private static readonly string serveur = ParametresDB.getParam1("SERVEUR", "ADDRESSE");
    private static ServiceClient sc;
    public static ServiceClient GetInstance()
    {
        if (sc == null)
        {
            sc = new ServiceClient(new BasicHttpBinding(), new EndpointAddress(serveur));
        }
        return sc;
    }

    public static string  SendReportPDF(ReportViewer reportViewer, string Header, string Guid, string immeuble_id, string copro_id)
    {
        GetInstance();
        var report = reportViewer.LocalReport.Render("PDF");
        var lenReport = report.Length;
        var pos = 0;
        while (pos < lenReport)
        {
            var buffer = new byte[32768];
            Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, lenReport - pos));
            pos += 32768;
            sc.UploadPartFile(Guid, buffer);
        }
        return sc.CloseFile(Header, Guid, immeuble_id, copro_id);
    }
    public static void SendReportPDF(string pdfFile, string Header, string Guid, string immeuble_id, string copro_id)
    {
        GetInstance();

        var fs = new FileStream(pdfFile,
            FileMode.Open,
            FileAccess.Read);
        var numBytes = new FileInfo(pdfFile).Length;
        var report = new byte[numBytes];
        fs.ReadExactly(report, 0, report.Length);
        fs.Close();

        var lenReport = report.Length;
        var pos = 0;
        while (pos < lenReport)
        {
            var buffer = new byte[32768];
            Buffer.BlockCopy(report, pos, buffer, 0, Math.Min(32768, lenReport - pos));
            pos += 32768;
            sc.UploadPartFile(Guid, buffer);
        }

        sc.CloseFile(Header, Guid, immeuble_id, copro_id);
    }
    public static string CreateUser(string UserCode, string Password)
    {
        var msg = "";
        GetInstance();
        msg = sc.CreateUser(UserCode, Password);
        return msg;
    }
    public static string UpdateUser(string Guid, string UserCode, string Password)
    {
        var msg = "";
        GetInstance();
        msg = sc.UpdateUser(Guid, UserCode, Password);
        return msg;
    }
    public static string DeleteUser(string userGuid)
    {
        GetInstance();
        var msg = sc.DeleteUser(userGuid);
        return msg;
    }
    public static string DeleteCopro(string userGuid)
    {
        var msg = "";
        GetInstance();
        msg = sc.DeleteCopro(userGuid);
        return msg;
    }
    public static string DeleteDocument(string docGuid)
    {
        var msg = "";
        GetInstance();
        msg = sc.DeleteDocument(docGuid);
        return msg;
    }
    public static bool ServiceClientIsConfigured()
    {
        var Configured = false;
        if ( !string.IsNullOrEmpty(serveur))
        {
            Configured = true;
        }
        return Configured;
    }
}