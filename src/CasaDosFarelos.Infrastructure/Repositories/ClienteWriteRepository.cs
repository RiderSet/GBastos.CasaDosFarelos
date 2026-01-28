using CasaDosFarelos.Application.DTOs;
using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class ClienteWriteRepository : IClienteReadRepository
{
    private readonly AppDbContext _context;

    public ClienteWriteRepository(AppDbContext context)
    {
        _context = context;
    }

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

    public async Task<Guid> AdicionarAsync(
        Pessoa cliente,
        CancellationToken cancellationToken)
    {
        _context.Add(cliente);
        await _context.SaveChangesAsync(cancellationToken);
        return cliente.Id;
    }

    public async Task AtualizarAsync(
        Pessoa cliente,
        CancellationToken cancellationToken)
    {
        _context.Update(cliente);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ExcluirAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var cliente = await ObterPorIdAsync(id, cancellationToken);

        if (cliente is null)
            throw new InvalidOperationException("Cliente não encontrado.");

        _context.Remove(cliente);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Pessoa?> ObterPorIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _context.Set<Pessoa>()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}