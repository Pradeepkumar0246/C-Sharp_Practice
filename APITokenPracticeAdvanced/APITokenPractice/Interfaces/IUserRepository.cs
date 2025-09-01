using APITokenPractice.Models;

namespace APITokenPractice.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetByUsernameAsync(string username);
        Task<Users> GetByEmailAsync(string email);
        // Add user-specific methods here
    }
}
