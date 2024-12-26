using Microsoft.AspNetCore.Mvc;
using HotelApi.Repositories;
using HotelApi.Models;
using System.Collections.Generic;

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
            var hotels = _hotelRepository.GetAllHotels();
            return Ok(hotels);
        }

        /// <summary>
        /// GET /api/hotels/{id}
        /// Returns details of a single hotel by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Hotel> GetById(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound(new { message = $"Hotel with ID {id} not found." });
            }
            return Ok(hotel);
        }
    }
}





