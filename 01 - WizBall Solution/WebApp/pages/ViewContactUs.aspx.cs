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

namespace WebApp.pages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private BLL bll;
        private List<Attachment> attachments;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (IsUserLoggedIn())
            {
                UNameHF.Text = IsUserLoggedIn();
            }*/

            bll = GLOBALS.BllSI;

            if (!IsPostBack)
            {
                attachments = new List<Attachment>();
            }
            else
            {/*
                User user = Session["User"] as User;

                user.Username = txtName.Text;
                user.Email = txtEmail.Text;
                if (Request.Files[0] != null)
                {
                    HttpPostedFile userPic = Request.Files[0];

                    if (userPic.ContentLength > 0)
                    {
                        if (userPic.ContentLength < 512001)
                        {
                            user.Picture = userPic.FileName;

                            string FileName = userPic.FileName;

                            int FileSize = userPic.ContentLength;

                            byte[] FileByteArray = new byte[FileSize];

                            userPic.InputStream.Read(FileByteArray, 0, FileSize);

                            string path = Server.MapPath("~") + GLOBALS.USERS + FileName;

                            userPic.SaveAs(path);
                        }
                    }
                }
                */

                
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            MailSender.MakeMails(txtEmail.Text, txtName.Text, txtSubject.Text, txtMessage.Text, attachments);
        }
    }
}