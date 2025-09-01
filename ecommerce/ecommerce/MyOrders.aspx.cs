// File: MyOrders.aspx.cs
using ecommerce;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.GridView gvOrders;
    }

    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadOrders();
        }

        private void LoadOrders()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string query = "SELECT * FROM Orders WHERE UserId = @UserId ORDER BY OrderDate DESC";
            SqlParameter[] param = { new SqlParameter("@UserId", userId) };

            DataTable dt = DbHelper.ExecuteQuery(query, param);
            gvOrders.DataSource = dt;
            gvOrders.DataBind();
        }
    }
}