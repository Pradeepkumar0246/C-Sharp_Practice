namespace APITokenPractice.Repositories
{
    using APITokenPractice.Interfaces;
    using APITokenPractice.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookAuthorContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            return await _context.Books
                .Where(b => b.Author.Contains(author))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksPublishedAfterAsync(DateTime date)
        {
            return await _context.Books
                .Where(b => b.PublishedDate > date)
                .ToListAsync();
        }
    }
}
