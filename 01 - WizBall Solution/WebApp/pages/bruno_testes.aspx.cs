using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebApp.App_Code;
using BusinessLogic.Entities;

namespace WebApp.pages
{
    public partial class bruno_testes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(Competition comp in GLOBALS.BllSI.GetAllCompetitions())
            {
                if (!(GLOBALS.BllSI.TierOneCompetitions().Where(x => x.Id == comp.Id).ToList().Count > 0)) continue;

                // Competition Wrapper.
                HtmlGenericControl competitionWrapper = new HtmlGenericControl("div");
                competitionWrapper.Attributes["style"] = "width:100%";

                // Country and Competition flags Wrapper.
                HtmlGenericControl flags = new HtmlGenericControl("div");
                flags.Attributes["style"] = "width:100%";

                // Competitons flag.
                Image countryFlag = new Image();
                countryFlag.ImageUrl = "/GlobalResourcesAcc/imgs/competitions/" + comp.Flag;
                countryFlag.Attributes["style"] = "width:50px;";
                countryFlag.AlternateText = comp.Name;
                flags.Controls.Add(countryFlag);


                // Insert Flags Wrapper.
                competitionWrapper.Controls.Add(flags);


                foreach (Match match in GLOBALS.BllSI.GetMatchesByCompetition(comp.Id.ToString()))
                {
                    comp.Area = GLOBALS.BllSI.GetAreaById(comp.Area.Id.ToString());

                    HtmlGenericControl matchWraper = new HtmlGenericControl("div");


                    HtmlGenericControl homeTeam = new HtmlGenericControl("div");
                    Image homeTeamFlag = new Image();
                    homeTeamFlag.ImageUrl = "/GlobalResourcesAcc/imgs/teams/" + comp.Area.Name + "/" + match.HomeTeam.Flag;
                    homeTeamFlag.Attributes["style"] = "width:50px;";
                    homeTeam.Controls.Add(homeTeamFlag);

                    HtmlGenericControl awayTeam = new HtmlGenericControl("div");
                    Image awayTeamFlag = new Image();
                    awayTeamFlag.ImageUrl = "/GlobalResourcesAcc/imgs/teams/" + comp.Area.Name + "/" + match.HomeTeam.Flag;
                    awayTeamFlag.Attributes["style"] = "width:50px;";
                    awayTeam.Controls.Add(homeTeamFlag);

                    matchWraper.Controls.Add(homeTeam);
                    matchWraper.Controls.Add(awayTeam);

                    competitionWrapper.Controls.Add(matchWraper);

                }

                this.Controls.Add(competitionWrapper);
            }


           

            
        }
    }
}