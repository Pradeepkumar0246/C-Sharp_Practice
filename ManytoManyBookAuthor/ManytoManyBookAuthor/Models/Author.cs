namespace ManytoManyBookAuthor.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<BookAuthor>? BookAuthor { get; set; }
    }
}
