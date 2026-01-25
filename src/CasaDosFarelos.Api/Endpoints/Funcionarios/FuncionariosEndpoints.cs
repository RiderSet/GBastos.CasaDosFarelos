using CasaDosFarelos.Application.Commands.FuncionarioCommand.Handlers;
using MediatR;

namespace src.CasaDosFarelos.Api.Endpoints.Funcionarios;

public static class FuncionariosEndpoints
{
    public static IEndpointRouteBuilder MapFuncionariosEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/funcionarios")
                       .RequireAuthorization("Gerente");

        group.MapPost("/", CriarFuncionario);

        return app;
    }

    private static async Task<IResult> CriarFuncionario(
        CriarFuncionarioCommand command,
        IMediator mediator)
    {
        var id = await mediator.Send(command);
        return Results.Created($"/api/funcionario/{id}", id);
    }
}