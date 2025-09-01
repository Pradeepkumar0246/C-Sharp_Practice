using APICodeFirst.Models;
using APICodeFirst.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorService.GetAllAuthorsAsync();
        }
    }
}
