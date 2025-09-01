using System;
using System.Data;
using System.Data.SqlClient;

namespace ec
{
    public partial class Products : System.Web.UI.Page
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
                LoadProducts();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Products (PName, Price, Qty, Category, ImagePath) VALUES (@PName, @Price, @Qty, @Category, @ImagePath)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PName", txtPName.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@ImagePath", txtImagePath.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            lblMessage.Text = "Product added successfully!";
            ClearFields();
            LoadProducts();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                lblMessage.Text = "Product ID is required for update.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "UPDATE Products SET PName=@PName, Price=@Price, Qty=@Qty, Category=@Category, ImagePath=@ImagePath WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", txtProductID.Text);
                cmd.Parameters.AddWithValue("@PName", txtPName.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@ImagePath", txtImagePath.Text);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = result > 0 ? "Product updated." : "No product found with this ID.";
            }

            ClearFields();
            LoadProducts();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                lblMessage.Text = "Product ID is required for deletion.";
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "DELETE FROM Products WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", txtProductID.Text);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = result > 0 ? "Product deleted." : "No product found with this ID.";
            }

            ClearFields();
            LoadProducts();
        }

        protected void btnCount_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetProductSummary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int totalProducts = reader["TotalProducts"] != DBNull.Value ? Convert.ToInt32(reader["TotalProducts"]) : 0;
                    int totalQty = reader["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(reader["TotalQuantity"]) : 0;
                    lblCount.Text = $"Total Products: {totalProducts}, Total Quantity in Stock: {totalQty}";
                }
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }

        private void ClearFields()
        {
            txtProductID.Text = "";
            txtPName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtCategory.Text = "";
            txtImagePath.Text = "";
        }
    }
}
