using CasaDosFarelos.Api.Contracts.Clientes;
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

    // CREATE PF
    private static async Task<IResult> CriarClientePF(
        CriarClientePFRequest request,
        AppDbContext context)
    {
        var cliente = new ClientePF(
            request.Nome,
            request.Email,
            request.Documento,
            request.CPF
        );

        context.Add(cliente);
        await context.SaveChangesAsync();

        return Results.Created($"/api/clientes/{cliente.Id}", cliente.Id);
    }

    // CREATE PJ
    private static async Task<IResult> CriarClientePJ(
        CriarClientePJRequest request,
        AppDbContext context)
    {
        var cliente = new ClientePJ(
            request.Nome,
            request.Email,
            request.Documento,
            request.CNPJ
        );

        context.Add(cliente);
        await context.SaveChangesAsync();

        return Results.Created($"/api/clientes/{cliente.Id}", cliente.Id);
    }

    // GET ALL
    private static async Task<IResult> ListarClientes(AppDbContext context)
    {
        var clientesPF = context.Set<ClientePF>()
            .AsNoTracking()
            .Select(pf => new ClienteResponse
            {
                Id = pf.Id,
                Nome = pf.Nome,
                Email = pf.Email,
                Documento = pf.Documento,
                Tipo = "PF",
                CPF = pf.CPF,
                CNPJ = null
            });

        var clientesPJ = context.Set<ClientePJ>()
            .AsNoTracking()
            .Select(pj => new ClienteResponse
            {
                Id = pj.Id,
                Nome = pj.Nome,
                Email = pj.Email,
                Documento = pj.Documento,
                Tipo = "PJ",
                CPF = null,
                CNPJ = pj.CNPJ
            });

        var clientes = await clientesPF
            .Union(clientesPJ)
            .ToListAsync();

        return Results.Ok(clientes);
    }

    // GET BY ID
    private static async Task<IResult> ObterClientePorId(
        Guid id,
        AppDbContext context)
    {
        ClienteResponse? response =
            await context.Set<ClientePF>()
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(pf => new ClienteResponse
                {
                    Id = pf.Id,
                    Nome = pf.Nome,
                    Email = pf.Email,
                    Documento = pf.Documento,
                    Tipo = "PF",
                    CPF = pf.CPF,
                    CNPJ = null
                })
                .FirstOrDefaultAsync()
            ??
            await context.Set<ClientePJ>()
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(pj => new ClienteResponse
                {
                    Id = pj.Id,
                    Nome = pj.Nome,
                    Email = pj.Email,
                    Documento = pj.Documento,
                    Tipo = "PJ",
                    CPF = null,
                    CNPJ = pj.CNPJ
                })
                .FirstOrDefaultAsync();

        return response is null
            ? Results.NotFound()
            : Results.Ok(response);
    }

    // UPDATE (PF ou PJ)
    private static async Task<IResult> AtualizarCliente(
        Guid id,
        AtualizarClienteRequest request,
        AppDbContext context)
    {
        var clientePF = await context.Set<ClientePF>()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (clientePF is not null)
        {
            clientePF.Update(
                request.Nome,
                request.Email,
                request.Documento,
                request.CPF ?? throw new InvalidOperationException("CPF obrigatório")
            );

            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        var clientePJ = await context.Set<ClientePJ>()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (clientePJ is not null)
        {
            clientePJ.Update(
                request.Nome,
                request.Email,
                request.Documento,
                request.CNPJ ?? throw new InvalidOperationException("CNPJ obrigatório")
            );

            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        return Results.NotFound();
    }

    // DELETE
    private static async Task<IResult> RemoverCliente(
        Guid id,
        AppDbContext context)
    {
        var cliente =
            await context.Set<ClientePF>().FirstOrDefaultAsync(c => c.Id == id)
            ?? (Pessoa?)await context.Set<ClientePJ>().FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null)
            return Results.NotFound();

        context.Remove(cliente);
        await context.SaveChangesAsync();

        return Results.NoContent();
    }
}