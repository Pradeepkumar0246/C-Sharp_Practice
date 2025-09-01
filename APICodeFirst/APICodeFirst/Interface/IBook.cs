using APICodeFirst.Models;

namespace APICodeFirst.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
