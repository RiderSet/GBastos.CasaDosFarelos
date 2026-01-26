using CasaDosFarelos.Application.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace CasaDosFarelos.Application.Queries.Relatorios.Handlers;

public class RelatorioVendasHandler
    : IRequestHandler<RelatorioVendasQuery, IEnumerable<RelatorioVendasDto>>
{
    private readonly IDbConnection _connection;

    public RelatorioVendasHandler(IDbConnection connection)
        => _connection = connection;

    public async Task<IEnumerable<RelatorioVendasDto>> Handle(
        RelatorioVendasQuery query,
        CancellationToken ct)
    {
        var sql = """
            SELECT Data, ValorTotal
            FROM Vendas
            WHERE Data BETWEEN @Inicio AND @Fim
        """;

        return await _connection.QueryAsync<RelatorioVendasDto>(
            sql,
            new
            {
                Inicio = query.DataInicio,
                Fim = query.DataFim
            });
    }
}