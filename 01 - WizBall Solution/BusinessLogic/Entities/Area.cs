using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Area : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public int ParentAreaId { get; set; }
        public string ParentArea { get; set; }



        public override Entity Assembler(List<object> Row)
        {
            return new Area
            {
                Id              = (int)Row[0],
                Name            = Row[1].ToString(),
                CountryCode     = Row[2].ToString(),
                ParentAreaId    = (int)Row[3]
            };
        }

        

        public override string GetId()
        {
            return Id.ToString();
        }
        public override string GetTableName()
        {
            return "areas";
        }


        public override string[] GetAllFields()
        {
            return new string[] { "id",
                                  "name",
                                  "country_code",
                                  "parent_area_id" };
        }
        public override string[] GetAllValues()
        {
            return new string[] { Id.ToString(),
                                  Name,
                                  CountryCode,
                                  ParentAreaId.ToString() };
        }


        public override string[] GetUpdatableFields()
        {
            return new string[] { "name",
                                  "country_code",
                                  "parent_area_id" };
        }
        public override string[] GetUpdatableValues()
        {
            return new string[] { Name,
                                  CountryCode,
                                  ParentAreaId.ToString() };
        }
    }
}
