using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace SMTP_email
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fromMail = "ameenalodhi9@gmail.com";
            string fromPassword = "ohck ewzf jxdy jdcn";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = " Recruiment drive";
            message.To.Add(new MailAddress("usmanlodhi0811@gmail.com"));
            message.Body = "<html><body> PFA </body></html>";
            message.IsBodyHtml = true;

            string filePath = @"C:\Users\HP\source\repos\SMTP email\testfile.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Create the attachment and add it to the email
                Attachment attachment = new Attachment(filePath);
                message.Attachments.Add(attachment);
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
