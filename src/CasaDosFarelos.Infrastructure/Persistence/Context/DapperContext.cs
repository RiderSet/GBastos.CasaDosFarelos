using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CasaDosFarelos.Infrastructure.Persistence.Context
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConn");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
