using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.App_Code;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Web.Configuration;

namespace WebApp.pages
{
    
    public partial class ProfileEdit : System.Web.UI.Page
    {
        User userUpdate;
        User userSession;
        User userFinal;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                userSession = Session["user"] as User;
            }
            catch (Exception)
            {

               // throw;
            }
            
            if (!Page.IsPostBack)
            {
                userUpdate = GLOBALS.BllSI.GetUserById(userSession.Id.ToString()); //GET CURRENT USER FIELDS
            }
        }

        protected void PicBtn_Click(object sender, EventArgs e)
        {
            if (ProfPic.HasFile)
            {
                try
                {
                    string filename = Guid.NewGuid().ToString() + ".png";
                    ProfPic.SaveAs(GLOBALS.GetPPPath(Server.MapPath(@"~\")) + filename);
                    userUpdate.Picture = filename;
                }
                catch (Exception ex)
                {
                    ErrorL.Text += "Upload status: The file could not be uploaded. The following error occured: " + ex.Message + "<br/>";
                    ErrorP.Visible = true;
                }
            }
            else
            {
                ErrorL.Text += "No Image Loaded!";
                ErrorP.Visible = true;
                
            }

            userFinal = CreateUserUpdate(userSession, userUpdate);
        }

        protected User CreateUserUpdate(User currUser, User updateUser)
        {
            if (updateUser.Id != 0)
            {
                if (!string.IsNullOrEmpty(inputUName.Text) && inputUName.Text != currUser.Username)
                {
                    updateUser.Username = inputUName.Text;
                }
                if (
                    !string.IsNullOrEmpty(inputPWD.Text) &&
                    !string.IsNullOrEmpty(inputCPWD.Text) &&
                    inputPWD.Text == inputCPWD.Text 
                )
                {
                    updateUser.Password = inputPWD.Text;
                }
                else
                {
                    ErrorL.Text += "Password fields are either invalid or mismatched. </br>";
                }
                return updateUser;
            }
            return new User();
        }
    }
}