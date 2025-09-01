using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ProductManagerApp
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=DESKTOP-BE5N6B8; Database=KANINI; Integrated Security=true; TrustServerCertificate=true;";
        public Form1()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            decimal price;
            int quantity;
            if (string.IsNullOrEmpty(name) ||
                !decimal.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter valid product details.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Product (ProductName, Price, Quantity) VALUES (@name, @price, @quantity)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product added successfully.");
            ClearInputs();
            LoadProducts();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadProducts();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Product WHERE ProductName LIKE @search";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE ProductID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product deleted.");
            LoadProducts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
            string name = txtName.Text.Trim();
            decimal price;
            int quantity;

            if (string.IsNullOrEmpty(name) ||
                !decimal.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Enter valid data.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product SET ProductName=@name, Price=@price, Quantity=@quantity WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product updated.");
            LoadProducts();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Product", conn);
                int count = (int)cmd.ExecuteScalar();
                MessageBox.Show("Total products: " + count);
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }
    }
}
