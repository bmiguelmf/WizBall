using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ApiFootballDataOrg.Entities;


namespace BusinessLogic
{
    public class DALSeasons : DAL
    {
        // Construtor.
        public DALSeasons(string ConnectionString) : base(ConnectionString)
        {
        }



        // Creates and assembles a new object of type Season.
        private Season Assembler(Dictionary<string, object> Row)
        {
            Season season = new Season
            {
                Id              = (int)Row["id"],
                StartDate       = Row["start_date"].ToString(),
                EndDate         = Row["end_date"].ToString(),
            };

            return season;
        }


        // Inserts a list of seasons.
        public bool Insert(List<Season> Seasons)
        {
            foreach (Season season in Seasons)
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO seasons VALUES(@id, @start_date, @end_date)"
                };

                DateTime start = DateTime.TryParse(season.StartDate);
                cmd.Parameters.AddWithValue("@id", season.Id);
                cmd.Parameters.AddWithValue("@start_date", DateTime.TryParse(season.StartDate));
                cmd.Parameters.AddWithValue("@end_date", season.EndDate);

                ExecuteNonQuery(cmd);
            }

            return true;
        }

    }
}
