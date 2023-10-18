using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Repositories
{
    public class HistoricoAprovacaoRepository : IHistoricoAprovacaoRepository
    {
        private readonly ApplicationContext _contexto;

        public HistoricoAprovacaoRepository(ApplicationContext contexto)
        {
            _contexto = contexto;            
        }

        public async Task<IEnumerable<HistoricoAprovacao>> Obter()
        {
            return await _contexto.HistoricoAprovacoes!.ToListAsync();
        }

        public async Task Inserir(HistoricoAprovacao historicoAprovacao)
        {
            await _contexto.AddAsync(historicoAprovacao);
        }
    }
}
