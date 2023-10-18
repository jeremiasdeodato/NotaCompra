using Microsoft.EntityFrameworkCore;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Core.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        Task<int> SaveChanges();
    }
}
