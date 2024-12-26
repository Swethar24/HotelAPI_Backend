using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using HotelApi.Models;

namespace HotelApi.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly List<Hotel> _hotels;

        public HotelRepository()
        {
            // Build the file path to Data/hotels.json
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "hotels.json");

            try
            { 
                if (File.Exists(jsonFilePath))
                {
                var jsonData = File.ReadAllText(jsonFilePath);
                 // Deserialize the JSON into _hotels
                 // PropertyNameCaseInsensitive = true matches "id" to Id.
                 _hotels = JsonSerializer.Deserialize<List<Hotel>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Hotel>();
                }
                else
                {
                // If the file is missing, fallback to an empty list or handle error
                _hotels = new List<Hotel>();
                }
            }
            catch (Exception ex)
            {
                // Throw, so the controller can catch it and return 500
                throw new Exception("Error reading hotels.json", ex);
            }
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotels;
        }

        public Hotel? GetHotelById(int id)
        {
            return _hotels.FirstOrDefault(h => h.Id == id);
        }
    }
}
