                                                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    
    

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
