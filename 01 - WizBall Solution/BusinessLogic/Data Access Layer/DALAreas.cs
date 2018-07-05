
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using ApiFootballDataOrg.Entities;

namespace BusinessLogic
{
    public class DALAreas : DAL
    {
        public DALAreas(string ConnectionString) : base(ConnectionString)
        {
        }

        // Creates and assembles a new object of type Area.
        private Area Assembler(Dictionary<string, object> Row)
        {
            Area area = new Area
            {
                Id              = (int)Row["id"],
                Name            = Row["name"].ToString(),
                CountryCode     = Row["country_code"].ToString(),
                ParentAreaId    = (int)Row["parent_area_id"]
            };

            return area;
        }


        public bool Insert(List<Area> Areas)
        {
            foreach(Area area in Areas)
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "INSERT INTO areas VALUES(@id, @name, @country_code, @parent_area_id)"
                };
                cmd.Parameters.AddWithValue("@id", area.Id);
                cmd.Parameters.AddWithValue("@name", area.Name);
                cmd.Parameters.AddWithValue("@country_code", area.CountryCode);
                cmd.Parameters.AddWithValue("@parent_area_id", area.ParentAreaId);

                ExecuteNonQuery(cmd);
            }

            return true;
        }

        public List<Area> GetAll()
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "SELECT * FROM areas"
            };

            List<Area> lstAreas = new List<Area>();

            foreach (Dictionary<string, object> row in ExecuteReader(cmd))
            {
                lstAreas.Add(Assembler(row));
            }

            return lstAreas;
        }
    }
}
