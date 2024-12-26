using Microsoft.AspNetCore.Mvc;
using HotelApi.Repositories;
using HotelApi.Models;
using System.Collections.Generic;
using System;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        /// <summary>
        /// GET /api/hotels
        /// Returns a list of all hotels.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAll()
        {
            try
            {
                var hotels = _hotelRepository.GetAllHotels();
                return Ok(hotels); // status 200 OK + JSON list
            }
            catch (Exception ex)
            {
                // If an unhandled exception occurs in the repository
                // we catch it here and return a 500 status code.
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// GET /api/hotels/{id}
        /// Returns details of a single hotel by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetById(int id)
        {
            try
            {
                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                {
                    // Returning 404 Not Found with a small JSON message
                    return NotFound(new { message = $"Hotel with ID {id} not found." });
                }
                return Ok(hotel); // status 200 OK + the single hotel in JSON
            }
            catch (Exception ex)
            {
                // If the repository throws an exception for some reason,
                // return 500 with a descriptive message
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}





