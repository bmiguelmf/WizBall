using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using BusinessLogic.Entities;


namespace BusinessLogic.DAL
{
    public abstract class DAL
    {
        // Private member.
        private string connectionString;


        // Constructor.
        public DAL(string ConnectionString)
        {
            //Home "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = blockbuster; Integrated Security = SSPI;";
            //ATEC "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = blockbuster; Integrated Security = SSPI;";

            connectionString = ConnectionString; // ConfigurationManager.ConnectionStrings["ConStringBlockBuster"].ConnectionString;
        }


        // Methods which communicate with the database. 
        private int ExecuteNonQuery(SqlCommand SqlCommand)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand.Connection = conn;
                conn.Open();

                try
                {
                    return SqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private object ExecuteScalar(SqlCommand SqlCommand)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand.Connection = conn;
                conn.Open();

                try
                {
                    return SqlCommand.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }       
        private List<Entity> ExecuteReader(Entity Entity, SqlCommand SqlCommand)
        {
            List<Entity> table = new List<Entity>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand.Connection = conn;
                conn.Open();

                try
                {
                        SqlDataReader dr = SqlCommand.ExecuteReader();

                        while (dr.Read())
                        {
                            List<object> row = new List<object>();

                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                row.Add(dr[i]);
                            }

                            table.Add(Entity.Assembler(row));
                        }

                        return table;
                    }
                    catch (Exception)
                    {
                        throw;
                    }

            }          
        }



        #region GETS


        /// <summary>
        /// Get all elements from the database for the corresponding Entity object.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <returns>Returns a list of objects of type Entity object.</returns>
        protected List<Entity> GetAll(Entity Entity)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("SELECT * FROM {0}", Entity.GetTableName())
            };

            return ExecuteReader(Entity, cmd);
        }

        /// <summary>
        /// Get one particular element from the database for the corresponding Entity object.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <param name="Id">Id of the element to search.</param>
        /// <returns>Returns a particular element from the database for the corresponding Entity object</returns>
        protected Entity GetById(Entity Entity, string Id)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("SELECT * FROM {0} WHERE id = @id", Entity.GetTableName())
            };
            cmd.Parameters.AddWithValue("@id", Id);

            List<Entity> lstEntities = ExecuteReader(Entity, cmd);

            return lstEntities.Count > 0 ? lstEntities[0] : null;
        }

        /// <summary>
        /// Get a subset of elements from the database for the corresponding Entity object.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <param name="Where">ex: { {field1, value1 }, {field2, value2} } </param>
        /// <returns>Returns a subset of objects of type Entity object.</returns>
        protected List<Entity> GetWhere(Entity Entity, Dictionary<string, string> Where)
        {
            List<string> matches = new List<string>();
            foreach (KeyValuePair<string, string> match in Where)
            {
                matches.Add(match.Key + " = @" + match.Key);
            }
            string where = string.Join(" AND ", matches);


            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("SELECT * FROM {0} WHERE {1}", Entity.GetTableName(), where)
            };

            foreach (KeyValuePair<string, string> match in Where)
            {
                cmd.Parameters.AddWithValue("@" + match.Key, match.Value);
            }

            return ExecuteReader(Entity, cmd);
        }


        #endregion


        #region INSERTS

        /// <summary>
        /// Insert one particular element of type Entity object into the corresponding database table.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <returns>True if successfully.</returns>
        protected bool Insert(Entity Entity)
        {
            string fields = string.Join(", ", Entity.GetAllFields().Select(x=> x = "[" + x + "]"));
            string values = string.Join(", ", Entity.GetAllFields().Select(x => x = "@" + x));

            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("INSERT INTO {0}({1}) VALUES({2})", Entity.GetTableName(), fields, values)
            };

            string[] flds = Entity.GetAllFields();
            string[] val = Entity.GetAllValues();
            for (int i = 0; i < Entity.GetAllFields().Count(); i++)
            {
                cmd.Parameters.AddWithValue("@" + flds[i], val[i]);
            }


            return ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        #endregion


        #region UPDATES

        /// <summary>
        /// Update one particular element of type Entity object from the corresponding database table.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <returns>True if successfully.</returns>
        protected bool Update(Entity Entity)
        {
            List<string> matches = new List<string>();
            foreach(string field in Entity.GetUpdatableFields())
            {
                matches.Add(field + " = @" + field);
            }
            string updatables = string.Join(", ", matches);


            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("UPDATE {0} SET {1} WHERE id={2}", Entity.GetTableName(), updatables, Entity.GetId())
            };


            string[] flds = Entity.GetUpdatableFields();
            string[] val = Entity.GetUpdatableValues();
            for (int i = 0; i < Entity.GetUpdatableFields().Count(); i++)
            {
                cmd.Parameters.AddWithValue("@" + flds[i], val[i]);
            }


            return ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        #endregion


        #region DELETES

        /// <summary>
        /// Delete one particular element of type Entity object from the corresponding database table.
        /// </summary>
        /// <param name="Entity">An object that implements Abstract Class Entity.</param>
        /// <returns>True if successfully.</returns>
        protected bool Delete(Entity Entity)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = string.Format("DELETE FROM {0} WHERE id = {1}", Entity.GetTableName(), Entity.GetId())
            };

            return ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        #endregion

    }
}
