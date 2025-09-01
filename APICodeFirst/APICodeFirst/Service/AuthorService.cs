using APICodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace APICodeFirst.Service
{
    public class AuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Author.Include(a => a.Books).ToListAsync();
        }
    }
}
