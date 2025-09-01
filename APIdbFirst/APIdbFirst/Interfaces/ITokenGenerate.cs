using APIdbFirst.Migrations;

namespace APIdbFirst.Interface
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
