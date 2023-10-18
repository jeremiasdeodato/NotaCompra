using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories;
using MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> ObterLista()
        {
            return await _repository.Obter();
        }

        public async Task<Usuario?> ObterPorId(Guid usuarioId)
        {
            return await _repository.ObterPorId(usuarioId);
        }

        public async Task Inserir(Usuario usuario)
        {
            await _repository.Inserir(usuario);
        }

        public async Task Excluir(Usuario usuario)
        {
            await _repository.Excluir(usuario);
        }
    }
}
