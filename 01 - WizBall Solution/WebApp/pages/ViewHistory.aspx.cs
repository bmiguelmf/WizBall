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

        public List<Competition> Competitions { get; set; }
        public List<Competition> CompResolve;

        protected void Page_Load(object sender, EventArgs e)
        {

            HistoryTipsGrid matchesTipsGrid;
            if (IsPostBack)
            {


                apiToken = WebConfigurationManager.AppSettings["ApiToken"];
                connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoATEC"].ConnectionString;
                bll = GLOBALS.BllSI;

                matchesTipsGrid = new HistoryTipsGrid(bll.GetMatchesByRangeDateAndCompetition("2018", new DateTime(), new DateTime()));

                placeHolderHistoryTips.Controls.Add(matchesTipsGrid.Create());

            } else
            {
                CompResolve = new List<Competition>();
                List<Match> matches = new List<Match>();
                DateTime yest = DateTime.Now.AddDays(-1);
                DateTime weekBefore = yest.AddDays(-7);
                bll = GLOBALS.BllSI;
                List<Competition> competitions = new List<Competition>();

                foreach (Competition comp in bll.TierOneCompetitions())
                {
                    CompResolve.Add(comp);
                }

                foreach (Competition competition in bll.TierOneCompetitions())
                {
                    competitions.Add(bll.GetCompetitionById(competition.Id.ToString()));
                }

                compRep.DataSource = competitions;
                compRep.DataBind();

                startRange.Value = weekBefore.ToString("yyyy-MM-dd");

                endRange.Value = yest.ToString("yyyy-MM-dd");

                foreach (Competition comp in bll.TierOneCompetitions())
                {
                    matches.AddRange(bll.GetMatchesByRangeDateAndCompetition(comp.Id.ToString(), weekBefore, yest));
                }

                matchesTipsGrid = new HistoryTipsGrid(matches);

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

            if (AllCompsCB.Checked)
            {
                foreach (Competition comp in bll.TierOneCompetitions())
                {
                    matches.AddRange(GLOBALS.BllSI.GetMatchesByCompetition(comp.Id.ToString()));
                }
                matchesTipsGrid = new HistoryTipsGrid(matches);
            }

            

            else
            {
                foreach (RepeaterItem i in compRep.Items)
                {
                    //Retrieve the state of the CheckBox
                    //CheckBox cb = (CheckBox)i.FindControl("CompCB");
                    if (AllCompsCB.Checked)
                    {
                        //Retrieve the value associated with that CheckBox
                        HiddenField hiddenComp = (HiddenField)i.FindControl("HidFieldComp");

                        //Now we can use that value to do whatever we want
                        matches.AddRange(GLOBALS.BllSI.GetMatchesByCompetition(hiddenComp.Value));
                        matchesTipsGrid = new HistoryTipsGrid(matches);
                    }
                }
            }
        }
    }
}