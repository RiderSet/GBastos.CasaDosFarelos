using CasaDosFarelos.Application.Interfaces.Fornecedores;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Fornecedores.ObterFornecedorPorId;

public class ObterFornecedorPorIdHandler
    : IRequestHandler<ObterFornecedorPorIdQuery, FornecedorResponseDto?>
{
    private readonly IFornecedorReadRepository _repository;

    public ObterFornecedorPorIdHandler(IFornecedorReadRepository repository)
    {
        _repository = repository;
    }

    public Task<FornecedorResponseDto?> Handle(
        ObterFornecedorPorIdQuery request,
        CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}