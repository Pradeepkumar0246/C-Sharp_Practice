using System.ComponentModel.DataAnnotations;

namespace Token.Models
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public int CategoryId { get; set; }
        public virtual Categories? Category { get; set; } 
    }
}
