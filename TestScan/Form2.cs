using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.Security;

namespace TestScan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbHost.Text = "smtp.gmail.com";
            tbDesti.Text = "gilles.vilin@free.fr";
            tbFrom.Text = "gilles.vilin.free@gmail.com";

            // Sur le compte Google Activer Appli moins securisées
            tbPort.Text = "587";
        }
        private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

            try
            {

//                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                
                MailMessage mail = new MailMessage(tbFrom.Text, tbDesti.Text);
                SmtpClient client = new SmtpClient(tbHost.Text);

                client.Port = Int16.Parse(tbPort.Text);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
//                client.ClientCertificates = 
                client.UseDefaultCredentials = false;
                client.Host = tbHost.Text;
                client.Timeout = 30000;
                client.Credentials = new System.Net.NetworkCredential("gilles.vilin.free@gmail.com", "gvifender");
                mail.Subject = "test";
                mail.Body = tbText.Text;
//                client.Send(mail);
//                mail.Attachments.Add(new Attachment())
                client.SendCompleted += client_SendCompleted;
                client.SendAsync(mail, tbDesti.Text);
                Console.WriteLine("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SmtpClient client = (SmtpClient) sender;
            Console.WriteLine("client_SendCompleted");
            Console.WriteLine(client);
            Console.WriteLine(e);

//            throw new NotImplementedException();
        }
    }
}
