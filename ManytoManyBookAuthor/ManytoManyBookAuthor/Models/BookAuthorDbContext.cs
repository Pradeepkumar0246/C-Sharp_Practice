using Microsoft.EntityFrameworkCore;
namespace ManytoManyBookAuthor.Models
{
    public class BookAuthorDbContext:DbContext
    {
        public BookAuthorDbContext(DbContextOptions<BookAuthorDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(ba => ba.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthor)
                .HasForeignKey(ba => ba.AuthorId);
            modelBuilder.Entity<Author>()
                .HasData(
                    new Author { AuthorId = 1, AuthorName = "Author One" },
                    new Author { AuthorId = 2, AuthorName = "Author Two" }
                );
            modelBuilder.Entity<Book>()
                .HasData(
                    new Book { BookId = 1, BookName = "Book One", publicationYear = 2020, Price = 19.99M },
                    new Book { BookId = 2, BookName = "Book Two", publicationYear = 2021, Price = 29.99M }
                );
            modelBuilder.Entity<BookAuthor>()
                .HasData(
                    new BookAuthor { BookId = 1, AuthorId = 1 },
                    new BookAuthor { BookId = 1, AuthorId = 2 },
                    new BookAuthor { BookId = 2, AuthorId = 1 },
                    new BookAuthor { BookId = 2, AuthorId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ManytoManyBookAuthor.Models.BookAuthor>? BookAuthor { get; set; } = default;
        }
}
