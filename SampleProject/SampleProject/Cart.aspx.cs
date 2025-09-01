using ECommerceWebApp.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerceWebApp
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            string query = @"SELECT c.ProductID, p.Name, p.Price, c.Quantity, (p.Price * c.Quantity) AS Subtotal
                            FROM Cart c
                            INNER JOIN Products p ON c.ProductID = p.ProductID
                            WHERE c.UserID = @UserID";

            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            gvCart.DataSource = dt;
            gvCart.DataBind();

            CalculateTotal(dt);
        }

        private void CalculateTotal(DataTable dt)
        {
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            lblTotal.Text = total.ToString("C");
        }

        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            int productId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "RemoveItem")
            {
                string query = "DELETE FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID";
                SqlParameter[] parameters = {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@ProductID", productId)
                };
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }
            else if (e.CommandName == "UpdateItem")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                int quantity = Convert.ToInt32(txtQuantity.Text);

                string query = "UPDATE Cart SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID";
                SqlParameter[] parameters = {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@ProductID", productId),
                    new SqlParameter("@Quantity", quantity)
                };
                DatabaseHelper.ExecuteNonQuery(query, parameters);
            }

            LoadCartItems();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            // Clear the cart
            string query = "DELETE FROM Cart WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            DatabaseHelper.ExecuteNonQuery(query, parameters);

            // Show success message
            ScriptManager.RegisterStartupScript(this, GetType(), "showToast",
                "alert('Your order has been placed successfully!'); window.location='Default.aspx';", true);
        }
    }
}