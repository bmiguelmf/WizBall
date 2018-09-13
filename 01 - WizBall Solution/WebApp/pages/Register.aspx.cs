using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.IO;
using System.Collections.Generic;
using System.Web.Configuration;
using WebApp.App_Code;
using System.Text.RegularExpressions;
using BusinessLogic.Entities;

namespace WebApp.pages
{
    public partial class Register : System.Web.UI.Page
    {
        Regex rEX;
        
        //private string connString;
        //private string apiToken;
        //private BLL bll;
        protected void Page_Load(object sender, EventArgs e)
        {
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            //apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            //bll = new BLL(connString, apiToken);
            ErrorP.Visible = false;
            rEX = new Regex(@"^(?=.{3,15}$)(?:(?:\p{L}|\p{N})[._()\[\]-]?)*$");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(inputUName.Text) &&
                !rEX.IsMatch(inputUName.Text) &&
                string.IsNullOrEmpty(inputPassword.Text) &&
                string.IsNullOrEmpty(inputPasswordConf.Text) &&
                string.IsNullOrEmpty(inputEmail.Text)
            )
            {
                ErrorL.Text += "Invalid Username! <br />";
                ErrorP.Visible = true;
            }
            else
            {
                if (inputPassword.Text == inputPasswordConf.Text)
                {

                    User user = new User();
                    user.Email = inputEmail.Text;
                    user.Username = inputUName.Text;
                    user.Password = inputPassword.Text;
                    if (NewsletterChkBox.Checked)
                    {
                        user.Newsletter = true;
                    }
                    
                    GLOBALS.BllSI.InsertUser(user);

                    Session["bool"] = "true";
                    Session["User"] = user;
                    Response.Redirect("default.aspx");
                }
                else
                {

                    ErrorL.Text = "The Passwords<strong> do not </ strong > match! <br />";
                    ErrorP.Visible = true;
                }

            }

        }
    }
}