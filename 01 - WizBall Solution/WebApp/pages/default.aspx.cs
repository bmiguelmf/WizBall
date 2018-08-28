using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using WebApp.App_Code;

namespace WebApp.pages
{
    public partial class _default : System.Web.UI.Page
    {
        //private string connString;
        //private string apiToken;
        //private BLL bll;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<Competition> competitions = GLOBALS.BllSI.GetAllCompetitions();
            List<string> checkedComps = new List<string>();
            Dictionary<string, string> compsKVP = new Dictionary<string, string>();
            //comp
            //connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;
            //apiToken = WebConfigurationManager.AppSettings["ApiToken"];
            //bll = new BLL(connString, apiToken);
            foreach (Competition comp in competitions)
            {
                compCBList.Items.Add(comp.Id.ToString());
                compRep.
            }
            if (Page.IsPostBack)
            {
                foreach (ListItem listItem in compCBList.Items)
                {
                    if (listItem.Selected)
                    {
                        checkedComps.Add(listItem.Selected.ToString());
                    }
                    else
                    {
                         
                    }
                }
                /*foreach (string str in checkedComps)
                {
                    
                }*/
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}