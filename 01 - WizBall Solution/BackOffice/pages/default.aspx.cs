using System;
using WebServices;
using System.Web.Configuration;
using BusinessLogic.BLL;
using BusinessLogic.Entities;



namespace BackOffice.pages
{
    public partial class _default : System.Web.UI.Page
    {
        private string connString = WebConfigurationManager.ConnectionStrings["ConnStringBroHome"].ConnectionString;
        private string apiToken = WebConfigurationManager.AppSettings["ApiToken"];
        private BLL bll;

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new BLL(connString, apiToken);
            WizballWebService ws = new WizballWebService();


            //bll.FullDatabaseSync();
            //Page.Response.Write("Base de dados sincronizada <br/>");

        }
    }
}