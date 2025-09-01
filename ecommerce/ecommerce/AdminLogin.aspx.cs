// File: AdminLogin.aspx.cs
using System;
using System.Data;
using System.Data.SqlClient;
namespace ecommerce
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.TextBox txtEmail;
        protected global::System.Web.UI.WebControls.TextBox txtPassword;
        protected global::System.Web.UI.WebControls.Button btnLogin;
        protected global::System.Web.UI.WebControls.Label lblMessage;
    }

    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Admins WHERE Email = @Email AND Password = @Password";
            SqlParameter[] parameters = {
            new SqlParameter("@Email", txtEmail.Text),
            new SqlParameter("@Password", txtPassword.Text)
        };


            DataTable dt = DbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                Session["AdminName"] = dt.Rows[0]["Username"];
                Response.Redirect("Admin/Dashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid admin credentials.";
            }
        }
    }
}