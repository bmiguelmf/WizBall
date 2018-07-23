using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;


namespace WebApp.pages
{
    public partial class Login : System.Web.UI.Page
    {
        BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (bll.UserLogin(inputEmail.Text, inputPassword.Text) != null)
            {
                User user = bll.UserLogin(inputEmail.Text, inputPassword.Text);
                Session["bool"] = "true";
                Session["username"] = user.Username;
                Session["profPic"] = user.Picture;
                Session["email"] = user.Email;
            }
            
        }
    }
}