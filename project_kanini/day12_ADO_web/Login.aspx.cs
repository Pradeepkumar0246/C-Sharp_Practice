using EcommWebApp.DataAccess;
using System;

namespace EcommWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                UserDataAccess userDataAccess = new UserDataAccess();
                bool isValidUser = userDataAccess.VerifyUser(username, password);

                if (isValidUser)
                {
                    // Create session
                    Session["Username"] = username;

                    // Remember me cookie
                    if (chkRememberMe.Checked)
                    {
                        Response.Cookies["Username"].Value = username;
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                    }

                    // Redirect to home page or dashboard
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}