using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace BusinessLogic
{
    public abstract class DAL
    {

        private string connectionString;

        public DAL(string ConnectionString)
        {
            //Home "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = blockbuster; Integrated Security = SSPI;";
            //ATEC "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = blockbuster; Integrated Security = SSPI;";

            connectionString = ConnectionString; // ConfigurationManager.ConnectionStrings["ConStringBlockBuster"].ConnectionString;
        }


        protected List<Dictionary<string, object>> ExecuteReader(SqlCommand SqlCommand)
        {
            List<Dictionary<string, object>> table = new List<Dictionary<string, object>>(); 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand.Connection = conn;
                conn.Open();

                try
                {
                    SqlDataReader dr = SqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();

                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            row.Add(dr.GetName(i), dr[i]);
                        }

                        table.Add(row);
                    }

                    return table;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected int ExecuteNonQuery(SqlCommand SqlCommand)
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

        protected object ExecuteScalar(SqlCommand SqlCommand)
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

    }
}
