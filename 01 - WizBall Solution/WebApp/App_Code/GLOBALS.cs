using System;
using System.Collections.Generic;
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

        public static readonly string connString1 = WebConfigurationManager.ConnectionStrings["ConnStringJoaoHome"].ConnectionString;

        public static readonly string connString2 = WebConfigurationManager.ConnectionStrings["ConnStringJoaoATEC"].ConnectionString;

        public static readonly string apiToken = WebConfigurationManager.AppSettings["ApiToken"];

        public static BLL BllSI = new BLL(connString2, apiToken);

        public const string TEAM_FLAGS = "/Public/Imgs/Teams/";
        public const string COMP_FLAGS = "/Public/Imgs/Competitions/";
        public const string MARKETS = "/Public/Imgs/Markets/";
        public const string WIZBALL = "/Public/Imgs/Wizball/";
        public const string USERS = "/Public/Imgs/Users/";


        public static DateTime? NormalizeApiDateTime(string Datetime)
        {
            if (string.IsNullOrEmpty(Datetime))
                return null;

            DateTime dateTimeNormalized;

            DateTime.TryParse(Datetime,
                              null,
                              System.Globalization.DateTimeStyles.AdjustToUniversal,
                              out dateTimeNormalized);


            return dateTimeNormalized;
        }

    }
}