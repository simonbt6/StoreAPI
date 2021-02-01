using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;
using System.ComponentModel;

namespace AdminPanel.Data.SMTP
{
    class SMTPConnection
    {
        SmtpClient client;

        public SMTPConnection()
        {
            client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("storeboreal4@gmail.com", "borealstorecom"),
                EnableSsl = true
            };
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        }

        public void sendMail(string subject, string content, List<String> recipients)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress("info@boreal-store.com", "Boreal Store"),

                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };
            recipients.ForEach(recipient =>
            {
                msg.To.Add(recipient);
            });

            client.SendAsync(msg, "testToken");
        }


        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs args)
        {
            Console.WriteLine("Message sent.");
        }
    }
}
