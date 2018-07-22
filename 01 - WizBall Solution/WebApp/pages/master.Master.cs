using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.pages
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bool"].ToString() != "true")
            {
                Sess.Visible = true;
                NoSess.Visible = false;
                ProfileImg.ImageUrl = Session["profPic"].ToString();
            } else
            {
                Sess.Visible = false;
                NoSess.Visible = true;
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

        }
    }
}