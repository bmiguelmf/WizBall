using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;

namespace FrontOffice.Resources
{
    public static class Factory
    {
        private static BLL bll;
        private static string apiToken;
        private static string connString;
   
        static Factory()
        {
            apiToken    = WebConfigurationManager.AppSettings["ApiToken"];
            connString  = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;

            bll = new BLL(connString, apiToken);
        }



        public static HtmlGenericControl DivCompetitions()
        {
            HtmlGenericControl wrapper = new HtmlGenericControl("div");

            wrapper.InnerText = "Bruno Ferreria";

            return wrapper;
        }


        public static HtmlGenericControl DivMatchesList()
        {
            HtmlGenericControl wrapper = new HtmlGenericControl("div");

            foreach (Competition comp in bll.GetAllCompetitions())
            {
                if (!(bll.TierOneCompetitions().Where(x => x.Id == comp.Id).ToList().Count > 0)) continue;
                comp.Area = bll.GetAreaById(comp.Area.Id.ToString());


                // Div Competition Wrapper.
                HtmlGenericControl competitionWrapper = new HtmlGenericControl("div");
                competitionWrapper.Attributes["class"] = "px-5 py-3 bg-white";


                // Div Competition Details.
                HtmlGenericControl compDetails = new HtmlGenericControl("div");
                compDetails.Attributes["class"] = "bg-info mb-3 rounded";
                // Competiton Flag.
                Image competitionsFlag = new Image();
                competitionsFlag.ImageUrl = "/Public/Imgs/Competitions/" + comp.Flag;
                competitionsFlag.Attributes["style"] = "height:200px;";
                competitionsFlag.Attributes["class"] = "pl-4 py-3";

                competitionsFlag.AlternateText = comp.Name;
                compDetails.Controls.Add(competitionsFlag);


                // Add compDetails.
                competitionWrapper.Controls.Add(compDetails);


                foreach (Match match in bll.GetMatchesByCompetition(comp.Id.ToString()))
                {
                    HtmlGenericControl matchWraper = new HtmlGenericControl("div");
                    matchWraper.Attributes["class"] = "grid-colors my-2";



                    // Match Details  Row--------------------------------------------------------------------------------------------------

                    // Row
                    HtmlGenericControl matchDetailsRow = new HtmlGenericControl("div");
                    matchDetailsRow.Attributes["class"] = "row p-0 m-0";
                    // Col
                    HtmlGenericControl matchDetailsCol = new HtmlGenericControl("div");
                    matchDetailsCol.Attributes["style"] = "font-size:10px; padding: 2px 0;";
                    matchDetailsCol.Attributes["class"] = "col-sm-12 pl-4 bg-dark text-white font-weight-bold rounded-top";

                    Label lblMatchDetail = new Label();
                    lblMatchDetail.Text = "Match Day : " + match.Matchday + " &emsp; UTC Date: " + match.UtcDate;
                    lblMatchDetail.Attributes["style"] = "";


                    matchDetailsCol.Controls.Add(lblMatchDetail);

                    matchDetailsRow.Controls.Add(matchDetailsCol);

                    matchWraper.Controls.Add(matchDetailsRow);





                    // Match Teams Row--------------------------------------------------------------------------------------------------
                    HtmlGenericControl matchTeamsRow = new HtmlGenericControl("div");
                    matchTeamsRow.Attributes["class"] = "row p-3";



                    // Home Team
                    HtmlGenericControl homeTeam = new HtmlGenericControl("div");
                    homeTeam.Attributes["class"] = "col-sm-5 px-0 text-right font-weight-bold";
                    homeTeam.Attributes["style"] = "font-size:12px;";

                    Label homeTeamName = new Label();
                    homeTeamName.Text = match.HomeTeam.Name;
                    homeTeamName.Attributes["class"] = "px-2";


                    Image homeTeamFlag = new Image();
                    homeTeamFlag.ImageUrl = "/Public/Imgs/Teams/" + comp.Area.Name + "/" + match.HomeTeam.Flag;
                    homeTeamFlag.Attributes["style"] = "width:55px;";
                    homeTeamFlag.Attributes["class"] = "px-2";

                    homeTeam.Controls.Add(homeTeamName);
                    homeTeam.Controls.Add(homeTeamFlag);

                    matchTeamsRow.Controls.Add(homeTeam);



                    // Score
                    HtmlGenericControl score = new HtmlGenericControl("div");
                    score.Attributes["class"] = "col-sm-2 px-0 text-center my-auto font-weight-bold";
                    score.Attributes["style"] = "font-size:12px;";

                    Label htScore = new Label();
                    htScore.Text = bll.NormalizeApiDateTime(match.UtcDate) < DateTime.Today ? match.Score.FullTime.HomeTeam.ToString() : "-";
                    htScore.Attributes["class"] = "px-2 align-middle";

                    Label atScore = new Label();
                    atScore.Text = bll.NormalizeApiDateTime(match.UtcDate) < DateTime.Today ? match.Score.FullTime.AwayTeam.ToString() : "-";
                    atScore.Attributes["class"] = "px-2 align-middle";

                    score.Controls.Add(htScore);
                    score.Controls.Add(atScore);

                    matchTeamsRow.Controls.Add(score);



                    // Away Team
                    HtmlGenericControl awayTeam = new HtmlGenericControl("div");
                    awayTeam.Attributes["class"] = "col-sm-5 font-weight-bold p-0";
                    awayTeam.Attributes["style"] = "font-size:12px;";

                    Label awayTeamName = new Label();
                    awayTeamName.Text = match.AwayTeam.Name;
                    awayTeamName.Attributes["class"] = "px-2";


                    Image awayTeamFlag = new Image();
                    awayTeamFlag.ImageUrl = "/Public/Imgs/Teams/" + comp.Area.Name + "/" + match.AwayTeam.Flag;
                    awayTeamFlag.Attributes["style"] = "width:55px;";
                    awayTeamFlag.Attributes["class"] = "px-2";

                    awayTeam.Controls.Add(awayTeamFlag);
                    awayTeam.Controls.Add(awayTeamName);

                    matchTeamsRow.Controls.Add(awayTeam);




                    matchWraper.Controls.Add(matchTeamsRow);



                    competitionWrapper.Controls.Add(matchWraper);

                }

                wrapper.Controls.Add(competitionWrapper);
            }

            return wrapper;
        }

    }
}
