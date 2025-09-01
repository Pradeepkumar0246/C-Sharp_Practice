using System;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        string conStr = @"Server=DESKTOP-BE5N6B8;Database=ecomm;Integrated Security=True;TrustServerCertificate=True";
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadOrders();
        }

        void LoadOrders()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvOrders.DataSource = dt;
                gvOrders.DataBind();
            }
        }
    }
}
