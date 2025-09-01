using System.ComponentModel.DataAnnotations;

namespace APICodeFirst.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Navigation property - one author can have many books
        public ICollection<Book>? Books { get; set; }
    }
}
