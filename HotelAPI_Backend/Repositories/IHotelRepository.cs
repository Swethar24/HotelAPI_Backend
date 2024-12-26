using System.Collections.Generic;
using HotelApi.Models;

namespace HotelApi.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAllHotels();
        Hotel? GetHotelById(int id);
    }
}
