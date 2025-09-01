using System;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    string conStr = @"Server=DESKTOP-BE5N6B8;Database=ec;Integrated Security=True;TrustServerCertificate=True";

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblMessage.Text = "Please fill all fields.";
            return;
        }

        SqlConnection con = new SqlConnection(conStr);
        string query = "SELECT Role, FirstName FROM Users WHERE Email = @Email AND Password = @Password";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Session["mailid"] = txtEmail.Text;
                Session["role"] = reader["Role"].ToString();
                Session["firstname"] = reader["FirstName"].ToString();  // ✅ Store first name
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials!";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: " + ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
}
