using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using WebApp.App_Code;
using System.Linq;
using System.Web.UI.HtmlControls;

namespace WebApp.pages
{
    public partial class _default : System.Web.UI.Page
    {

        public List<Competition> GetCompetitionsTierOne()
        {
            List<Competition> c = new List<Competition>();
            foreach (Competition competition in GLOBALS.BllSI.TierOneCompetitions())
            {
                c.Add(GLOBALS.BllSI.GetCompetitionById(competition.Id.ToString()));
            }
            return c;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL bll = GLOBALS.BllSI;


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
                competitionsFlag.ImageUrl = "/GlobalResourcesAcc/imgs/competitions/" + comp.Flag;
                competitionsFlag.Attributes["style"] = "height:200px;";
                competitionsFlag.Attributes["class"] = "pl-4 py-3";

                competitionsFlag.AlternateText = comp.Name;
                compDetails.Controls.Add(competitionsFlag);



                // Add compDetails.
                competitionWrapper.Controls.Add(compDetails);


                foreach (Match match in bll.GetMatchesByCompetition(comp.Id.ToString()))
                {
                    HtmlGenericControl matchWrapper = new HtmlGenericControl("div");
                    matchWrapper.Attributes["class"] = "grid-colors my-2 rounded";



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

                    matchWrapper.Controls.Add(matchDetailsRow);





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
                    homeTeamFlag.ImageUrl = "/GlobalResourcesAcc/imgs/teams/" + comp.Area.Name + "/" + match.HomeTeam.Flag;
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
                    awayTeamFlag.ImageUrl = "/GlobalResourcesAcc/imgs/teams/" + comp.Area.Name + "/" + match.AwayTeam.Flag;
                    awayTeamFlag.Attributes["style"] = "width:55px;";
                    awayTeamFlag.Attributes["class"] = "px-2";

                    awayTeam.Controls.Add(awayTeamFlag);
                    awayTeam.Controls.Add(awayTeamName);

                    // Over 2.5x / Tips Row--------------------------------------------------------------------------------------------------

                    // Row
                    HtmlGenericControl recRow = new HtmlGenericControl("div");
                    recRow.Attributes["class"] = "row p-0 m-0";
                    // Col
                    HtmlGenericControl recCol = new HtmlGenericControl("div");
                    recCol.Attributes["style"] = "font-size:15px; padding: 2px 0;";
                    recCol.Attributes["class"] = "col-sm-12 pl-4 text-white font-weight-bold text-center rounded-bottom";

                    Label lblRec = new Label();
                    lblRec.Text = "2.5x";
                    //Tip tip = bll.tip;
                    try
                    {
                        if (bll.NormalizeApiDateTime(match.UtcDate) < DateTime.Today)
                        {

                        }
                        if (tip.BetNoBet) //verificar 2.5x
                        {
                            recCol.Attributes["class"] += " bg-success";
                        }
                        else
                        {
                            recCol.Attributes["class"] += " bg-danger";
                        }
                    }
                    catch (Exception)
                    {
                        recCol.Attributes["class"] += " bg-info";
                    }

                    lblRec.Attributes["style"] = "";


                    recCol.Controls.Add(lblRec);

                    recRow.Controls.Add(recCol);



                    matchTeamsRow.Controls.Add(awayTeam);




                    matchWrapper.Controls.Add(matchTeamsRow);

                    matchWrapper.Controls.Add(recRow);


                    competitionWrapper.Controls.Add(matchWrapper);

                }

                frmMain.Controls.Add(competitionWrapper);
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

        protected void CompFilterBtn_Click(object sender, EventArgs e)
        {
            /* if (AllCompsCB.Checked)
             {
                 competitions = GetCompetitionsTierOne();
                 foreach (Competition comp in competitions)
                 {
                     matches.AddRange(GLOBALS.BllSI.GetMatchesByCompetition(comp.Id.ToString()));

                 }
             }
             else
             {
                 foreach (RepeaterItem i in compRep.Items)
                 {
                     //Retrieve the state of the CheckBox
                     CheckBox cb = (CheckBox)i.FindControl("CompCB");
                     if (cb.Checked)
                     {
                         //Retrieve the value associated with that CheckBox
                         HiddenField hiddenComp = (HiddenField)i.FindControl("HidFieldComp");

                         //Now we can use that value to do whatever we want
                         matches.AddRange(GLOBALS.BllSI.GetMatchesByCompetition(hiddenComp.Value));
                     }
                 }
             }
             if (/*matches != null && !matches.Any() true)
             {
                 MatchTArray = new ArrayList();
                 foreach (Match match in matches)
                 {
                     MatchTArray.Add(new MatchTruncated(match.Id.ToString(), match.HomeTeam, match.AwayTeam, match.Score, match.Matchday, match.Competition, match.Stage, match.UtcDate));
                 }

                 MatchRepeater.DataSource = MatchTArray;
                 MatchRepeater.DataBind();
             }*/

        }
    }
}