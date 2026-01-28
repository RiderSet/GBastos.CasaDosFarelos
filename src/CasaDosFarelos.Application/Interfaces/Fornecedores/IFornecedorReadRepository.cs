using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Fornecedores;

public interface IFornecedorReadRepository
{
    Task<List<Fornecedor>> GetAllAsync(CancellationToken cancellationToken);
    Task<Fornecedor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}