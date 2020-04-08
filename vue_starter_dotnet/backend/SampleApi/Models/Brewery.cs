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
        /// The brewers name.
        /// </summary>
        public string Brewer { get; set; }
        /// <summary>
        /// The brewers user id.
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// The breweries hours of operation.
        /// </summary>
        public string Hours { get; set; }
        /// <summary>
        /// The breweries contact info.
        /// </summary>
        public string ContactInfo { get; set; }
        /// <summary>
        /// The breweries address.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// The breweries history.
        /// </summary>
        public string History { get; set; }
        /// <summary>
        /// The breweries images.
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// If the brewery is to be shown to the user or not. Defaults to true.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
