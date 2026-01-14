using FoodAngularAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAngularAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Food>().HasData(
               new Food { Id = 1, Name = "Non-veg Meals", Price = 150, Category = "Non-Veg", ImageUrl = "FoodImages/food1.png" },
                new Food { Id = 2, Name = "Veg-Meals", Price = 100, Category = "Veg", ImageUrl = "FoodImages/food2.png" },
                new Food { Id = 3, Name = "Parotta(NV)", Price = 70, Category = "Non-Veg", ImageUrl = "FoodImages/food3.png" },
                new Food { Id = 4, Name = "Parotta", Price = 50, Category = "Veg", ImageUrl = "FoodImages/food3.png" }
            );
        }
    }
}
