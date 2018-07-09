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
        public int Founded { get; set; }
        public string ClubColors { get; set; }
        public string Venue { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }
        public List<Player> Squad { get; set; }


        public override Entity Assembler(List<object> Row)
        {
            Team team = new Team();

            Id              = (int)Row[0];
            Area            = new Area { Id = (int)Row[1]};
            Name            = Row[2].ToString();
            ShortName       = Row[3].ToString();
            TLA             = Row[4].ToString();
            Address         = Row[5].ToString();
            Phone           = Row[6].ToString();
            WebSite         = Row[7].ToString();
            Email           = Row[8].ToString();
            Founded         = (int)Row[9];
            ClubColors      = Row[10].ToString();
            Venue           = Row[11].ToString();
            Flag            = Row[12].ToString();
            LastUpdated     = Row[13].ToString();

            return team;
        }


        public override string GetId()
        {
            return Id.ToString();
        }
        public override string GetTableName()
        {
            return "teams";
        }


        public override string[] GetAllFields()
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
        public override string[] GetAllValues()
        {
            return new string[] {   Id.ToString(),
                                    Area.Id.ToString(),
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
     

        public override string[] GetUpdatableFields()
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
        public override string[] GetUpdatableValues()
        {
            return new string[] {   Area.Id.ToString(),
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
