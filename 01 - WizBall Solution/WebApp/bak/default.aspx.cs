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

namespace WebApp.pages
{
    public partial class _default : System.Web.UI.Page
    {
        
        //private string connString;
        //private string apiToken;
        //private BLL bll;
        ArrayList CompTArray;
        ArrayList MatchTArray;
        List<Match> matches;
        List<Competition> competitions;

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
            matches = new List<Match>();
            competitions = GetCompetitionsTierOne();
            
            //competitions = GLOBALS.BllSI.GetAllCompetitions();
            List<string> checkedComps = new List<string>();
            Dictionary<string, string> compsKVP = new Dictionary<string, string>();



            //matches.Where(x => x.Competition.Id == 2412 && x.Competition.Id == 1231).ToList();

            //comp
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            //apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            //bll = new BLL(connString, apiToken);

            if (!IsPostBack)
            {
                CompTArray = new ArrayList();

                foreach (Competition comp in competitions)
                {
                    //compsKVP.Add(comp.Id.ToString(),comp.Name);
                    CompTArray.Add(new CompetitionTruncated(comp.Id.ToString(), comp.Name));

                }

                compRep.DataSource = CompTArray;
                compRep.DataBind();
            }


            


            if (Page.IsPostBack)
            {
                /*foreach (ListItem listItem in compCBList.Items)
                {
                    if (listItem.Selected)
                    {
                        checkedComps.Add(listItem.Text.ToString());

                    }
                    else
                    {

                    }
                }*/
                /*foreach (string str in checkedComps)
                {
                    
                }*/
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
            /*foreach (Control ctl in compPanel.Controls)
            {
                if (ctl is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)ctl;
                    if (checkBox.Checked)
                    {
                        GLOBALS.BllSI.GetMatchesByCompetition(checkBox.Value.TrimStart(new Char[] {'C','o','m','p'}));
                    }
                }
            }*/
            if (AllCompsCB.Checked)
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
            if (/*matches != null && !matches.Any()*/ true)
            {
                MatchTArray = new ArrayList();
                foreach (Match match in matches)
                {
                    MatchTArray.Add(new MatchTruncated(match.Id.ToString(), match.HomeTeam, match.AwayTeam, match.Score, match.Matchday, match.Competition, match.Stage, match.UtcDate));
                }

                MatchRepeater.DataSource = MatchTArray;
                MatchRepeater.DataBind();
            }

        }
    }
}