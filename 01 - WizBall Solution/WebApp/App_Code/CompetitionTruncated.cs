using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.App_Code
{
    public class CompetitionTruncated
    {
        private string id;
        private string name;

        public CompetitionTruncated(string ID, string Name)
        {
            this.id = ID;
            this.name = Name;
        }

        public string ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}