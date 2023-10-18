using MicroUniverso.AprovacaoNotasCompra.Application.Models.Autorizacao;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Interfaces
{
    public interface INotaCompraApplication
    {
        Task<IEnumerable<NotaCompraListaModel>> ObterNotasPendentesAprovacao(Guid usuarioId);
        Task AprovarNotaCompra(Guid notaCompraId, Guid usuarioId);
        Task RegistrarVisto(Guid notaCompraId, Guid usuarioId);
    }
}
