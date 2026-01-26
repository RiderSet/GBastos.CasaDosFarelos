using System.Data;

namespace CasaDosFarelos.Infrastructure.Persistence.Interfaces
{
    public interface IDapperReadRepository
    {
        IDbConnection GetConnection();
    }
}
