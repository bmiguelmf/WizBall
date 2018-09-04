using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;
using WebApp.App_Code;

namespace WebApp
{
    public partial class datadeploy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void InAreas_Click(object sender, EventArgs e)
        {
            GLOBALS.BllSI.FullDatabaseSync();
        }

        protected void InSeasons_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home");
        }

        protected void InComps_Click(object sender, EventArgs e)
        {

        }

        protected void InTeams_Click(object sender, EventArgs e)
        {

        }
    }
}