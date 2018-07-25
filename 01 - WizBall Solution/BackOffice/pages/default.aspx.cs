using System;
using WebServices;
using System.Web.Configuration;
using BusinessLogic.BLL;
using BusinessLogic.Entities;



namespace BackOffice.pages
{
    public partial class _default : System.Web.UI.Page
    {
        private string connString;
        private string apiToken;
        private BLL bll;


        protected void Page_Load(object sender, EventArgs e)
        {
            connString = WebConfigurationManager.ConnectionStrings["ConnStringBroHome"].ConnectionString;
            apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            
            bll = new BLL(connString, apiToken);
            WizballWebService ws = new WizballWebService();

            //bll.FullDatabaseSync();
            //Page.Response.Write("Base de dados sincronizada <br/>");



        }
    }
}