using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ecommerce
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["pid"] != null)
                {
                    LoadProductDetails(Request.QueryString["pid"]);
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private void LoadProductDetails(string productId)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM Products WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = reader["Name"].ToString();
                    lblPrice.Text = reader["Price"].ToString();
                    lblDescription.Text = reader["Description"].ToString();
                    imgProduct.ImageUrl = reader["ImageUrl"].ToString();
                }
                else
                {
                    lblMessage.Text = "Product not found.";
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string productId = Request.QueryString["pid"];
            string quantity = txtQuantity.Text.Trim();

            if (Session["cart"] == null)
            {
                DataTable cart = new DataTable();
                cart.Columns.Add("ProductId");
                cart.Columns.Add("ProductName");
                cart.Columns.Add("Price");
                cart.Columns.Add("Quantity");

                AddRowToCart(cart, productId, quantity);
                Session["cart"] = cart;
            }
            else
            {
                DataTable cart = (DataTable)Session["cart"];
                AddRowToCart(cart, productId, quantity);
                Session["cart"] = cart;
            }

            lblMessage.Text = "Product added to cart!";
        }

        private void AddRowToCart(DataTable cart, string productId, string quantity)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string query = "SELECT Name, Price FROM Products WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DataRow row = cart.NewRow();
                    row["ProductId"] = productId;
                    row["ProductName"] = reader["Name"].ToString();
                    row["Price"] = reader["Price"].ToString();
                    row["Quantity"] = quantity;
                    cart.Rows.Add(row);
                }
            }
        }
    }
}
