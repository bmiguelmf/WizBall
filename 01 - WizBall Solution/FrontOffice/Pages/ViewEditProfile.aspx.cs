using BusinessLogic.BLL;
using BusinessLogic.Entities;
using FrontOffice.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Pages
{
    public partial class ViewEditProfile : System.Web.UI.Page
    {
        private BLL bll;

        private bool IsUserLoggedIn()
        {
            // Get songoku for test porpuses.

            User u = bll.UserLogin("songoku", "06121984");

            Session["User"] = u;

            User user = Session["User"] as User;

            return user is null ? false : true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bll = new Globals().CreateBll();
            IsUserLoggedIn();
            PrepareForm();

            //if(!IsUserLoggedIn())
            //{
            //    Page.Response.Redirect("/Pages/ViewHome.aspx");
            //}

            //if (!IsPostBack)
            //{
            //    bll = new Globals().CreateBll();
            //    PrepareForm();
            //}      
        }


        private void PrepareForm()
        {
            User user = Session["User"] as User;

            imgUserPic.ImageUrl = Globals.USERS + user.Picture;             // Set user picture.
   

            txtUsername.Text    = user.Username;
            txtEmail.Text       = user.Email;

            txtPassword.Text = user.Password;
        }
    }
}