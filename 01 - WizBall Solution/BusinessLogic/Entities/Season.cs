using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Season : Entity
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public List<string> AvailableStages { get; set; }

        public override Entity Assembler(List<object> Row)
        {
            Season season = new Season();

            season.Id           = (int)Row[0];
            season.StartDate    = Row[1].ToString();
            season.EndDate      = Row[2].ToString();

            return season;
        }


        public override string GetId()
        {
            return Id.ToString();
        }
        public override string GetTableName()
        {
            return "seasons";
        }

        public override string[] GetAllFields()
        {
            return new string[] { "id",
                                  "start_date",
                                  "end_date" };
        }
        public override object[] GetAllValues()
        {
            return new string[] { Id.ToString(),
                                  StartDate,
                                  EndDate };
        }
       
        public override string[] GetUpdatableFields()
        {
            return new string[] { "start_date",
                                  "end_date" };
        }
        public override object[] GetUpdatableValues()
        {
            return new string[] { StartDate,
                                  EndDate };
        }
    }
}
