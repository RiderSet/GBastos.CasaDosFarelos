using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Cliente.PJ
{
    public interface IClienteWritePJRepository
    {
        Task<Guid> AddAsync(ClientePJ cliente, CancellationToken cancellationToken);
        Task UpdateAsync(ClientePJ cliente, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    }
}
