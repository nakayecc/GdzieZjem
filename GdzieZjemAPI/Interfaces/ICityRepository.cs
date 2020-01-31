using System.Collections.Generic;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;

namespace GdzieZjemAPI.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        RestaurantInCityDao FindRestaurantByCityId(int cityId);
        List<SelectCityDto> GetAllCity();
        bool PostCity(City city);
        bool RemoveCity(int id);

    }
}