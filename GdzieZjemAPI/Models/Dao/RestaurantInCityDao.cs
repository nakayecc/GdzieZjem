using System.Collections.Generic;

namespace GdzieZjemAPI.Models.Dao
{
    public class RestaurantInCityDao
    {
        public string City { get; set; }
        public List<SelectRestaurantDao> Restaurant { get; set; }
        public RestaurantInCityDao()
        {
            Restaurant = new List<SelectRestaurantDao>();
        }
    }
}