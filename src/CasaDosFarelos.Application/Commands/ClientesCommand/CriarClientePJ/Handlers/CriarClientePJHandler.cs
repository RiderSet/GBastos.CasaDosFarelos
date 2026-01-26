using CasaDosFarelos.Application.Commands.Clientes;
using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

public class CriarClientePJHandler
    : IRequestHandler<CriarClientePJCommand, Guid>
{
    private readonly IClienteWriteRepository _repository;

    public CriarClientePJHandler(IClienteWriteRepository repository)
        => _repository = repository;

    public Task<Guid> Handle(
        CriarClientePJCommand request,
        CancellationToken cancellationToken)
    {
        var cliente = new ClientePJ(
            request.Nome,
            request.Email,
            request.Documento,
            request.CNPJ
        );

        return _repository.AdicionarAsync(cliente, cancellationToken);
    }
}