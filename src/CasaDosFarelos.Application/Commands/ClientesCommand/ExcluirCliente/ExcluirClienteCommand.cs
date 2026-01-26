using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes
{
    public record ExcluirClienteCommand(Guid Id) : IRequest<Unit>;
}