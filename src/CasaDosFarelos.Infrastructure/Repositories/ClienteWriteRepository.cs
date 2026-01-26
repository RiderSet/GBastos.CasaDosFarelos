using CasaDosFarelos.Application.Interfaces;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;

namespace CasaDosFarelos.Infrastructure.Repositories
{
    public class ClienteWriteRepository : IClienteWriteRepository
    {
        private readonly AppDbContext _context;
        public ClienteWriteRepository(AppDbContext context) => _context = context;

        public async Task<Guid> CriarClientePFAsync(ClientePF cliente, CancellationToken cancellationToken)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync(cancellationToken);
            return cliente.Id;
        }

        public async Task<Guid> CriarClientePJAsync(ClientePJ cliente, CancellationToken cancellationToken)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync(cancellationToken);
            return cliente.Id;
        }

        public async Task AtualizarClienteAsync(Pessoa cliente, CancellationToken cancellationToken)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task ExcluirClienteAsync(Guid id, CancellationToken cancellationToken)
        {
            var cliente = await _context.Set<Pessoa>().FindAsync(new object[] { id }, cancellationToken);
            if (cliente != null)
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}