using System.Collections.Generic;
using GdzieZjemAPI.Models;
using GdzieZjemAPI.Models.Dao;

namespace GdzieZjemAPI.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        List<RestaurantFullLocalization> GetRestaurantFullLocalizationBy(string name, string address);
        RestaurantFullLocalization GetRestaurantFullLocalization();
    }
}