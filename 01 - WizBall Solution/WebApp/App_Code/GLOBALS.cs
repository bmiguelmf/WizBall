using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Web.Configuration;

namespace WebApp.App_Code
{
    public static class GLOBALS
    {
        public static string GetUserPPPath(string ProfilePicture)
        {
           return string.Format(@"~/LocalResourcesAcc/ProfilePicture/{0}", ProfilePicture);
        }

        public static string GetPPPath(string SMapPath)
        {
            return string.Format(@"{0}/LocalResourcesAcc/ProfilePicture/", SMapPath);
        }

        public static string GetHTMLImagePath(string ProfilePicture)
        {
            return string.Format(@"../LocalResourcesAcc/ProfilePicture/{0}", ProfilePicture);
        }

        public static readonly string connString = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;

        public static readonly string apiToken = WebConfigurationManager.AppSettings["ApiToken"];

        public static BLL BllSI = new BLL(connString, apiToken);

    }
}