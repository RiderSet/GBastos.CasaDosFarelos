using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Cliente.PJ
{
    public interface IClienteReadPJRepository : IClienteReadRepository
    {
        Task<ClientePJ?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
