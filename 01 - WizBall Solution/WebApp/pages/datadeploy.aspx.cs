using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;

namespace WebApp
{
    public partial class datadeploy : System.Web.UI.Page
    {
        private string connString;
        private string apiToken;
        private BLL bll;
        protected void Page_Load(object sender, EventArgs e)
        {
            connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            bll = new BLL(connString, apiToken);
        }

        protected void InAreas_Click(object sender, EventArgs e)
        {
            bll.FullDatabaseSync();
        }

        protected void InSeasons_Click(object sender, EventArgs e)
        {

        }

        protected void InComps_Click(object sender, EventArgs e)
        {

        }

        protected void InTeams_Click(object sender, EventArgs e)
        {

        }
    }
}