using Microsoft.EntityFrameworkCore;

namespace APITokenPractice.Models
{
    public class BookAuthorContext:DbContext
    {
        public BookAuthorContext(DbContextOptions<BookAuthorContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }    
}
