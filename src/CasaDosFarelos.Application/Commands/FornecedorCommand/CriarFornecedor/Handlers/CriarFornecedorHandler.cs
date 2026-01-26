using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Commands.FornecedorCommand.CriarFornecedor.Handlers
{
    public class CriarFornecedorHandler : IRequestHandler<CriarFornecedorCommand, Guid>
    {
        private readonly IFornecedorWriteRepository _repository;

        public CriarFornecedorHandler(IFornecedorWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = new Fornecedor(
                request.Nome,
                request.Email,
                request.Documento,
                new List<Produto>() // Você pode preencher com IDs reais se desejar
            );

            return await _repository.CriarFornecedorAsync(fornecedor, cancellationToken);
        }
    }
}