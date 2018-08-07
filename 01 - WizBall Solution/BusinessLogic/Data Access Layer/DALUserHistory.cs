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

        // GET By User
        public List<UserHistory> GetByUserId(string UserId)
        {
            return GetWhere(new UserHistory(),
                            new Dictionary<string, string>() { { "user_id", UserId } })

                            .Cast<UserHistory>().ToList();
        }


        // INSERTS.
        public bool Insert(List<UserHistory> UserHistory)
        {
            foreach (UserHistory userHistory in UserHistory)
            {
                Insert(userHistory);
            }

            return true;
        }


        // UPDATE.
        public bool Update(List<UserHistory> UserHistories)
        {
            foreach (UserHistory userHistory in UserHistories)
            {
                Update(userHistory);
            }

            return true;
        }


        // DELETE.
        public bool Delete(List<UserHistory> UserHistories)
        {
            foreach (UserHistory userHistory in UserHistories)
            {
                Delete(userHistory);
            }

            return true;
        }
    }
}
