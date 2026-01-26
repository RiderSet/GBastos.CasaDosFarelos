using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Api.Endpoints.Clientes;

public static class ClienteEndpoints
{
    public static IEndpointRouteBuilder MapClienteEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/clientes")
                       .RequireAuthorization();

        group.MapPost("/pf", CriarClientePF);
        group.MapPost("/pj", CriarClientePJ);

        group.MapGet("/", ListarClientes);
        group.MapGet("/{id:guid}", ObterClientePorId);

        group.MapPut("/{id:guid}", AtualizarCliente);
        group.MapDelete("/{id:guid}", RemoverCliente);

        return app;
    }

    // CreatePF
    private static async Task<IResult> CriarClientePF(
        CriarClientePFRequest request,
        AppDbContext context)
    {
        var cliente = new ClientePF
        {
            Nome = request.Nome,
            Email = request.Email,
            Documento = request.Documento,
            CPF = request.CPF
        };

        context.Add(cliente);
        await context.SaveChangesAsync();

        return Results.Created($"/api/clientes/{cliente.Id}", cliente.Id);
    }

    // CreatePJ
    private static async Task<IResult> CriarClientePJ(
        CriarClientePJRequest request,
        AppDbContext context)
    {
        var cliente = new ClientePJ
        {
            Nome = request.Nome,
            Email = request.Email,
            Documento = request.Documento,
            CNPJ = request.CNPJ
        };

        context.Add(cliente);
        await context.SaveChangesAsync();

        return Results.Created($"/api/clientes/{cliente.Id}", cliente.Id);
    }

    // GetAll
    private static async Task<IResult> ListarClientes(AppDbContext context)
    {
        var clientesPF = context.Set<ClientePF>()
            .AsNoTracking()
            .Select(c => new ClienteResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PF",
                CPF = c.CPF,
                CNPJ = null
            });

        var clientesPJ = context.Set<ClientePJ>()
            .AsNoTracking()
            .Select(c => new ClienteResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PJ",
                CPF = null,
                CNPJ = c.CNPJ
            });

        var clientes = await clientesPF
            .Union(clientesPJ)
            .ToListAsync();

        return Results.Ok(clientes);
    }

    // GetById
    private static async Task<IResult> ObterClientePorId(
        Guid id,
        AppDbContext context)
    {
        Pessoa? cliente = await context.Set<ClientePF>().FindAsync(id) as Pessoa ?? await context.Set<ClientePJ>().FindAsync(id) as Pessoa;

        if (cliente is null)
            return Results.NotFound();

        ClienteResponse response = cliente switch
        {
            ClientePF pf => new ClienteResponse
            {
                Id = pf.Id,
                Nome = pf.Nome,
                Email = pf.Email,
                Documento = pf.Documento,
                Tipo = "PF",
                CPF = pf.CPF,
                CNPJ = null
            },

            ClientePJ pj => new ClienteResponse
            {
                Id = pj.Id,
                Nome = pj.Nome,
                Email = pj.Email,
                Documento = pj.Documento,
                Tipo = "PJ",
                CPF = null,
                CNPJ = pj.CNPJ
            },

            _ => throw new InvalidOperationException("Tipo de cliente desconhecido")
        };

        return Results.Ok(response);
    }

    // UpDate
    private static async Task<IResult> AtualizarCliente(
        Guid id,
        CriarClientePFRequest request,
        AppDbContext context)
    {
        var cliente = await context.Set<ClientePF>().FindAsync(id);

        if (cliente is null)
            return Results.NotFound();

        cliente.Nome = request.Nome;
        cliente.Email = request.Email;
        cliente.Documento = request.Documento;
        cliente.CPF = request.CPF;

        await context.SaveChangesAsync();

        return Results.NoContent();
    }

    // Delete
    private static async Task<IResult> RemoverCliente(
        Guid id,
        AppDbContext context)
    {
        var cliente = await context.Set<Pessoa>().FindAsync(id);

        if (cliente is null)
            return Results.NotFound();

        context.Remove(cliente);
        await context.SaveChangesAsync();

        return Results.NoContent();
    }
}