using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces;
using MediatR;

namespace CasaDosFarelos.Application.Queries.FornecedoresQueries.Handlers;

    public class ListarFornecedoresHandler
    : IRequestHandler<ListarFornecedoresQuery, List<FornecedorResponseDto>>
{
    private readonly IFornecedorReadRepository _repository;

    public ListarFornecedoresHandler(IFornecedorReadRepository repository)
    {
        _repository = repository;
    }

    public Task<List<FornecedorResponseDto>> Handle(
        ListarFornecedoresQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.ListarAsync(cancellationToken);
    }
}