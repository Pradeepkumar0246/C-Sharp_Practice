using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Token.Interfaces;
using Token.Models;

namespace Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly APItokenContext _con;
        private readonly ITokenGenerate _tokenService;
        public TokenController(APItokenContext con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Users userData)
        {
            if (userData != null && !string.IsNullOrEmpty(userData.Email) &&
            !string.IsNullOrEmpty(userData.Password))
            {
                var user = await GetUser(userData.Email, userData.Password, userData.Role);
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);

                    return Ok(new { token });

                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid request data");
            }
        }
        private async Task<Users> GetUser(string email, string password, string role)
        {
            return await _con.Users.FirstOrDefaultAsync(u => u.Email == email &&
            u.Password == password && u.Role==role) ?? new Models.Users();
        }
    }
}
