using System;
using System.Data.SqlClient;

namespace ecommerce
{
    
    public partial class Register : System.Web.UI.Page
    {
        string conStr = @"Server=DESKTOP-BE5N6B8;Database=ecomm;Integrated Security=True;TrustServerCertificate=True";
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FN, @LN, @Email, @Pass)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FN", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPassword.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Registration successful!";
        }
    }
}
