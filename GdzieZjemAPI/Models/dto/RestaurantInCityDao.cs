using System.Collections.Generic;

namespace GdzieZjemAPI.Models.dto
{
    public class RestaurantInCityDao
    {
        public string City { get; set; }
        public List<SelectRestaurantDto> Restaurant { get; set; }
        public RestaurantInCityDao()
        {
            Restaurant = new List<SelectRestaurantDto>();
        }
    }
}