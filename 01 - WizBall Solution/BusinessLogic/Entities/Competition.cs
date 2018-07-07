using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Competition : Entity
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }

        public override Entity Assembler(List<object> Row)
        {
            return new Competition
            {
                Id              = (int)Row[0],
                Area            = new Area { Id = (int)Row[1] },
                Name            = Row[2].ToString(),
                Code            = (int)Row[3],
                Plan            = Row[4].ToString(),
                LastUpdated     = Row[5].ToString()
            };
        }


        public override string GetId()
        {
            return Id.ToString();
        }
        public override string GetTableName()
        {
            return "competitions";
        }


        public override string[] GetAllFields()
        {
            return new string[] { "id",
                                  "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "last_updated"};
        }
        public override string[] GetAllValues()
        {
            return new string[] { Id.ToString(),
                                  Area.Id.ToString(),
                                  Name,
                                  Code.ToString(),
                                  Plan,
                                  LastUpdated};
        }

       

        public override string[] GetUpdatableFields()
        {
            return new string[] { "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "last_updated"};
        }
        public override string[] GetUpdatableValues()
        {
            return new string[] { Area.Id.ToString(),
                                  Name,
                                  Code.ToString(),
                                  Plan,
                                  LastUpdated};
        }
    }
}
