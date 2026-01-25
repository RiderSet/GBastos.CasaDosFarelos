using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Produtos;

public sealed record ListarProdutosQuery
    : IRequest<IEnumerable<ProdutoDto>>;