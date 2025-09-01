using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce.Admin
{
    public partial class Categories : System.Web.UI.Page
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
                LoadCategories();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@Name", txtCategory.Text.Trim());

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

            //lblMessage.Text = "Category added!";
            //txtCategory.Text = "";
            //LoadCategories();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", con);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategory.Text.Trim());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lblMessage.Text = "Category added successfully!";
            txtCategory.Text = "";
        }

        void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCategories.DataSource = dt;
                gvCategories.DataBind();
            }
        }
    }
}
