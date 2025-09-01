using RazorProductManager.Data;
using RazorProductManager.Interfaces;
using RazorProductManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProductManager.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository() : base(InMemoryProductStore.Products) { }

        public Task<IEnumerable<Product>> GetProductsAbovePriceAsync(decimal price)
        {
            var results = _store.Where(p => p.Price > price);
            return Task.FromResult<IEnumerable<Product>>(results);
        }
    }
}
