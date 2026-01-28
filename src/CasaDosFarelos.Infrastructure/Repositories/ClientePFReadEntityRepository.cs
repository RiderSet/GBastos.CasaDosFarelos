using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Cliente.PF;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories;

public sealed class ClientePFReadEntityRepository
    : IClienteReadPFRepository
{
    private readonly AppDbContext _context;

    public ClientePFReadEntityRepository(AppDbContext context)
        => _context = context;

    public async Task<List<ClienteResponseDto>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Set<ClientePF>()
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
    }

    public async Task<ClienteResponseDto?> GetByIdAsync(
        Guid id,
        CancellationToken ct)
    {
        return await _context.Set<ClientePF>()
            .AsNoTracking()
            .Where(c => c.Id == id)
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
            .FirstOrDefaultAsync(ct);
    }
}