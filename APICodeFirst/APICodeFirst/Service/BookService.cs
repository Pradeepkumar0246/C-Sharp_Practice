using APICodeFirst.Interface;
using APICodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace APICodeFirst.Service
{
    public class BookService : IBook
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Book.Include(e => e.Author).ToListAsync();
        }
    }
}
