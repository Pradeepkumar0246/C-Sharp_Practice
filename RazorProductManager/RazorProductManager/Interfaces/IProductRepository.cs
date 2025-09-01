using System.Collections.Generic;
using System.Threading.Tasks;
using RazorProductManager.Models;

namespace RazorProductManager.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetProductsAbovePriceAsync(decimal price);
    }
}
