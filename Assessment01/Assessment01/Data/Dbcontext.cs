using System;
using System.Data;
using System.Data.SqlClient;

namespace Assessment01.Data
{
    internal class Dbcontext : IDisposable
    {
        
        private readonly string _connectionString;        
        private SqlConnection _connection;

        public Dbcontext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                return _connection;
            }
        }

        public SqlCommand CreateCommand(string storedProcedureName)
        {
            var command = new SqlCommand(storedProcedureName, Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            return command;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}