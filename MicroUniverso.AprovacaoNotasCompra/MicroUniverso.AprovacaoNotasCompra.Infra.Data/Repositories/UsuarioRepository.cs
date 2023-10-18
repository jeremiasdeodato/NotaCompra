using Microsoft.EntityFrameworkCore;
using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;

namespace MicroUniverso.AprovacaoNotasCompra.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _contexto;

        public UsuarioRepository(ApplicationContext contexto)
        {
            _contexto = contexto;            
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _contexto.Usuarios!.ToListAsync();
        }

        public async Task<Usuario?> ObterPorId(Guid id)
        {
            return await _contexto.Usuarios!
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Inserir(Usuario usuario)
        {
            await _contexto.AddAsync(usuario);
        }

        public async Task Excluir(Usuario usuario)
        {
            _contexto.Remove(usuario);
            await _contexto.SaveChangesAsync();
        }
    }
}
