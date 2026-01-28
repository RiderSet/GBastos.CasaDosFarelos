using CasaDosFarelos.Application.Interfaces.Fornecedores;
using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories
{
    public class FornecedorWriteRepository : IFornecedorWriteRepository
    {
        private readonly AppDbContext _context;

        public FornecedorWriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            await _context.Set<Fornecedor>().AddAsync(fornecedor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return fornecedor.Id;
        }

        public async Task UpdateAsync(Fornecedor fornecedor, CancellationToken cancellationToken)
        {
            _context.Set<Fornecedor>().Update(fornecedor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var fornecedor = await _context.Set<Fornecedor>()
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);

            if (fornecedor != null)
            {
                _context.Set<Fornecedor>().Remove(fornecedor);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}