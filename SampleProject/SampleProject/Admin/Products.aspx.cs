using ECommerceWebApp.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ECommerceWebApp.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
                {
                    Response.Redirect("~/Account/Login.aspx");
                    return;
                }
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            string query = "SELECT * FROM Products";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvProducts.DataSource = dt;
            gvProducts.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void gvProducts_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
            LoadProducts();
        }

        protected void gvProducts_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProducts.EditIndex = -1;
            LoadProducts();
        }

        protected void gvProducts_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);

            string name = ((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtName")).Text;
            string description = ((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtDescription")).Text;
            decimal price = Convert.ToDecimal(((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtPrice")).Text);
            int stock = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtStock")).Text);
            string imageUrl = ((System.Web.UI.WebControls.TextBox)gvProducts.Rows[e.RowIndex].FindControl("txtImage")).Text;

            string query = @"UPDATE Products SET 
                            Name = @Name, 
                            Description = @Description, 
                            Price = @Price, 
                            StockQuantity = @StockQuantity, 
                            ImageURL = @ImageURL 
                            WHERE ProductID = @ProductID";

            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@StockQuantity", stock),
                new SqlParameter("@ImageURL", imageUrl),
                new SqlParameter("@ProductID", productId)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);

            gvProducts.EditIndex = -1;
            LoadProducts();
        }

        protected void gvProducts_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);

            // Soft delete (set IsActive to false)
            string query = "UPDATE Products SET IsActive = 0 WHERE ProductID = @ProductID";
            SqlParameter[] parameters = { new SqlParameter("@ProductID", productId) };
            DatabaseHelper.ExecuteNonQuery(query, parameters);

            LoadProducts();
        }
    }
}