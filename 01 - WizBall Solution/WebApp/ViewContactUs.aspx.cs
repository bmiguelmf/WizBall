using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web;
using WebApp.App_Code;

namespace WebApp
{
    public partial class ViewContactUs : System.Web.UI.Page
    {
        private User user;
        private BLL bll;
        private List<Attachment> attachments = new List<Attachment>();

        private string FolderFormat(string email, string FileName)
        {
            DateTime dateTime = DateTime.Now;

            string emailEscape = Uri.EscapeDataString(email);

            string rt = dateTime.ToString("yyyy/MM/dd/HH/mm/ss") + "/" + emailEscape + "/";

            string attachment = Server.MapPath("~/Attachments/");
            string path = Path.Combine(attachment, rt);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            rt = path + FileName;

            return rt;
        }

        private bool IsUserLoggedIn()
        {
            user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = GLOBALS.BllSI;

            if (!IsPostBack)
            {
                attachments = new List<Attachment>();
                if (IsUserLoggedIn())
                {
                    User user = Session["User"] as User;
                    UNameHF.Value = user.Username;
                    UEmailHF.Value = user.Email;
                }
            }
            else
            {





                if (Request.Files[0] != null)
                {
                    int AttListFileSize = new int();

                    foreach (HttpPostedFile uploadedFile in attachmentInp.PostedFiles)
                    {
                        //Getting the sum of the sum of all the files, to verifies that it can be sent through an e-mail
                        AttListFileSize += uploadedFile.ContentLength;
                    }

                    if (AttListFileSize > 2048000)
                    {

                        return;
                    }
                    else
                    {

                        foreach (HttpPostedFile uploadedFile in attachmentInp.PostedFiles)
                        {
                            if (uploadedFile.ContentLength > 0)
                            {
                                string FileName = (FolderFormat(txtEmail.Text, Path.GetFileName(uploadedFile.FileName)));
                                uploadedFile.SaveAs(FileName);
                                attachments.Add(new Attachment(FileName));
                            }

                        }
                    }


                }

            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            MailSender.MakeMails(txtEmail.Text, txtName.Text, txtSubject.Text, txtMessage.Text, attachments);
        }
    }
}