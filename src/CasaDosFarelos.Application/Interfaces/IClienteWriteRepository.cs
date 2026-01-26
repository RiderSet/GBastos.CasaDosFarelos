using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces
{
    public interface IClienteWriteRepository
    {
        Task<Guid> CriarClientePFAsync(ClientePF cliente, CancellationToken cancellationToken);
        Task<Guid> CriarClientePJAsync(ClientePJ cliente, CancellationToken cancellationToken);
        Task AtualizarClienteAsync(Pessoa cliente, CancellationToken cancellationToken);
        Task ExcluirClienteAsync(Guid id, CancellationToken cancellationToken);
    }
}