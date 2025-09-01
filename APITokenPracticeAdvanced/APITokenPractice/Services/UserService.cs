using APITokenPractice.Interfaces;
using APITokenPractice.Models;

namespace APITokenPractice.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
            => await _userRepository.GetAllAsync();

        public async Task<Users> GetUserByIdAsync(int id)
            => await _userRepository.GetByIdAsync(id);

        public async Task<Users> GetUserByUsernameAsync(string username)
            => await _userRepository.GetByUsernameAsync(username);

        public async Task<Users> CreateUserAsync(Users user)
            => await _userRepository.AddAsync(user);

        public async Task<Users> UpdateUserAsync(Users user)
            => await _userRepository.UpdateAsync(user);

        public async Task<bool> DeleteUserAsync(int id)
            => await _userRepository.DeleteAsync(id);
    }
}
