using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories;

public sealed class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterPorIdsAsync(IEnumerable<Guid> ids, CancellationToken ct)
    {
        return await _context.Produtos
            .Where(p => ids.Contains(p.Id))
            .ToListAsync(ct);
    }

    public async Task<Produto?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task AddAsync(Produto produto, CancellationToken ct)
    {
        await _context.Produtos.AddAsync(produto, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Produto produto, CancellationToken ct)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<List<Produto>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Produtos.ToListAsync(ct);
    }
}