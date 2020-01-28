namespace GdzieZjemAPI.Models
{
    public class CityRestaurant
    {
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}