using Microsoft.EntityFrameworkCore;
using Token.Models;

namespace Token.Models
{
    public class APItokenContext : DbContext
    {
        public APItokenContext(DbContextOptions<APItokenContext> options) : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Or Restrict based on your needs

            // Optional: Configure entity properties if needed
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Password).IsRequired();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(p => p.productName).IsRequired().HasMaxLength(200);
                entity.Property(p => p.price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
            });
        }
    }
}