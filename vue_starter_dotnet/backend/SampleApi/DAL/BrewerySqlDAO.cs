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
        /// Returns all of the breweries.
        /// </summary>
        /// <returns></returns>
        public IList<Brewery> GetBreweries()
        {
            List<Brewery> output = new List<Brewery>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT * 
                        FROM breweries";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Brewery brewery = RowToObject(reader);
                        output.Add(brewery);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// Gets a brewery by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brewery GetBreweryById(int id)
        {
            Brewery brewery = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT * 
                        FROM breweries 
                        where id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a brewery
                        brewery = RowToObject(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return brewery;
        }

        private Brewery RowToObject(SqlDataReader reader)
        {
            // Create a brewery
            Brewery brewery = new Brewery();
            brewery.Id = Convert.ToInt32(reader["id"]);
            brewery.Name = Convert.ToString(reader["name"]);
            brewery.Brewer = Convert.ToString(reader["brewer"]);
            brewery.UserID = Convert.ToInt32(reader["userID"]);
            brewery.Username = Convert.ToString(reader["username"]);
            brewery.Hours = Convert.ToString(reader["hours"]);
            brewery.ContactInfo = Convert.ToString(reader["contactInfo"]);
            brewery.Address = Convert.ToString(reader["address"]);
            brewery.History = Convert.ToString(reader["history"]);
            brewery.Images = Convert.ToString(reader["images"]);
            brewery.IsActive = Convert.ToBoolean(reader["isActive"]);
            return brewery;
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

                    string sql = $"INSERT INTO breweries (name, brewer, userID, username) VALUES (@name, @brewer, @userID, @username); Select @@Identity;";
                    //string sql = $"INSERT INTO breweries (name, brewer, userID, username) VALUES (@name, @brewer, (SELECT id FROM users where username = @username), @username); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithValue("@brewer", brewery.Brewer);
                    cmd.Parameters.AddWithValue("@userID", brewery.UserID);
                    //cmd.Parameters.AddWithValue("@username", brewery.UserID);
                    cmd.Parameters.AddWithValue("@username", brewery.Username);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateBreweryInfo(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Update breweries Set hours = @hours, contactInfo = @contactInfo, address = @address, history = @history, images = @images, isActive = @isActive Where name = @name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@hours", brewery.Hours);
                    cmd.Parameters.AddWithValue("@contactInfo", brewery.ContactInfo);
                    cmd.Parameters.AddWithValue("@address", brewery.Address);
                    cmd.Parameters.AddWithValue("@history", brewery.History);
                    cmd.Parameters.AddWithValue("@images", brewery.Images);
                    cmd.Parameters.AddWithValue("@isActive", brewery.IsActive);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);

                    int i = cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
