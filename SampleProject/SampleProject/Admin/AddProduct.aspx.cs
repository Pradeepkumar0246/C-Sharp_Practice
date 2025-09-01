using System;
using System.Data.SqlClient;
using ECommerceWebApp.Utilities;

namespace ECommerceWebApp.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            string imageUrl = txtImage.Text.Trim();
            bool isActive = chkActive.Checked;

            string query = @"INSERT INTO Products 
                            (Name, Description, Price, StockQuantity, ImageURL, IsActive) 
                            VALUES 
                            (@Name, @Description, @Price, @StockQuantity, @ImageURL, @IsActive)";

            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@Price", price),
                new SqlParameter("@StockQuantity", stock),
                new SqlParameter("@ImageURL", imageUrl),
                new SqlParameter("@IsActive", isActive)
            };

            try
            {
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Product added successfully!";
                    Response.Redirect("Products.aspx");
                }
                else
                {
                    lblMessage.Text = "Failed to add product.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}