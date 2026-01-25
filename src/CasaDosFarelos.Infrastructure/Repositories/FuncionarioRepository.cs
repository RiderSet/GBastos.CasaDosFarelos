using CasaDosFarelos.Domain.Entities;
using CasaDosFarelos.Infrastructure.Persistence.Context;
using CasaDosFarelos.Infrastructure.Repositories;

public class FuncionarioRepository
    : Repository<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(AppDbContext context)
        : base(context)
    {
    }
}