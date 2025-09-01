using System.Data;
using System.Data.SqlClient;
using Assessment01.Models;

namespace Assessment01.Repositories
{
    internal class PiRepository
    {

        private readonly string _connectionString;

        public PiRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void InsertPi(pi pi)
        {
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("InsertPi");
                command.Parameters.AddWithValue("@piId", pi.piId);
                command.Parameters.AddWithValue("@piName", pi.piName);
                command.Parameters.AddWithValue("@piQuantity", pi.piQuantity);
                command.Parameters.AddWithValue("@piprice", pi.piprice);
                command.ExecuteNonQuery();
            }
        }
        public void UpdatePi(pi pi)
        {
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("UpdatePi");
                command.Parameters.AddWithValue("@piId", pi.piId);
                command.Parameters.AddWithValue("@piName", pi.piName);
                command.Parameters.AddWithValue("@piQuantity", pi.piQuantity);
                command.Parameters.AddWithValue("@piprice", pi.piprice);
                command.ExecuteNonQuery();
            }
        }
        public void DeletePi(int piId)
        {
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("DeletePi");
                command.Parameters.AddWithValue("@piId", piId);
                command.ExecuteNonQuery();
            }
        }
        public List<pi> GetAllPi()
        {
            var piList = new List<pi>();
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("GetAllPi");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pi = new pi
                        {
                            piId = reader.GetInt32(0),
                            piName = reader.GetString(1),
                            piQuantity = reader.GetInt32(2),
                            piprice = reader.GetDecimal(3)
                        };
                        piList.Add(pi);
                    }
                }
            }
            return piList;
        }
        public pi GetPiById(int piId)
        {
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("GetPiById");
                command.Parameters.AddWithValue("@piId", piId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new pi
                        {
                            piId = reader.GetInt32(0),
                            piName = reader.GetString(1),
                            piQuantity = reader.GetInt32(2),
                            piprice = reader.GetDecimal(3)
                        };
                    }
                }
            }
            return null;
        }
        public int Countpi()
        {
            using (var context = new Data.Dbcontext(_connectionString))
            {
                var command = context.CreateCommand("CountPi");
                return (int)command.ExecuteScalar();
            }
        }
    }
}