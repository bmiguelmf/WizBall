using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Inserir nulls na base de dados.

namespace BusinessLogic.Entities
{
    public class Team : Entity
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
        public int? Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }
        public List<Player> Squad { get; set; }



        public Entity Assembler(List<object> Row)
        {
            Team team = new Team();

            team.Id = (int)Row[0];
            team.Area = new Area { Id = (int)Row[1]};
            team.Name            = Row[2].ToString();
            team.ShortName       = Row[3].ToString();
            team.TLA             = Row[4].ToString();
            team.Address         = Row[5].ToString();
            team.Phone           = Row[6].ToString();
            team.WebSite         = Row[7].ToString();
            team.Email           = Row[8].ToString();
            team.Founded         = (int)Row[9];
            team.ClubColors      = Row[10].ToString();
            team.Venue           = Row[11].ToString();
            team.Flag            = Row[12].ToString();
            team.LastUpdated     = Row[13].ToString();

            return team;
        }


        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "teams";
        }


        public string[] GetAllFields()
        {
            return new string[] {   "id",
                                    "area_id",
                                    "name",
                                    "short_name",
                                    "tla",
                                    "address",
                                    "phone",
                                    "website",
                                    "email",
                                    "founded",
                                    "club_colors",
                                    "venue",
                                    "flag",
                                    "last_updated"};
        }
        public object[] GetAllValues()
        {
            return new string[] {   Id.ToString(),
                                    Area.Id is null ? null : Area.Id.ToString(),
                                    Name,
                                    ShortName,
                                    TLA,
                                    Address,
                                    Phone,
                                    WebSite,
                                    Email,
                                    Founded.ToString(),
                                    ClubColors,
                                    Venue,
                                    Flag,
                                    LastUpdated};
        }
     

        public string[] GetUpdatableFields()
        {
            return new string[] {   "area_id",
                                    "name",
                                    "short_name",
                                    "tla",
                                    "address",
                                    "phone",
                                    "website",
                                    "email",
                                    "founded",
                                    "club_colors",
                                    "venue",
                                    "flag",
                                    "last_updated"};
        }
        public object[] GetUpdatableValues()
        {
            return new string[] {   Area.Id is null ? null : Area.Id.ToString(),
                                    Name,
                                    ShortName,
                                    TLA,
                                    Address,
                                    Phone,
                                    WebSite,
                                    Email,
                                    Founded.ToString(),
                                    ClubColors,
                                    Venue,
                                    Flag,
                                    LastUpdated};
        }
    }
}
