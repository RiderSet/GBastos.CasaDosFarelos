using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Produtos.Handlers;

public sealed class ObterProdutoHandler
    : IRequestHandler<ObterProdutoQuery, ProdutoDto?>
{
    public async Task<ProdutoDto?> Handle(
        ObterProdutoQuery request,
        CancellationToken ct)
    {
        await Task.Delay(10);

        return new ProdutoDto
        {
            Id = request.Id,
            Nome = "Farinha",
            Preco = 10
        };
    }
}