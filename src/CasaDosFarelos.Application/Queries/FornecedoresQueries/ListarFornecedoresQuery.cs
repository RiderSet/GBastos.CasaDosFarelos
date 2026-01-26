using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.FornecedoresQueries
{
    public class ListarFornecedoresQuery : IRequest<List<FornecedorResponseDto>> { }
}