// x_unit.csproj test file content omitted for brevity – focus on the test class.
// x_unit.cs
using UserRegistrationSystemApp;
using Xunit;

namespace x_unit
{
    public class RegistrationServiceTests
    {
        private static RegistrationService CreateService(out InMemoryUserRepository repo)
        {
            repo = new InMemoryUserRepository();
            return new RegistrationService(repo);
        }

        [Fact]
        public void Register_NewUser_Succeeds()
        {
            var service = CreateService(out var repo);

            var (ok, err) = service.Register("john@example.com", "StrongP4ss", "John Doe");

            Assert.True(ok);
            Assert.Equal(string.Empty, err);
            Assert.Single(repo.GetAll());
        }

        [Fact]
        public void Register_DuplicateEmail_Fails()
        {
            var service = CreateService(out var repo);
            service.Register("jane@example.com", "StrongP4ss", "Jane");

            var (ok, err) = service.Register("jane@example.com", "StrongP4ss", "Jane 2");

            Assert.False(ok);
            Assert.Equal("Email already registered.", err);
            Assert.Single(repo.GetAll());
        }

        [Theory]
        [InlineData("bademail", "StrongP4ss", "Name", "Invalid email.")]
        [InlineData("ok@example.com", "short", "Name", "Password must be at least 8 characters.")]
        [InlineData("ok@example.com", "alllowercase1", "Name", "Password must contain an uppercase letter.")]
        [InlineData("ok@example.com", "ALLUPPERCASE1", "Name", "Password must contain a lowercase letter.")]
        [InlineData("ok@example.com", "NoDigitsHere", "Name", "Password must contain a digit.")]
        [InlineData("ok@example.com", "Valid1Pass", "", "Full name is required.")]
        public void Register_InvalidInputs_Fail(string email, string pwd, string name, string expectedError)
        {
            var service = CreateService(out _);

            var (ok, err) = service.Register(email, pwd, name);

            Assert.False(ok);
            Assert.Equal(expectedError, err);
        }
    }
}
