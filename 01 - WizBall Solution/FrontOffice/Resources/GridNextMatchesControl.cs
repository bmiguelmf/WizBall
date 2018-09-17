using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;
using FrontOffice.Resources;

namespace FrontOffice.Resources
{
    public static class GridNextMatchesControl
    {

        private static BLL bll;
        private static string apiToken;
        private static string connString;
   
        static GridNextMatchesControl()
        {
            apiToken    = WebConfigurationManager.AppSettings["ApiToken"];
            connString  = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;

            bll = new BLL(connString, apiToken);
        }



        private static HtmlGenericControl HeaderGridNextMatches()
        {
            List<Competition> lstCompetitions = bll.TierOneCompetitions();
           
            for(int i = 0; i < lstCompetitions.Count; i ++)
            {
                lstCompetitions[i] = bll.GetCompetitionById(lstCompetitions[i].Id.ToString());

            }


            HtmlGenericControl wrapper = new HtmlGenericControl("div");
            wrapper.Attributes["class"] = "tire-one-comps";
            
            foreach(Competition comp in lstCompetitions)
            {
                HtmlGenericControl divComp  = new HtmlGenericControl("div");
                divComp.Attributes["class"] = "text-center competitions-wrapper";

                Image compImg               = new Image();
                compImg.ImageUrl            = Globals.COMP_FLAGS + comp.Flag;
                compImg.AlternateText       = comp.Name;
                compImg.Attributes["title"] = comp.Name;

                divComp.Controls.Add(compImg);

                wrapper.Controls.Add(divComp);
            }

            return wrapper;
        }


