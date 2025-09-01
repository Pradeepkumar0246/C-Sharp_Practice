namespace ManytoManyBookAuthor.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int publicationYear { get; set; }
        public decimal Price { get; set; }
        public ICollection<BookAuthor>? BookAuthor { get; set; }
    }
}
