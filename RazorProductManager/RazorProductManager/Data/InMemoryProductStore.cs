using System.Collections.Generic;
using RazorProductManager.Models;

namespace RazorProductManager.Data
{
    public static class InMemoryProductStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Pen", Price = 10 },
            new Product { Id = 2, Name = "Notebook", Price = 25 },
            new Product { Id = 3, Name = "Marker", Price = 40 }
        };
    }
}
