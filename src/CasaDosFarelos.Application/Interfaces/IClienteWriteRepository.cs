using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces
{
    public interface IClienteWriteRepository
    {
        Task<Guid> AdicionarAsync(Pessoa cliente, CancellationToken cancellationToken);
        Task AtualizarAsync(Pessoa cliente, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid id, CancellationToken cancellationToken);

        Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    }
}