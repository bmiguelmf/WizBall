using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace WebApp.App_Code
{
    public static class MailSender
    {
        public static void SendMail(string UserEmail, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            try
            {
                MailMessage message = new MailMessage(UserEmail, "");

                message.BodyEncoding = Encoding.UTF8;
                message.Subject = MessageSubject;
                message.Body = MessageSubject;

                //Attachment at = new Attachment("~/Attachments/txt.doc");
                foreach (Attachment attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }

                message.Priority = MailPriority.High;
                message.IsBodyHtml = true;

                //prepare to send mail via SMTP transport
                SmtpClient objSMTPClient = new SmtpClient();
                objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                objSMTPClient.Send(message);
            }
            catch (Exception ex)
            {
            }
        }
    }
}