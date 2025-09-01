using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptProducts.DataSource = dt;
            rptProducts.DataBind();
        }

    }
}