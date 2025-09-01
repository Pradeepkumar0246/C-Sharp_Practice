using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductManager.Models;
using RazorProductManager.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorProductManager.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _repo;

        public IndexModel()
        {
            _repo = new ProductRepository(); 
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var items = await _repo.GetAllAsync();
            Products = new List<Product>(items);
        }
    }
}
