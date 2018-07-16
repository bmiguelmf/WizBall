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

        // Gets
        public List<Match> GetAll()
        {
            return base.GetAll(new Match()).Cast<Match>().ToList();
        }
        public Match GetById(string Id)
        {
            return GetById(new Match(), Id) as Match;
        }
        public List<Match> GetByCompetitionId(string CompetitionId)
        {
            return GetWhere(new Match(), 
                            new Dictionary<string, string>() { { "competition_id", CompetitionId } } )
                             
                            .Cast<Match>().ToList();
        }

        // Insert.
        public bool Insert(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Insert(match);
            }

            return true;
        }

        // Delete.
        public bool Delete(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Delete(match);
            }

            return true;
        }

        // Update.
        public bool Update(List<Match> Matches)
        {
            foreach (Match match in Matches)
            {
                Update(match);
            }

            return true;
        }

    }
}
