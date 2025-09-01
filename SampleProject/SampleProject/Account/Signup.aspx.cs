using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using ECommerceWebApp.Utilities;
namespace ECommerceWebApp.Account
{
    public partial class Signup : Page
    {
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // In production, hash this password
            string email = txtEmail.Text.Trim();

            // Check if username already exists
            string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            SqlParameter[] checkParams = { new SqlParameter("@Username", username) };
            int userCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(checkUserQuery, checkParams).Rows[0][0]);

            if (userCount > 0)
            {
                lblMessage.Text = "Username already exists. Please choose another.";
                return;
            }

            // Insert new user
            string insertQuery = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
            SqlParameter[] insertParams = {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password), // In production, store hashed password
                new SqlParameter("@Email", email)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);

            if (rowsAffected > 0)
            {
                lblMessage.Text = "Registration successful! Please login.";
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
            }
        }
    }
}