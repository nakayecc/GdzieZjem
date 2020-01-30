using Microsoft.EntityFrameworkCore;

namespace GdzieZjemAPI.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityRestaurant>().HasKey(cr => new {cr.CityId, cr.RestaurantId});

            modelBuilder.Entity<DishRestaurant>().HasKey(dr => new {dr.DishId, dr.RestaurantId});
            
        }
    }
}