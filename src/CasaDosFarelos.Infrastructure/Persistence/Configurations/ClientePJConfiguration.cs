using CasaDosFarelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClientePJConfiguration : IEntityTypeConfiguration<ClientePJ>
{
    public void Configure(EntityTypeBuilder<ClientePJ> builder)
    {
        builder.ToTable("ClientesPJ");

      //  builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(c => c.Email)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(c => c.Documento)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(c => c.CNPJ)
               .HasMaxLength(14)
               .IsRequired();
    }
}