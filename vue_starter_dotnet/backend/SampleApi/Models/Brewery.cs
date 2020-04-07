using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a brewery in the system
    /// </summary>
    public class Brewery
    {
        /// <summary>
        /// The breweries id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The breweries name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The brewers user id.
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// The brewers username.
        /// </summary>
        public string Username { get; set; }
    }
}
