using AnimeAPIProject.Migrations;
using System.Xml.Linq;

namespace AnimeAPIProject.Models
{
    public class UnitTest1
    {
        [Fact]
        public void Users_Should_Assign_And_Retrieve_Values()
        {
            // Arrange
            var anime = new Anime { Anime_Id = 1, Anime_Name = "Naruto" };

            var user = new Users
            {
                User_Id = 1,
                User_Name = "Alice",
                User_Email = "alice@example.com",
                User_Password = "Pass@123",
                Role = "User",
                WatchedAnimes = new List<Anime> { anime }
            };

            // Act & Assert
            Assert.Equal(1, user.User_Id);
            Assert.Equal("Alice", user.User_Name);
            Assert.Equal("alice@example.com", user.User_Email);
            Assert.Equal("Pass@123", user.User_Password);
            Assert.Equal("User", user.Role);

            Assert.Single(user.WatchedAnimes);
            Assert.Equal("Naruto", user.WatchedAnimes.First().Anime_Name);
        }
    }
}