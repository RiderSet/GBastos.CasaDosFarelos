using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Domain.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Commands.Vendas.Handlers
{
    public class CriarVendaHandler : IRequestHandler<CriarVendaCommand, Guid>
    {
        private readonly IUnitOfWork _uow;


        public CriarVendaHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> Handle(
            CriarVendaCommand request,
            CancellationToken cancellationToken)
        {
            var itens = request.Itens.Select(i =>
                new VendaItem(
                    i.ProdutoId,
                    i.DescricaoProduto,
                    i.Quantidade,
                    i.PrecoUnitario
                )
            ).ToList();

            var venda = Venda.Criar(request.ClienteId, itens);

            await _uow.Vendas.AddAsync(venda);
            await _uow.CommitAsync();

            return venda.Id;
        }
    }
}
