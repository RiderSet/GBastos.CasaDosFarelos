using CasaDosFarelos.Application.Commands.Vendas;
using MediatR;

namespace CasaDosFarelos.Api.Endpoints.Vendas;

public static class VendasEndpoints
{
    public static IEndpointRouteBuilder MapVendasEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/vendas")
                       .RequireAuthorization();

        group.MapPost("/", CriarVenda);

        return app;
    }

    private static async Task<IResult> CriarVenda(
        IMediator mediator,
        CriarVendaCommand command)
    {
        var id = await mediator.Send(command);
        return Results.Created($"/api/vendas/{id}", id);
    }
}