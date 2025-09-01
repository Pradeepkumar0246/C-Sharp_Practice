using System.ComponentModel.DataAnnotations;

namespace codefirst.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        // Navigation property for related products
        public IList<Product> Products { get; set; }
    }
}
