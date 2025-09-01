using APITokenPractice.DTOs;
using APITokenPractice.Models;
using APITokenPractice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITokenPractice.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class BooksController : ControllerBase
    //{
    //    private readonly BookAuthorContext _context;

    //    public BooksController(BookAuthorContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/Books
    //    [HttpGet]
    //    [Authorize(Roles = "Admin,User")]
    //    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    //    {
    //        return await _context.Books.ToListAsync();
    //    }

    //    // GET: api/Books/5
    //    [HttpGet("{id}")]
    //    [Authorize(Roles = "Admin,User")]
    //    public async Task<ActionResult<Book>> GetBook(int id)
    //    {
    //        var book = await _context.Books.FindAsync(id);

    //        if (book == null)
    //        {
    //            return NotFound();
    //        }

    //        return book;
    //    }

    //    // PUT: api/Books/5
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    [Authorize(Roles = "Admin")]
    //    public async Task<IActionResult> PutBook(int id, Book book)
    //    {
    //        if (id != book.BookId)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(book).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!BookExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Books
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    [Authorize(Roles = "Admin")]
    //    public async Task<ActionResult<Book>> PostBook(Book book)
    //    {
    //        _context.Books.Add(book);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetBook", new { id = book.BookId }, book);
    //    }

    //    // DELETE: api/Books/5
    //    [HttpDelete("{id}")]
    //    [Authorize(Roles = "Admin")]
    //    public async Task<IActionResult> DeleteBook(int id)
    //    {
    //        var book = await _context.Books.FindAsync(id);
    //        if (book == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Books.Remove(book);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool BookExists(int id)
    //    {
    //        return _context.Books.Any(e => e.BookId == id);
    //    }
    //}
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // Add authentication if needed
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")] // Ensure only authorized users can access this endpoint
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")] // Ensure only authorized users can access this endpoint
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Ensure only Admin can create books
        public async Task<ActionResult<Book>> CreateBook(BookDto book)
        {
            var bookEntity = new Book
            {
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate
            };
            var createdBook = await _bookService.CreateBookAsync(bookEntity);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.BookId }, createdBook);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Ensure only Admin can update books
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.BookId) return BadRequest();

            var updatedBook = await _bookService.UpdateBookAsync(book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Ensure only Admin can delete books
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("author/{author}")]
        [Authorize(Roles = "Admin,User")] // Ensure only authorized users can access this endpoint
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string author)
        {
            var books = await _bookService.GetBooksByAuthorAsync(author);
            return Ok(books);
        }
    }
}
