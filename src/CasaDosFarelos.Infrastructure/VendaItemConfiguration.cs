using CasaDosFarelos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDosFarelos.Infrastructure
{
    public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.ToTable("VendaItens");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.DescricaoProduto)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.PrecoUnitario)
                .HasPrecision(18, 2);

            builder.HasOne<Venda>()
                .WithMany(v => v.Itens)
                .HasForeignKey(i => i.VendaId);
        }
    }
}
