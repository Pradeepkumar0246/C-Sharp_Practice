// File: DbHelper.cs
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public static class DbHelper
{
    private static readonly string connStr = "Server=DESKTOP-BE5N6B8; Database=ecomm; Integrated Security=true; TrustServerCertificate=true;";

    public static SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        return conn;
    }

    public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteNonQuery();
        }
    }

    public static object ExecuteScalar(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteScalar();
        }
    }

    public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
