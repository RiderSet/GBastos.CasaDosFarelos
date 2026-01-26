using CasaDosFarelos.Application.Commands.FornecedorCommand.AtualizarForneecdor;
using CasaDosFarelos.Application.Commands.FornecedorCommand.CriarFornecedor;
using CasaDosFarelos.Application.Commands.FornecedorCommand.ExcluirFornecedor;
using CasaDosFarelos.Application.Queries.Fornecedores.ObterFornecedorPorId;
using CasaDosFarelos.Application.Queries.FornecedoresQueries;
using MediatR;

namespace src.CasaDosFarelos.Api.Endpoints.Fornecedores;

public static class FornecedoresEndpoints
{
    public static IEndpointRouteBuilder MapFornecedoresEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fornecedores")
                       .RequireAuthorization("Gerente")
                       .WithTags("Fornecedores");

        group.MapPost("/", Criar);
        group.MapGet("/", Listar);
        group.MapGet("/{id:guid}", ObterPorId);
        group.MapPut("/{id:guid}", Atualizar);
        group.MapDelete("/{id:guid}", Excluir);

        return app;
    }

    private static async Task<IResult> Criar(
        CriarFornecedorCommand command,
        IMediator mediator)
    {
        var id = await mediator.Send(command);
        return Results.Created($"/api/fornecedores/{id}", id);
    }

    private static async Task<IResult> Listar(IMediator mediator)
    {
        var result = await mediator.Send(new ListarFornecedoresQuery());
        return Results.Ok(result);
    }

    private static async Task<IResult> ObterPorId(
        Guid id,
        IMediator mediator)
    {
        var result = await mediator.Send(new ObterFornecedorPorIdQuery(id));
        return result is null ? Results.NotFound() : Results.Ok(result);
    }

    private static async Task<IResult> Atualizar(
        Guid id,
        AtualizarFornecedorCommand command,
        IMediator mediator)
    {
        if (id != command.Id)
            return Results.BadRequest();

        await mediator.Send(command);
        return Results.NoContent();
    }

    private static async Task<IResult> Excluir(
        Guid id,
        IMediator mediator)
    {
        await mediator.Send(new ExcluirFornecedorCommand(id));
        return Results.NoContent();
    }
}