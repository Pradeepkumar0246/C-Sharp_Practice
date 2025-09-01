using System.ComponentModel.DataAnnotations;

namespace Token.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Products> Products { get; set; }= new List<Products>();
    }
}
