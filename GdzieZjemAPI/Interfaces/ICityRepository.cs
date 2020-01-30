using System.Collections.Generic;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;

namespace GdzieZjemAPI.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        RestaurantInCityDao RestaurantInCity(int cityId);

    }
}