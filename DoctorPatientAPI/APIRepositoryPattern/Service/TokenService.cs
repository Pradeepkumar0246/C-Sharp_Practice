using APIRepositoryPattern.Interface;
using APIRepositoryPattern.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIRepositoryPattern.Service
{
    public class TokenService : IToken
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(config["TokenKey"]!)
           );
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
              {
                 new Claim(ClaimTypes.NameIdentifier, user.UserId!),
                 new Claim(ClaimTypes.Name, user.UserName!),
                 new Claim(ClaimTypes.Role, user.Role!.RoleName!)
              };

            string token = string.Empty;
           
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = cred,
            };
            var tokenHandler = new JwtSecurityTokenHandler();//Handles the creation and validation of JWTs
            var myToken = tokenHandler.CreateToken(tokenDescription);//Creates a raw JWT object
            token = tokenHandler.WriteToken(myToken);//Converts the JWT object to a string format(The header and payload are Base64Url encoded.) and the hashing and signing of the data is carried out and the result is returned
            return token;
        }
    }
}
