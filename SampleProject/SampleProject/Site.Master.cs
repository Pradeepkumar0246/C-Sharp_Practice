using System;
using System.Web.UI;

namespace SampleProject
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateNavigation();
            }
        }

        private void UpdateNavigation()
        {
            bool isLoggedIn = (Session["UserID"] != null);
            bool isAdmin = isLoggedIn && Convert.ToBoolean(Session["IsAdmin"]);

            loginLink.Visible = !isLoggedIn;
            signupLink.Visible = !isLoggedIn;
            logoutLink.Visible = isLoggedIn;
            adminLink.Visible = isAdmin;
            userGreeting.Visible = isLoggedIn;

            if (isLoggedIn)
            {
                litUsername.Text = Session["Username"].ToString();
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}