using CasaDosFarelos.Application.Queries.Relatorios;
using MediatR;

namespace CasaDosFarelos.Api.Endpoints.Relatorios;

public static class RelatoriosEndpoints
{
    public static IEndpointRouteBuilder MapRelatoriosEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/relatorios").RequireAuthorization("Gerente");
        group.MapGet("/vendas", RelatorioVendas);
        return app;
    }

    private static async Task<IResult> RelatorioVendas(
        IMediator mediator,
        DateTime dataInicio,
        DateTime dataFim)
    {
        var query = new RelatorioVendasQuery
        {
            DataInicio = dataInicio,
            DataFim = dataFim
        };
        var resultado = await mediator.Send(query);
        return Results.Ok(resultado);
    }
}