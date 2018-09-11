using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
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

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapPageRoute("", "", "~/pages/default.aspx");
            RouteTable.Routes.MapPageRoute("", "Home", "~/pages/default.aspx");

            RouteTable.Routes.MapPageRoute("", "Auth/Login", "~/pages/Login.aspx");
            RouteTable.Routes.MapPageRoute("", "Auth/CredRecovery", "~/pages/RecoverPassword.aspx");
            RouteTable.Routes.MapPageRoute("", "Auth/Register", "~/pages/Register.aspx");

            RouteTable.Routes.MapPageRoute("", "Profile/Edit", "~/pages/ProfileEdit.aspx");

            RouteTable.Routes.MapPageRoute("", "Error", "~/pages/Misc/Error.aspx");
            RouteTable.Routes.MapPageRoute("", "Error/{status}", "~/pages/Misc/Error.aspx");
        }
    }
}