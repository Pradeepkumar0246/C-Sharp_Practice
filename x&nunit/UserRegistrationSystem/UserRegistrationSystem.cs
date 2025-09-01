
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace UserRegistrationSystemApp
{
    public record User(string Email, string Password, string FullName);

    public interface IUserRepository
    {
        bool EmailExists(string email);
        void Add(User user);
        IReadOnlyCollection<User> GetAll();
    }

    public sealed class InMemoryUserRepository : IUserRepository
    {
        private readonly HashSet<string> _emails = new(StringComparer.OrdinalIgnoreCase);
        private readonly List<User> _users = new();

        public bool EmailExists(string email) => _emails.Contains(email);

        public void Add(User user)
        {
            if (_emails.Add(user.Email))
            {
                _users.Add(user);
            }
            else
            {
                throw new InvalidOperationException("Email already exists.");
            }
        }

        public IReadOnlyCollection<User> GetAll() => _users.AsReadOnly();
    }

    public sealed class RegistrationService
    {
        private readonly IUserRepository _repo;

        public RegistrationService(IUserRepository repo) => _repo = repo;

        public (bool Success, string Error) Register(string email, string password, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return (false, "Full name is required.");

            if (!IsValidEmail(email))
                return (false, "Invalid email.");

            if (_repo.EmailExists(email))
                return (false, "Email already registered.");

            var pwdError = ValidatePassword(password);
            if (pwdError is not null)
                return (false, pwdError);

            _repo.Add(new User(email, password, fullName));
            return (true, "");
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                _ = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string? ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return "Password must be at least 8 characters.";

            if (!password.Any(char.IsUpper)) return "Password must contain an uppercase letter.";
            if (!password.Any(char.IsLower)) return "Password must contain a lowercase letter.";
            if (!password.Any(char.IsDigit)) return "Password must contain a digit.";

            return null;
        }
    }
}
