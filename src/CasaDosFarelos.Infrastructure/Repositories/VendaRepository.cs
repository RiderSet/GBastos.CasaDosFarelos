using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AppDbContext context)
        : base(context)
        {
        }

        public async Task<IEnumerable<Venda>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim)
        {
            return await _dbSet
            .Include(v => v.Itens)
            .Where(v => v.DataVenda >= inicio && v.DataVenda <= fim)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
