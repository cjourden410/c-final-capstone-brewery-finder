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

                    string sql = $"INSERT INTO breweries (name, brewer, userID) VALUES (@name, @brewer, @userID); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithValue("@brewer", brewery.Brewer);
                    cmd.Parameters.AddWithValue("@userID", brewery.UserID);
                    

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update a brewery in the database.
        /// </summary>
        /// <param name="brewery"></param>
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

        /// <summary>
        /// Returns all of the beers by brewery.
        /// </summary>
        /// <returns></returns>
        public IList<Beer> GetBeersByBrewery(int breweryID)
        {
            List<Beer> output = new List<Beer>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT * 
                        FROM beers
                        WHERE breweryID = @breweryID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@breweryID", breweryID);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Beer beer = RowToObjectBeer(reader);
                        output.Add(beer);
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
        /// Gets a beer by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Beer GetBeerById(int id)
        {
            Beer beer = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT *
                        FROM beers
                        WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a brewery
                        beer = RowToObjectBeer(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return beer;
        }

        /// <summary>
        /// Gets a beer average rating by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Beer GetRatingByBeerById(int id)
        {
            Beer beer = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT b.id, b.name, b.description, b.image, b.abv, b.beerType, b.breweryID, AVG(rating) avgRating
                        FROM beers b
                        JOIN beerReviews br on b.id = br.beerID
                        WHERE b.id = @id
                        GROUP BY b.id, b.name, b.description, b.image, b.abv, b.beerType, b.breweryID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a brewery
                        beer = RowToObjectBeer2(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return beer;
        }

        private Beer RowToObjectBeer(SqlDataReader reader)
        {
            // Create a beer
            Beer beer = new Beer();
            beer.Id = Convert.ToInt32(reader["id"]);
            beer.Name = Convert.ToString(reader["name"]);
            beer.Description = Convert.ToString(reader["description"]);
            beer.Image = Convert.ToString(reader["image"]);
            beer.ABV = Convert.ToString(reader["abv"]);
            beer.BeerType = Convert.ToString(reader["beerType"]);
            beer.BreweryID = Convert.ToInt32(reader["breweryID"]);
            return beer;
        }

        private Beer RowToObjectBeer2(SqlDataReader reader)
        {
            // Create a beer
            Beer beer = new Beer();
            beer.Id = Convert.ToInt32(reader["id"]);
            beer.Name = Convert.ToString(reader["name"]);
            beer.Description = Convert.ToString(reader["description"]);
            beer.Image = Convert.ToString(reader["image"]);
            beer.ABV = Convert.ToString(reader["abv"]);
            beer.BeerType = Convert.ToString(reader["beerType"]);
            beer.BreweryID = Convert.ToInt32(reader["breweryID"]);
            beer.AvgRating = Convert.ToDecimal(reader["avgRating"]);
            return beer;
        }

        /// <summary>
        /// Adds a beer to the database.
        /// </summary>
        /// <param name="beer"></param>
        public int AddBeer(Beer beer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = 
                        @"INSERT INTO beers
                          (name, description, image, abv, beerType, breweryID)
                        VALUES
                          (@name, @description, @image, @abv, @beerType, @breweryID); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", beer.Name);
                    cmd.Parameters.AddWithValue("@description", beer.Description);
                    cmd.Parameters.AddWithValue("@image", beer.Image);
                    cmd.Parameters.AddWithValue("@abv", beer.ABV);
                    cmd.Parameters.AddWithValue("@beerType", beer.BeerType);
                    cmd.Parameters.AddWithValue("@breweryID", beer.BreweryID);


                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes a beer from the database.
        /// </summary>
        /// <param name="beerID"></param>
        public void DeleteBeer(int beerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"Delete from beers where id = @beerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beerID", beerID);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns all of the reviews.
        /// </summary>
        /// <returns></returns>
        public IList<BeerReview> GetReviews()
        {
            List<BeerReview> output = new List<BeerReview>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT br.id, br.review, br.beerID, b.name, br.rating 
                        FROM beerReviews br
                        JOIN beers b on br.beerID = b.id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        BeerReview review = RowToObjectReview(reader);
                        output.Add(review);
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
        /// Gets a review by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeerReview GetReviewById(int id)
        {
            BeerReview review = null;
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT br.id, br.review, br.beerID, b.name, br.rating 
                        FROM beerReviews br
                        JOIN beers b on br.beerID = b.id
                        WHERE br.id = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    if (reader.Read())
                    {
                        // Create a review
                        review = RowToObjectReview(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return review;
        }

        /// <summary>
        /// Returns all of the reviews by beer.
        /// </summary>
        /// <returns></returns>
        public IList<BeerReview> GetReviewsByBeer(int beerID)
        {
            List<BeerReview> output = new List<BeerReview>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT br.id, br.review, br.beerID, b.name, br.rating 
                        FROM beerReviews br
                        JOIN beers b on br.beerID = b.id
                        WHERE br.beerID = @beerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beerID", beerID);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        BeerReview review = RowToObjectReview(reader);
                        output.Add(review);
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
        /// Returns all of the reviews by beer.
        /// </summary>
        /// <returns></returns>
        public IList<BeerReview> GetReviewsByBrewery(int breweryID)
        {
            List<BeerReview> output = new List<BeerReview>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"SELECT br.id, br.review, br.beerID, b.name, br.rating 
                        FROM beerReviews br
                        JOIN beers b on br.beerID = b.id
                        JOIN breweries bw on b.breweryID = bw.id
                        WHERE bw.id = @breweryID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@breweryID", breweryID);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        BeerReview review = RowToObjectReview(reader);
                        output.Add(review);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        private BeerReview RowToObjectReview(SqlDataReader reader)
        {
            // Create a review
            BeerReview review = new BeerReview();
            review.Id = Convert.ToInt32(reader["id"]);
            review.Review = Convert.ToString(reader["review"]);
            review.BeerID = Convert.ToInt32(reader["beerID"]);
            review.Rating = Convert.ToInt32(reader["rating"]);
            review.BeerName = Convert.ToString(reader["name"]);
            return review;
        }

        /// <summary>
        /// Add a new review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public int AddReview(BeerReview review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        @"INSERT INTO beerReviews
                          (review,beerID,rating)
                        VALUES
                          (@review, @beerID, @rating); Select @@Identity;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@review", review.Review);
                    cmd.Parameters.AddWithValue("@beerID", review.BeerID);
                    cmd.Parameters.AddWithValue("@rating", review.Rating);

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
