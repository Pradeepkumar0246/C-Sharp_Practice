using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace EcommWebApp.DataAccess
{
    public class UserDataAccess
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EcommConnection"].ConnectionString;

        // Method to register a new user
        public bool RegisterUser(string username, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";
                SqlCommand command = new SqlCommand(query, connection);

                // Hash the password before storing
                string passwordHash = HashPassword(password);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                connection.Open();
                int result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        // Method to verify user login
        public bool VerifyUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                string storedHash = (string)command.ExecuteScalar();

                if (storedHash != null)
                {
                    return VerifyPassword(password, storedHash);
                }
                return false;
            }
        }

        // Helper method to hash password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Helper method to verify password
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash.Equals(storedHash);
        }
    }
}