using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Web.Configuration;
using WebApp.App_Code;


namespace WebApp.pages
{
    public partial class Login : System.Web.UI.Page
    {
        //private string connString;
        //private string apiToken;
        //private BLL bll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Abandon();
            }
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            //apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            //bll = new BLL(connString, apiToken);
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            User user = GLOBALS.BllSI.UserLogin(inputUsername.Text, inputPassword.Text);

            if (user != null)
            {
                user.Password = string.Empty;
                Session["bool"] = "true";
                Session["user"] = user;
                Response.Redirect("default.aspx");
            }
            else
            {

            }
            

        }
    }
}