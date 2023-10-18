using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Repositories
{
    public class FaixaValorAprovacaoRepository : IFaixaValorAprovacaoRepository
    {
        private readonly ApplicationContext _contexto;

        public FaixaValorAprovacaoRepository(ApplicationContext contexto)
        {
            _contexto = contexto;            
        }

        public async Task<IEnumerable<FaixaValorAprovacao>> ObterTodasFaixas()
        {
            return await _contexto.FaixaValorAprovacoes!.ToListAsync();
        }
    }
}
