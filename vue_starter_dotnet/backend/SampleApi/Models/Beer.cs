using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Beer
    {
        /// <summary>
        /// The beers id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The beers name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The beers description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The beers image.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// The beers abv.
        /// </summary>
        public string ABV { get; set; }
        /// <summary>
        /// The beers type.
        /// </summary>
        public string BeerType { get; set; }
        /// <summary>
        /// The brewerys Id to connect beer to a brewery.
        /// </summary>
        public int BreweryID { get; set; }
        /// <summary>
        /// The beers average rating
        /// </summary>
        public decimal AvgRating { get; set; }
    }
}
