using APITokenPractice.DTOs;
using APITokenPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APITokenPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly BookAuthorContext _con;
        private readonly IConfiguration _tokenService;
        public TokenController(BookAuthorContext con, IConfiguration tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto != null && !string.IsNullOrEmpty(loginDto.Email))
            {
                var user = await GetUser(loginDto.Email, loginDto.Role);
                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenService["Tokenkey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(ClaimTypes.Role, user.Role!)
                    };
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(30),
                        SigningCredentials = creds,
                        Issuer = _tokenService["Jwt.Issuer"],
                        Audience = _tokenService["Jwt.Audience"]
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var mytoken = tokenHandler.CreateToken(tokenDescription);
                    var token = tokenHandler.WriteToken(mytoken);
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
        private async Task<Users> GetUser(string email, string role)
        {
            return await _con.Users.FirstOrDefaultAsync(u => u.Email == email && u.Role == role) ?? new Models.Users();
        }
    }
}
