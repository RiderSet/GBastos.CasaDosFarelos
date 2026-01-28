using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Cliente
{
    public interface IClienteWritePFRepository
    {
        Task<Guid> AddAsync(ClientePF cliente, CancellationToken cancellationToken);
        Task UpdateAsync(ClientePF cliente, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    }
}
