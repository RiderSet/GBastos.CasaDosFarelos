using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;


        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);


        public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();


        public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);


        public void Update(T entity)
        => _dbSet.Update(entity);


        public void Remove(T entity)
        => _dbSet.Remove(entity);
    }
}
