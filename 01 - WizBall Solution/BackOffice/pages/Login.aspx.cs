using System;
using System.Web.Configuration;
using BusinessLogic.BLL;
using BusinessLogic.Entities;


namespace BackOffice.pages
{
    public partial class Login : System.Web.UI.Page
    {
        private string connString;
        private string apiToken;
        private BLL bll;


        protected void Page_Load(object sender, EventArgs e)
        {
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringPasseiraAtec"].ConnectionString;
            connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;
            apiToken = WebConfigurationManager.AppSettings["ApiToken"];

            bll = new BLL(connString, apiToken);
            WebService ws = new WebService();

            //bll.FullDatabaseSync();
            //Page.Response.Write("Base de dados sincronizada <br/>");



        }
    }
}