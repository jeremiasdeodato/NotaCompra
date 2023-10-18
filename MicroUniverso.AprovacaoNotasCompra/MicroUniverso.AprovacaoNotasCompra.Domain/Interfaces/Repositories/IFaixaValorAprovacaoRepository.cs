using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories
{
    public interface IFaixaValorAprovacaoRepository
    {
        Task<IEnumerable<FaixaValorAprovacao>> ObterTodasFaixas();
    }
}
