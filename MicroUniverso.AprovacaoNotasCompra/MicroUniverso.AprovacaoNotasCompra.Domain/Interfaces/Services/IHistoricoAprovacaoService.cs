using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services
{
    public interface IHistoricoAprovacaoService
    {   
        Task<IEnumerable<HistoricoAprovacao>> ObterLista();        
        Task Inserir(HistoricoAprovacao usuario);        
    }
}
