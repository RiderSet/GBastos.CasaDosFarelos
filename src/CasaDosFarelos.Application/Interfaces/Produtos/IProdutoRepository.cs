using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Produtos;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterPorIdsAsync(IEnumerable<Guid> ProdutosIds, CancellationToken ct);
    Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(Produto produto, CancellationToken ct);
    Task UpdateAsync(Produto produto, CancellationToken ct);
    Task<List<Produto>> GetAllAsync(CancellationToken ct);
}