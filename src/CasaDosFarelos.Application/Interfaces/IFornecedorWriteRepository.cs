using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces
{
    public interface IFornecedorWriteRepository
    {
        Task<Guid> CriarFornecedorAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task AtualizarFornecedorAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task ExcluirFornecedorAsync(Guid id, CancellationToken cancellationToken);
    }
}