using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

public class CriarClientePFHandler
    : IRequestHandler<CriarClientePFCommand, Guid>
{
    private readonly IClienteWriteRepository _repository;

    public CriarClientePFHandler(IClienteWriteRepository repository)
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

        return _repository.AdicionarAsync(cliente, cancellationToken);
    }
}