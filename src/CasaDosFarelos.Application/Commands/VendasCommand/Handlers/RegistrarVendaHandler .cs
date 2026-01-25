using CasaDosFarelos.Domain.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Vendas.Handlers;

public sealed class RegistrarVendaHandler
    : IRequestHandler<RegistrarVendaCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarVendaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        RegistrarVendaCommand request,
        CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}