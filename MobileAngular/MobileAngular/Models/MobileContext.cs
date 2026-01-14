using Microsoft.EntityFrameworkCore;

namespace MobileAngular.Models
{
    public class MobileContext: DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
        }
        public DbSet<Mobile> Mobiles { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mobile>().HasData(
                new Mobile { MobileId = 1, ModelName = "iPhone 13", Brand = "Apple", Price = 999.99M },
                new Mobile { MobileId = 2, ModelName = "Galaxy S21", Brand = "Samsung", Price = 799.99M },
                new Mobile { MobileId = 3, ModelName = "Pixel 6", Brand = "Google", Price = 599.99M }
            );
        }
    }
}
