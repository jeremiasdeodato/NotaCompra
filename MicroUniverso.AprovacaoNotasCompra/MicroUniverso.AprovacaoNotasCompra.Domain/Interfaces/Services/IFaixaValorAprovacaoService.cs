using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services
{
    public interface IFaixaValorAprovacaoService
    {   
        Task<IEnumerable<FaixaValorAprovacao>> ObterTodasFaixas();
    }
}
