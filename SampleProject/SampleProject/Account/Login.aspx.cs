using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using ECommerceWebApp.Utilities;

namespace ECommerceWebApp.Account
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // In production, hash and compare

            string query = "SELECT UserID, Username, IsAdmin FROM Users WHERE Username = @Username AND Password = @Password";
            var parameters = new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@Username", username),
                new System.Data.SqlClient.SqlParameter("@Password", password) // In production, compare hashes
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int userId = Convert.ToInt32(row["UserID"]);
                bool isAdmin = Convert.ToBoolean(row["IsAdmin"]);

                // Store user information in session
                Session["UserID"] = userId;
                Session["Username"] = username;
                Session["IsAdmin"] = isAdmin;

                // Redirect based on user type
                if (isAdmin)
                {
                    Response.Redirect("~/Admin/Products.aspx");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}