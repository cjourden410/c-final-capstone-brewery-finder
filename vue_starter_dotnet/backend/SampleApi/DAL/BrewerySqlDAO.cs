using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleApi.DAL
{
    public class BrewerySqlDAO : IBreweryDAO
    {
        private readonly string connectionString;

        public BrewerySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a brewery to the database.
        /// </summary>
        /// <param name="brewery"></param>
        public int AddBrewery(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO breweries (name, userID, username) VALUES (@name, @userID, @username); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithValue("@userID", brewery.UserID);
                    cmd.Parameters.AddWithValue("@username", brewery.Username);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
