using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace NoteClasses
{
    public class Email
    {
        private string smtpHost;
        private int smtpPort;
        private string smtpUser;
        private string smtpPassword;

        public Email(string smtpHost, int smtpPort, string smtpUser, string smtpPassword)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.smtpUser = smtpUser;
            this.smtpPassword = smtpPassword;
        }

        public void SendEmail(string fromAddress, string toAddress, string subject, string body)
        {
            MailMessage mail = new MailMessage(fromAddress, toAddress);
            SmtpClient client = new SmtpClient();

            client.Port = smtpPort;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = smtpHost;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            mail.Subject = subject;
            mail.Body = body;

            try
            {
                client.Send(mail);
                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email. Error: " + ex.Message);
            }


        }
    }
}
