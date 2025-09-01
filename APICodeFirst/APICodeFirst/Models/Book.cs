using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICodeFirst.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        // Foreign key
        public int AuthorId { get; set; }

        // Navigation property
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
