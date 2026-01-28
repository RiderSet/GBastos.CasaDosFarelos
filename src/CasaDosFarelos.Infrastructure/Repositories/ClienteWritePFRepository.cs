using CasaDosFarelos.Application.Interfaces.Cliente;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;

namespace CasaDosFarelos.Infrastructure.Repositories.Clientes
{
    public sealed class ClienteWritePFRepository : IClienteWritePFRepository
    {
        private readonly AppDbContext _context;

        public ClienteWritePFRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClientePF cliente, CancellationToken ct)
        {
            _context.Set<ClientePF>().Add(cliente);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(ClientePF cliente, CancellationToken ct)
        {
            _context.Clientes.Update(cliente); // EF detecta PF automaticamente
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(ClientePF cliente, CancellationToken ct)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync(ct);
        }
    }
}