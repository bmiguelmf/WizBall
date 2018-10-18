using FrontOffice.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Entities;

namespace FrontOffice.Pages
{
    public partial class ViewHistoryTips : System.Web.UI.Page
    {
        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn() &&  (Session["User"] as User).CurrentUserHistory.AfterState.Id == 21)
            {
                MatchesTipsHistoryGrid matchesTipsHistoryGrid = new MatchesTipsHistoryGrid();
                placeHolderTipsHistoryGrid.Controls.Add(matchesTipsHistoryGrid.FiltersAndGrid());
            }
            else
            {
                Page.Response.Write("Exclusivo");
            }
            
        }
    }
}