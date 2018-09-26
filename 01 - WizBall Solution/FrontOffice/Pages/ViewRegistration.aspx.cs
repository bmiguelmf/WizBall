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
    public partial class ViewRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                Globals globals = new Globals();
                BLL bll = globals.CreateBll();

               
                if(!FieldsValidatior())
                {

                    return;
                }
                else if(!globals.IsValidEmail(txtEmail.Text))
                {

                    return;  
                }
                else if (bll.UserMailExists(txtEmail.Text))
                {

                    return;
                }
                else if (bll.UsernameExists(txtUsername.Text))
                {

                    return;
                }
                else
                {
                    User newUser = new User
                    {
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        Password = txtPassword.Text
                    };

                    if(bll.InsertUser(newUser))
                    {

                    }
                }
            }
        }

        private bool FieldsValidatior()
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(string.IsNullOrWhiteSpace(email) ||
               string.IsNullOrWhiteSpace(username) ||
               string.IsNullOrWhiteSpace(password))
            {              
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}