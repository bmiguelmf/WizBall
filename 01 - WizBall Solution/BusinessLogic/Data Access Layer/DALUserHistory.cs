using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;

namespace BusinessLogic.DAL
{
    public class DALUserHistory : DAL
    {
        public DALUserHistory(string ConnectionString) : base(ConnectionString)
        { }


        // GET By Id
        public UserHistory GetById(string Id)
        {
            return GetById(new UserHistory(), Id) as UserHistory;
        }
    }
}
