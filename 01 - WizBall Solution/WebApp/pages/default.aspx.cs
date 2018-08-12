using System;
using System.Web.Configuration;
using System.Web.UI;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using WebApp.App_Code;

namespace WebApp.pages
{
    public partial class _default : System.Web.UI.Page
    {
        //private string connString;
        //private string apiToken;
        //private BLL bll;


        protected void Page_Load(object sender, EventArgs e)
        {
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            //apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            //bll = new BLL(connString, apiToken);

            
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}