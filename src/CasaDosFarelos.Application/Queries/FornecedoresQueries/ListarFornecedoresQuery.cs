using CasaDosFarelos.Domain.Entities;
using MediatR;

namespace CasaDosFarelos.Application.Queries.FornecedoresQueries
{
    public sealed class ListarFornecedoresQuery : IRequest<List<Fornecedor>> { }
}