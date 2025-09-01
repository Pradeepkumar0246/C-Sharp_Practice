using EcommWebApp.DataAccess;
using System;

namespace EcommWebApp
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                UserDataAccess userDataAccess = new UserDataAccess();
                bool isRegistered = userDataAccess.RegisterUser(username, email, password);

                if (isRegistered)
                {
                    lblMessage.Text = "Registration successful! Please login.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    // Clear form
                    txtUsername.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    lblMessage.Text = "Registration failed. Username or email may already exist.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}