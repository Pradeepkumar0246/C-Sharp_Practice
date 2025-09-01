using APIdbFirst.Interface;
using APIdbFirst.Migrations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenGenerate
{
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration configuration)
    {
        _key = new
        SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));
    }
    public string GenerateToken(User user)
    {
        string token = string.Empty;
        var claims = new List<Claim>
{
new Claim(JwtRegisteredClaimNames.NameId,user.UserName!)
};
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(2),
            SigningCredentials = cred
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var myToken = tokenHandler.CreateToken(tokenDescription);
        token = tokenHandler.WriteToken(myToken);
        return token;
    }

    public object GenerateToken(APIdbFirst.Models.User user)
    {
        throw new NotImplementedException();
    }
}