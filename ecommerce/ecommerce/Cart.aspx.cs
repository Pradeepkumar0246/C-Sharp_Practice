using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mailid"] == null || Session["mailid"].ToString() == "admin@gmail.com")
            {
                Response.Redirect("Login.aspx");
                return;
            }
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
            else
            {
                lblMessage.Text = "Your cart is empty.";
            }
        }
    }
}
