using CasaDosFarelos.Infrastructure.Persistence.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CasaDosFarelos.Infrastructure.Persistence.Read
{
    public class DapperReadRepository : IDapperReadRepository
    {
        private readonly string _connectionString;

        public DapperReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConn");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}