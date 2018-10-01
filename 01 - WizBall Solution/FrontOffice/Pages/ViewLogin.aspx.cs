using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Resources;
using BusinessLogic.BLL;
using System.Web.Configuration;
using BusinessLogic.Entities;

namespace FrontOffice.Pages
{
    public partial class ViewLogin : System.Web.UI.Page
    {
        private BLL bll;

        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn())
            {
                Response.Redirect("/Pages/ViewHome.aspx");
            }


            if (IsPostBack)
            {
                bll = new Globals().CreateBll();
            }    
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Form validation.
            if(!UsernameValidation() || !PasswordValidation())
            {
                txtHeader.Style.Value = "color:orange;";
                txtHeader.InnerText = "Invalid username and/or password";
                return;
            }
            

            // Tries to login.
            User user =  bll.UserLogin(txtUsername.Text, txtPassword.Text);

            
            // Checks login result.
            if(user is null)
            {
                txtHeader.Style.Value = "color:orange;";
                txtHeader.InnerText = "Login not found";
            }
            else
            {
                Session["User"] = user;
                Response.Redirect("/Pages/ViewHome.aspx");
            }
        }

        private bool UsernameValidation()
        {
            string username = txtUsername.Text;

            if (string.IsNullOrWhiteSpace(username))        // Validates if null or empty.
                return false;
            else if (username.Length > 50)                  // Validates if length > 50.
                return false;

            return true;
        }
        private bool PasswordValidation()
        {
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))                // Validates if null or empty.
                return false;
            else if (password.Length < 6 || password.Length > 100)  // Validates if length < 6 or > 100.
                return false;

            return true;
        }
    }
}