
using NUnit.Framework;
using UserRegistrationSystemApp;

namespace n_unit
{
    [TestFixture]
    public class RegistrationServiceTests
    {
        private static RegistrationService CreateService(out InMemoryUserRepository repo)
        {
            repo = new InMemoryUserRepository();
            return new RegistrationService(repo);
        }

        [Test]
        public void Register_NewUser_Succeeds()
        {
            var service = CreateService(out var repo);

            var (ok, err) = service.Register("john@example.com", "StrongP4ss", "John Doe");

            Assert.That(ok, Is.True);
            Assert.That(err, Is.EqualTo(string.Empty));
            Assert.That(repo.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void Register_DuplicateEmail_Fails()
        {
            var service = CreateService(out var repo);
            service.Register("jane@example.com", "StrongP4ss", "Jane");

            var (ok, err) = service.Register("jane@example.com", "StrongP4ss", "Jane 2");

            Assert.That(ok, Is.False);
            Assert.That(err, Is.EqualTo("Email already registered."));
            Assert.That(repo.GetAll().Count, Is.EqualTo(1));
        }

        [TestCase("bademail", "StrongP4ss", "Name", "Invalid email.")]
        [TestCase("ok@example.com", "short", "Name", "Password must be at least 8 characters.")]
        [TestCase("ok@example.com", "alllowercase1", "Name", "Password must contain an uppercase letter.")]
        [TestCase("ok@example.com", "ALLUPPERCASE1", "Name", "Password must contain a lowercase letter.")]
        [TestCase("ok@example.com", "NoDigitsHere", "Name", "Password must contain a digit.")]
        [TestCase("ok@example.com", "Valid1Pass", "", "Full name is required.")]
        public void Register_InvalidInputs_Fail(string email, string pwd, string name, string expectedError)
        {
            var service = CreateService(out _);

            var (ok, err) = service.Register(email, pwd, name);

            Assert.That(ok, Is.False);
            Assert.That(err, Is.EqualTo(expectedError));
        }
    }
}
