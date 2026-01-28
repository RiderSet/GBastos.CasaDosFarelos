using CasaDosFarelos.Api.Endpoints.Clientes;
using CasaDosFarelos.Api.Endpoints.Produtos;
using CasaDosFarelos.Api.Endpoints.Relatorios;
using CasaDosFarelos.Api.Endpoints.Vendas;
using src.CasaDosFarelos.Api.Endpoints.Fornecedores;
using src.CasaDosFarelos.Api.Endpoints.Funcionarios;

namespace CasaDosFarelos.Api.Endpoints;

public static class EndpointExtensions
{
    public static WebApplication MapApplicationEndpoints(
        this WebApplication app)
    {
        app.MapClienteEndpoints();
        app.MapRelatoriosEndpoints();
        app.MapVendasEndpoints();
        app.MapProdutosEndpoints();
        app.MapFuncionariosEndpoints();
        app.MapFornecedoresEndpoints();

        //// Clientes Endpoints
        //var group = app.MapGroup("/api/clientes");

        //// Listar todos
        //group.MapGet("/", async (IMediator mediator) =>
        //    Results.Ok(await mediator.Send(new ListarClientesQuery()))
        //);

        //// Obter por Id
        //group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        //    Results.Ok(await mediator.Send(new ObterClientePorIdQuery(id)))
        //);

        //// Criar PF
        //group.MapPost("/pf", async (IMediator mediator, CriarClientePFCommand command) =>
        //{
        //    var id = await mediator.Send(command);
        //    return Results.Created($"/api/clientes/{id}", null);
        //});

        //// Criar PJ
        //group.MapPost("/pj", async (IMediator mediator, CriarClientePJCommand command) =>
        //{
        //    var id = await mediator.Send(command);
        //    return Results.Created($"/api/clientes/{id}", null);
        //});

        //// Atualizar Cliente (PF ou PJ)
        //group.MapPut("/{id:guid}", async (IMediator mediator, Guid id, AtualizarClienteCommand command) =>
        //{
        //    // Garante que o Id do route seja aplicado ao command
        //    command.Id = id;
        //    await mediator.Send(command);
        //    return Results.NoContent();
        //});

        //// Excluir Cliente
        //group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        //{
        //    await mediator.Send(new ExcluirClienteCommand(id));
        //    return Results.NoContent();
        //});

        return app;
    }
}