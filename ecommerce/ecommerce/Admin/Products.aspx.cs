using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace ecommerce.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        string conStr = @"Server=DESKTOP-BE5N6B8;Database=ecomm;Integrated Security=True;TrustServerCertificate=True";
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mailid"] == null || Session["mailid"].ToString() != "admin@gmail.com")
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
            }
        }

        void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Categories", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataBind();
            }
        }

        void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Products (Name, Description, Price, ImageUrl, CategoryId) VALUES (@Name, @Desc, @Price, @Image, @Cat)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Image", txtImage.Text);
                cmd.Parameters.AddWithValue("@Cat", ddlCategory.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            lblMessage.Text = "Product added!";
            txtName.Text = txtDesc.Text = txtPrice.Text = txtImage.Text = "";
            LoadProducts();
        }
    }
}
