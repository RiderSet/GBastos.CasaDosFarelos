using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Interfaces.Produtos;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterPorIdsAsync(
        IEnumerable<Guid> ProdutosIds,
        CancellationToken ct);
}