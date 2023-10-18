using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Services
{
    public class FaixaValorAprovacaoService : IFaixaValorAprovacaoService
    {
        private readonly IFaixaValorAprovacaoRepository _repository;

        public FaixaValorAprovacaoService(IFaixaValorAprovacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FaixaValorAprovacao>> ObterTodasFaixas()
        {
            return await _repository.ObterTodasFaixas();
        }
    }
}
