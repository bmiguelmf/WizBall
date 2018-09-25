using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLogic.Entities;
using WebApp.App_Code;

namespace WebApp.pages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private bool IsUserLoggedIn()
        {
            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetupUserPanel();


            if (IsPostBack)
            {
                return;
            }
        }


        private void SetupUserPanel()
        {
            if (IsUserLoggedIn())
            {
                GenerateUserPanelDesktop();
                GenerateUserPanelResponsive();
            }
            else
            {
                GenerateGuestPanelDesktop();
                GenerateGuestPanelResponsive();
            }
        }
        private void GenerateUserPanelDesktop()
        {
            // Gets user picture.
            User user = Session["User"] as User;
            // And sets.
            imgUserPic.Src = GLOBALS.USERS + user.Picture;


            // Creates Edit Profile menu.   
            HtmlGenericControl editProfileLink = new HtmlGenericControl("a");
            editProfileLink.Attributes["href"] = "/Pages/ViewEditProfile.aspx";
            editProfileLink.InnerText = " Edit Profile";
            HtmlGenericControl editProfileIcon = new HtmlGenericControl("i");
            editProfileIcon.Attributes["class"] = "fas fa-user-edit";
            editProfileIcon.Controls.Add(editProfileLink);


            // Creates Logout menu.
            LinkButton logoutLink = new LinkButton();
            logoutLink.Click += Logout_Click;
            logoutLink.Text = " Log Out";
            logoutLink.OnClientClick = "return confirm('Are you sure?')";
            HtmlGenericControl logoutIcon = new HtmlGenericControl("i");
            logoutIcon.Attributes["class"] = "fas fa-sign-out-alt";
            logoutIcon.Controls.Add(logoutLink);


            divDesktopMenuUserOptions.Controls.Add(logoutIcon);
            divDesktopMenuUserOptions.Controls.Add(editProfileIcon);


        }
        private void GenerateUserPanelResponsive()
        {
            // Gets user picture.
            User user = Session["User"] as User;
            // And sets.
            imgUserPicResp.Src = GLOBALS.USERS + user.Picture;


            // Creates Edit Profile menu.   
            HtmlGenericControl editProfileLink = new HtmlGenericControl("a");
            editProfileLink.Attributes["href"] = "/Pages/ViewEditProfile.aspx";
            editProfileLink.InnerText = " Edit Profile";
            HtmlGenericControl editProfileIcon = new HtmlGenericControl("i");
            editProfileIcon.Attributes["class"] = "fas fa-user-edit";
            editProfileIcon.Controls.Add(editProfileLink);


            // Creates Logout menu.
            LinkButton logoutLink = new LinkButton();
            logoutLink.Click += Logout_Click;
            logoutLink.Text = " Log Out";
            logoutLink.OnClientClick = "return confirm('Are you sure?')";
            HtmlGenericControl logoutIcon = new HtmlGenericControl("i");
            logoutIcon.Attributes["class"] = "fas fa-sign-out-alt";
            logoutIcon.Controls.Add(logoutLink);


            divDesktopMenuUserOptionsResp.Controls.Add(logoutIcon);
            divDesktopMenuUserOptionsResp.Controls.Add(editProfileIcon);


        }
        private void Logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;

            Page.Response.Redirect("/Pages/ViewHome.aspx");

        }
        private void GenerateGuestPanelDesktop()
        {
            // Loads default guest user picuture.
            imgUserPicResp.Src = GLOBALS.USERS + "user.png";


            // Creates  Login | Resgristration | Recover Password menus.
            string loginLink = "<i class='fas fa-sign-in-alt'> <a href='/Pages/ViewLogin.aspx'>Login</a></i>";
            string registrationLink = "<i class='fas fa-plus-circle'> <a href='/Pages/ViewRegistration.aspx'>Registration</a></i>";
            string recoverPasswordLink = "<i class='fas fa-unlock-alt'> <a href ='/Pages/RecoverPassword.aspx'>Recover Password</a></i>";


            divDesktopMenuUserOptions.InnerHtml = loginLink + registrationLink + recoverPasswordLink;
        }
        private void GenerateGuestPanelResponsive()
        {
            // Loads default guest user picuture.
            imgUserPic.Src = GLOBALS.USERS + "user.png";


            // Creates  Login | Resgristration | Recover Password menus.
            string loginLink = "<i class='fas fa-sign-in-alt'> <a href='/Pages/ViewLogin.aspx'>Login</a></i>";
            string registrationLink = "<i class='fas fa-plus-circle'> <a href='/Pages/ViewRegistration.aspx'>Registration</a></i>";
            string recoverPasswordLink = "<i class='fas fa-unlock-alt'> <a href ='/Pages/RecoverPassword.aspx'>Recover Password</a></i>";


            divDesktopMenuUserOptionsResp.InnerHtml = loginLink + registrationLink + recoverPasswordLink;
        }
    }
}