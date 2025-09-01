using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Hardcoded Admin check
            if (email == "admin@gmail.com" && password == "123456")
            {
                Session["UserEmail"] = email;
                Session["UserRole"] = "Admin";
                Response.Redirect("Admin/Dashboard.aspx");
                return;
            }

            // Check user in DB
            string conStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string query = "SELECT FirstName FROM Users WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["UserEmail"] = email;
                    Session["UserName"] = reader["FirstName"].ToString();
                    Session["UserRole"] = "User";
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                }
            }
        }
    }
}
