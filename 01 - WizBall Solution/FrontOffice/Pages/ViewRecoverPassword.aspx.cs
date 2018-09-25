using BusinessLogic.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Resources;

namespace FrontOffice.Pages
{
    public partial class ViewRecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                Globals globals = new Globals();

                if(globals.IsValidEmail(txtEmail.Text))
                {
                    bool result = globals.CreateBll().RecoverUserPassword(txtEmail.Text);

                    if (result)
                    {
                        lblStatus.Text = "Your login information has been sent to the provided email.";
                        lblStatus.BackColor = System.Drawing.Color.Green;
                        lblStatus.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        lblStatus.Text = "The email you provided does not exists.";
                        lblStatus.BackColor = System.Drawing.Color.Red;
                        lblStatus.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    lblStatus.Text = "The provided email is not valid.";
                    lblStatus.BackColor = System.Drawing.Color.Red;
                    lblStatus.ForeColor = System.Drawing.Color.White;
                }               
            }
        }
    }
}