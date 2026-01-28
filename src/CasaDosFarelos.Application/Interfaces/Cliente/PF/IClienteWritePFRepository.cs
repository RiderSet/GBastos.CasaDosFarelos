using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Cliente
{
    public interface IClienteWritePFRepository
    {
        Task AddAsync(ClientePF cliente, CancellationToken ct);
        Task UpdateAsync(ClientePF cliente, CancellationToken ct);
        Task DeleteAsync(ClientePF cliente, CancellationToken ct);
    }
}
