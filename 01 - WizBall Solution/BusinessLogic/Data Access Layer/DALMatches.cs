using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALMatches : DAL
    {
        public DALMatches(string ConnString) : base(ConnString)
        { }



        // Insert.
        public bool Insert(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Insert(match);
            }

            return true;
        }

    }
}
