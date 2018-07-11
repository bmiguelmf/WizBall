using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public interface Entity
    {

        Entity Assembler(List<object> Row);


        string GetId();
        string GetTableName();
        

        string[] GetAllFields();
        object[] GetAllValues();


        string[] GetUpdatableFields();
        object[] GetUpdatableValues();

    }
}
