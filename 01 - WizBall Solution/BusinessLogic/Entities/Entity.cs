using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public abstract class Entity
    {

        public abstract Entity Assembler(List<object> Row);


        public abstract string GetId();
        public abstract string GetTableName();
        

        public abstract string[] GetAllFields();
        public abstract string[] GetAllValues();


        public abstract string[] GetUpdatableFields();
        public abstract string[] GetUpdatableValues();

    }
}
