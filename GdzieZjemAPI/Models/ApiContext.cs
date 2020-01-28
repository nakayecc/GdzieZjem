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
            
            modelBuilder.Entity<CityRestaurant>()
                .HasOne<City>(cr => cr.City)
                .WithMany(c => c.CityRestaurants)
                .HasForeignKey(cr => cr.CityId);

            modelBuilder.Entity<CityRestaurant>()
                .HasOne<Restaurant>(cr => cr.Restaurant)
                .WithMany(r => r.CityRestaurants)
                .HasForeignKey(cr => cr.CityId);

            modelBuilder.Entity<DishRestaurant>().HasKey(dr => new {dr.DishId, dr.RestaurantId});

            modelBuilder.Entity<DishRestaurant>()
                .HasOne<Dish>(dr => dr.Dish)
                .WithMany(d => d.DishRestaurants)
                .HasForeignKey(dr => dr.DishId);

            modelBuilder.Entity<DishRestaurant>()
                .HasOne<Restaurant>(dr => dr.Restaurant)
                .WithMany(r => r.DishRestaurants)
                .HasForeignKey(dr => dr.RestaurantId);
        }
    }
}