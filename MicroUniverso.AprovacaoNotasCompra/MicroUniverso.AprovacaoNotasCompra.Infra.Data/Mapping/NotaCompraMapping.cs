using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Mapping
{
    public class NotaCompraMapping : IEntityTypeConfiguration<NotaCompra>
    {
        public void Configure(EntityTypeBuilder<NotaCompra> builder)
        {
            builder.ToTable("nota_compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDeEmissao)
                .HasColumnType("datetime");

            builder.Property(p => p.ValorMercadorias)
                .HasColumnType("decimal");

            builder.Property(p => p.ValorDesconto)
                .HasColumnType("decimal");

            builder.Property(p => p.ValorFrete)
                .HasColumnType("decimal");

            builder.Property(p => p.ValorTotal)
                .HasColumnType("decimal");

            builder.Property(p => p.Status)
                .HasColumnType("smallint")
                .IsRequired(true);

            builder.Property(x => x.DataCriacao)
                .HasColumnType("datetime");

            builder.Property(x => x.Ativo)
                .HasColumnType("bit")
                .IsRequired(true);
        }
    }
}
