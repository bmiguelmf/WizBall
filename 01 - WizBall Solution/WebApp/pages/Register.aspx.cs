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

namespace WebApp.pages
{
    public partial class Register : System.Web.UI.Page
    {
        BLL bll = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorP.Visible = false;
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> success = new Dictionary<string, bool>();
            if (
                (inputUName.Text != string.Empty && inputUName.Text != null) &&
                (inputPassword.Text != string.Empty && inputPassword.Text != null) &&
                (inputPasswordConf.Text != string.Empty && inputPasswordConf.Text != null) &&
                (inputEmail.Text != string.Empty && inputEmail.Text != null)
            )
            {
                if (inputPassword.Text == inputPasswordConf.Text)
                {
                    
                    User user = new User();

                    user.Email = inputEmail.Text;
                    user.Username = inputUName.Text;
                    user.Password = inputPassword.Text;
                    if (ProfPic.HasFile)
                    {
                        try
                        {
                            string filename = user.Username;
                            ProfPic.SaveAs(Server.MapPath("~/") + filename);
                        }
                        catch (Exception ex)
                        {
                            ErrorL.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                            ErrorP.Visible = true;
                        }
                    }

                    bll.InsertUser(user);
                    Response.Redirect("default.aspx");
                } else
                {
                    ErrorL.Text = "The Passwords<strong>do not </ strong > match!"; 
                    ErrorP.Visible = true;
                }

            }

        }
    }
}