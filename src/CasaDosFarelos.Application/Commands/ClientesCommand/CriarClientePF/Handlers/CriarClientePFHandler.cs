using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

public class CriarClientePFHandler : IRequestHandler<CriarClientePFCommand, Guid>
{
    private readonly IClienteWriteRepository _repository;
    public CriarClientePFHandler(IClienteWriteRepository repository) => _repository = repository;

    public Task<Guid> Handle(CriarClientePFCommand request, CancellationToken cancellationToken)
        => _repository.CriarClientePFAsync(new ClientePF
        {
            Nome = request.Nome,
            Email = request.Email,
            Documento = request.Documento,
            CPF = request.CPF
        }, cancellationToken);
}