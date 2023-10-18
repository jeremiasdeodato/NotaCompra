using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.Senha)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(p => p.Papel)
                .HasColumnType("tinyint")
                .IsRequired(true);

            builder.Property(p => p.ValorMinimo)
                .HasColumnType("decimal");

            builder.Property(p => p.ValorMaximo)
                .HasColumnType("decimal");

            builder.Property(x => x.DataCriacao)
                .HasColumnType("datetime");
            
            builder.Property(x => x.Ativo)
                .HasColumnType("bit")
                .IsRequired(true);
        }
    }
}