        private static HtmlGenericControl BodyGridNextMatches()
        {
            // Header.
            HtmlGenericControl header               = new HtmlGenericControl("div");
            header.Attributes["class"]              = "my-grid-header";




            // Header cells.
            HtmlGenericControl cellCompetition      = new HtmlGenericControl("div");
            cellCompetition.Attributes["class"]     = "my-grid-cell";
            cellCompetition.Attributes["title"]     = "Competition";
            cellCompetition.InnerText               = "C";
            header.Controls.Add(cellCompetition);

            HtmlGenericControl cellMatchDay         = new HtmlGenericControl("div");
            cellMatchDay.Attributes["class"]        = "my-grid-cell";
            cellMatchDay.Attributes["title"]        = "Match Day";
            cellMatchDay.InnerHtml                  = "MD";            
            header.Controls.Add(cellMatchDay);

            HtmlGenericControl cellHomeTeam         = new HtmlGenericControl("div");
            cellHomeTeam.Attributes["class"]        = "my-grid-cell text-right";
            cellHomeTeam.Attributes["title"]        = "Home Team";
            cellHomeTeam.InnerText                  = "Home Team";
            header.Controls.Add(cellHomeTeam);

            HtmlGenericControl cellDate             = new HtmlGenericControl("div");
            cellDate.Attributes["class"]            = "my-grid-cell";
            cellDate.Attributes["title"]            = "Match Date";
            cellDate.InnerText                      = "Date";
            header.Controls.Add(cellDate);

            HtmlGenericControl cellAwayTeam         = new HtmlGenericControl("div");
            cellAwayTeam.Attributes["class"]        = "my-grid-cell text-left";
            cellAwayTeam.Attributes["title"]        = "Away Team";
            cellAwayTeam.InnerText                  = "Away Team";
            header.Controls.Add(cellAwayTeam);

            HtmlGenericControl cellTips             = new HtmlGenericControl("div");
            cellTips.Attributes["class"]            = "my-grid-cell";
            cellTips.Attributes["title"]            = "Markets Tips";
            cellTips.InnerText                      = "Tips";
            header.Controls.Add(cellTips);


            HtmlGenericControl scroll               = new HtmlGenericControl("div");
            scroll.Attributes["id"]                 = "scrolableGridMatchesBody";
            scroll.Attributes["class"]              = "scroll";


            // Body
            HtmlGenericControl body                 = new HtmlGenericControl("div");
            body.Attributes["class"]                = "my-grid-body";
            body.Attributes["id"]                   = "my-grid-body";

            scroll.Controls.Add(body);

            foreach (Match match in bll.GetNextMatchesByTierOneCompetitions())
            {
                // Rows
                HtmlGenericControl row                  = new HtmlGenericControl("div");
                row.Attributes["class"]                 = "my-grid-row";


                // Row cells.
                HtmlGenericControl rowCellCompetition   = new HtmlGenericControl("div");
                rowCellCompetition.Attributes["class"]  = "my-grid-cell";
                rowCellCompetition.InnerHtml            = "<img src='" + Globals.COMP_FLAGS + match.Competition.Flag + "' alt='" + match.Competition.Name + "' title='" + match.Competition.Name + "' width ='24px;'>";
                row.Controls.Add(rowCellCompetition);

                HtmlGenericControl rowCellMatchDay      = new HtmlGenericControl("div");
                rowCellMatchDay.Attributes["class"]     = "my-grid-cell";
                rowCellMatchDay.InnerHtml               = match.Matchday.ToString();
                row.Controls.Add(rowCellMatchDay);

                HtmlGenericControl rowCellHomeTeam      = new HtmlGenericControl("div");
                rowCellHomeTeam.Attributes["class"]     = "my-grid-cell text-right";
                rowCellHomeTeam.InnerHtml               = match.HomeTeam.ShortName + "<img class='teamFlag pl-2' src='" + Globals.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.HomeTeam.Flag + "' alt='" + match.HomeTeam.ShortName + "' title='" + match.HomeTeam.ShortName + "' width='24px;'>";
                row.Controls.Add(rowCellHomeTeam);

                HtmlGenericControl rowCellDate          = new HtmlGenericControl("div");
                rowCellDate.Attributes["class"]         = "my-grid-cell";
                rowCellDate.InnerHtml                   = bll.NormalizeApiDateTime(match.UtcDate).Value.ToString("dd MMM HH:mm");
                row.Controls.Add(rowCellDate);

                HtmlGenericControl rowCellAwayTeam      = new HtmlGenericControl("div");
                rowCellAwayTeam.Attributes["class"]     = "my-grid-cell text-left";
                rowCellAwayTeam.InnerHtml               = "<img class='teamFlag pr-2' src='" + Globals.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.AwayTeam.Flag + "' alt='" + match.AwayTeam.ShortName + "' title='" + match.AwayTeam.ShortName + "' width='24px;'> " + match.AwayTeam.ShortName;
                row.Controls.Add(rowCellAwayTeam);


                HtmlGenericControl rowCellTip           = new HtmlGenericControl("div");
                rowCellTip.Attributes["class"]          = "my-grid-cell";
                rowCellTip.InnerHtml                    = "<img src='" + Globals.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.AwayTeam.Flag + "' alt='" + match.AwayTeam.ShortName + "' title='" + match.AwayTeam.ShortName + "' width='24px;'> " + match.AwayTeam.Id.ToString();
                row.Controls.Add(rowCellTip);

                if (match.Id % 3 == 0)
                    rowCellTip.InnerHtml = "<p title='Full Time Under 2.5 Goals' style='display:inline; color:red;'>FT -2.5</p>";
                else if (match.Id % 4 == 0)
                    rowCellTip.InnerHtml = "<p title='Full Time Over 2.5 Goals' style='display:inline; color:green;'>FT +2.5</p>";
                else
                    rowCellTip.InnerHtml = "---";

                body.Controls.Add(row);
            }



            HtmlGenericControl grid = new HtmlGenericControl("div");
            grid.Attributes["class"] = "my-grid";
            grid.Controls.Add(header);
            grid.Controls.Add(scroll);

            return grid;
        }

        
        public static HtmlGenericControl Create()
        {
            HtmlGenericControl GridNextMatches  = new HtmlGenericControl("div");
            GridNextMatches.Attributes["id"]    = "GridNextMatches";

            GridNextMatches.Controls.Add(HeaderGridNextMatches());
            GridNextMatches.Controls.Add(BodyGridNextMatches()  );

            return GridNextMatches;
        }

    }
}
