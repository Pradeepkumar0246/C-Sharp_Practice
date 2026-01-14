using APIRepositoryPattern.Models;

namespace APIRepositoryPattern.Interface
{
    public interface IHospitalAPI<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        object Include(Func<object, object> value);
    }

    public interface IUser
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
