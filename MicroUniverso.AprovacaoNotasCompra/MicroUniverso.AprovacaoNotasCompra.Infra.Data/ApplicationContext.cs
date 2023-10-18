using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Infra.Data.Mapping;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<NotaCompra>? NotasCompras { get; set; }
    public DbSet<FaixaValorAprovacao>? FaixaValorAprovacoes { get; set; }
    public DbSet<HistoricoAprovacao>? HistoricoAprovacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UsuarioMapping());
        builder.ApplyConfiguration(new NotaCompraMapping());
        builder.ApplyConfiguration(new FaixaValorAprovacaoMapping());
        builder.ApplyConfiguration(new HistoricoAprovacaoMapping());
    }
}
