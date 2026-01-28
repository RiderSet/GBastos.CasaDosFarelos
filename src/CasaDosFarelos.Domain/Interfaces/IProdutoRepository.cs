using CasaDosFarelos.Domain.Entities;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterPorIdsAsync(
        IEnumerable<Guid> ids,
        CancellationToken ct);
}