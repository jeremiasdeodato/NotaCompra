using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Mapping
{
    public class HistoricoAprovacaoMapping : IEntityTypeConfiguration<HistoricoAprovacao>
    {
        public void Configure(EntityTypeBuilder<HistoricoAprovacao> builder)
        {
            builder.ToTable("historico_aprovacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data)
                .HasColumnType("datetime");

            builder.Property(x => x.UsuarioId)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.NotaCompraId)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(p => p.Operacao)
                .HasColumnType("smallint")
                .IsRequired(true);

            builder.HasOne(x => x.NotaCompra)
                .WithMany()
                .HasForeignKey(x => x.NotaCompraId);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
