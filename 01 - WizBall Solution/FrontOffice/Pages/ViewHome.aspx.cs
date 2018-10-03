using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BusinessLogic.Entities;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using System.Web.Configuration;
using FrontOffice.Resources;

namespace FrontOffice.Pages
{
    public partial class ViewHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MatchesTipsGrid matchesTipsGrid = new MatchesTipsGrid();

            placeHolderMatchesTipsGrid.Controls.Add(matchesTipsGrid.Create());
        }
    }
}