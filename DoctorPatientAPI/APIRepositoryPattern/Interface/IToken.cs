using APIRepositoryPattern.Models;

namespace APIRepositoryPattern.Interface
{
    public interface IToken
    {
        string GenerateToken(User user);
    }
}
