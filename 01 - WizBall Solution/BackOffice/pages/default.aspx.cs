using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogic.BLL;
using BusinessLogic.Entities;


namespace BackOffice.pages
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BLL bll = new BLL();
           

            foreach(Match match in bll.GetMatchesByCompetition("2017"))
            {
                Page.Response.Write(match.HomeTeam.Name + " " +
                                    "<img src='/resources/imgs/teams/portugal/" + match.HomeTeam.Flag + "' width='50px'/> " +
                                    "<img src='/resources/imgs/teams/portugal/" + match.AwayTeam.Flag + "' width='50px'/> " +
                                     match.AwayTeam.Name + "<br/>");
            }
        }
    }
}