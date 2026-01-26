using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Clientes
{
    public class AtualizarClienteHandler : IRequestHandler<AtualizarClienteCommand, Unit>
    {
        private readonly IClienteWriteRepository _repository;

        public AtualizarClienteHandler(IClienteWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            Pessoa cliente;

            if (request.Tipo == "PF")
            {
                cliente = new ClientePF
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Email = request.Email,
                    Documento = request.Documento,
                    CPF = request.CPF ?? string.Empty
                };
            }
            else if (request.Tipo == "PJ")
            {
                cliente = new ClientePJ
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Email = request.Email,
                    Documento = request.Documento,
                    CNPJ = request.CNPJ ?? string.Empty
                };
            }
            else
            {
                throw new InvalidOperationException("Tipo de cliente inválido. Deve ser 'PF' ou 'PJ'.");
            }

            await _repository.AtualizarClienteAsync(cliente, cancellationToken);

            return Unit.Value;
        }
    }
}