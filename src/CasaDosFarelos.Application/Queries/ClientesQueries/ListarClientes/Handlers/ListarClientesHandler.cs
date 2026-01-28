using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using MediatR;

public class ListarClientesHandler : IRequestHandler<ListarClientesQuery, List<ClienteResponseDto>>
{
    private readonly IClienteReadPFRepository _repository;

    public ListarClientesHandler(IClienteReadPFRepository repository)
    {
        _repository = repository;
    }

    public Task<List<ClienteResponseDto>> Handle(
        ListarClientesQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}