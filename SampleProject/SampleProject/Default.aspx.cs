using ECommerceWebApp.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace ECommerceWebApp
{
    public partial class _Default : System.Web.UI.Page
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
            string query = "SELECT ProductID, Name, Description, Price, ImageURL FROM Products WHERE IsActive = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            rptProducts.DataSource = dt;
            rptProducts.DataBind();
        }

        protected void rptProducts_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }

                int productId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(Session["UserID"]);

                // Check if product already in cart
                string checkQuery = "SELECT COUNT(*) FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID";
                SqlParameter[] checkParams = {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@ProductID", productId)
                };

                int itemCount = Convert.ToInt32(DatabaseHelper.ExecuteQuery(checkQuery, checkParams).Rows[0][0]);

                if (itemCount > 0)
                {
                    // Update quantity
                    string updateQuery = "UPDATE Cart SET Quantity = Quantity + 1 WHERE UserID = @UserID AND ProductID = @ProductID";
                    DatabaseHelper.ExecuteNonQuery(updateQuery, checkParams);
                }
                else
                {
                    // Add new item
                    string insertQuery = "INSERT INTO Cart (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, 1)";
                    DatabaseHelper.ExecuteNonQuery(insertQuery, checkParams);
                }

                // Show success message
                ScriptManager.RegisterStartupScript(this, GetType(), "showToast", "alert('Product added to cart!');", true);
            }
        }
    }
}