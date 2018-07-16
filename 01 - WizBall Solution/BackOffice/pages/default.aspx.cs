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
            //bll.FullDatabaseSync();

            foreach(Match match in bll.GetMatchesByCompetition("2017"))
            {
                Page.Response.Write(match.Id + " " + match.UtcDate + "<br/>");
            }
        }
    }
}