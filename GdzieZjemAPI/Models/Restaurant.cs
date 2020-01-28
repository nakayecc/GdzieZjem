using System.Collections.Generic;

namespace GdzieZjemAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public virtual ICollection<DishRestaurant> DishRestaurants { get; set; }
        public virtual ICollection<CityRestaurant> CityRestaurants { get; set; }
        
    }
}