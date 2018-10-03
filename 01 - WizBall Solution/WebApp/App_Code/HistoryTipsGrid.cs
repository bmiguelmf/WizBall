using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using WebApp.App_Code;

namespace WebApp.App_Code
{
    public class HistoryTipsGrid
    {
        List<Match> matches;
        public HistoryTipsGrid(List<Match> Matches)
        {
            matches = Matches;
        }

       

        public HtmlGenericControl Create()
        {
            // Grid to return.
            HtmlGenericControl grid = new HtmlGenericControl("div");
            grid.Attributes["id"] = "grid";
            grid.Attributes["class"] = "gridHist";

            // Header.
            HtmlGenericControl header = new HtmlGenericControl("div");
            header.Attributes["id"] = "grid-header";
            header.Attributes["class"] = "grid-header";
            grid.Controls.Add(header);

            // Scrollable.
            HtmlGenericControl scroll = new HtmlGenericControl("div");
            scroll.Attributes["id"] = "grid-body-scrollable";
            scroll.Attributes["class"] = "grid-body-scrollable";
            grid.Controls.Add(scroll);


            // Body.
            HtmlGenericControl body = new HtmlGenericControl("div");
            body.Attributes["class"] = "grid-body";
            body.Attributes["id"] = "grid-body";
            scroll.Controls.Add(body);





            // Header cells.
            HtmlGenericControl cellCompetition = new HtmlGenericControl("div");
            cellCompetition.Attributes["class"] = "grid-cell";
            cellCompetition.Attributes["title"] = "Competition";
            cellCompetition.InnerText = "C";
            header.Controls.Add(cellCompetition);

            HtmlGenericControl cellMatchDay = new HtmlGenericControl("div");
            cellMatchDay.Attributes["class"] = "grid-cell";
            cellMatchDay.Attributes["title"] = "Match Day";
            cellMatchDay.InnerHtml = "MD";
            header.Controls.Add(cellMatchDay);

            HtmlGenericControl cellDate = new HtmlGenericControl("div");
            cellDate.Attributes["class"] = "grid-cell";
            cellDate.Attributes["title"] = "Match Date";
            cellDate.InnerText = "Date";
            header.Controls.Add(cellDate);

            HtmlGenericControl cellHomeTeam = new HtmlGenericControl("div");
            cellHomeTeam.Attributes["class"] = "grid-cell";
            cellHomeTeam.Attributes["title"] = "Home Team";
            cellHomeTeam.InnerText = "Home Team";
            header.Controls.Add(cellHomeTeam);

            HtmlGenericControl cellFTS = new HtmlGenericControl("div");
            cellFTS.Attributes["class"] = "grid-cell";
            cellFTS.Attributes["title"] = "Away Team";
            cellFTS.InnerText = "HTS";
            header.Controls.Add(cellFTS);

            HtmlGenericControl cellAwayTeam = new HtmlGenericControl("div");
            cellAwayTeam.Attributes["class"] = "grid-cell";
            cellAwayTeam.Attributes["title"] = "Away Team";
            cellAwayTeam.InnerText = "Away Team";
            header.Controls.Add(cellAwayTeam);

            HtmlGenericControl cellFtOverTwoAndHalGoals = new HtmlGenericControl("div");
            cellFtOverTwoAndHalGoals.Attributes["class"] = "grid-cell";
            cellFtOverTwoAndHalGoals.Attributes["title"] = "Full-time over two and half goals";
            cellFtOverTwoAndHalGoals.InnerText = "FT +2.5";
            header.Controls.Add(cellFtOverTwoAndHalGoals);



            foreach (Match match in matches)
            {
                // Rows
                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes["class"] = "grid-row";


                // Row cells.
                HtmlGenericControl rowCellCompetition = new HtmlGenericControl("div");
                rowCellCompetition.Attributes["class"] = "grid-cell";
                rowCellCompetition.InnerHtml = "<img src='" + GLOBALS.COMP_FLAGS + match.Competition.Flag + "' alt='" + match.Competition.Name + "' title='" + match.Competition.Name + "' width ='20px;'>";
                row.Controls.Add(rowCellCompetition);

                HtmlGenericControl rowCellMatchDay = new HtmlGenericControl("div");
                rowCellMatchDay.Attributes["class"] = "grid-cell";
                rowCellMatchDay.InnerHtml = match.Matchday.ToString();
                row.Controls.Add(rowCellMatchDay);

                HtmlGenericControl rowCellDate = new HtmlGenericControl("div");
                rowCellDate.Attributes["class"] = "grid-cell";
                rowCellDate.Attributes["utc-date"] = GLOBALS.NormalizeApiDateTime(match.UtcDate).Value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString();
                rowCellDate.InnerHtml = GLOBALS.NormalizeApiDateTime(match.UtcDate).Value.ToString("dd MMM HH:mm");
                row.Controls.Add(rowCellDate);

                HtmlGenericControl rowCellHomeTeam = new HtmlGenericControl("div");
                rowCellHomeTeam.Attributes["class"] = "grid-cell";
                rowCellHomeTeam.InnerHtml = match.HomeTeam.ShortName + "<img class='teamFlag pl-2' src='" + GLOBALS.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.HomeTeam.Flag + "' alt='" + match.HomeTeam.ShortName + "' title='" + match.HomeTeam.ShortName + "' width='20px;'>";
                row.Controls.Add(rowCellHomeTeam);

                HtmlGenericControl rowFTS = new HtmlGenericControl("div");
                rowFTS.Attributes["class"] = "grid-cell";
                rowFTS.InnerHtml = match.Score.FullTime.HomeTeam + " - " + match.Score.FullTime.AwayTeam;
                row.Controls.Add(rowFTS);

                HtmlGenericControl rowCellAwayTeam = new HtmlGenericControl("div");
                rowCellAwayTeam.Attributes["class"] = "grid-cell";
                rowCellAwayTeam.InnerHtml = "<img class='teamFlag pr-2' src='" + GLOBALS.TEAM_FLAGS + match.Competition.Area.Name + "/" + match.AwayTeam.Flag + "' alt='" + match.AwayTeam.ShortName + "' title='" + match.AwayTeam.ShortName + "' width='20px;'> " + match.AwayTeam.ShortName;
                row.Controls.Add(rowCellAwayTeam);

                HtmlGenericControl rowCellTip = new HtmlGenericControl("div");
                rowCellTip.Attributes["class"] = "grid-cell";
                if (match.Id % 3 == 0)
                    rowCellTip.InnerHtml = "Yes";
                else
                    rowCellTip.InnerHtml = "No";
                row.Controls.Add(rowCellTip);


                body.Controls.Add(row);
            }



            return grid;
        }
    }
}