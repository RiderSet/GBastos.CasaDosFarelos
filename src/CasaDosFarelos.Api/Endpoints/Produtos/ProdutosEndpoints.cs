using CasaDosFarelos.Application.Queries.Produtos;
using MediatR;

namespace CasaDosFarelos.Api.Endpoints.Produtos;

public static class ProdutosEndpoints
{
    public static IEndpointRouteBuilder MapProdutosEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/produtos")
                       .RequireAuthorization();

        group.MapGet("/", Listar);
        group.MapGet("/{id:guid}", Obter);

        return app;
    }

    private static async Task<IResult> Listar(IMediator mediator)
        => Results.Ok(await mediator.Send(new ListarProdutosQuery()));

    private static async Task<IResult> Obter(
        IMediator mediator, Guid id)
        => Results.Ok(await mediator.Send(new ObterProdutoQuery(id)));
}