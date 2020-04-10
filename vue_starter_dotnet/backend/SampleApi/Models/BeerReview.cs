using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class BeerReview
    {
        /// <summary>
        /// The beer reviews id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The beers review
        /// </summary>
        public string Review { get; set; }
        /// <summary>
        /// The beers Id to connect review to a beer.
        /// </summary>
        public int BeerID { get; set; }
        /// <summary>
        /// The beers rating.
        /// </summary>
        public int Rating { get; set; }
    }
}
