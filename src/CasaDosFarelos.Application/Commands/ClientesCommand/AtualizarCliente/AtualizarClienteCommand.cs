using MediatR;

namespace CasaDosFarelos.Application.Commands.ClientesCommand.AtualizarCliente
{
    public class AtualizarClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}