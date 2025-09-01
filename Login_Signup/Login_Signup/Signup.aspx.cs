using System;
using System.Data.SqlClient;

public partial class Signup : System.Web.UI.Page
{
    string conStr = @"Server=DESKTOP-BE5N6B8;Database=ec;Integrated Security=True;TrustServerCertificate=True";

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        // Basic validation
        if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
            string.IsNullOrWhiteSpace(txtLastName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtPassword.Text) ||
            string.IsNullOrWhiteSpace(txtConfirmPassword.Text) ||
            string.IsNullOrWhiteSpace(txtContact.Text) ||
            string.IsNullOrWhiteSpace(txtAddress.Text))
        {
            lblMessage.Text = "All fields are required!";
            return;
        }

        if (txtPassword.Text.Length < 6)
        {
            lblMessage.Text = "Password must be at least 6 characters.";
            return;
        }

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblMessage.Text = "Passwords do not match.";
            return;
        }

        try
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Check for existing email
                string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand checkCmd = new SqlCommand(checkEmailQuery, con);
                checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                int userExists = (int)checkCmd.ExecuteScalar();

                if (userExists > 0)
                {
                    lblMessage.Text = "Email already registered!";
                    return;
                }

                // Insert new user
                string query = "INSERT INTO Users (FirstName, LastName, Email, Password, Contact, Address) " +
                               "VALUES (@FirstName, @LastName, @Email, @Password, @Contact, @Address)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    // Redirect after success
                    Response.Redirect("Login.aspx?signup=success");
                }
                else
                {
                    lblMessage.Text = "Signup failed. Try again.";
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: " + ex.Message;
        }
    }
}
