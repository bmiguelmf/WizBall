using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Resources;
using BusinessLogic.BLL;
using System.Web.Configuration;
using BusinessLogic.Entities;

namespace FrontOffice.Pages
{
    public partial class ViewLogin : System.Web.UI.Page
    {
        private static BLL bll;
        private static string apiToken;
        private static string connString;

        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn())
            {
                Response.Redirect("/Pages/ViewHome.aspx");
            }


            if (IsPostBack)
            {
                return;
            }


            apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;
            bll = new BLL(connString, apiToken);
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user =  bll.UserLogin(username, password);

            if(user is null)
            {
                Page.Response.Write("fds");
            }
            else
            {
                Session["User"] = user;
                Response.Redirect("/Pages/ViewHome.aspx");
            }
        }       
    }
}