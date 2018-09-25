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
                    lblStatus.Text = "All fields are required.";
                    return;
                }
                else if(!globals.IsValidEmail(txtEmail.Text))
                {
                    lblStatus.Text = "The email you provided is not valid.";
                    return;  
                }
                else if (bll.UserMailExists(txtEmail.Text))
                {
                    lblStatus.Text = "The email you provided is already registered.";
                    return;
                }
                else if (bll.UsernameExists(txtUsername.Text))
                {
                    lblStatus.Text = "The username you provided is already taken.";
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
                        lblStatus.Text = "You account has been successfuly created.";
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