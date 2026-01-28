using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Cliente.PJ
{
    public interface IClienteWritePJRepository
    {
        Task AddAsync(ClientePJ cliente, CancellationToken ct);
        Task UpdateAsync(ClientePJ cliente, CancellationToken ct);
        Task RemoveAsync(ClientePJ cliente, CancellationToken ct);
    }
}
