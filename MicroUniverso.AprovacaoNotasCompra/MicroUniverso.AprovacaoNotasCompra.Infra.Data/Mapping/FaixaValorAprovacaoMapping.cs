using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Mapping
{
    public class FaixaValorAprovacaoMapping : IEntityTypeConfiguration<FaixaValorAprovacao>
    {
        public void Configure(EntityTypeBuilder<FaixaValorAprovacao> builder)
        {
            builder.ToTable("faixa_valor_aprovacao");

            builder.HasKey(x => x.Id);

            builder.Property(f => f.ValorMinimo)
                .HasColumnType("decimal")
                .IsRequired(true);

            builder.Property(f => f.ValorMaximo)
                .HasColumnType("decimal")
                .IsRequired(true);

            builder.Property(f => f.VistosNecessarios)
                .HasColumnType("smallint")
                .IsRequired(true);

            builder.Property(f => f.AprovacoesNecessarias)
                .HasColumnType("smallint")
                .IsRequired(true);
        }
    }
}
