using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.ClientesQueries.ObterClientePorId;

public sealed record ObterClientePorIdQuery(Guid Id)
    : IRequest<ClienteResponseDto?>;