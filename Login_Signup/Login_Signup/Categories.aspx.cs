using System;
using System.Data;
using System.Data.SqlClient;

namespace ec
{
    public partial class Categories : System.Web.UI.Page
    {
        string conStr = @"Server=DESKTOP-BE5N6B8;Database=ec;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mailid"] == null || Session["mailid"].ToString() != "admin@gmail.com")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMessage.Text = "Both ID and Category Name are required.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_AddCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCategoryID.Text));
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            lblMessage.Text = "Category added successfully!";
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            LoadCategories();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text) || string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMessage.Text = "Both ID and Name required for update.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCategoryID.Text));
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = rowsAffected > 0 ? "Category updated." : "No category found with this ID.";
            }

            LoadCategories();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                lblMessage.Text = "Category ID is required for deletion.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCategoryID.Text));
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = rowsAffected > 0 ? "Category deleted." : "No category found with this ID.";
            }

            LoadCategories();
        }

        private void LoadCategories()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetCategories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCategories.DataSource = dt;
                gvCategories.DataBind();
            }
        }
    }
}
