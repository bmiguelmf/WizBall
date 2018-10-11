using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using WebApp.App_Code;
using System.Net.Mail;
using System.IO;

namespace WebApp.pages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private User user;
        private BLL bll;
        private List<Attachment> attachments;

        private bool IsUserLoggedIn()
        {
            user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            UNameHF.Value = "guestXwb";
            if (IsUserLoggedIn())

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

                    }

                    foreach (HttpPostedFile uploadedFile in attachmentInp.PostedFiles)
                    {
                        string tempFileName = Path.GetFileName(uploadedFile.FileName);
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Attachments/"), uploadedFile.FileName));
                        attachments.Add(new Attachment(uploadedFile.InputStream, tempFileName));

                        if (uploadedFile.ContentLength > 2048000 || (uploadedFile.ContentLength < 0 || uploadedFile is null))
                        {

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