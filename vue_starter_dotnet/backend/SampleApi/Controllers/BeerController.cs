using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerController : Controller
    {
        /**** DEPENDENCY INJECTION *****/
        private IBreweryDAO breweryDAO;

        private readonly ILogger<BreweryController> _logger;

        // TODO 04 (Controller): implement dependency injection to get BreweryDAO
        public BeerController(ILogger<BreweryController> logger, IBreweryDAO breweryDAO)
        {
            _logger = logger;
            this.breweryDAO = breweryDAO;
        }

        /// <summary>
        /// Get a list of beers. 
        /// </summary>
        /// <returns>Returns a list of all beers in the DB.</returns>
        [HttpGet("")]
        public IActionResult GetBeers()
        {
            return new JsonResult(breweryDAO.GetBeers());
        }

        /// <summary>
        /// Gets a single Beer by id.
        /// </summary>
        /// <param name="id">Identifier of the beer</param>
        /// <returns>A Beer object. 404 if not found.</returns>
        /// <response code="200">Beer was not found and returned in body.</response>
        /// <response code="404">Id was not found</response>
        [HttpGet("{id}", Name = "GetBeer")]
        [ProducesResponseType(404)]
        public IActionResult GetBeer(int id)
        {
            Beer beer = breweryDAO.GetBeerById(id);
            if (beer == null)
            {
                return NotFound();
            }
            return new JsonResult(beer);
        }

        /// <summary>
        /// Insert a Beer into the DB
        /// </summary>
        /// <param name="beer">Beer object to add to the DB.</param>
        /// <returns>The new Beer object in the body, as well as a 201 Created message with a location to the new beer.</returns>
        /// <response code="201">Beer was created.</response>
        /// <response code="400">Data was not valid for adding a beer.</response>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddBeer([FromBody]Beer beer)
        {
            if (ModelState.IsValid)
            {
                int newId = breweryDAO.AddBeer(beer);
                beer = breweryDAO.GetBeerById(newId);
                // Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetBeer", new { id = newId }, beer);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}