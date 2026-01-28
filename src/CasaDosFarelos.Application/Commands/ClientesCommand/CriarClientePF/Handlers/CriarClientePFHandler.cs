using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Commands.ClientesCommand.CriarClientePF.Handlers;

public class CriarClientePFHandler
    : IRequestHandler<CriarClientePFCommand, Guid>
{
    private readonly IClienteWritePFRepository _repository;

    public CriarClientePFHandler(IClienteWritePFRepository repository)
        => _repository = repository;

    public Task<Guid> Handle(
      CriarClientePFCommand request,
      CancellationToken cancellationToken)
    {
        var cliente = new ClientePF(
            request.Nome,
            request.Email,
            request.Documento,
            request.CPF
        );

        return _repository.AddAsync(cliente, cancellationToken);
    }
}