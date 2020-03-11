using System.Collections.Generic;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.dto;

namespace GdzieZjemAPI.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        RestaurantInCityDao FindRestaurantByCityId(int cityId);
        List<SelectRestaurantDto> GetAllRestaurantByCity(string cityName);
        List<SelectCityDto> GetAllCity();
        bool PostCity(City city);
        bool RemoveCity(int id);

    }
}