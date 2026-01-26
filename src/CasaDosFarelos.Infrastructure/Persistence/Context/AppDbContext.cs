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

        modelBuilder.Entity<Venda>(builder =>
        {
            builder.Ignore(v => v.Itens);
            builder.Ignore(v => v.ValorTotal);
            builder.HasMany<VendaItem>("_itens")
                   .WithOne()
                   .HasForeignKey("VendaId");

            // Força acesso via campo
            builder.Navigation("_itens")
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        base.OnModelCreating(modelBuilder);
    }
}