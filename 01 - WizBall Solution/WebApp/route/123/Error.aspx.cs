using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.pages
{
	public partial class Error : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            int status;
            try
            {
                status = Convert.ToInt16(RouteData.Values["status"].ToString());
            }
            catch (Exception)
            {
                status = 200;
            }
            ErrBody.Text = status.ToString();

                switch (status)
                {
                    // https://kb.iu.edu/d/bfrc
                    // http://www.eeemo.net/
                    // https://www.tutorialrepublic.com/html-reference/http-status-codes.php

                    case 200:
                        // Ok
                        ErrBody.Text = "The page was loaded successfully! Although...";
                        break;
                    case 400:
                        // Bad Request
                        ErrBody.Text = "Are you trying to trick me? :^)";
                        break;
                    case 401:
                        // Unauthorized  
                        ErrBody.Text = "We're getting on unauthorized territory now, aren't we? :^)";
                        break;
                    case 403:
                        // Forbidden
                        ErrBody.Text = "Someone's got the wrong credentials...";
                        break;
                    case 404:
                        // Not Found
                        ErrBody.Text = "This page doesn't seem to exist, but you are always welcome to look for it! :)";
                        break;
                    case 500:
                        // Internal Server Error
                        ErrBody.Text = "Well, this is awkward...";
                        break;
                    case 501:
                        // Not Implemented
                        ErrBody.Text = "That's not finished yet.";
                        break;
                    case 502:
                        // Bad Gateway
                        ErrBody.Text = "Well, we've got to fix some stuff with our server host...";
                        break;
                    case 503:
                        // Out of Resources
                        ErrBody.Text = "Well, you've managed to overload the Server...";
                        break;
                    case 505:
                        // HTTP Version Not Supported
                        ErrBody.Text = "Hummm... So, what HTTP version are we really using?";
                        break;
                    default:
                        if (status == -1)
                        {
                            ErrBody.Text = "A culpa não é nossa...";
                        }
                        else
                        {
                            Response.Redirect("~/Erro");
                        }
                        break;
                }
            
            
            
        }
	}
}