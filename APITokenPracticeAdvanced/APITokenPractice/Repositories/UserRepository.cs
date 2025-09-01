namespace APITokenPractice.Repositories
{
    using APITokenPractice.Interfaces;
    using APITokenPractice.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(BookAuthorContext context) : base(context) { }

        public async Task<Users> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<Users> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
