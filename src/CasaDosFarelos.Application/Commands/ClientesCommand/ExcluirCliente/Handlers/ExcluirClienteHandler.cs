using CasaDosFarelos.Application.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes.Handlers
{
    public class ExcluirClienteHandler : IRequestHandler<ExcluirClienteCommand, Unit>
    {
        private readonly IClienteWriteRepository _repository;

        public ExcluirClienteHandler(IClienteWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
        {
            await _repository.ExcluirAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}