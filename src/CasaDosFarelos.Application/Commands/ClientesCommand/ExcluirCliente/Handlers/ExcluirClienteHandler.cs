using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes.Handlers
{
    public class ExcluirClienteHandler : IRequestHandler<ExcluirClienteCommand, Unit>
    {
        private readonly IClienteReadPJRepository _repositoryRead;
        private readonly IClienteWritePJRepository _repositoryWrite;

        public ExcluirClienteHandler(IClienteWritePJRepository repositoryW, IClienteReadPJRepository repositoryR)
        {
            _repositoryWrite = repositoryW;
            _repositoryRead = repositoryR;
        }

        public async Task<Unit> Handle(ExcluirClienteCommand request, CancellationToken ct)
        {
            var clienteDto = await _repositoryRead.GetByIdAsync(request.Id, ct)
                ?? throw new KeyNotFoundException("Cliente PF não encontrado");

            await _repositoryWrite.RemoveAsync(clienteDto, ct);
            return Unit.Value;
        }
    }
}