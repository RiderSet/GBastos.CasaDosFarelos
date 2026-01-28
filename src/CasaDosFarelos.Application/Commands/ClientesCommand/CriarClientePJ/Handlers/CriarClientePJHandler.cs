using CasaDosFarelos.Application.Commands.ClientesCommand.CriarClientePJ;
using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using CasaDosFarelos.Domain.Entities;
using MediatR;

public class CriarClientePJHandler
    : IRequestHandler<CriarClientePJCommand, Guid>
{
    private readonly IClienteWritePJRepository _repository;

    public CriarClientePJHandler(IClienteWritePJRepository repository)
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

        return _repository.AddAsync(cliente, cancellationToken);
    }
}