using CasaDosFarelos.Application.DTOs;
using MediatR;

namespace CasaDosFarelos.Application.Queries.Relatorios;

public sealed class RelatorioVendasQuery
    : IRequest<IEnumerable<RelatorioVendasDto>>
{
    public DateTime DataInicio { get; init; }
    public DateTime DataFim { get; init; }
}