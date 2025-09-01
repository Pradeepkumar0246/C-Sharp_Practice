using APITokenPractice.Interfaces;
using APITokenPractice.Models;

namespace APITokenPractice.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
            => await _bookRepository.GetAllAsync();

        public async Task<Book> GetBookByIdAsync(int id)
            => await _bookRepository.GetByIdAsync(id);

        public async Task<Book> CreateBookAsync(Book book)
            => await _bookRepository.AddAsync(book);

        public async Task<Book> UpdateBookAsync(Book book)
            => await _bookRepository.UpdateAsync(book);

        public async Task<bool> DeleteBookAsync(int id)
            => await _bookRepository.DeleteAsync(id);

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
            => await _bookRepository.GetBooksByAuthorAsync(author);
    }
}
