using CasaDosFarelos.Application.Interfaces.Cliente.PJ;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;

namespace CasaDosFarelos.Infrastructure.Repositories.Clientes
{
    public sealed class ClienteWritePJRepository : IClienteWritePJRepository
    {
        private readonly AppDbContext _context;

        public ClienteWritePJRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClientePJ cliente, CancellationToken ct)
        {
            _context.Set<ClientePJ>().Add(cliente);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(ClientePJ cliente, CancellationToken ct)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(ClientePJ cliente, CancellationToken ct)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync(ct);
        }
    }
}