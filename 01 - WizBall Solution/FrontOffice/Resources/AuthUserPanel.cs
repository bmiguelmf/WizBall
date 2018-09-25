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

namespace FrontOffice.Resources
{
    public class AuthUserPanel
    {
        User user;
        public AuthUserPanel(User User)
        {
            user = User;

   
        }

        
    }
}