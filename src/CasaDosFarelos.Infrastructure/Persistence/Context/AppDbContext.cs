using CasaDosFarelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using src.CasaDosFarelos.Domain.Entities;

namespace CasaDosFarelos.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ClientePF> ClientesPF => Set<ClientePF>();
    public DbSet<ClientePJ> ClientesPJ => Set<ClientePJ>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
    public DbSet<Produto> Produto => Set<Produto>();
    public DbSet<Veiculo> Veiculo => Set<Veiculo>();
    public DbSet<Venda> Venda => Set<Venda>();
    public DbSet<VendaItem> VendaItem => Set<VendaItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new VendaItemConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}