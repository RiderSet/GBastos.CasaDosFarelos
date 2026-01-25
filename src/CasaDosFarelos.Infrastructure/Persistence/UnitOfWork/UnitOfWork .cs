using CasaDosFarelos.Domain.Interfaces;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Repositories;

namespace CasaDosFarelos.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IVendaRepository Vendas { get; }
    public IFuncionarioRepository Funcionarios { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Vendas = new VendaRepository(context);
        Funcionarios = new FuncionarioRepository(context);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
