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
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : Controller
    {
        /**** DEPENDENCY INJECTION *****/
        private IBreweryDAO breweryDAO;

        private readonly ILogger<BreweryController> _logger;

        // TODO 04 (Controller): implement dependency injection to get BreweryDAO
        public ReviewController(ILogger<BreweryController> logger, IBreweryDAO breweryDAO)
        {
            _logger = logger;
            this.breweryDAO = breweryDAO;
        }

        /// <summary>
        /// Gets a single review by id.
        /// </summary>
        /// <param name="id">Identifier of the review</param>
        /// <returns>A BeerReview object. 404 if not found.</returns>
        /// <response code="200">BeerReview was not found and returned in body.</response>
        /// <response code="404">Id was not found</response>
        [HttpGet("{id}", Name = "GetBeerReview")]
        [ProducesResponseType(404)]
        public IActionResult GetBeerReview(int id)
        {
            BeerReview review = breweryDAO.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return new JsonResult(review);
        }

        /// <summary>
        /// Insert a BeerReview into the DB
        /// </summary>
        /// <param name="review">BeerReview object to add to the DB.</param>
        /// <returns>The new BeerReview object in the body, as well as a 201 Created message with a location to the new beer review.</returns>
        /// <response code="201">Beer review was created.</response>
        /// <response code="400">Data was not valid for adding a beer review.</response>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddBeerReview([FromBody]BeerReview review)
        {
            if (ModelState.IsValid)
            {
                int newId = breweryDAO.AddReview(review);
                review = breweryDAO.GetReviewById(newId);
                // Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetBeerReview", new { id = newId }, review);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        /// <summary>
        /// Get a list of beer reviews. 
        /// </summary>
        /// <returns>Returns a list of all beer reviews in the DB.</returns>
        [HttpGet("")]
        public IActionResult GetReviews()
        {
            return new JsonResult(breweryDAO.GetReviews());
        }

        /// <summary>
        /// Get a list of reviews for a single beer. 
        /// </summary>
        /// <returns>Returns a list of all reviews in the DB for a single beer.</returns>
        [HttpGet("")]
        public IActionResult GetReviewsByBeer(int beerID)
        {
            return new JsonResult(breweryDAO.GetReviewsByBeer(beerID));
        }

        /// <summary>
        /// Get a list of reviews for a single breweries beers. 
        /// </summary>
        /// <returns>Returns a list of all reviews in the DB for a single brewery.</returns>
        [HttpGet("")]
        public IActionResult GetReviewsByBrewery(int breweryID)
        {
            return new JsonResult(breweryDAO.GetReviewsByBrewery(breweryID));
        }
    }
}