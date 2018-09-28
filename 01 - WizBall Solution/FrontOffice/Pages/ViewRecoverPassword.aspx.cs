using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Resources;

namespace FrontOffice.Pages
{
    public partial class ViewRecoverPassword2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)                                                                 // Primeiro pedido
            {
                Session["antiXeats"] = true;
            }   
            else if (IsPostBack && (bool)Session["antiXeats"])                              // Postback passou pelas validações js então é porque é para tentar recuperar pass
            {
                bool result = new Globals().CreateBll().UserMailExists(txtEmail.Text);

                if (result)
                {
                    emailStatus.InnerText = "";
                    title.InnerText = "Email found";

                    Session["antiXeats"] = false;

                    Page.ClientScript.RegisterStartupScript(GetType(), "recoverPasswordConfirmation", "recoverPasswordConfirmation()", true);
                }
                else
                {
                    emailStatus.InnerText = "Email not found";  
                }
            }
            else
            {
                txtEmail.Text = string.Empty;
                Session["antiXeats"] = true;
            }

        }
    }
}