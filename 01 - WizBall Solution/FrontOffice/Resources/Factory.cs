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
            connString  = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;

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
            wrapper.Attributes["class"] = "d-flex justify-content-between py-5";
            
            foreach(Competition comp in lstCompetitions)
            {
                HtmlGenericControl divComp  = new HtmlGenericControl("div");
                divComp.Attributes["style"] = "padding: 20px 3%;";

                Image compImg               = new Image();
                compImg.ImageUrl            = COMP_FLAGS + comp.Flag;
                compImg.AlternateText       = comp.Name;
                compImg.Attributes["style"] = "width: 100%";
                compImg.Attributes["title"] = comp.Name;

                divComp.Controls.Add(compImg);

                wrapper.Controls.Add(divComp);
            }

            return wrapper;
        }




        public static HtmlGenericControl TableMatchesX()
        {          
            // Table Columns.
            HtmlGenericControl thComp       = new HtmlGenericControl("th");
            thComp.InnerText                = "Competiton";
            thComp.Attributes["class"]      = "my-th";

            HtmlGenericControl thMatchDay   = new HtmlGenericControl("th");
            thMatchDay.InnerText            = "Match Day";
            thMatchDay.Attributes["class"]  = "my-th";

            HtmlGenericControl thHomeTeam   = new HtmlGenericControl("th");
            thHomeTeam.InnerText            = "Home Team";
            thHomeTeam.Attributes["class"]  = "my-th";

            HtmlGenericControl thDate       = new HtmlGenericControl("th");
            thDate.InnerText                = "Date";
            thDate.Attributes["class"]      = "my-th";

            HtmlGenericControl thAwayTeam   = new HtmlGenericControl("th");
            thAwayTeam.InnerText            = "Away Team";
            thAwayTeam.Attributes["class"]  = "my-th";

            HtmlGenericControl thFtOverTwoAndHalfGoals  = new HtmlGenericControl("th");
            thFtOverTwoAndHalfGoals.InnerText           = "Tips";
            thFtOverTwoAndHalfGoals.Attributes["class"] = "my-th";


            HtmlGenericControl trHeader     = new HtmlGenericControl("tr");
            trHeader.Attributes["class"]    = "my-tr";
            trHeader.Controls.Add(thComp);          
            trHeader.Controls.Add(thMatchDay);
            trHeader.Controls.Add(thHomeTeam);
            trHeader.Controls.Add(thDate);
            trHeader.Controls.Add(thAwayTeam);
            trHeader.Controls.Add(thFtOverTwoAndHalfGoals);


            HtmlGenericControl thead        = new HtmlGenericControl("thead");
            thead.Attributes["class"]       = "my-thead";
            thead.Controls.Add(trHeader);
            

            HtmlGenericControl table        = new HtmlGenericControl("table");
            table.Attributes["class"]       = "my-table";
            table.Controls.Add(thead);


            HtmlGenericControl tbody        = new HtmlGenericControl("tbody");
            tbody.Attributes["class"]       = "my-tbody";


            table.Controls.Add(tbody);


            foreach (Match match in bll.GetMatchesByCompetition("2017"))
            {
                // Table Columns.
                HtmlGenericControl tdComp       = new HtmlGenericControl("td");
                tdComp.InnerHtml                = "<img src='" + COMP_FLAGS + match.Competition.Flag + "' alt='" + match.Competition.Name + "' title='" + match.Competition.Name + "' width ='35px;'>";
                tdComp.Attributes["class"]      = "my-td";             

                HtmlGenericControl tdMatchDay   = new HtmlGenericControl("td");
                tdMatchDay.InnerText            = match.Matchday.ToString();
                tdMatchDay.Attributes["class"]  = "my-td";

                HtmlGenericControl tdHomeTeam   = new HtmlGenericControl("td");
                tdHomeTeam.InnerHtml            = "<img src='" + TEAM_FLAGS + match.Competition.Area.Name + "/" + match.HomeTeam.Flag + "' alt='" + match.HomeTeam.ShortName + "' title='" + match.HomeTeam.ShortName + "' width='35px;'>";
                tdHomeTeam.Attributes["class"]  = "my-td";

                HtmlGenericControl tdDate       = new HtmlGenericControl("td");
                tdDate.InnerText                = bll.NormalizeApiDateTime(match.UtcDate).Value.ToString("dd MMM HH:mm");
                tdDate.Attributes["class"]      = "my-td";

                HtmlGenericControl tdAwayTeam   = new HtmlGenericControl("td");
                tdAwayTeam.InnerHtml            = "<img src='" + TEAM_FLAGS + match.Competition.Area.Name + "/" + match.AwayTeam.Flag + "' alt='" + match.AwayTeam.ShortName + "' title='" + match.AwayTeam.ShortName + "' width='35px;'>";
                tdAwayTeam.Attributes["class"]  = "my-td";

                HtmlGenericControl tdFtOverTwoAndHalfGoals  = new HtmlGenericControl("td");
                if(match.Id % 3 == 0)
                    tdFtOverTwoAndHalfGoals.InnerHtml       = "<img src='" + MARKETS + "ft_over_two_and_half_goals.png' alt='FT Over 2.5 Goals' title='FT Over 2.5 Goals' width='35px;'>";
                else if (match.Id % 4 == 0)
                    tdFtOverTwoAndHalfGoals.InnerHtml       = "<img src='" + MARKETS + "ft_under_two_and_half_goals.png' alt='FT Under 2.5 Goals' title='FT  Under 2.5 Goals' width='35px;'>";
                else
                    tdFtOverTwoAndHalfGoals.InnerHtml       = "No Tips";
                tdFtOverTwoAndHalfGoals.Attributes["class"] = "my-td";



                HtmlGenericControl trMatch      = new HtmlGenericControl("tr");
                trMatch.Attributes["class"]     = "my-tr";


                trMatch.Controls.Add(tdComp); 
                trMatch.Controls.Add(tdMatchDay);
                trMatch.Controls.Add(tdHomeTeam);
                trMatch.Controls.Add(tdDate);
                trMatch.Controls.Add(tdAwayTeam);
                trMatch.Controls.Add(tdFtOverTwoAndHalfGoals);

                tbody.Controls.Add(trMatch);               
            }

            return table;
        }

    }
}
