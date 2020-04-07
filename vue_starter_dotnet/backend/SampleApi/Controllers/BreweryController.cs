﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : Controller
    {
        /**** DEPENDENCY INJECTION *****/
        private IBreweryDAO breweryDAO;

        private readonly ILogger<BreweryController> _logger;

        // TODO 04 (Controller): implement dependency injection to get BreweryDAO
        public BreweryController(ILogger<BreweryController> logger, IBreweryDAO breweryDAO)
        {
            _logger = logger;
            this.breweryDAO = breweryDAO;
        }

        /// <summary>
        /// Gets a single Brewery by id.
        /// </summary>
        /// <param name="id">Identifier of the brewery</param>
        /// <returns>A Brewery object. 404 if not found.</returns>
        /// <response code="200">Brewery was not found and returned in body.</response>
        /// <response code="404">Id was not found</response>
        [HttpGet("{id}", Name = "GetBrewery")]
        [ProducesResponseType(404)]
        public IActionResult GetBrewery(int id)
        {
            Brewery brewery = breweryDAO.GetBreweryById(id);
            if (brewery == null)
            {
                return NotFound();
            }
            return new JsonResult(brewery);
        }

        /// <summary>
        /// Insert a Brewery into the DB
        /// </summary>
        /// <param name="brewery">Brewery object to add to the DB.</param>
        /// <returns>The new Brewery object in the body, as well as a 201 Created message with a location to the new brewery.</returns>
        /// <response code="201">Brewery was created.</response>
        /// <response code="400">Data was not valid for adding a brewery.</response>
        [HttpPost("")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddCity([FromBody]Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                int newId = breweryDAO.AddBrewery(brewery);
                brewery = breweryDAO.GetBreweryById(newId);
                // Return CreatedAtRoute to return 201
                return CreatedAtRoute("GetBrewery", new { id = newId }, brewery);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}