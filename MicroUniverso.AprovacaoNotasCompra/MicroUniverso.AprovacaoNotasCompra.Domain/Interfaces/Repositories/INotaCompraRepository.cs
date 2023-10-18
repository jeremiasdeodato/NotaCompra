using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories
{
    public interface INotaCompraRepository
    {
        Task<IEnumerable<NotaCompra>> ObterNotasPendentesAprovacao();
        //Task AprovarNotaCompra(NotaCompra notaCompra);
        Task RegistrarVisto(Guid notaCompraId, Guid usuarioId);
        Task<NotaCompra?> ObterNotaPorId(Guid notaCompraId);
    }
}
