using System;
using System.Web.Configuration;
using System.Web.UI;
using BusinessLogic.BLL;
using BusinessLogic.Entities;

namespace WebApp.pages
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

            foreach (Match match in bll.GetMatchesByCompetition("2017"))
            {
                Page.Response.Write(match.HomeTeam.Name + " " +
                                    "<img src='/resources/imgs/teams/portugal/" + match.HomeTeam.Flag + "' width='50px'/> " +
                                    "<img src='/resources/imgs/teams/portugal/" + match.AwayTeam.Flag + "' width='50px'/> " +
                                     match.AwayTeam.Name + "<br/>");
            }
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