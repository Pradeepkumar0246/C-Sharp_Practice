using APIRepositoryPattern.Models;
using System.Globalization;

namespace APIRepositoryPattern.DTOs
{
    public class LoginDto
    {
            public string Username { get; set; }
            public string PasswordHash { get; set; }

    }
}
