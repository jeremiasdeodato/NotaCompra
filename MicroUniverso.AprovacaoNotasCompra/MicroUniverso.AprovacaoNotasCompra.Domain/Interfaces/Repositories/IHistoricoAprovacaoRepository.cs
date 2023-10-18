using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories
{
    public interface IHistoricoAprovacaoRepository
    {
        Task<IEnumerable<HistoricoAprovacao>> Obter();
        Task Inserir(HistoricoAprovacao usuario);
    }
}
