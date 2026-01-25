using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Produtos;

public sealed record ObterProdutoQuery(Guid Id)
    : IRequest<ProdutoDto?>;