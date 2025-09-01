using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
namespace APICodeFirst.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)                
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { BookId = 1, Title = "C# Programming", Description = "A comprehensive guide to C# programming.", AuthorId = 1 },
                    new Book { BookId = 2, Title = "ASP.NET Core", Description = "Building web applications with ASP.NET Core.", AuthorId = 2 }
                );
            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Author>()
            .HasData(
                new Author { AuthorId = 1, Name = "John Doe", Email = "abc.gmail.com" },
                new Author { AuthorId = 2, Name = "Jane Smith", Email = "xyz.gmail.com" }
                );

        }
    }
}
