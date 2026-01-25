using CasaDosFarelos.Application.Commands.Fornecedor;
using MediatR;

namespace src.CasaDosFarelos.Api.Endpoints.Fornecedores ;

public static class FornecedoresEndpoints
{
    public static IEndpointRouteBuilder MapFornecedoresEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fornecedores")
                       .RequireAuthorization("Gerente");

        group.MapPost("/", CriarFornecedor);

        return app;
    }

    private static async Task<IResult> CriarFornecedor(
        CriarFornecedorCommand command,
        IMediator mediator)
    {
        var id = await mediator.Send(command);
        return Results.Created($"/api/fornecedores/{id}", id);
    }
}
