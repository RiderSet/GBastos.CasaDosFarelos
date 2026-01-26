using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Fornecedores.ObterFornecedorPorId;

public record ObterFornecedorPorIdQuery(Guid Id)
    : IRequest<FornecedorResponseDto?>;