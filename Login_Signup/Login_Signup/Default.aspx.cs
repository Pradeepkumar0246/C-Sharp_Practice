using System;
using System.Data;
using System.Data.SqlClient;

namespace ec
{
    public partial class _Default : System.Web.UI.Page
    {
        string conStr = @"Server=DESKTOP-BE5N6B8;Database=ec;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mailid"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUser.Text = Session["firstname"]?.ToString();
                BindProducts();
            }
        }

        private void BindProducts(string keyword = "")
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT PName, Price, Qty, Category, ImagePath FROM Products";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " WHERE PName LIKE @kw OR Category LIKE @kw";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Add a new column for resolved image path
                    if (!dt.Columns.Contains("ResolvedImageUrl"))
                        dt.Columns.Add("ResolvedImageUrl", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        string rawPath = row["ImagePath"]?.ToString();
                        string resolvedPath = ResolveImagePath(rawPath);
                        row["ResolvedImageUrl"] = resolvedPath;
                    }

                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
        }

        private string ResolveImagePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return ResolveClientUrl("~/Images/placeholder.jpg");

            if (path.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                return path;

            string virtualPath = "~/" + path.TrimStart('/').Replace("\\", "/");
            string physicalPath = Server.MapPath(virtualPath);

            if (!System.IO.File.Exists(physicalPath))
                return ResolveClientUrl("~/Images/placeholder.jpg");

            return ResolveClientUrl(virtualPath);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            BindProducts(keyword);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
