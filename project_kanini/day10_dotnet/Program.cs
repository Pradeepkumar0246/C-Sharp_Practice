using Microsoft.Data.SqlClient;
using System.Transactions;
internal class Program
{
    static SqlCommand cmd;
    static SqlConnection conn;
    private static void Main(string[] args)
    {
        insertData();
    }
    static void getconnection()
    {
        conn = new SqlConnection(
            "Server=DESKTOP-BE5N6B8; Database=KANINI; Integrated Security=true; TrustServerCertificate=true;");
        conn.Open();
    }
    static void insertData()
    {
        getconnection();
        Console.WriteLine("Enter the total number of values :");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter the {i+1} value for ID , Name");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("INSERT INTO product (pro_id,pro_name) VALUES (@pro_id, @pro_name)", conn);
            cmd.Parameters.AddWithValue("@pro_id", id);
            cmd.Parameters.AddWithValue("@pro_name", name);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Data Inserted Successfully");
        conn.Close();
    }
}