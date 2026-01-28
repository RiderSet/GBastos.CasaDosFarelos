using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Fornecedores
{
    public interface IFornecedorWriteRepository
    {
        Task<Guid> AddAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task UpdateAsync(Fornecedor fornecedor, CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    }
}