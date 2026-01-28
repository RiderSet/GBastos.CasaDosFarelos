using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Fornecedores.ObterFornecedorPorId;

public class ObterFornecedorPorIdHandler
    : IRequestHandler<ObterFornecedorPorIdQuery, Fornecedor?>
{
    private readonly IFornecedorReadRepository _repository;

    public ObterFornecedorPorIdHandler(IFornecedorReadRepository repository)
    {
        _repository = repository;
    }

    public Task<Fornecedor?> Handle(
        ObterFornecedorPorIdQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}