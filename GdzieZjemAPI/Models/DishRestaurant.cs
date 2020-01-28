namespace GdzieZjemAPI.Models
{
    public class DishRestaurant
    {
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}