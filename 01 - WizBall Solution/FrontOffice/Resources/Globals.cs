using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Resources
{
    public class Globals
    {
        public const string TEAM_FLAGS = "/Public/Imgs/Teams/";
        public const string COMP_FLAGS = "/Public/Imgs/Competitions/";
        public const string MARKETS    = "/Public/Imgs/Markets/";
        public const string WIZBALL    = "/Public/Imgs/Wizball/";
        public const string USERS      = "/Public/Imgs/Users/";


        public DateTime? NormalizeApiDateTime(string Datetime)
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