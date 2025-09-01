using Token.Models;
namespace Token.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(Users user);
    }
}
