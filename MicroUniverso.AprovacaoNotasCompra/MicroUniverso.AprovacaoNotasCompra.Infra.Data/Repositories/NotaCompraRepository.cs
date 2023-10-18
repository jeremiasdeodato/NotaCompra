using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Repositories
{
    public class NotaCompraRepository : INotaCompraRepository
    {
        private readonly ApplicationContext _contexto;

        public NotaCompraRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<NotaCompra>> ObterNotasPendentesAprovacao()
        {
            return await _contexto.NotasCompras!
                .Where(x => x.Status == StatusEnum.Pendente)
                .ToListAsync();
        }

        public Task RegistrarVisto(Guid notaCompraId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<NotaCompra?> ObterNotaPorId(Guid notaCompraId)
        {
            return await _contexto.NotasCompras!.FirstOrDefaultAsync(x => x.Id == notaCompraId);
        }
    }
}
