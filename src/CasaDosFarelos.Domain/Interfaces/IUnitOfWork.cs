namespace CasaDosFarelos.Domain.Interfaces;

public interface IUnitOfWork
{
    IVendaRepository Vendas { get; }
    IFuncionarioRepository Funcionarios { get; }

    Task CommitAsync();
}
