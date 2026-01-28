using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Queries.FornecedoresQueries.Handlers;

    public class ListarFornecedoresHandler
    : IRequestHandler<ListarFornecedoresQuery, List<Fornecedor>>
{
    private readonly IFornecedorReadRepository _repository;

    public ListarFornecedoresHandler(IFornecedorReadRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Fornecedor>> Handle(
        ListarFornecedoresQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}