using CasaDosFarelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDosFarelos.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Pessoa> Clientes => Set<Pessoa>();
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<VendaItem> VendaItens => Set<VendaItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ==========================
        // Configuração ClientePF / ClientePJ usando TPH
        // ==========================
        modelBuilder.Entity<Pessoa>(builder =>
        {
            builder.ToTable("Clientes"); // UMA tabela só para todos
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Documento)
                   .IsRequired()
                   .HasMaxLength(20);

            // Discriminador
            builder.HasDiscriminator<string>("Tipo")
                   .HasValue<ClientePF>("PF")
                   .HasValue<ClientePJ>("PJ");
        });

        // ==========================
        // Configuração Venda / VendaItem
        // ==========================
        modelBuilder.Entity<Venda>(builder =>
        {
            builder.Ignore(v => v.Itens);
            builder.Ignore(v => v.ValorTotal);

            builder.HasMany<VendaItem>("_itens")
                   .WithOne()
                   .HasForeignKey("VendaId");

            builder.Navigation("_itens")
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        base.OnModelCreating(modelBuilder);
    }
}