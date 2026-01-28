using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using MediatR;

namespace CasaDosFarelos.Application.Queries.ClientesQueries.ObterClientePorId.Handlers;

public sealed class ObterClientePorIdHandler
    : IRequestHandler<ObterClientePorIdQuery, ClienteResponseDto?>
{
    private readonly IClienteReadPFRepository _repository;

    public ObterClientePorIdHandler(IClienteReadPFRepository repository)
        => _repository = repository;

    public async Task<ClienteResponseDto?> Handle(
        ObterClientePorIdQuery request,
        CancellationToken ct)
    {
        return await _repository.GetByIdAsync(request.Id, ct);
    }
}