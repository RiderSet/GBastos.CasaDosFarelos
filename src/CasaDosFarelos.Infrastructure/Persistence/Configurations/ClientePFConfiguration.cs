using CasaDosFarelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDosFarelos.Infrastructure.Persistence.Configurations;

public class ClientePFConfiguration : IEntityTypeConfiguration<ClientePF>
{
    public void Configure(EntityTypeBuilder<ClientePF> builder)
    {
        builder.ToTable("ClientesPF");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(c => c.Email)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(c => c.Documento)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(c => c.CPF)
               .HasMaxLength(11)
               .IsRequired();
    }
}