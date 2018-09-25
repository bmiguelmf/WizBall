using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;
using WebApp.App_Code;

namespace WebApp.pages
{
    public partial class ViewHistory : System.Web.UI.Page
    {

        private static BLL bll;
        private static string apiToken;
        private static string connString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;


            apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;
            bll = new BLL(connString, apiToken);
            



            HistoryTipsGrid matchesTipsGrid = new HistoryTipsGrid(bll.GetMatchesByRangeDateAndCompetition("2018",new DateTime(),new DateTime()));


            placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());

        }
    }
}