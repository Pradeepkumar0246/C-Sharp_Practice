using APITokenPractice.Models;

namespace APITokenPractice.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        Task<IEnumerable<Book>> GetBooksPublishedAfterAsync(DateTime date);
        // Add book-specific methods here
    }
}
