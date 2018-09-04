using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace WebApp
{
	public class Global : System.Web.HttpApplication
	{
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            RouteTable.Routes.MapPageRoute("", "", "~/pages/default.aspx");
            RouteTable.Routes.MapPageRoute("", "Home", "~/pages/default.aspx");

            RouteTable.Routes.MapPageRoute("", "Auth/Login", "~/pages/authMain/Login.aspx");
            RouteTable.Routes.MapPageRoute("", "Auth/CredRecovery", "~/pages/authMain/RecoverPassword.aspx");
            RouteTable.Routes.MapPageRoute("", "Auth/Register", "~/pages/authMain/Register.aspx");

            RouteTable.Routes.MapPageRoute("", "Profile/Edit", "~/pages/authMain/ProfileEdit.aspx");

            RouteTable.Routes.MapPageRoute("", "Error", "~/pages/Misc/Error.aspx");
            RouteTable.Routes.MapPageRoute("", "Error/{status}", "~/pages/Misc/Error.aspx");

            /*RouteTable.Routes.MapPageRoute("", "Utilizadores", "~/pages/Users.aspx");
            RouteTable.Routes.MapPageRoute("", "Criar/Utilizador", "~/pages/User/Create.aspx");
            RouteTable.Routes.MapPageRoute("", "Editar/Utilizador/{email}", "~/pages/User/Edit.aspx");

            RouteTable.Routes.MapPageRoute("", "Zonas", "~/pages/Zones.aspx");
            RouteTable.Routes.MapPageRoute("", "Criar/Zona", "~/pages/Zone/Create.aspx");
            RouteTable.Routes.MapPageRoute("", "Editar/Zona/{id}", "~/pages/Zone/Edit.aspx");*/

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            try
            {
                Exception LastError = Server.GetLastError();

                if (LastError.GetType() == typeof(HttpException))
                {
                    Response.Redirect("~/Error/" + ((HttpException)LastError).GetHttpCode());
                }
                else
                {
                    Response.Redirect("~/Error");
                }
            }
            catch (Exception)
            {
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

		protected void Application_BeginRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) 
		{

		}
        
	}
}