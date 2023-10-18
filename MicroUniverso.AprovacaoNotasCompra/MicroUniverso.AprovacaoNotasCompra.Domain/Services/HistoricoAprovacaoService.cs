using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Services
{
    public class HistoricoAprovacaoService : IHistoricoAprovacaoService
    {
        private readonly IHistoricoAprovacaoRepository _repository;

        public HistoricoAprovacaoService(IHistoricoAprovacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistoricoAprovacao>> ObterLista()
        {
            return await _repository.Obter();
        }                

        public async Task Inserir(HistoricoAprovacao historicoAprovacao)
        {
            await _repository.Inserir(historicoAprovacao);
        }
    }
}
