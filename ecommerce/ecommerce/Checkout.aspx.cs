using System;
using System.Data;

namespace ecommerce
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            if (Session["cart"] != null)
            {
                DataTable cartTable = (DataTable)Session["cart"];
                gvCart.DataSource = cartTable;
                gvCart.DataBind();

                decimal total = 0;
                foreach (DataRow row in cartTable.Rows)
                {
                    total += Convert.ToDecimal(row["Total"]);
                }

                lblTotal.Text = total.ToString("0.00");
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // TODO: Save order to DB here
            Session["cart"] = null;
            lblMessage.Text = "Order placed successfully!";
            gvCart.DataSource = null;
            gvCart.DataBind();
            lblTotal.Text = "0.00";
        }
    }
}
