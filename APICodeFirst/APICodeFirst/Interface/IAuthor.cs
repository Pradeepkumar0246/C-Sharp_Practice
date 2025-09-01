using APICodeFirst.Models;

namespace APICodeFirst.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
    }
}
