using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.Entities;
using WebApp.App_Code;

namespace WebApp.pages
{
    public partial class master : System.Web.UI.MasterPage
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["bool"] == null)
            {
                Sess.Visible = false;
                NoSess.Visible = true;
            } else
            {
                try
                {
                    user = Session["user"] as User;
                }
                catch (Exception)
                {
                    Response.Redirect("Login.aspx");
                }
                ProfLbl.Text = user.Username;
                ProfImg.ImageUrl = GLOBALS.GetHTMLImagePath(user.Picture);
                Sess.Visible = true;
                NoSess.Visible = false;
            }
        }

        protected void ProfileImg_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void ProfBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfileEdit.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("default.aspx");
        }
    }
}