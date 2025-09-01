using System.ComponentModel.DataAnnotations;

namespace APITokenPractice.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
    }
}
