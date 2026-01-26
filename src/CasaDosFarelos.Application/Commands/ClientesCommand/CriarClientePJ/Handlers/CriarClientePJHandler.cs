using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes
{
    public class CriarClientePJHandler : IRequestHandler<CriarClientePJCommand, Guid>
    {
        private readonly IClienteWriteRepository _repository;

        public CriarClientePJHandler(IClienteWriteRepository repository)
        {
            _repository = repository;
        }

        public Task<Guid> Handle(CriarClientePJCommand request, CancellationToken cancellationToken)
        {
            var cliente = new ClientePJ
            {
                Nome = request.Nome,
                Email = request.Email,
                Documento = request.Documento,
                CNPJ = request.CNPJ
            };

            return _repository.CriarClientePJAsync(cliente, cancellationToken);
        }
    }
}
