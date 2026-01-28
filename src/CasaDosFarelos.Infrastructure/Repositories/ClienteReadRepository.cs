using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories;

public sealed class ClienteReadRepository : IClienteReadPFRepository
{
    private readonly AppDbContext _context;

    public ClienteReadRepository(AppDbContext context)
        => _context = context;

    public async Task<List<ClienteResponseDto>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var clientesPF = await _context.Set<ClientePF>()
            .AsNoTracking()
            .Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PF",
                CPF = c.CPF,
                CNPJ = null
            })
            .ToListAsync(cancellationToken);

        var clientesPJ = await _context.Set<ClientePJ>()
            .AsNoTracking()
            .Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PJ",
                CPF = null,
                CNPJ = c.CNPJ
            })
            .ToListAsync(cancellationToken);

        return clientesPF
            .Concat(clientesPJ)
            .ToList();
    }

    public async Task<ClienteResponseDto?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var pf = await _context.Set<ClientePF>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PF",
                CPF = c.CPF,
                CNPJ = null
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (pf is not null)
            return pf;

        return await _context.Set<ClientePJ>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(c => new ClienteResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Tipo = "PJ",
                CPF = null,
                CNPJ = c.CNPJ
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}