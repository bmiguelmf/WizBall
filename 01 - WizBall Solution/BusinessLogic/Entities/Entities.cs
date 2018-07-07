                                                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    
    public class Team
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string TLA { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public int Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public string LastUpdated { get; set; }
        public List<Player> Squad { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public string UtcDate { get; set; }
        public string Status { get; set; }
        public int Minute { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public string LastUpdated { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Result HalfTime { get; set; }
        public Result FullTime { get; set; }
        public Result ExtraTime { get; set; }
        public Result Penalties { get; set; }
    }

    public class Result
    {
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
    }
}
