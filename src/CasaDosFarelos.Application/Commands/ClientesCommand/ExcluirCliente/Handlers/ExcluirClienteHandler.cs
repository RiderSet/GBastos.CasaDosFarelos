using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes.Handlers
{
    public class ExcluirClienteHandler : IRequestHandler<ExcluirClienteCommand, Unit>
    {
        private readonly IClienteWritePJRepository _repository;

        public ExcluirClienteHandler(IClienteWritePJRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}