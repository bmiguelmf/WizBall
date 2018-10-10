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


        private static MailMessage ClientMailBuilder(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            MailMessage messageToClient = new MailMessage();
            try
            {
                messageToClient.From = new MailAddress("pftestessrc@gmail.com");
                messageToClient.To.Add(UserEmail);
                messageToClient.BodyEncoding = Encoding.UTF8;
                messageToClient.Subject = MessageSubject;
                messageToClient.Body = string.Format(@"Hello, {0}<br /><br />
                                                        Thank you for your message, our staff will check it out ASAP, so that we can see what's going on.<br /><br />
                                                        The message you sent was as follows:<br /><br />
                                                        {1}<br /><br />
                                                        {2}<br /><br />
                                                        This is an automated message, please do not reply.<br /><br />
                                                        With best regards from WizBall.", 
                                                        UserName, 
                                                        MessageSubject, 
                                                        MessageBody
                );

                //Attachment at = new Attachment("~/Attachments/txt.doc");

                if (!(attachments is null))
                {
                    foreach (Attachment attachment in attachments)
                    {
                        messageToClient.Attachments.Add(attachment);
                    }
                }

                

                messageToClient.Priority = MailPriority.High;
                messageToClient.IsBodyHtml = true;

                //prepare to send mail via SMTP transport
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return messageToClient;
        }




        private static MailMessage ServerMailBuilder(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            MailMessage messageToServer = new MailMessage("pftestessrc@gmail.com", "pftestesdepo@gmail.com");
            try
            {



                messageToServer.BodyEncoding = Encoding.UTF8;
                messageToServer.Subject = MessageSubject;
                messageToServer.Body = MessageSubject;

                //Attachment at = new Attachment("~/Attachments/txt.doc");
                if (!(attachments is null))
                {
                    foreach (Attachment attachment in attachments)
                    {
                        messageToServer.Attachments.Add(attachment);
                    }
                }

                messageToServer.Priority = MailPriority.High;
                messageToServer.IsBodyHtml = true;

                //prepare to send mail via SMTP transport
                /*SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com");
                objSMTPClient.Port = 587;
                objSMTPClient.Credentials = new System.Net.NetworkCredential("pftestessrc@gmail.com", "pf2018atec");
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(messageToServer);*/

                return messageToServer;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return messageToServer;
        }

        private static bool SendMailToServer(MailMessage message)
        {
            try
            {
                SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com");
                objSMTPClient.Port = 587;
                objSMTPClient.Credentials = new System.Net.NetworkCredential("pftestesdepo@gmail.com", "pf2018atec");
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
                return false;
            }
            return true;
            
        }

        private static bool SendMailToClient(MailMessage message)
        {
            try
            {
                SmtpClient objSMTPClient = new SmtpClient("smtp.gmail.com");
                objSMTPClient.Port = 587;
                objSMTPClient.Credentials = new System.Net.NetworkCredential("pftestesdepo@gmail.com", "pf2018atec");
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
                return false;
            }
            return true;

        }

        public static bool MakeMails(string UserEmail, string UserName, string MessageSubject, string MessageBody, List<Attachment> attachments)
        {
            MailMessage ClientMessage = ClientMailBuilder(UserEmail, UserName, MessageSubject, MessageBody, attachments);
            SendMailToClient(ClientMessage);

            MailMessage ServerMessage = ServerMailBuilder(UserEmail, UserName, MessageSubject, MessageBody, attachments);
            SendMailToServer(ServerMessage);

            return true;
        }

    }
}