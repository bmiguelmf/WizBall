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
        public string Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public string Flag { get; set; }
        public string LastUpdated { get; set; }

        public Entity Assembler(List<object> Row)
        {
            Competition comp = new Competition();

            comp.Id = (int)Row[0];
            comp.Area = new Area() { Id = (int)Row[1] };
            comp.Name = Row[2].ToString();
            comp.Code = Row[3].ToString();
            comp.Plan = Row[4].ToString();
            comp.Flag = Row[5].ToString();
            comp.LastUpdated = Row[6].ToString();

            return comp;
        }


        public string GetId()
        {
            return Id.ToString();
        }
        public string GetTableName()
        {
            return "competitions";
        }


        public string[] GetAllFields()
        {
            return new string[] { "id",
                                  "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "flag",
                                  "last_updated"};
        }
        public object[] GetAllValues()
        {
            return new string[] { Id.ToString(),
                                  Area.Id.ToString(),
                                  Name,
                                  Code.ToString(),
                                  Plan,
                                  Flag == null ? "null" : Flag,
                                  LastUpdated};
        }

       

        public string[] GetUpdatableFields()
        {
            return new string[] { "area_id",
                                  "name",
                                  "code",
                                  "plan",
                                  "flag",
                                  "last_updated"};
        }
        public object[] GetUpdatableValues()
        {
            return new string[] { Area.Id.ToString(),
                                  Name,
                                  Code.ToString(),
                                  Plan,
                                  Flag,
                                  LastUpdated};
        }
    }
}
