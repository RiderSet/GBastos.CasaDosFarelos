using MediatR;
using CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Application.Queries.Fornecedores.ObterFornecedorPorId;

public sealed class ObterFornecedorPorIdQuery : IRequest<Fornecedor?>
{
    public Guid Id { get; }

    public ObterFornecedorPorIdQuery(Guid id)
    {
        Id = id;
    }
}