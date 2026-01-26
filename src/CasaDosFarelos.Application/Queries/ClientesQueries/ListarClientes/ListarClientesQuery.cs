using CasaDosFarelos.Application.DTOs;
using MediatR;

public record ListarClientesQuery : IRequest<List<ClienteResponseDto>>;