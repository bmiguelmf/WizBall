using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.App_Code
{
    public class GLOBALS
    {
        public static string GetTeamImg(string area, string team)
        {

            return string.Format("..\\resources\\teams\\{0}\\{1}.ico", area, team);
        }

        public static string GetFedImg(string area)
        {
            return string.Format("..\\federations\\{0}.ico", area);
        }
    }
}