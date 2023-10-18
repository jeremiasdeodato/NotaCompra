using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Interfaces;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
