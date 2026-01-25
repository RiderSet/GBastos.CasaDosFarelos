using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Produtos.Handlers;

public sealed class ListarProdutosHandler
    : IRequestHandler<ListarProdutosQuery, IEnumerable<ProdutoDto>>
{
    public async Task<IEnumerable<ProdutoDto>> Handle(
        ListarProdutosQuery request,
        CancellationToken ct)
    {
        await Task.Delay(10);

        return new[]
        {
            new ProdutoDto { Id = Guid.NewGuid(), Nome = "Farinha", Preco = 10 },
            new ProdutoDto { Id = Guid.NewGuid(), Nome = "Farelo", Preco = 8 }
        };
    }
}