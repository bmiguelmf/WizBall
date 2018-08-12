using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.App_Code;


namespace WebApp.pages
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void RecoverBtn_Click(object sender, EventArgs e)
        {
            GLOBALS.BllSI.RecoverUserPassword(inputEmail.Text);
        }
    }
}