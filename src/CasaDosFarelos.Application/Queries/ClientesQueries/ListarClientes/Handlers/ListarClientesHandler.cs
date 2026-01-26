using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces;
using MediatR;

public class ListarClientesHandler : IRequestHandler<ListarClientesQuery, List<ClienteResponseDto>>
{
    private readonly IClienteReadRepository _repository;

    public ListarClientesHandler(IClienteReadRepository repository)
    {
        _repository = repository;
    }

    public Task<List<ClienteResponseDto>> Handle(
        ListarClientesQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.ListarClientesAsync(cancellationToken);
    }
}