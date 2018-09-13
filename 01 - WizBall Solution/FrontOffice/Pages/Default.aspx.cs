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


namespace FrontOffice.Pages
{
    public partial class Default : System.Web.UI.Page
    {
       
            

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

           


            phCompetitions.Controls.Add(Factory.TierOneCompetitions());

            phMatchesList.Controls.Add(Factory.TableMatchesX());
        }

    }
}