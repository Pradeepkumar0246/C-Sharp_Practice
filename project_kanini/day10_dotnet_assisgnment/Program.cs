using Microsoft.Data.SqlClient;
using System;
class Program
{
    static string connectionString = @"Server=DESKTOP-BE5N6B8;Database=CompanyDB;Integrated Security=true;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Management ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Search Employee by Name");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1: AddEmployee(); break;
                case 2: ViewEmployees(); break;
                case 3: UpdateEmployee(); break;
                case 4: DeleteEmployee(); break;
                case 5: SearchEmployee(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice!"); break;
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Department: ");
        string department = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Salary: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
        {
            Console.WriteLine("Invalid salary input.");
            return;
        }

        using SqlConnection con = new SqlConnection(connectionString);
        string query = "INSERT INTO Employee (Name, Department, Email, Salary) VALUES (@Name, @Department, @Email, @Salary)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Department", department);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Salary", salary);

        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Employee added successfully!");
    }

    static void ViewEmployees()
    {
        using SqlConnection con = new SqlConnection(connectionString);
        string query = "SELECT * FROM Employee";
        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n-- Employee List --");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["Name"]}, Department: {reader["Department"]}, Email: {reader["Email"]}, Salary: {reader["Salary"]}");
        }
    }

    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to Update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID input.");
            return;
        }

        Console.Write("Enter New Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter New Department: ");
        string department = Console.ReadLine();

        Console.Write("Enter New Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter New Salary: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
        {
            Console.WriteLine("Invalid salary input.");
            return;
        }

        using SqlConnection con = new SqlConnection(connectionString);
        string query = "UPDATE Employee SET Name=@Name, Department=@Department, Email=@Email, Salary=@Salary WHERE EmployeeID=@ID";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Department", department);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Salary", salary);

        con.Open();
        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "Employee updated successfully!" : "Employee not found.");
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to Delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID input.");
            return;
        }

        using SqlConnection con = new SqlConnection(connectionString);
        string query = "DELETE FROM Employee WHERE EmployeeID=@ID";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@ID", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine(rows > 0 ? "Employee deleted successfully!" : "Employee not found.");
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Name to Search: ");
        string name = Console.ReadLine();

        using SqlConnection con = new SqlConnection(connectionString);
        string query = "SELECT * FROM Employee WHERE Name LIKE @Name";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\n-- Search Results --");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["Name"]}, Department: {reader["Department"]}, Email: {reader["Email"]}, Salary: {reader["Salary"]}");
        }
    }
}
