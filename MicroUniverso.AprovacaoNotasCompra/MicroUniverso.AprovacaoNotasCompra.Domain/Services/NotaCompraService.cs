using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Services
{
    public class NotaCompraService : INotaCompraService
    {
        private readonly INotaCompraRepository _repository;

        public NotaCompraService(INotaCompraRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotaCompra>> ObterNotasPendentesAprovacao()
        {
            return await _repository.ObterNotasPendentesAprovacao();
        }

        public async Task AprovarNotaCompra(NotaCompra notaCompra)
        {
            //await _repository.AprovarNotaCompra(notaCompra);
        }

        public async Task RegistrarVisto(Guid notaCompraId, Guid usuarioId)
        {
            await _repository.RegistrarVisto(notaCompraId, usuarioId);
        }

        public async Task<NotaCompra?> ObterNotaPorId(Guid notaCompraId)
        {
            return await _repository.ObterNotaPorId(notaCompraId);
        }
    }
}
