using APICodeFirst.Interface;
using APICodeFirst.Models;
using APICodeFirst.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookService;
        public BookController(IBook bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooksAsync();
        }
    }
}
