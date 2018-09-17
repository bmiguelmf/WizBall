using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using WebServices;
using FrontOffice.Resources;
using System.Web.UI.HtmlControls;

namespace FrontOffice.Pages
{
    public partial class Default : System.Web.UI.Page
    {
                 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;


            
            string apiToken = WebConfigurationManager.AppSettings["ApiToken"];                              // Database sync purposes. //
            string connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;         // // // // // // // // // //
            BLL  bll = new BLL(connString, apiToken);                                                       // // // // // // // // // //
            //bll.FullDatabaseSync();                                                                       // // // // // // // // // //
            // bll.SyncAreas();                                                                             // // // // // // // // // //
            //bll.SyncSeasons();                                                                            // // // // // // // // // //
            //bll.SyncCompetitions();                                                                       // // // // // // // // // //
            //bll.SyncTeams();                                                                              // // // // // // // // // //
            //bll.SyncMatchesTierOne();                                                                     // // // // // // // // // //



            phGridNextMatchesControl.Controls.Add(GridNextMatchesControl.Create());
        }

    }
}