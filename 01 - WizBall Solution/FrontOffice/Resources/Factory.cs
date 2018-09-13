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
        private const string TEAM_FLAGS = "/Public/Imgs/Teams/";
        private const string COMP_FLAGS = "/Public/Imgs/Competitions/";
        private const string MARKETS    = "/Public/Imgs/Markets/";


        private static BLL bll;
        private static string apiToken;
        private static string connString;
   
        static Factory()
        {
            apiToken    = WebConfigurationManager.AppSettings["ApiToken"];
            connString  = WebConfigurationManager.ConnectionStrings["atec"].ConnectionString;

            bll = new BLL(connString, apiToken);
        }



        public static HtmlGenericControl TierOneCompetitions()
        {
            List<Competition> lstCompetitions = bll.TierOneCompetitions();
           
            for(int i = 0; i < lstCompetitions.Count; i ++)
            {
                lstCompetitions[i] = bll.GetCompetitionById(lstCompetitions[i].Id.ToString());

            }


            HtmlGenericControl wrapper = new HtmlGenericControl("div");
            wrapper.Attributes["class"] = "d-flex";
            
            foreach(Competition comp in lstCompetitions)
            {
                HtmlGenericControl divComp  = new HtmlGenericControl("div");

                divComp.Attributes["class"] = "p-4";

                Image compImg               = new Image();
                compImg.ImageUrl            = COMP_FLAGS + comp.Flag;
                compImg.AlternateText       = comp.Name;
                compImg.Attributes["style"] = "width: 100%";

                divComp.Controls.Add(compImg);

                wrapper.Controls.Add(divComp);
            }

            return wrapper;
        }


        public static HtmlGenericControl MatchesList()
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


        public static Table TableMatches()
        {     
            // Table Columns.

            // Match competition flag.
            TableHeaderCell thCompetition = new TableHeaderCell();
            thCompetition.Text = "Competition";
            thCompetition.Font.Size = 9;
            thCompetition.Width = new Unit(15, UnitType.Percentage);
            thCompetition.CssClass = "text-center";

            // Match date time.
            TableHeaderCell thDate = new TableHeaderCell();
            thDate.Text = "Utc Date";
            thDate.Font.Size = 9;
            thDate.Width = new Unit(15, UnitType.Percentage);
            thDate.CssClass = "text-center";

            // Match day.
            TableHeaderCell thMatchDay = new TableHeaderCell();
            thMatchDay.Text = "Match Day";
            thMatchDay.Font.Size = 9;
            thMatchDay.Width = new Unit(15, UnitType.Percentage);
            thMatchDay.CssClass = "text-center";

            // Home team.
            TableHeaderCell thHomeTeam = new TableHeaderCell();
            thHomeTeam.Text = "Home Team";
            thHomeTeam.Font.Size = 9;
            thHomeTeam.Width = new Unit(20, UnitType.Percentage);
            thHomeTeam.CssClass = "text-right";

            // Score.
            TableHeaderCell thScore = new TableHeaderCell();
            thScore.Text = "Score";
            thScore.Font.Size = 9;
            thScore.Width = new Unit(15, UnitType.Percentage);
            thScore.CssClass = "text-center";

            // Away team.
            TableHeaderCell thAwayTeam = new TableHeaderCell();
            thAwayTeam.Text = "Away Team";
            thAwayTeam.Font.Size = 9;
            thAwayTeam.Width = new Unit(20, UnitType.Percentage);
            thAwayTeam.CssClass = "text-left";

            TableHeaderRow thead    = new TableHeaderRow();           
            thead.CssClass          = "bg-dark text-white";
            thead.Style.Value       = "width:100%;";

            thead.Controls.Add(thCompetition);
            thead.Controls.Add(thDate);
            thead.Controls.Add(thMatchDay);
            thead.Controls.Add(thHomeTeam);
            thead.Controls.Add(thScore);
            thead.Controls.Add(thAwayTeam);

            Table table         = new Table();        
            table.CssClass      = "table";
            table.Style.Value   = "width:100%;";

            table.Width = new Unit(100, UnitType.Percentage);
            table.Controls.Add(thead);

            return table;

            //foreach (Competition comp in bll.GetAllCompetitions())
            //{
            //    if (!(bll.TierOneCompetitions().Where(x => x.Id == comp.Id).ToList().Count > 0)) continue;
            //    comp.Area = bll.GetAreaById(comp.Area.Id.ToString());


            //    // Div Competition Wrapper.
            //    HtmlGenericControl competitionWrapper = new HtmlGenericControl("div");
            //    competitionWrapper.Attributes["class"] = "px-5 py-3 bg-white";


            //    // Div Competition Details.
            //    HtmlGenericControl compDetails = new HtmlGenericControl("div");
            //    compDetails.Attributes["class"] = "bg-info mb-3 rounded";
            //    // Competiton Flag.
            //    Image competitionsFlag = new Image();
            //    competitionsFlag.ImageUrl = "/Public/Imgs/Competitions/" + comp.Flag;
            //    competitionsFlag.Attributes["style"] = "height:200px;";
            //    competitionsFlag.Attributes["class"] = "pl-4 py-3";

            //    competitionsFlag.AlternateText = comp.Name;
            //    compDetails.Controls.Add(competitionsFlag);


            //    // Add compDetails.
            //    competitionWrapper.Controls.Add(compDetails);


            //    foreach (Match match in bll.GetMatchesByCompetition(comp.Id.ToString()))
            //    {
            //        HtmlGenericControl matchWraper = new HtmlGenericControl("div");
            //        matchWraper.Attributes["class"] = "grid-colors my-2";



            //        // Match Details  Row--------------------------------------------------------------------------------------------------

            //        // Row
            //        HtmlGenericControl matchDetailsRow = new HtmlGenericControl("div");
            //        matchDetailsRow.Attributes["class"] = "row p-0 m-0";
            //        // Col
            //        HtmlGenericControl matchDetailsCol = new HtmlGenericControl("div");
            //        matchDetailsCol.Attributes["style"] = "font-size:10px; padding: 2px 0;";
            //        matchDetailsCol.Attributes["class"] = "col-sm-12 pl-4 bg-dark text-white font-weight-bold rounded-top";

            //        Label lblMatchDetail = new Label();
            //        lblMatchDetail.Text = "Match Day : " + match.Matchday + " &emsp; UTC Date: " + match.UtcDate;
            //        lblMatchDetail.Attributes["style"] = "";


            //        matchDetailsCol.Controls.Add(lblMatchDetail);

            //        matchDetailsRow.Controls.Add(matchDetailsCol);

            //        matchWraper.Controls.Add(matchDetailsRow);





            //        // Match Teams Row--------------------------------------------------------------------------------------------------
            //        HtmlGenericControl matchTeamsRow = new HtmlGenericControl("div");
            //        matchTeamsRow.Attributes["class"] = "row p-3";



            //        // Home Team
            //        HtmlGenericControl homeTeam = new HtmlGenericControl("div");
            //        homeTeam.Attributes["class"] = "col-sm-5 px-0 text-right font-weight-bold";
            //        homeTeam.Attributes["style"] = "font-size:12px;";

            //        Label homeTeamName = new Label();
            //        homeTeamName.Text = match.HomeTeam.Name;
            //        homeTeamName.Attributes["class"] = "px-2";


            //        Image homeTeamFlag = new Image();
            //        homeTeamFlag.ImageUrl = "/Public/Imgs/Teams/" + comp.Area.Name + "/" + match.HomeTeam.Flag;
            //        homeTeamFlag.Attributes["style"] = "width:55px;";
            //        homeTeamFlag.Attributes["class"] = "px-2";

            //        homeTeam.Controls.Add(homeTeamName);
            //        homeTeam.Controls.Add(homeTeamFlag);

            //        matchTeamsRow.Controls.Add(homeTeam);



            //        // Score
            //        HtmlGenericControl score = new HtmlGenericControl("div");
            //        score.Attributes["class"] = "col-sm-2 px-0 text-center my-auto font-weight-bold";
            //        score.Attributes["style"] = "font-size:12px;";

            //        Label htScore = new Label();
            //        htScore.Text = bll.NormalizeApiDateTime(match.UtcDate) < DateTime.Today ? match.Score.FullTime.HomeTeam.ToString() : "-";
            //        htScore.Attributes["class"] = "px-2 align-middle";

            //        Label atScore = new Label();
            //        atScore.Text = bll.NormalizeApiDateTime(match.UtcDate) < DateTime.Today ? match.Score.FullTime.AwayTeam.ToString() : "-";
            //        atScore.Attributes["class"] = "px-2 align-middle";

            //        score.Controls.Add(htScore);
            //        score.Controls.Add(atScore);

            //        matchTeamsRow.Controls.Add(score);



            //        // Away Team
            //        HtmlGenericControl awayTeam = new HtmlGenericControl("div");
            //        awayTeam.Attributes["class"] = "col-sm-5 font-weight-bold p-0";
            //        awayTeam.Attributes["style"] = "font-size:12px;";

            //        Label awayTeamName = new Label();
            //        awayTeamName.Text = match.AwayTeam.Name;
            //        awayTeamName.Attributes["class"] = "px-2";


            //        Image awayTeamFlag = new Image();
            //        awayTeamFlag.ImageUrl = "/Public/Imgs/Teams/" + comp.Area.Name + "/" + match.AwayTeam.Flag;
            //        awayTeamFlag.Attributes["style"] = "width:55px;";
            //        awayTeamFlag.Attributes["class"] = "px-2";

            //        awayTeam.Controls.Add(awayTeamFlag);
            //        awayTeam.Controls.Add(awayTeamName);

            //        matchTeamsRow.Controls.Add(awayTeam);




            //        matchWraper.Controls.Add(matchTeamsRow);



            //        competitionWrapper.Controls.Add(matchWraper);

            //    }

            //    wrapper.Controls.Add(competitionWrapper);
            //}

        }

        public static HtmlGenericControl TableMatchesX()
        {
            // Table Columns.
            HtmlGenericControl thComp       = new HtmlGenericControl("th");
            thComp.InnerText                = "Competiton";
            thComp.Attributes["style"]      = "width:10%; font-size:10px;";
            thComp.Attributes["class"]      = "text-center";

            HtmlGenericControl thDate       = new HtmlGenericControl("th");
            thDate.InnerText                = "Date";
            thDate.Attributes["style"]      = "width:15%; font-size:10px;";
            thDate.Attributes["class"]      = "text-center";

            HtmlGenericControl thMatchDay   = new HtmlGenericControl("th");
            thMatchDay.InnerText            = "Match Day";
            thMatchDay.Attributes["style"]  = "width:15%; font-size:10px;";
            thMatchDay.Attributes["class"]  = "text-center";

            HtmlGenericControl thHomeTeam   = new HtmlGenericControl("th");
            thHomeTeam.InnerText            = "Home Team";
            thHomeTeam.Attributes["style"]  = "width:25%; font-size:10px;";
            thHomeTeam.Attributes["class"]  = "text-right";

            HtmlGenericControl thScore      = new HtmlGenericControl("th");
            thScore.InnerText               = "Score";
            thScore.Attributes["style"]     = "width:10%; font-size:10px;";
            thScore.Attributes["class"]     = "text-center";

            HtmlGenericControl thAwayTeam   = new HtmlGenericControl("th");
            thAwayTeam.InnerText            = "Away Team";
            thAwayTeam.Attributes["style"]  = "width:25%; font-size:10px;";
            thAwayTeam.Attributes["class"]  = "text-left";
               

            HtmlGenericControl trHeader     = new HtmlGenericControl("tr");
            trHeader.Attributes["style"]          = "width:100%;";
            trHeader.Controls.Add(thComp);
            trHeader.Controls.Add(thDate);
            trHeader.Controls.Add(thMatchDay);
            trHeader.Controls.Add(thHomeTeam);
            trHeader.Controls.Add(thScore);
            trHeader.Controls.Add(thAwayTeam);


            HtmlGenericControl thead        = new HtmlGenericControl("thead");
            thead.Attributes["style"]       = "width:100%;";
            thead.Controls.Add(trHeader);
            

            HtmlGenericControl table        = new HtmlGenericControl("table");
            table.Attributes["class"]       = "table";
            table.Attributes["style"]       = "width:100%; margin-top:10px;";
            table.Controls.Add(thead);


            HtmlGenericControl tbody = new HtmlGenericControl("tbdoy");

            foreach (Match match in bll.GetMatchesByCompetition("2017"))
            {
                // Table Columns.
                HtmlGenericControl tdComp = new HtmlGenericControl("td");
                tdComp.InnerText = match.Competition.Flag;
                tdComp.Attributes["style"] = "";
                tdComp.Attributes["class"] = "text-center";

                HtmlGenericControl tdDate = new HtmlGenericControl("td");
                tdDate.InnerText = match.UtcDate;
                tdDate.Attributes["style"] = "";
                tdDate.Attributes["class"] = "text-center";

                HtmlGenericControl tdMatchDay = new HtmlGenericControl("td");
                tdMatchDay.InnerText = match.Matchday.ToString();
                tdMatchDay.Attributes["style"] = "";
                tdMatchDay.Attributes["class"] = "text-center";

                HtmlGenericControl tdHomeTeam = new HtmlGenericControl("td");
                tdHomeTeam.InnerText = match.HomeTeam.ShortName;
                tdHomeTeam.Attributes["style"] = "";
                tdHomeTeam.Attributes["class"] = "text-right";

                HtmlGenericControl tdScore = new HtmlGenericControl("td");
                tdScore.InnerText = match.Score.FullTime.HomeTeam + " " + match.Score.FullTime.AwayTeam;
                tdScore.Attributes["style"] = "";
                tdScore.Attributes["class"] = "text-center";

                HtmlGenericControl tdAwayTeam = new HtmlGenericControl("td");
                tdAwayTeam.InnerText = match.AwayTeam.ShortName;
                tdAwayTeam.Attributes["style"] = "";
                tdAwayTeam.Attributes["class"] = "text-left";

                HtmlGenericControl trMatch = new HtmlGenericControl("tr");
                trMatch.Attributes["style"] = "width:100%;";
                trMatch.Controls.Add(tdComp);
                trMatch.Controls.Add(tdDate);
                trMatch.Controls.Add(tdMatchDay);
                trMatch.Controls.Add(tdHomeTeam);
                trMatch.Controls.Add(tdScore);
                trMatch.Controls.Add(tdAwayTeam);

                tbody.Controls.Add(trMatch);

                
            }

            table.Controls.Add(tbody);

            return table;
        }

    }
}
