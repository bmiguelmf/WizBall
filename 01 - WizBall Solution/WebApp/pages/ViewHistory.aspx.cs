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
            if (IsPostBack)
            {


                apiToken = WebConfigurationManager.AppSettings["ApiToken"];
                connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoATEC"].ConnectionString;
                bll = GLOBALS.BllSI;




                HistoryTipsGrid matchesTipsGrid = new HistoryTipsGrid(bll.GetMatchesByRangeDateAndCompetition("2018", new DateTime(), new DateTime()));


                placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());

            } else
            {
                List<Match> matches = new List<Match>();
                DateTime yest = DateTime.Now.AddDays(-1);
                DateTime weekBefore = yest.AddDays(-7);
                bll = GLOBALS.BllSI;

                startRange.Value = weekBefore.ToString("yyyy-MM-dd");

                endRange.Value = yest.ToString("yyyy-MM-dd");

                foreach (Competition comp in bll.TierOneCompetitions())
                {
                    matches.AddRange(bll.GetMatchesByRangeDateAndCompetition(comp.Id.ToString(), weekBefore, yest));
                }

                HistoryTipsGrid matchesTipsGrid = new HistoryTipsGrid(matches);

                placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());
            }
        }

        protected void Filter_Btn_Click(object sender, EventArgs e)
        {
            List<Match> matches = new List<Match>();
            DateTime startdate = DateTime.Parse(startRange.Value);
            DateTime enddate = DateTime.Parse(endRange.Value);
            foreach (Competition comp in bll.TierOneCompetitions())
            {
                matches.AddRange(bll.GetMatchesByRangeDateAndCompetition(comp.Id.ToString(), startdate, enddate));
            }

            HistoryTipsGrid matchesTipsGrid = new HistoryTipsGrid(matches);

            placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());
        }
    }
}