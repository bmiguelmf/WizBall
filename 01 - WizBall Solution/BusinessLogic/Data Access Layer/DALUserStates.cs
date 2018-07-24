﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public class DALUserStates :DAL
    {
        public DALUserStates(string ConnectionString) : base(ConnectionString)
        { }


        // GETS
        public List<UserState> GetAll()
        {
            return GetAll(new UserState()).Cast<UserState>().ToList();
        }

    }
}
